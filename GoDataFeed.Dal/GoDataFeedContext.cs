using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    public class GoDataFeedContext : DbContext
    {
        public GoDataFeedContext() : base("name=GoDataFeedDbConnection") { }

        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
