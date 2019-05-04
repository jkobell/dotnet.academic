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
    public class CostumesController : ApiController
    {
        private wk8_james_kobell_csContext db = new wk8_james_kobell_csContext();

        // GET: api/Costumes
        public IQueryable<Costumes> GetCostumes()
        {
            return db.Costumes;
        }

        // GET: api/Costumes/5
        [ResponseType(typeof(Costumes))]
        public async Task<IHttpActionResult> GetCostumes(string id)
        {
            Costumes costumes = await db.Costumes.FindAsync(id);
            if (costumes == null)
            {
                return NotFound();
            }

            return Ok(costumes);
        }

        // PUT: api/Costumes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCostumes(string id, Costumes costumes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costumes.ProductID)
            {
                return BadRequest();
            }

            db.Entry(costumes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostumesExists(id))
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

        // POST: api/Costumes
        [ResponseType(typeof(Costumes))]
        public async Task<IHttpActionResult> PostCostumes(Costumes costumes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Costumes.Add(costumes);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CostumesExists(costumes.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = costumes.ProductID }, costumes);
        }

        // DELETE: api/Costumes/5
        [ResponseType(typeof(Costumes))]
        public async Task<IHttpActionResult> DeleteCostumes(string id)
        {
            Costumes costumes = await db.Costumes.FindAsync(id);
            if (costumes == null)
            {
                return NotFound();
            }

            db.Costumes.Remove(costumes);
            await db.SaveChangesAsync();

            return Ok(costumes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CostumesExists(string id)
        {
            return db.Costumes.Count(e => e.ProductID == id) > 0;
        }
    }
}