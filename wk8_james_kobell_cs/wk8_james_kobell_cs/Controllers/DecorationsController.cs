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
    public class DecorationsController : ApiController
    {
        private wk8_james_kobell_csContext db = new wk8_james_kobell_csContext();

        // GET: api/Decorations
        public IQueryable<Decorations> GetDecorations()
        {
            return db.Decorations;
        }

        // GET: api/Decorations/5
        [ResponseType(typeof(Decorations))]
        public async Task<IHttpActionResult> GetDecorations(string id)
        {
            Decorations decorations = await db.Decorations.FindAsync(id);
            if (decorations == null)
            {
                return NotFound();
            }

            return Ok(decorations);
        }

        // PUT: api/Decorations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDecorations(string id, Decorations decorations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != decorations.ProductID)
            {
                return BadRequest();
            }

            db.Entry(decorations).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DecorationsExists(id))
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

        // POST: api/Decorations
        [ResponseType(typeof(Decorations))]
        public async Task<IHttpActionResult> PostDecorations(Decorations decorations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Decorations.Add(decorations);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DecorationsExists(decorations.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = decorations.ProductID }, decorations);
        }

        // DELETE: api/Decorations/5
        [ResponseType(typeof(Decorations))]
        public async Task<IHttpActionResult> DeleteDecorations(string id)
        {
            Decorations decorations = await db.Decorations.FindAsync(id);
            if (decorations == null)
            {
                return NotFound();
            }

            db.Decorations.Remove(decorations);
            await db.SaveChangesAsync();

            return Ok(decorations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DecorationsExists(string id)
        {
            return db.Decorations.Count(e => e.ProductID == id) > 0;
        }
    }
}