using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using wk8_james_kobell_cs.Models;

namespace wk8_james_kobell_cs.Controllers
{
    public class MasksController : ApiController
    {
        private wk8_james_kobell_csContext db = new wk8_james_kobell_csContext();

        // GET: api/Masks
        public IQueryable<Masks> GetMasks()
        {
            return db.Masks;
        }

        // GET: api/Masks/5
        [ResponseType(typeof(Masks))]
        public async Task<IHttpActionResult> GetMasks(string id)
        {
            Masks masks = await db.Masks.FindAsync(id);
            if (masks == null)
            {
                return NotFound();
            }

            return Ok(masks);
        }

        // PUT: api/Masks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMasks(string id, Masks masks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != masks.ProductID)
            {
                return BadRequest();
            }

            db.Entry(masks).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasksExists(id))
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

        // POST: api/Masks
        [ResponseType(typeof(Masks))]
        public async Task<IHttpActionResult> PostMasks(Masks masks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Masks.Add(masks);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MasksExists(masks.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = masks.ProductID }, masks);
        }

        // DELETE: api/Masks/5
        [ResponseType(typeof(Masks))]
        public async Task<IHttpActionResult> DeleteMasks(string id)
        {
            Masks masks = await db.Masks.FindAsync(id);
            if (masks == null)
            {
                return NotFound();
            }

            db.Masks.Remove(masks);
            await db.SaveChangesAsync();

            return Ok(masks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MasksExists(string id)
        {
            return db.Masks.Count(e => e.ProductID == id) > 0;
        }
    }
}