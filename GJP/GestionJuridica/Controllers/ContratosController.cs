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
    builder.EntitySet<Contratos>("Contratos");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ContratosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Contratos
        [EnableQuery]
        public IQueryable<Contratos> GetContratos()
        {
            return db.Contratos;
        }

        // GET: odata/Contratos(5)
        [EnableQuery]
        public SingleResult<Contratos> GetContratos([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contratos.Where(contratos => contratos.IdContrato == key));
        }

        // PUT: odata/Contratos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Contratos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contratos contratos = await db.Contratos.FindAsync(key);
            if (contratos == null)
            {
                return NotFound();
            }

            patch.Put(contratos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contratos);
        }

        // POST: odata/Contratos
        public async Task<IHttpActionResult> Post(Contratos contratos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contratos.Add(contratos);
            await db.SaveChangesAsync();

            return Created(contratos);
        }

        // PATCH: odata/Contratos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Contratos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contratos contratos = await db.Contratos.FindAsync(key);
            if (contratos == null)
            {
                return NotFound();
            }

            patch.Patch(contratos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contratos);
        }

        // DELETE: odata/Contratos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Contratos contratos = await db.Contratos.FindAsync(key);
            if (contratos == null)
            {
                return NotFound();
            }

            db.Contratos.Remove(contratos);
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

        private bool ContratosExists(int key)
        {
            return db.Contratos.Count(e => e.IdContrato == key) > 0;
        }
    }
}
