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
    public class TB_VehiclesController : ApiController
    {
        private BD_VEHICLESEntities db = new BD_VEHICLESEntities();

        // GET: api/TB_Vehicles
        public IQueryable<TB_Vehicles> GetTB_Vehicles()
        {
            return db.TB_Vehicles;
        }

        // GET: api/TB_Vehicles/5
        [ResponseType(typeof(TB_Vehicles))]
        public async Task<IHttpActionResult> GetTB_Vehicles(int id)
        {
            TB_Vehicles tB_Vehicles = await db.TB_Vehicles.FindAsync(id);
            if (tB_Vehicles == null)
            {
                return NotFound();
            }

            return Ok(tB_Vehicles);
        }

        // PUT: api/TB_Vehicles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTB_Vehicles(int id, TB_Vehicles tB_Vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tB_Vehicles.IdVehicle)
            {
                return BadRequest();
            }

            db.Entry(tB_Vehicles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB_VehiclesExists(id))
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

        // POST: api/TB_Vehicles
        [ResponseType(typeof(TB_Vehicles))]
        public async Task<IHttpActionResult> PostTB_Vehicles(TB_Vehicles tB_Vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TB_Vehicles.Add(tB_Vehicles);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tB_Vehicles.IdVehicle }, tB_Vehicles);
        }

        // DELETE: api/TB_Vehicles/5
        [ResponseType(typeof(TB_Vehicles))]
        public async Task<IHttpActionResult> DeleteTB_Vehicles(int id)
        {
            TB_Vehicles tB_Vehicles = await db.TB_Vehicles.FindAsync(id);
            if (tB_Vehicles == null)
            {
                return NotFound();
            }

            db.TB_Vehicles.Remove(tB_Vehicles);
            await db.SaveChangesAsync();

            return Ok(tB_Vehicles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TB_VehiclesExists(int id)
        {
            return db.TB_Vehicles.Count(e => e.IdVehicle == id) > 0;
        }
    }
}