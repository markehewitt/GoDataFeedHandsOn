using System;
using System.Collections.Generic;
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
        public long retailer_id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public decimal price { get; set; }
    }

}
