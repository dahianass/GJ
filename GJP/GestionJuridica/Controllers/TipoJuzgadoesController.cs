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
    builder.EntitySet<TipoJuzgado>("TipoJuzgadoes");
    builder.EntitySet<Juzgado>("Juzgado"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TipoJuzgadoesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/TipoJuzgadoes
        [EnableQuery]
        public IQueryable<TipoJuzgado> GetTipoJuzgadoes()
        {
            return db.TipoJuzgado;
        }

        // GET: odata/TipoJuzgadoes(5)
        [EnableQuery]
        public SingleResult<TipoJuzgado> GetTipoJuzgado([FromODataUri] int key)
        {
            return SingleResult.Create(db.TipoJuzgado.Where(tipoJuzgado => tipoJuzgado.IdTipoJuzgado == key));
        }

        // PUT: odata/TipoJuzgadoes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<TipoJuzgado> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoJuzgado tipoJuzgado = await db.TipoJuzgado.FindAsync(key);
            if (tipoJuzgado == null)
            {
                return NotFound();
            }

            patch.Put(tipoJuzgado);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoJuzgadoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tipoJuzgado);
        }

        // POST: odata/TipoJuzgadoes
        public async Task<IHttpActionResult> Post(TipoJuzgado tipoJuzgado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoJuzgado.Add(tipoJuzgado);
            await db.SaveChangesAsync();

            return Created(tipoJuzgado);
        }

        // PATCH: odata/TipoJuzgadoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<TipoJuzgado> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoJuzgado tipoJuzgado = await db.TipoJuzgado.FindAsync(key);
            if (tipoJuzgado == null)
            {
                return NotFound();
            }

            patch.Patch(tipoJuzgado);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoJuzgadoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tipoJuzgado);
        }

        // DELETE: odata/TipoJuzgadoes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            TipoJuzgado tipoJuzgado = await db.TipoJuzgado.FindAsync(key);
            if (tipoJuzgado == null)
            {
                return NotFound();
            }

            db.TipoJuzgado.Remove(tipoJuzgado);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/TipoJuzgadoes(5)/Juzgado
        [EnableQuery]
        public IQueryable<Juzgado> GetJuzgado([FromODataUri] int key)
        {
            return db.TipoJuzgado.Where(m => m.IdTipoJuzgado == key).SelectMany(m => m.Juzgado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoJuzgadoExists(int key)
        {
            return db.TipoJuzgado.Count(e => e.IdTipoJuzgado == key) > 0;
        }
    }
}
