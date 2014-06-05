using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using GoDataFeed.Dal;

namespace GoDataFeed.WebSite.Controllers
{
    public class GDFApiRetailController : ApiController
    {

        [HttpGet]
        public Retailer Get(long id)
        {
            var dalRetailer = new Retailer();
            return dalRetailer.Get(id);
        }

        [HttpGet]
        public Retailer GetRetailer(long id)
        {
            var dalRetailer = new Retailer();
            return dalRetailer.Get(id);
        }
    }
}
