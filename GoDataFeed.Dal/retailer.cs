using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    [Table("dbo.retailer")]
    public class Retailer 
    {
        public Retailer()
        {
            this.Products = new HashSet<Product>();
        }

        public long id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

}
