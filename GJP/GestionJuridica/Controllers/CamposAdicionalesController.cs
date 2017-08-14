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
    builder.EntitySet<CamposAdicionales>("CamposAdicionales");
    builder.EntitySet<CamposTipos>("CamposTipos"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CamposAdicionalesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/CamposAdicionales
        [EnableQuery]
        public IQueryable<CamposAdicionales> GetCamposAdicionales()
        {
            return db.CamposAdicionales;
        }

        // GET: odata/CamposAdicionales(5)
        [EnableQuery]
        public SingleResult<CamposAdicionales> GetCamposAdicionales([FromODataUri] int key)
        {
            return SingleResult.Create(db.CamposAdicionales.Where(camposAdicionales => camposAdicionales.IdCampos == key));
        }

        // PUT: odata/CamposAdicionales(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CamposAdicionales> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CamposAdicionales camposAdicionales = await db.CamposAdicionales.FindAsync(key);
            if (camposAdicionales == null)
            {
                return NotFound();
            }

            patch.Put(camposAdicionales);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamposAdicionalesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(camposAdicionales);
        }

        // POST: odata/CamposAdicionales
        public async Task<IHttpActionResult> Post(CamposAdicionales camposAdicionales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CamposAdicionales.Add(camposAdicionales);
            await db.SaveChangesAsync();

            return Created(camposAdicionales);
        }

        // PATCH: odata/CamposAdicionales(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CamposAdicionales> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CamposAdicionales camposAdicionales = await db.CamposAdicionales.FindAsync(key);
            if (camposAdicionales == null)
            {
                return NotFound();
            }

            patch.Patch(camposAdicionales);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamposAdicionalesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(camposAdicionales);
        }

        // DELETE: odata/CamposAdicionales(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CamposAdicionales camposAdicionales = await db.CamposAdicionales.FindAsync(key);
            if (camposAdicionales == null)
            {
                return NotFound();
            }

            db.CamposAdicionales.Remove(camposAdicionales);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CamposAdicionales(5)/CamposTipos
        [EnableQuery]
        public IQueryable<CamposTipos> GetCamposTipos([FromODataUri] int key)
        {
            return db.CamposAdicionales.Where(m => m.IdCampos == key).SelectMany(m => m.CamposTipos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CamposAdicionalesExists(int key)
        {
            return db.CamposAdicionales.Count(e => e.IdCampos == key) > 0;
        }
    }
}
