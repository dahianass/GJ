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
    builder.EntitySet<ChequeoTipo>("ChequeoTipoes");
    builder.EntitySet<Chequeo>("Chequeo"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ChequeoTipoesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/ChequeoTipoes
        [EnableQuery]
        public IQueryable<ChequeoTipo> GetChequeoTipoes()
        {
            return db.ChequeoTipo;
        }

        // GET: odata/ChequeoTipoes(5)
        [EnableQuery]
        public SingleResult<ChequeoTipo> GetChequeoTipo([FromODataUri] int key)
        {
            return SingleResult.Create(db.ChequeoTipo.Where(chequeoTipo => chequeoTipo.IdChequeoTipo == key));
        }

        // PUT: odata/ChequeoTipoes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ChequeoTipo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChequeoTipo chequeoTipo = await db.ChequeoTipo.FindAsync(key);
            if (chequeoTipo == null)
            {
                return NotFound();
            }

            patch.Put(chequeoTipo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoTipoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeoTipo);
        }

        // POST: odata/ChequeoTipoes
        public async Task<IHttpActionResult> Post(ChequeoTipo chequeoTipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChequeoTipo.Add(chequeoTipo);
            await db.SaveChangesAsync();

            return Created(chequeoTipo);
        }

        // PATCH: odata/ChequeoTipoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ChequeoTipo> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChequeoTipo chequeoTipo = await db.ChequeoTipo.FindAsync(key);
            if (chequeoTipo == null)
            {
                return NotFound();
            }

            patch.Patch(chequeoTipo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoTipoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeoTipo);
        }

        // DELETE: odata/ChequeoTipoes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ChequeoTipo chequeoTipo = await db.ChequeoTipo.FindAsync(key);
            if (chequeoTipo == null)
            {
                return NotFound();
            }

            db.ChequeoTipo.Remove(chequeoTipo);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ChequeoTipoes(5)/Chequeo
        [EnableQuery]
        public SingleResult<Chequeo> GetChequeo([FromODataUri] int key)
        {
            return SingleResult.Create(db.ChequeoTipo.Where(m => m.IdChequeoTipo == key).Select(m => m.Chequeo));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChequeoTipoExists(int key)
        {
            return db.ChequeoTipo.Count(e => e.IdChequeoTipo == key) > 0;
        }
    }
}
