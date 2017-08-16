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
    builder.EntitySet<Rol>("Rols");
    builder.EntitySet<Permisos>("Permisos"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RolsController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Rols
        [EnableQuery]
        public IQueryable<Rol> GetRols()
        {
            return db.Rol;
        }

        // GET: odata/Rols(5)
        [EnableQuery]
        public SingleResult<Rol> GetRol([FromODataUri] int key)
        {
            return SingleResult.Create(db.Rol.Where(rol => rol.IdRol == key));
        }

        // PUT: odata/Rols(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Rol> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rol rol = await db.Rol.FindAsync(key);
            if (rol == null)
            {
                return NotFound();
            }

            patch.Put(rol);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(rol);
        }

        // POST: odata/Rols
        public async Task<IHttpActionResult> Post(Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rol.Add(rol);
            await db.SaveChangesAsync();

            return Created(rol);
        }

        // PATCH: odata/Rols(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Rol> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rol rol = await db.Rol.FindAsync(key);
            if (rol == null)
            {
                return NotFound();
            }

            patch.Patch(rol);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(rol);
        }

        // DELETE: odata/Rols(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Rol rol = await db.Rol.FindAsync(key);
            if (rol == null)
            {
                return NotFound();
            }

            db.Rol.Remove(rol);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Rols(5)/Permisos
        [EnableQuery]
        public IQueryable<Permisos> GetPermisos([FromODataUri] int key)
        {
            return db.Rol.Where(m => m.IdRol == key).SelectMany(m => m.Permisos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolExists(int key)
        {
            return db.Rol.Count(e => e.IdRol == key) > 0;
        }
    }
}
