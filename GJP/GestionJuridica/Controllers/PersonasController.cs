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
    builder.EntitySet<Personas>("Personas");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PersonasController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Personas
        [EnableQuery]
        public IQueryable<Personas> GetPersonas()
        {
            return db.Personas;
        }

        // GET: odata/Personas(5)
        [EnableQuery]
        public SingleResult<Personas> GetPersonas([FromODataUri] int key)
        {
            return SingleResult.Create(db.Personas.Where(personas => personas.IdPersona == key));
        }

        // PUT: odata/Personas(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Personas> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Personas personas = await db.Personas.FindAsync(key);
            if (personas == null)
            {
                return NotFound();
            }

            patch.Put(personas);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(personas);
        }

        // POST: odata/Personas
        public async Task<IHttpActionResult> Post(Personas personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personas.Add(personas);
            await db.SaveChangesAsync();

            return Created(personas);
        }

        // PATCH: odata/Personas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Personas> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Personas personas = await db.Personas.FindAsync(key);
            if (personas == null)
            {
                return NotFound();
            }

            patch.Patch(personas);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(personas);
        }

        // DELETE: odata/Personas(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Personas personas = await db.Personas.FindAsync(key);
            if (personas == null)
            {
                return NotFound();
            }

            db.Personas.Remove(personas);
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

        private bool PersonasExists(int key)
        {
            return db.Personas.Count(e => e.IdPersona == key) > 0;
        }
    }
}
