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
    builder.EntitySet<Distrito>("Distritoes");
    builder.EntitySet<Circuito>("Circuito"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DistritoesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Distritoes
        [EnableQuery]
        public IQueryable<Distrito> GetDistritoes()
        {
            return db.Distrito;
        }

        // GET: odata/Distritoes(5)
        [EnableQuery]
        public SingleResult<Distrito> GetDistrito([FromODataUri] int key)
        {
            return SingleResult.Create(db.Distrito.Where(distrito => distrito.IdDistrito == key));
        }

        // PUT: odata/Distritoes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Distrito> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Distrito distrito = await db.Distrito.FindAsync(key);
            if (distrito == null)
            {
                return NotFound();
            }

            patch.Put(distrito);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistritoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(distrito);
        }

        // POST: odata/Distritoes
        public async Task<IHttpActionResult> Post(Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distrito.Add(distrito);
            await db.SaveChangesAsync();

            return Created(distrito);
        }

        // PATCH: odata/Distritoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Distrito> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Distrito distrito = await db.Distrito.FindAsync(key);
            if (distrito == null)
            {
                return NotFound();
            }

            patch.Patch(distrito);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistritoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(distrito);
        }

        // DELETE: odata/Distritoes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Distrito distrito = await db.Distrito.FindAsync(key);
            if (distrito == null)
            {
                return NotFound();
            }

            db.Distrito.Remove(distrito);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Distritoes(5)/Circuito
        [EnableQuery]
        public IQueryable<Circuito> GetCircuito([FromODataUri] int key)
        {
            return db.Distrito.Where(m => m.IdDistrito == key).SelectMany(m => m.Circuito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistritoExists(int key)
        {
            return db.Distrito.Count(e => e.IdDistrito == key) > 0;
        }
    }
}
