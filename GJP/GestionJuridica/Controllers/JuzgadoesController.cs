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
    builder.EntitySet<Juzgado>("Juzgadoes");
    builder.EntitySet<Municipio>("Municipio"); 
    builder.EntitySet<TipoJuzgado>("TipoJuzgado"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class JuzgadoesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Juzgadoes
        [EnableQuery]
        public IQueryable<Juzgado> GetJuzgadoes()
        {
            return db.Juzgado;
        }

        // GET: odata/Juzgadoes(5)
        [EnableQuery]
        public SingleResult<Juzgado> GetJuzgado([FromODataUri] int key)
        {
            return SingleResult.Create(db.Juzgado.Where(juzgado => juzgado.IdJuzgado == key));
        }

        // PUT: odata/Juzgadoes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Juzgado> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Juzgado juzgado = await db.Juzgado.FindAsync(key);
            if (juzgado == null)
            {
                return NotFound();
            }

            patch.Put(juzgado);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JuzgadoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(juzgado);
        }

        // POST: odata/Juzgadoes
        public async Task<IHttpActionResult> Post(Juzgado juzgado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Juzgado.Add(juzgado);
            await db.SaveChangesAsync();

            return Created(juzgado);
        }

        // PATCH: odata/Juzgadoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Juzgado> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Juzgado juzgado = await db.Juzgado.FindAsync(key);
            if (juzgado == null)
            {
                return NotFound();
            }

            patch.Patch(juzgado);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JuzgadoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(juzgado);
        }

        // DELETE: odata/Juzgadoes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Juzgado juzgado = await db.Juzgado.FindAsync(key);
            if (juzgado == null)
            {
                return NotFound();
            }

            db.Juzgado.Remove(juzgado);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Juzgadoes(5)/Municipio
        [EnableQuery]
        public SingleResult<Municipio> GetMunicipio([FromODataUri] int key)
        {
            return SingleResult.Create(db.Juzgado.Where(m => m.IdJuzgado == key).Select(m => m.Municipio));
        }

        // GET: odata/Juzgadoes(5)/TipoJuzgado
        [EnableQuery]
        public SingleResult<TipoJuzgado> GetTipoJuzgado([FromODataUri] int key)
        {
            return SingleResult.Create(db.Juzgado.Where(m => m.IdJuzgado == key).Select(m => m.TipoJuzgado));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JuzgadoExists(int key)
        {
            return db.Juzgado.Count(e => e.IdJuzgado == key) > 0;
        }
    }
}
