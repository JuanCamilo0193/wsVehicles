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
    public class TB_CountriesController : ApiController
    {
        private BD_VEHICLESEntities db = new BD_VEHICLESEntities();

        // GET: api/TB_Countries
        public IQueryable<TB_Countries> GetTB_Countries()
        {
            return db.TB_Countries;
        }

        // GET: api/TB_Countries/5
        [ResponseType(typeof(TB_Countries))]
        public async Task<IHttpActionResult> GetTB_Countries(int id)
        {
            TB_Countries tB_Countries = await db.TB_Countries.FindAsync(id);
            if (tB_Countries == null)
            {
                return NotFound();
            }

            return Ok(tB_Countries);
        }

        // PUT: api/TB_Countries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTB_Countries(int id, TB_Countries tB_Countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tB_Countries.IdCountry)
            {
                return BadRequest();
            }

            db.Entry(tB_Countries).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB_CountriesExists(id))
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

        // POST: api/TB_Countries
        [ResponseType(typeof(TB_Countries))]
        public async Task<IHttpActionResult> PostTB_Countries(TB_Countries tB_Countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TB_Countries.Add(tB_Countries);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tB_Countries.IdCountry }, tB_Countries);
        }

        // DELETE: api/TB_Countries/5
        [ResponseType(typeof(TB_Countries))]
        public async Task<IHttpActionResult> DeleteTB_Countries(int id)
        {
            TB_Countries tB_Countries = await db.TB_Countries.FindAsync(id);
            if (tB_Countries == null)
            {
                return NotFound();
            }

            db.TB_Countries.Remove(tB_Countries);
            await db.SaveChangesAsync();

            return Ok(tB_Countries);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TB_CountriesExists(int id)
        {
            return db.TB_Countries.Count(e => e.IdCountry == id) > 0;
        }
    }
}