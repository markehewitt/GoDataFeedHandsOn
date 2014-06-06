using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using GoDataFeed.Dal;

namespace GoDataFeed.WebSite.Controllers
{
    public class GDFApiController : ApiController
    {
        private GoDataFeedEfService efSvc = new GoDataFeedEfService();
        private GoDataFeedDapperService dapSvc = new GoDataFeedDapperService();

        #region Entity Framework Calls

        [HttpGet]
        public Retailer GetRetailer(long id)
        {
            return efSvc.GetRetailer(id);
        }

        [HttpGet]
        public IQueryable<Retailer> GetAllRetailers()
        {
            return efSvc.GetAllRetailers();
        }

        [HttpPost]
        public IHttpActionResult AddRetailer(long id, string name, string description)
        {
            efSvc.AddRetailer(id, name, description);
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpPost]
        public IHttpActionResult UpdateRetailer(long id, string name, string description)
        {
            efSvc.UpdateRetailer(id, name, description);
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpPost]
        public IHttpActionResult DeleteRetailer(long id)
        {
            efSvc.DeleteRetailer(id);
            return StatusCode(HttpStatusCode.OK);
        }

        #endregion

        #region Dapper Calls

        [HttpGet]
        public Retailer GetRetailerViaDapper(long id)
        {
            return dapSvc.Get(id);
        }

        [HttpGet]
        public IEnumerable<Retailer> GetAllRetailersViaDapper()
        {
            return dapSvc.GetAll();
        }

        #endregion

    }
}
