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
    builder.EntitySet<TipoProcesos>("TipoProcesos");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TipoProcesosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/TipoProcesos
        [EnableQuery]
        public IQueryable<TipoProcesos> GetTipoProcesos()
        {
            return db.TipoProcesos;
        }

        // GET: odata/TipoProcesos(5)
        [EnableQuery]
        public SingleResult<TipoProcesos> GetTipoProcesos([FromODataUri] int key)
        {
            return SingleResult.Create(db.TipoProcesos.Where(tipoProcesos => tipoProcesos.IdTiposProcesos == key));
        }

        // PUT: odata/TipoProcesos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<TipoProcesos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoProcesos tipoProcesos = await db.TipoProcesos.FindAsync(key);
            if (tipoProcesos == null)
            {
                return NotFound();
            }

            patch.Put(tipoProcesos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProcesosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tipoProcesos);
        }

        // POST: odata/TipoProcesos
        public async Task<IHttpActionResult> Post(TipoProcesos tipoProcesos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoProcesos.Add(tipoProcesos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoProcesosExists(tipoProcesos.IdTiposProcesos))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tipoProcesos);
        }

        // PATCH: odata/TipoProcesos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<TipoProcesos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoProcesos tipoProcesos = await db.TipoProcesos.FindAsync(key);
            if (tipoProcesos == null)
            {
                return NotFound();
            }

            patch.Patch(tipoProcesos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProcesosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tipoProcesos);
        }

        // DELETE: odata/TipoProcesos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            TipoProcesos tipoProcesos = await db.TipoProcesos.FindAsync(key);
            if (tipoProcesos == null)
            {
                return NotFound();
            }

            db.TipoProcesos.Remove(tipoProcesos);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoProcesosExists(int key)
        {
            return db.TipoProcesos.Count(e => e.IdTiposProcesos == key) > 0;
        }
    }
}
