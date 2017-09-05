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
    builder.EntitySet<ChequeoFormulario>("ChequeoFormularios");
    builder.EntitySet<EstadosFormulario>("EstadosFormulario"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ChequeoFormulariosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/ChequeoFormularios
        [EnableQuery]
        public IQueryable<ChequeoFormulario> GetChequeoFormularios()
        {
            return db.ChequeoFormulario;
        }

        // GET: odata/ChequeoFormularios(5)
        [EnableQuery]
        public SingleResult<ChequeoFormulario> GetChequeoFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.ChequeoFormulario.Where(chequeoFormulario => chequeoFormulario.IdCheqeoF == key));
        }

        // PUT: odata/ChequeoFormularios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ChequeoFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChequeoFormulario chequeoFormulario = await db.ChequeoFormulario.FindAsync(key);
            if (chequeoFormulario == null)
            {
                return NotFound();
            }

            patch.Put(chequeoFormulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeoFormulario);
        }

        // POST: odata/ChequeoFormularios
        public async Task<IHttpActionResult> Post(ChequeoFormulario chequeoFormulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChequeoFormulario.Add(chequeoFormulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChequeoFormularioExists(chequeoFormulario.IdCheqeoF))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(chequeoFormulario);
        }

        // PATCH: odata/ChequeoFormularios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ChequeoFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChequeoFormulario chequeoFormulario = await db.ChequeoFormulario.FindAsync(key);
            if (chequeoFormulario == null)
            {
                return NotFound();
            }

            patch.Patch(chequeoFormulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeoFormulario);
        }

        // DELETE: odata/ChequeoFormularios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ChequeoFormulario chequeoFormulario = await db.ChequeoFormulario.FindAsync(key);
            if (chequeoFormulario == null)
            {
                return NotFound();
            }

            db.ChequeoFormulario.Remove(chequeoFormulario);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ChequeoFormularios(5)/EstadosFormulario
        [EnableQuery]
        public SingleResult<EstadosFormulario> GetEstadosFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.ChequeoFormulario.Where(m => m.IdCheqeoF == key).Select(m => m.EstadosFormulario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChequeoFormularioExists(int key)
        {
            return db.ChequeoFormulario.Count(e => e.IdCheqeoF == key) > 0;
        }
    }
}
