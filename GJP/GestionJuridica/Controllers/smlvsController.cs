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
    builder.EntitySet<smlv>("smlvs");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class smlvsController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/smlvs
        [EnableQuery]
        public IQueryable<smlv> Getsmlvs()
        {
            return db.smlv;
        }

        // GET: odata/smlvs(5)
        [EnableQuery]
        public SingleResult<smlv> Getsmlv([FromODataUri] int key)
        {
            return SingleResult.Create(db.smlv.Where(smlv => smlv.Idsmlv == key));
        }

        // PUT: odata/smlvs(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<smlv> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            smlv smlv = await db.smlv.FindAsync(key);
            if (smlv == null)
            {
                return NotFound();
            }

            patch.Put(smlv);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!smlvExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(smlv);
        }

        // POST: odata/smlvs
        public async Task<IHttpActionResult> Post(smlv smlv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.smlv.Add(smlv);
            await db.SaveChangesAsync();

            return Created(smlv);
        }

        // PATCH: odata/smlvs(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<smlv> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            smlv smlv = await db.smlv.FindAsync(key);
            if (smlv == null)
            {
                return NotFound();
            }

            patch.Patch(smlv);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!smlvExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(smlv);
        }

        // DELETE: odata/smlvs(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            smlv smlv = await db.smlv.FindAsync(key);
            if (smlv == null)
            {
                return NotFound();
            }

            db.smlv.Remove(smlv);
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

        private bool smlvExists(int key)
        {
            return db.smlv.Count(e => e.Idsmlv == key) > 0;
        }
    }
}
