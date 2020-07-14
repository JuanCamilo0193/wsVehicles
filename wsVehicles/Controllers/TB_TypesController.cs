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
using wsVehicles.Models;

namespace wsVehicles.Controllers
{
    public class TB_TypesController : ApiController
    {
        private BD_VEHICLESEntities db = new BD_VEHICLESEntities();

        // GET: api/TB_Types
        public IQueryable<TB_Types> GetTB_Types()
        {
            return db.TB_Types;
        }

        // GET: api/TB_Types/5
        [ResponseType(typeof(TB_Types))]
        public async Task<IHttpActionResult> GetTB_Types(int id)
        {
            TB_Types tB_Types = await db.TB_Types.FindAsync(id);
            if (tB_Types == null)
            {
                return NotFound();
            }

            return Ok(tB_Types);
        }

        // PUT: api/TB_Types/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTB_Types(int id, TB_Types tB_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tB_Types.IdType)
            {
                return BadRequest();
            }

            db.Entry(tB_Types).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB_TypesExists(id))
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

        // POST: api/TB_Types
        [ResponseType(typeof(TB_Types))]
        public async Task<IHttpActionResult> PostTB_Types(TB_Types tB_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TB_Types.Add(tB_Types);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tB_Types.IdType }, tB_Types);
        }

        // DELETE: api/TB_Types/5
        [ResponseType(typeof(TB_Types))]
        public async Task<IHttpActionResult> DeleteTB_Types(int id)
        {
            TB_Types tB_Types = await db.TB_Types.FindAsync(id);
            if (tB_Types == null)
            {
                return NotFound();
            }

            db.TB_Types.Remove(tB_Types);
            await db.SaveChangesAsync();

            return Ok(tB_Types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TB_TypesExists(int id)
        {
            return db.TB_Types.Count(e => e.IdType == id) > 0;
        }
    }
}