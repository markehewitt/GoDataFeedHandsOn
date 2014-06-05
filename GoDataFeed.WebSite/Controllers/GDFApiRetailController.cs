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
        private RetailerEfService efSvc = new RetailerEfService();

        [HttpGet]
        public Retailer GetViaEf(long id)
        {
            return efSvc.Get(id);
            //var dalRetailer = new Retailer();
            //return dalRetailer.Get(id);
        }

        [HttpGet]
        public Retailer GetRetailer(long id)
        {
            var dalRetailer = new Retailer();
            return dalRetailer.Get(id);
        }
    }
}
