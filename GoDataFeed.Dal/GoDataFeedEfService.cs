using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    public class GoDataFeedEfService
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
            var products = db.Products.Where<Product>(p => p.retailer_id == id).AsEnumerable<Product>();
            db.Products.RemoveRange(products);

            var entity = db.Retailers.Find(id);
            db.Retailers.Remove(entity);

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

        public void AddProduct(long id, long retailer_id, string name, string sku, decimal price)
        {
            var product = new Product
            {
                id = id,
                retailer_id = retailer_id,
                name = name,
                sku = sku,
                price = price
            };

            db.Products.Add(product);
            db.SaveChanges();
        }

        public void UpdateProduct(long id, long retailer_id, string name, string sku, decimal price)
        {
            var entity = db.Products.Find(id);
            var entry = db.Entry<Product>(entity);
            entity.name = name;
            entity.sku = sku;
            entity.price = price;
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            var entity = db.Products.Find(id);
            db.Products.Remove(entity);

            db.SaveChanges();
        }

    }
}
