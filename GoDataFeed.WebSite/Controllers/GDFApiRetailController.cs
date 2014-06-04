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
        public retailer GetRetailer(long id)
        {
            var dalRetailer = new retailer();
            return dalRetailer.Get(id);
        }
    }
}
