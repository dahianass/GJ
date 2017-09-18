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
    builder.EntitySet<Pdtes>("PdtesActividades");
    builder.EntitySet<EstadosFormulario>("EstadosFormulario"); 
    builder.EntitySet<Formulario>("Formulario"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PdtesActividadesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/PdtesActividades
        [EnableQuery]
        public IQueryable<Pdtes> GetPdtesActividades()
        {
            return db.Pdtes;
        }

        // GET: odata/PdtesActividades(5)
        [EnableQuery]
        public SingleResult<Pdtes> GetPdtes([FromODataUri] int key)
        {
            return SingleResult.Create(db.Pdtes.Where(pdtes => pdtes.IdPdte == key));
        }

        // PUT: odata/PdtesActividades(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Pdtes> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pdtes pdtes = await db.Pdtes.FindAsync(key);
            if (pdtes == null)
            {
                return NotFound();
            }

            patch.Put(pdtes);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdtesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pdtes);
        }

        // POST: odata/PdtesActividades
        public async Task<IHttpActionResult> Post(Pdtes pdtes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pdtes.Add(pdtes);
            await db.SaveChangesAsync();

            return Created(pdtes);
        }

        // PATCH: odata/PdtesActividades(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Pdtes> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pdtes pdtes = await db.Pdtes.FindAsync(key);
            if (pdtes == null)
            {
                return NotFound();
            }

            patch.Patch(pdtes);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdtesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pdtes);
        }

        // DELETE: odata/PdtesActividades(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Pdtes pdtes = await db.Pdtes.FindAsync(key);
            if (pdtes == null)
            {
                return NotFound();
            }

            db.Pdtes.Remove(pdtes);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/PdtesActividades(5)/EstadosFormulario
        [EnableQuery]
        public SingleResult<EstadosFormulario> GetEstadosFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Pdtes.Where(m => m.IdPdte == key).Select(m => m.EstadosFormulario));
        }

        // GET: odata/PdtesActividades(5)/Formulario
        [EnableQuery]
        public SingleResult<Formulario> GetFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Pdtes.Where(m => m.IdPdte == key).Select(m => m.Formulario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PdtesExists(int key)
        {
            return db.Pdtes.Count(e => e.IdPdte == key) > 0;
        }
    }
}
