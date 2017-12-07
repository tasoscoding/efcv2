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
using efcv2.Models;

namespace efcv2.Controllers
{
    public class Valuesis2Controller : ApiController
    {
        private efcv2DBEntities db = new efcv2DBEntities();

        // GET: api/Valuesis2
        public IQueryable<Valuesi> GetValuesis()
        {
            return db.Valuesis;
        }

        // GET: api/Valuesis2/5
        [ResponseType(typeof(Valuesi))]
        public IHttpActionResult GetValuesi(long id)
        {

            
            
            Valuesi valuesi = db.Valuesis.Find(id);
            if (valuesi == null)
            {
                return NotFound();
            }

            return Ok(valuesi);
            
        }

        // PUT: api/Valuesis2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutValuesi(long id, Valuesi valuesi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != valuesi.ValueiID)
            {
                return BadRequest();
            }

            db.Entry(valuesi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValuesiExists(id))
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

        // POST: api/Valuesis2
        [ResponseType(typeof(Valuesi))]
        public IHttpActionResult PostValuesi(Valuesi valuesi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Valuesis.Add(valuesi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = valuesi.ValueiID }, valuesi);
        }

        // DELETE: api/Valuesis2/5
        [ResponseType(typeof(Valuesi))]
        public IHttpActionResult DeleteValuesi(long id)
        {
            Valuesi valuesi = db.Valuesis.Find(id);
            if (valuesi == null)
            {
                return NotFound();
            }

            db.Valuesis.Remove(valuesi);
            db.SaveChanges();

            return Ok(valuesi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValuesiExists(long id)
        {
            return db.Valuesis.Count(e => e.ValueiID == id) > 0;
        }
    }
}