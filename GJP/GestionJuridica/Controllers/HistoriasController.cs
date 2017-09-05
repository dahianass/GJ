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
    builder.EntitySet<Historia>("Historias");
    builder.EntitySet<Formulario>("Formulario"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class HistoriasController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Historias
        [EnableQuery]
        public IQueryable<Historia> GetHistorias()
        {
            return db.Historia;
        }

        // GET: odata/Historias(5)
        [EnableQuery]
        public SingleResult<Historia> GetHistoria([FromODataUri] int key)
        {
            return SingleResult.Create(db.Historia.Where(historia => historia.IdHistoria == key));
        }

        // PUT: odata/Historias(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Historia> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Historia historia = await db.Historia.FindAsync(key);
            if (historia == null)
            {
                return NotFound();
            }

            patch.Put(historia);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historia);
        }

        // POST: odata/Historias
        public async Task<IHttpActionResult> Post(Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Historia.Add(historia);
            await db.SaveChangesAsync();

            return Created(historia);
        }

        // PATCH: odata/Historias(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Historia> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Historia historia = await db.Historia.FindAsync(key);
            if (historia == null)
            {
                return NotFound();
            }

            patch.Patch(historia);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historia);
        }

        // DELETE: odata/Historias(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Historia historia = await db.Historia.FindAsync(key);
            if (historia == null)
            {
                return NotFound();
            }

            db.Historia.Remove(historia);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Historias(5)/Formulario
        [EnableQuery]
        public SingleResult<Formulario> GetFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Historia.Where(m => m.IdHistoria == key).Select(m => m.Formulario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoriaExists(int key)
        {
            return db.Historia.Count(e => e.IdHistoria == key) > 0;
        }
    }
}
