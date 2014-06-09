using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    public interface IGoDataFeedEfService
    {
        Retailer GetRetailer(long id);
        IQueryable<Retailer> GetAllRetailers();
        void AddRetailer(string name, string description);
        void UpdateRetailer(long id, string name, string description);
        void DeleteRetailer(long id);
        Product GetProduct(long id);
        IQueryable<Product> GetAllProducts();
        Retailer AddProduct(long retailer_id, string name, string sku, decimal price);
        Retailer UpdateProduct(long id, long retailer_id, string name, string sku, decimal price);
        Retailer DeleteProduct(long productId, long retailer_id);

    }

    public class GoDataFeedEfService : IGoDataFeedEfService
    {
        private GoDataFeedContext db = new GoDataFeedContext();

        public Retailer GetRetailer(long id)
        {
            return db.Retailers.Find(id);
        }

        public IQueryable<Retailer> GetAllRetailers()
        {
            return db.Retailers;
        }

        public void AddRetailer(string name, string description)
        {
            var retailer = new Retailer
            {
                name = name,
                description = description
            };

            db.Retailers.Add(retailer);
            db.SaveChanges();
        }

        public void UpdateRetailer(long id, string name, string description)
        {
            var entity = db.Retailers.Find(id);
            var entry = db.Entry<Retailer>(entity);
            entity.name = name;
            entity.description = description;
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteRetailer(long id)
        {
            // Delete any referenced products first, then delete the retailer
            var retailer = GetRetailer(id);
            retailer.Products.ToList<Product>().ForEach(p => DeleteProduct(p.id, retailer.id));
            db.Retailers.Remove(retailer);

            db.SaveChanges();
        }

        public Product GetProduct(long id)
        {
            return db.Products.Find(id);
        }

        public IQueryable<Product> GetAllProducts()
        {
            return db.Products;
        }

        public Retailer AddProduct(long retailer_id, string name, string sku, decimal price)
        {
            // Note the retailer_id is implies by the FKEY relationship
            var product = new Product
            {
                name = name,
                sku = sku,
                price = price
            };

            var retailer = GetRetailer(retailer_id);
            retailer.Products.Add(product);
            db.SaveChanges();

            return (retailer);
        }

        public Retailer UpdateProduct(long id, long retailer_id, string name, string sku, decimal price)
        {
            var entity = db.Products.Find(id);
            var entry = db.Entry<Product>(entity);
            entity.name = name;
            entity.sku = sku;
            entity.price = price;
            entry.State = EntityState.Modified;
            db.SaveChanges();

            return (GetRetailer(retailer_id));
        }

        public Retailer DeleteProduct(long productId, long retailer_id)
        {
            var entity = db.Products.Find(productId);
            db.Products.Remove(entity);
            db.SaveChanges();

            return (GetRetailer(retailer_id));
        }

    }
}
