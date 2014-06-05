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
        private RetailerContext db = new RetailerContext();

        // GET: api/retailers
        public IQueryable<Retailer> Getretailers()
        {
            return db.Retailers;
        }

        // GET: api/retailers/5
        [ResponseType(typeof(Retailer))]
        public IHttpActionResult Getretailer(long id)
        {
            Retailer retailer = db.Retailers.Find(id);
            if (retailer == null)
            {
                return NotFound();
            }

            return Ok(retailer);
        }

        // PUT: api/retailers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putretailer(long id, Retailer retailer)
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
        [ResponseType(typeof(Retailer))]
        public IHttpActionResult Postretailer(Retailer retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Retailers.Add(retailer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = retailer.id }, retailer);
        }

        // DELETE: api/retailers/5
        [ResponseType(typeof(Retailer))]
        public IHttpActionResult Deleteretailer(long id)
        {
            Retailer retailer = db.Retailers.Find(id);
            if (retailer == null)
            {
                return NotFound();
            }

            db.Retailers.Remove(retailer);
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
            return db.Retailers.Count(e => e.id == id) > 0;
        }
    }
}