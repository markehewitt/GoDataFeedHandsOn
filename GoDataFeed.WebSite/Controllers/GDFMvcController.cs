using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GoDataFeed.Dal;

namespace GoDataFeed.WebSite.Controllers
{
    public class GDFMvcController : Controller
    {
        private GoDataFeedEfService efSvc = new GoDataFeedEfService();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult ManageProducts(long id)
        {            
            var retailer = efSvc.GetRetailer(id);
            return View(retailer);
        }

        [HttpGet]
        public ActionResult EditProduct(long id)  // productid
        {
            long retailerid = GetRetailerId();
            var retailer = efSvc.GetRetailer(retailerid);
            ViewBag.RetailerName = retailer.name;
            ViewBag.RetailerId = retailer.id;            
            return View(efSvc.GetProduct(id));
        }

        [HttpPost]
        public ActionResult EditProduct(long id, string name, string sku, string price)
        {
            decimal dPrice = 0;
            Decimal.TryParse(price, out dPrice);
            long retailerid = GetRetailerId();
            var retailer = efSvc.UpdateProduct(id, retailerid, name, sku, dPrice);
            return View("ManageProducts", retailer);
        }

        public ActionResult DeleteProduct(long id)
        {
            long retailerid = GetRetailerId();
            var retailer = efSvc.DeleteProduct(id, retailerid);
            return View("ManageProducts", retailer);
        }

        private long GetRetailerId()
        {
            var retailer_id = Request.QueryString["retailer_id"];
            long retailerid = 0;
            long.TryParse(retailer_id, out retailerid);
            return retailerid;
        }

        [HttpGet]
        public ActionResult AddProduct(long id)
        {
            var retailer = efSvc.GetRetailer(id);
            return View(retailer);
        }

        [HttpPost]
        public ActionResult AddProduct(long retailer_id, string name, string sku, string price )
        {
            decimal dPrice = 0;
            Decimal.TryParse(price, out dPrice);
            var retailer = efSvc.AddProduct(retailer_id, name, sku, dPrice);
            return View("ManageProducts", retailer);
        }
	}
}