using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GoDataFeed.Dal;

namespace GoDataFeed.WebSite.Models
{
    public class RetailerContext : DbContext
    {
        public RetailerContext() : base("name=GoDataFeedDbConnection")
        {
        }

        public DbSet<Retailer> Retailers { get; set; }
    }
}