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
    builder.EntitySet<Proyectos>("Proyectos");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProyectosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Proyectos
        [EnableQuery]
        public IQueryable<Proyectos> GetProyectos()
        {
            return db.Proyectos;
        }

        // GET: odata/Proyectos(5)
        [EnableQuery]
        public SingleResult<Proyectos> GetProyectos([FromODataUri] int key)
        {
            return SingleResult.Create(db.Proyectos.Where(proyectos => proyectos.IdProyectos == key));
        }

        // PUT: odata/Proyectos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Proyectos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Proyectos proyectos = await db.Proyectos.FindAsync(key);
            if (proyectos == null)
            {
                return NotFound();
            }

            patch.Put(proyectos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(proyectos);
        }

        // POST: odata/Proyectos
        public async Task<IHttpActionResult> Post(Proyectos proyectos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proyectos.Add(proyectos);
            await db.SaveChangesAsync();

            return Created(proyectos);
        }

        // PATCH: odata/Proyectos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Proyectos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Proyectos proyectos = await db.Proyectos.FindAsync(key);
            if (proyectos == null)
            {
                return NotFound();
            }

            patch.Patch(proyectos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(proyectos);
        }

        // DELETE: odata/Proyectos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Proyectos proyectos = await db.Proyectos.FindAsync(key);
            if (proyectos == null)
            {
                return NotFound();
            }

            db.Proyectos.Remove(proyectos);
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

        private bool ProyectosExists(int key)
        {
            return db.Proyectos.Count(e => e.IdProyectos == key) > 0;
        }
    }
}
