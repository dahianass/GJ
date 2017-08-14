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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GestionJuridica.Models;

namespace GestionJuridica.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using GestionJuridica.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EstadosProcesales>("EstadosProcesales");
    builder.EntitySet<EstadosTipos>("EstadosTipos"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EstadosProcesalesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/EstadosProcesales
        [EnableQuery]
        public IQueryable<EstadosProcesales> GetEstadosProcesales()
        {
            return db.EstadosProcesales;
        }

        // GET: odata/EstadosProcesales(5)
        [EnableQuery]
        public SingleResult<EstadosProcesales> GetEstadosProcesales([FromODataUri] int key)
        {
            return SingleResult.Create(db.EstadosProcesales.Where(estadosProcesales => estadosProcesales.IdEstados == key));
        }

        // PUT: odata/EstadosProcesales(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<EstadosProcesales> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadosProcesales estadosProcesales = await db.EstadosProcesales.FindAsync(key);
            if (estadosProcesales == null)
            {
                return NotFound();
            }

            patch.Put(estadosProcesales);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosProcesalesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estadosProcesales);
        }

        // POST: odata/EstadosProcesales
        public async Task<IHttpActionResult> Post(EstadosProcesales estadosProcesales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadosProcesales.Add(estadosProcesales);
            await db.SaveChangesAsync();

            return Created(estadosProcesales);
        }

        // PATCH: odata/EstadosProcesales(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<EstadosProcesales> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadosProcesales estadosProcesales = await db.EstadosProcesales.FindAsync(key);
            if (estadosProcesales == null)
            {
                return NotFound();
            }

            patch.Patch(estadosProcesales);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosProcesalesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estadosProcesales);
        }

        // DELETE: odata/EstadosProcesales(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            EstadosProcesales estadosProcesales = await db.EstadosProcesales.FindAsync(key);
            if (estadosProcesales == null)
            {
                return NotFound();
            }

            db.EstadosProcesales.Remove(estadosProcesales);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/EstadosProcesales(5)/EstadosTipos
        [EnableQuery]
        public IQueryable<EstadosTipos> GetEstadosTipos([FromODataUri] int key)
        {
            return db.EstadosProcesales.Where(m => m.IdEstados == key).SelectMany(m => m.EstadosTipos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadosProcesalesExists(int key)
        {
            return db.EstadosProcesales.Count(e => e.IdEstados == key) > 0;
        }
    }
}
