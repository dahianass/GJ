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
    builder.EntitySet<Naturaleza>("Naturalezas");
    builder.EntitySet<Juzgado>("Juzgado"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class NaturalezasController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Naturalezas
        [EnableQuery]
        public IQueryable<Naturaleza> GetNaturalezas()
        {
            return db.Naturaleza;
        }

        // GET: odata/Naturalezas(5)
        [EnableQuery]
        public SingleResult<Naturaleza> GetNaturaleza([FromODataUri] int key)
        {
            return SingleResult.Create(db.Naturaleza.Where(naturaleza => naturaleza.IdNaturaleza == key));
        }

        // PUT: odata/Naturalezas(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Naturaleza> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Naturaleza naturaleza = await db.Naturaleza.FindAsync(key);
            if (naturaleza == null)
            {
                return NotFound();
            }

            patch.Put(naturaleza);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaturalezaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(naturaleza);
        }

        // POST: odata/Naturalezas
        public async Task<IHttpActionResult> Post(Naturaleza naturaleza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Naturaleza.Add(naturaleza);
            await db.SaveChangesAsync();

            return Created(naturaleza);
        }

        // PATCH: odata/Naturalezas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Naturaleza> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Naturaleza naturaleza = await db.Naturaleza.FindAsync(key);
            if (naturaleza == null)
            {
                return NotFound();
            }

            patch.Patch(naturaleza);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaturalezaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(naturaleza);
        }

        // DELETE: odata/Naturalezas(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Naturaleza naturaleza = await db.Naturaleza.FindAsync(key);
            if (naturaleza == null)
            {
                return NotFound();
            }

            db.Naturaleza.Remove(naturaleza);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// GET: odata/Naturalezas(5)/Juzgado
        //[EnableQuery]
        //public IQueryable<Juzgado> GetJuzgado([FromODataUri] int key)
        //{
        //    return db.Naturaleza.Where(m => m.IdNaturaleza == key).SelectMany(m => m.Juzgado);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NaturalezaExists(int key)
        {
            return db.Naturaleza.Count(e => e.IdNaturaleza == key) > 0;
        }
    }
}
