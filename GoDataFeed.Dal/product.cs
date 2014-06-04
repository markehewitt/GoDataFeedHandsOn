using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    public class product
    {
        public long id { get; set; }
        public string name { get; set; }

        public string sku { get; set; }

        public decimal price { get; set; }
    }
}
