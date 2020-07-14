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
    public class TB_ManufacturersController : ApiController
    {
        private BD_VEHICLESEntities db = new BD_VEHICLESEntities();

        // GET: api/TB_Manufacturers
        public IQueryable<TB_Manufacturers> GetTB_Manufacturers()
        {
            return db.TB_Manufacturers;
        }

        // GET: api/TB_Manufacturers/5
        [ResponseType(typeof(TB_Manufacturers))]
        public async Task<IHttpActionResult> GetTB_Manufacturers(int id)
        {
            TB_Manufacturers tB_Manufacturers = await db.TB_Manufacturers.FindAsync(id);
            if (tB_Manufacturers == null)
            {
                return NotFound();
            }

            return Ok(tB_Manufacturers);
        }

        // PUT: api/TB_Manufacturers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTB_Manufacturers(int id, TB_Manufacturers tB_Manufacturers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tB_Manufacturers.IdManufacturer)
            {
                return BadRequest();
            }

            db.Entry(tB_Manufacturers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB_ManufacturersExists(id))
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

        // POST: api/TB_Manufacturers
        [ResponseType(typeof(TB_Manufacturers))]
        public async Task<IHttpActionResult> PostTB_Manufacturers(TB_Manufacturers tB_Manufacturers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TB_Manufacturers.Add(tB_Manufacturers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tB_Manufacturers.IdManufacturer }, tB_Manufacturers);
        }

        // DELETE: api/TB_Manufacturers/5
        [ResponseType(typeof(TB_Manufacturers))]
        public async Task<IHttpActionResult> DeleteTB_Manufacturers(int id)
        {
            TB_Manufacturers tB_Manufacturers = await db.TB_Manufacturers.FindAsync(id);
            if (tB_Manufacturers == null)
            {
                return NotFound();
            }

            db.TB_Manufacturers.Remove(tB_Manufacturers);
            await db.SaveChangesAsync();

            return Ok(tB_Manufacturers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TB_ManufacturersExists(int id)
        {
            return db.TB_Manufacturers.Count(e => e.IdManufacturer == id) > 0;
        }
    }
}