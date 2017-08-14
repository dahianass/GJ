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
    builder.EntitySet<EstadosTipos>("EstadosTipos");
    builder.EntitySet<EstadosProcesales>("EstadosProcesales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EstadosTiposController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/EstadosTipos
        [EnableQuery]
        public IQueryable<EstadosTipos> GetEstadosTipos()
        {
            return db.EstadosTipos;
        }

        // GET: odata/EstadosTipos(5)
        [EnableQuery]
        public SingleResult<EstadosTipos> GetEstadosTipos([FromODataUri] int key)
        {
            return SingleResult.Create(db.EstadosTipos.Where(estadosTipos => estadosTipos.IdEstadosTipos == key));
        }

        // PUT: odata/EstadosTipos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<EstadosTipos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadosTipos estadosTipos = await db.EstadosTipos.FindAsync(key);
            if (estadosTipos == null)
            {
                return NotFound();
            }

            patch.Put(estadosTipos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosTiposExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estadosTipos);
        }

        // POST: odata/EstadosTipos
        public async Task<IHttpActionResult> Post(EstadosTipos estadosTipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadosTipos.Add(estadosTipos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadosTiposExists(estadosTipos.IdEstadosTipos))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(estadosTipos);
        }

        // PATCH: odata/EstadosTipos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<EstadosTipos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadosTipos estadosTipos = await db.EstadosTipos.FindAsync(key);
            if (estadosTipos == null)
            {
                return NotFound();
            }

            patch.Patch(estadosTipos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosTiposExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estadosTipos);
        }

        // DELETE: odata/EstadosTipos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            EstadosTipos estadosTipos = await db.EstadosTipos.FindAsync(key);
            if (estadosTipos == null)
            {
                return NotFound();
            }

            db.EstadosTipos.Remove(estadosTipos);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/EstadosTipos(5)/EstadosProcesales
        [EnableQuery]
        public SingleResult<EstadosProcesales> GetEstadosProcesales([FromODataUri] int key)
        {
            return SingleResult.Create(db.EstadosTipos.Where(m => m.IdEstadosTipos == key).Select(m => m.EstadosProcesales));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadosTiposExists(int key)
        {
            return db.EstadosTipos.Count(e => e.IdEstadosTipos == key) > 0;
        }
    }
}
