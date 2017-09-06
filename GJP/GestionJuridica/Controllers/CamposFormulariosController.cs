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
    builder.EntitySet<CamposFormulario>("CamposFormularios");
    builder.EntitySet<CamposAdicionales>("CamposAdicionales"); 
    builder.EntitySet<Formulario>("Formulario"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CamposFormulariosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/CamposFormularios
        [EnableQuery]
        public IQueryable<CamposFormulario> GetCamposFormularios()
        {
            return db.CamposFormulario;
        }

        // GET: odata/CamposFormularios(5)
        [EnableQuery]
        public SingleResult<CamposFormulario> GetCamposFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.CamposFormulario.Where(camposFormulario => camposFormulario.IdCamposFormulario == key));
        }

        // PUT: odata/CamposFormularios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CamposFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CamposFormulario camposFormulario = await db.CamposFormulario.FindAsync(key);
            if (camposFormulario == null)
            {
                return NotFound();
            }

            patch.Put(camposFormulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamposFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(camposFormulario);
        }

        // POST: odata/CamposFormularios
        public async Task<IHttpActionResult> Post(CamposFormulario camposFormulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CamposFormulario.Add(camposFormulario);
            await db.SaveChangesAsync();

            return Created(camposFormulario);
        }

        // PATCH: odata/CamposFormularios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CamposFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CamposFormulario camposFormulario = await db.CamposFormulario.FindAsync(key);
            if (camposFormulario == null)
            {
                return NotFound();
            }

            patch.Patch(camposFormulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamposFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(camposFormulario);
        }

        // DELETE: odata/CamposFormularios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CamposFormulario camposFormulario = await db.CamposFormulario.FindAsync(key);
            if (camposFormulario == null)
            {
                return NotFound();
            }

            db.CamposFormulario.Remove(camposFormulario);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CamposFormularios(5)/CamposAdicionales
        [EnableQuery]
        public SingleResult<CamposAdicionales> GetCamposAdicionales([FromODataUri] int key)
        {
            return SingleResult.Create(db.CamposFormulario.Where(m => m.IdCamposFormulario == key).Select(m => m.CamposAdicionales));
        }

        // GET: odata/CamposFormularios(5)/Formulario
        [EnableQuery]
        public SingleResult<Formulario> GetFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.CamposFormulario.Where(m => m.IdCamposFormulario == key).Select(m => m.Formulario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CamposFormularioExists(int key)
        {
            return db.CamposFormulario.Count(e => e.IdCamposFormulario == key) > 0;
        }
    }
}
