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
    public class PropsController : ApiController
    {
        private wk8_james_kobell_csContext db = new wk8_james_kobell_csContext();

        // GET: api/Props
        public IQueryable<Props> GetProps()
        {
            return db.Props;
        }

        // GET: api/Props/5
        [ResponseType(typeof(Props))]
        public async Task<IHttpActionResult> GetProps(string id)
        {
            Props props = await db.Props.FindAsync(id);
            if (props == null)
            {
                return NotFound();
            }

            return Ok(props);
        }

        // PUT: api/Props/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProps(string id, Props props)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != props.ProductID)
            {
                return BadRequest();
            }

            db.Entry(props).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropsExists(id))
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

        // POST: api/Props
        [ResponseType(typeof(Props))]
        public async Task<IHttpActionResult> PostProps(Props props)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Props.Add(props);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropsExists(props.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = props.ProductID }, props);
        }

        // DELETE: api/Props/5
        [ResponseType(typeof(Props))]
        public async Task<IHttpActionResult> DeleteProps(string id)
        {
            Props props = await db.Props.FindAsync(id);
            if (props == null)
            {
                return NotFound();
            }

            db.Props.Remove(props);
            await db.SaveChangesAsync();

            return Ok(props);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropsExists(string id)
        {
            return db.Props.Count(e => e.ProductID == id) > 0;
        }
    }
}