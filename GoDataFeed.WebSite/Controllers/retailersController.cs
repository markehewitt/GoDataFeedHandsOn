using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GoDataFeed.Dal;
using GoDataFeed.WebSite.Models;

namespace GoDataFeed.WebSite.Controllers
{
    public class retailersController : ApiController
    {
        private GoDataFeedWebSiteContext db = new GoDataFeedWebSiteContext();

        // GET: api/retailers
        public IQueryable<retailer> Getretailers()
        {
            return db.retailers;
        }

        // GET: api/retailers/5
        [ResponseType(typeof(retailer))]
        public IHttpActionResult Getretailer(long id)
        {
            retailer retailer = db.retailers.Find(id);
            if (retailer == null)
            {
                return NotFound();
            }

            return Ok(retailer);
        }

        // PUT: api/retailers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putretailer(long id, retailer retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != retailer.id)
            {
                return BadRequest();
            }

            db.Entry(retailer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!retailerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/retailers
        [ResponseType(typeof(retailer))]
        public IHttpActionResult Postretailer(retailer retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.retailers.Add(retailer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = retailer.id }, retailer);
        }

        // DELETE: api/retailers/5
        [ResponseType(typeof(retailer))]
        public IHttpActionResult Deleteretailer(long id)
        {
            retailer retailer = db.retailers.Find(id);
            if (retailer == null)
            {
                return NotFound();
            }

            db.retailers.Remove(retailer);
            db.SaveChanges();

            return Ok(retailer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool retailerExists(long id)
        {
            return db.retailers.Count(e => e.id == id) > 0;
        }
    }
}