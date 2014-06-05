using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    public class RetailerEfService
    {
        private RetailerContext db = new RetailerContext();

        public Retailer Get(long id)
        {
            return db.Retailers.Find(id);
        }
    }
}
