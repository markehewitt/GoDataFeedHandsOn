using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    [Table("dbo.product")]
    public class Product
    {
        public long id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public decimal price { get; set; }
    }

    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=GoDataFeedDbConnection") {}

        public DbSet<Product> Products { get; set; }
    }
}
