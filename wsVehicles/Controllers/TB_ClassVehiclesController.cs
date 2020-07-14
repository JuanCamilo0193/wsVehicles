using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using wsVehicles.Models;

namespace wsVehicles.Controllers
{
    public class TB_ClassVehiclesController : ApiController
    {
        private BD_VEHICLESEntities db = new BD_VEHICLESEntities();

        // GET: api/TB_ClassVehicles
        public IQueryable<TB_ClassVehicles> GetTB_ClassVehicles()
        {
            return db.TB_ClassVehicles;
        }

        // GET: api/TB_ClassVehicles/5
        [ResponseType(typeof(TB_ClassVehicles))]
        public async Task<IHttpActionResult> GetTB_ClassVehicles(int id)
        {
            TB_ClassVehicles tB_ClassVehicles = await db.TB_ClassVehicles.FindAsync(id);
            if (tB_ClassVehicles == null)
            {
                return NotFound();
            }

            return Ok(tB_ClassVehicles);
        }

        // PUT: api/TB_ClassVehicles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTB_ClassVehicles(int id, TB_ClassVehicles tB_ClassVehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tB_ClassVehicles.IdClassVehicle)
            {
                return BadRequest();
            }

            db.Entry(tB_ClassVehicles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB_ClassVehiclesExists(id))
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

        // POST: api/TB_ClassVehicles
        [ResponseType(typeof(TB_ClassVehicles))]
        public async Task<IHttpActionResult> PostTB_ClassVehicles(TB_ClassVehicles tB_ClassVehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TB_ClassVehicles.Add(tB_ClassVehicles);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tB_ClassVehicles.IdClassVehicle }, tB_ClassVehicles);
        }

        // DELETE: api/TB_ClassVehicles/5
        [ResponseType(typeof(TB_ClassVehicles))]
        public async Task<IHttpActionResult> DeleteTB_ClassVehicles(int id)
        {
            TB_ClassVehicles tB_ClassVehicles = await db.TB_ClassVehicles.FindAsync(id);
            if (tB_ClassVehicles == null)
            {
                return NotFound();
            }

            db.TB_ClassVehicles.Remove(tB_ClassVehicles);
            await db.SaveChangesAsync();

            return Ok(tB_ClassVehicles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TB_ClassVehiclesExists(int id)
        {
            return db.TB_ClassVehicles.Count(e => e.IdClassVehicle == id) > 0;
        }
    }
}