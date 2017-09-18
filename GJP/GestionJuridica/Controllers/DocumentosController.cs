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
    builder.EntitySet<Documentos>("Documentos");
    builder.EntitySet<EstadosFormulario>("EstadosFormulario"); 
    builder.EntitySet<Formulario>("Formulario"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DocumentosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Documentos
        [EnableQuery]
        public IQueryable<Documentos> GetDocumentos()
        {
            return db.Documentos;
        }

        // GET: odata/Documentos(5)
        [EnableQuery]
        public SingleResult<Documentos> GetDocumentos([FromODataUri] int key)
        {
            return SingleResult.Create(db.Documentos.Where(documentos => documentos.IdDocumentos == key));
        }

        // PUT: odata/Documentos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Documentos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Documentos documentos = await db.Documentos.FindAsync(key);
            if (documentos == null)
            {
                return NotFound();
            }

            patch.Put(documentos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(documentos);
        }

        // POST: odata/Documentos
        public async Task<IHttpActionResult> Post(Documentos documentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Documentos.Add(documentos);
            await db.SaveChangesAsync();

            return Created(documentos);
        }

        // PATCH: odata/Documentos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Documentos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Documentos documentos = await db.Documentos.FindAsync(key);
            if (documentos == null)
            {
                return NotFound();
            }

            patch.Patch(documentos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(documentos);
        }

        // DELETE: odata/Documentos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Documentos documentos = await db.Documentos.FindAsync(key);
            if (documentos == null)
            {
                return NotFound();
            }

            db.Documentos.Remove(documentos);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Documentos(5)/EstadosFormulario
        [EnableQuery]
        public SingleResult<EstadosFormulario> GetEstadosFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Documentos.Where(m => m.IdDocumentos == key).Select(m => m.EstadosFormulario));
        }

        // GET: odata/Documentos(5)/Formulario
        [EnableQuery]
        public SingleResult<Formulario> GetFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Documentos.Where(m => m.IdDocumentos == key).Select(m => m.Formulario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentosExists(int key)
        {
            return db.Documentos.Count(e => e.IdDocumentos == key) > 0;
        }
    }
}
