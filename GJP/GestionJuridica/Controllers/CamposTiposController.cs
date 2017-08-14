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
    builder.EntitySet<CamposTipos>("CamposTipos");
    builder.EntitySet<CamposAdicionales>("CamposAdicionales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CamposTiposController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/CamposTipos
        [EnableQuery]
        public IQueryable<CamposTipos> GetCamposTipos()
        {
            return db.CamposTipos;
        }

        // GET: odata/CamposTipos(5)
        [EnableQuery]
        public SingleResult<CamposTipos> GetCamposTipos([FromODataUri] int key)
        {
            return SingleResult.Create(db.CamposTipos.Where(camposTipos => camposTipos.IdCamposTipos == key));
        }

        // PUT: odata/CamposTipos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CamposTipos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CamposTipos camposTipos = await db.CamposTipos.FindAsync(key);
            if (camposTipos == null)
            {
                return NotFound();
            }

            patch.Put(camposTipos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamposTiposExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(camposTipos);
        }

        // POST: odata/CamposTipos
        public async Task<IHttpActionResult> Post(CamposTipos camposTipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CamposTipos.Add(camposTipos);
            await db.SaveChangesAsync();

            return Created(camposTipos);
        }

        // PATCH: odata/CamposTipos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CamposTipos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CamposTipos camposTipos = await db.CamposTipos.FindAsync(key);
            if (camposTipos == null)
            {
                return NotFound();
            }

            patch.Patch(camposTipos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamposTiposExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(camposTipos);
        }

        // DELETE: odata/CamposTipos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CamposTipos camposTipos = await db.CamposTipos.FindAsync(key);
            if (camposTipos == null)
            {
                return NotFound();
            }

            db.CamposTipos.Remove(camposTipos);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CamposTipos(5)/CamposAdicionales
        [EnableQuery]
        public SingleResult<CamposAdicionales> GetCamposAdicionales([FromODataUri] int key)
        {
            return SingleResult.Create(db.CamposTipos.Where(m => m.IdCamposTipos == key).Select(m => m.CamposAdicionales));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CamposTiposExists(int key)
        {
            return db.CamposTipos.Count(e => e.IdCamposTipos == key) > 0;
        }
    }
}
