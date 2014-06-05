using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDataFeed.Dal
{
    [Table("Retailer")]
    public class Retailer 
    {
        public long id { get; set; }
        public string name { get; set; }
        public IQueryable<Product> Products;

        public Retailer Get(long id)
        {
            return new Retailer
            {
                id = 3,
                name = "cool beans"
            };
        }

    }
}
