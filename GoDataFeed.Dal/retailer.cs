using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    public class retailer
    {
        public long id { get; set; }
        public string name { get; set; }

        public IEnumerable<product> products;

        public retailer Get(long id)
        {
            return new retailer
            {
                id = 3,
                name = "cool beans"
            };
        }

    }
}
