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
    builder.EntitySet<Auditoria>("Auditorias");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AuditoriasController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Auditorias
        [EnableQuery]
        public IQueryable<Auditoria> GetAuditorias()
        {
            return db.Auditoria;
        }

        // GET: odata/Auditorias(5)
        [EnableQuery]
        public SingleResult<Auditoria> GetAuditoria([FromODataUri] int key)
        {
            return SingleResult.Create(db.Auditoria.Where(auditoria => auditoria.IdAuditoria == key));
        }

        // PUT: odata/Auditorias(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Auditoria> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Auditoria auditoria = await db.Auditoria.FindAsync(key);
            if (auditoria == null)
            {
                return NotFound();
            }

            patch.Put(auditoria);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(auditoria);
        }

        // POST: odata/Auditorias
        public async Task<IHttpActionResult> Post(Auditoria auditoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Auditoria.Add(auditoria);
            await db.SaveChangesAsync();

            return Created(auditoria);
        }

        // PATCH: odata/Auditorias(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Auditoria> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Auditoria auditoria = await db.Auditoria.FindAsync(key);
            if (auditoria == null)
            {
                return NotFound();
            }

            patch.Patch(auditoria);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(auditoria);
        }

        // DELETE: odata/Auditorias(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Auditoria auditoria = await db.Auditoria.FindAsync(key);
            if (auditoria == null)
            {
                return NotFound();
            }

            db.Auditoria.Remove(auditoria);
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

        private bool AuditoriaExists(int key)
        {
            return db.Auditoria.Count(e => e.IdAuditoria == key) > 0;
        }
    }
}
