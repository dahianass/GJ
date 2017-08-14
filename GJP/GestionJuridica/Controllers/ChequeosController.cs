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
    builder.EntitySet<Chequeo>("Chequeos");
    builder.EntitySet<ChequeoTipo>("ChequeoTipo"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ChequeosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Chequeos
        [EnableQuery]
        public IQueryable<Chequeo> GetChequeos()
        {
            return db.Chequeo;
        }

        // GET: odata/Chequeos(5)
        [EnableQuery]
        public SingleResult<Chequeo> GetChequeo([FromODataUri] int key)
        {
            return SingleResult.Create(db.Chequeo.Where(chequeo => chequeo.IdChequeo == key));
        }

        // PUT: odata/Chequeos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Chequeo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Chequeo chequeo = await db.Chequeo.FindAsync(key);
            if (chequeo == null)
            {
                return NotFound();
            }

            patch.Put(chequeo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeo);
        }

        // POST: odata/Chequeos
        public async Task<IHttpActionResult> Post(Chequeo chequeo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chequeo.Add(chequeo);
            await db.SaveChangesAsync();

            return Created(chequeo);
        }

        // PATCH: odata/Chequeos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Chequeo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Chequeo chequeo = await db.Chequeo.FindAsync(key);
            if (chequeo == null)
            {
                return NotFound();
            }

            patch.Patch(chequeo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeo);
        }

        // DELETE: odata/Chequeos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Chequeo chequeo = await db.Chequeo.FindAsync(key);
            if (chequeo == null)
            {
                return NotFound();
            }

            db.Chequeo.Remove(chequeo);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Chequeos(5)/ChequeoTipo
        [EnableQuery]
        public IQueryable<ChequeoTipo> GetChequeoTipo([FromODataUri] int key)
        {
            return db.Chequeo.Where(m => m.IdChequeo == key).SelectMany(m => m.ChequeoTipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChequeoExists(int key)
        {
            return db.Chequeo.Count(e => e.IdChequeo == key) > 0;
        }
    }
}
