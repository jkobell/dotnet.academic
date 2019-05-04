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
    public class FxController : ApiController
    {
        private wk8_james_kobell_csContext db = new wk8_james_kobell_csContext();

        // GET: api/FXes
        public IQueryable<FX> GetFXes()
        {
            return db.Fx;
        }

        // GET: api/Fx/5
        [ResponseType(typeof(FX))]
        public async Task<IHttpActionResult> GetFX(string id)
        {
            FX fX = await db.Fx.FindAsync(id);
            if (fX == null)
            {
                return NotFound();
            }

            return Ok(fX);
        }

        // PUT: api/Fx/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFX(string id, FX fX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fX.ProductID)
            {
                return BadRequest();
            }

            db.Entry(fX).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FXExists(id))
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

        // POST: api/Fx
        [ResponseType(typeof(FX))]
        public async Task<IHttpActionResult> PostFX(FX fX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fx.Add(fX);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FXExists(fX.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fX.ProductID }, fX);
        }

        // DELETE: api/Fx/5
        [ResponseType(typeof(FX))]
        public async Task<IHttpActionResult> DeleteFX(string id)
        {
            FX fX = await db.Fx.FindAsync(id);
            if (fX == null)
            {
                return NotFound();
            }

            db.Fx.Remove(fX);
            await db.SaveChangesAsync();

            return Ok(fX);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FXExists(string id)
        {
            return db.Fx.Count(e => e.ProductID == id) > 0;
        }
    }
}