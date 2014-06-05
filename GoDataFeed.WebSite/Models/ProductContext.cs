using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GoDataFeed.Dal;

namespace GoDataFeed.WebSite.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=GoDataFeedDbConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}