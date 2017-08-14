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
    builder.EntitySet<Usuarios>("Usuarios");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UsuariosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Usuarios
        [EnableQuery]
        public IQueryable<Usuarios> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: odata/Usuarios(5)
        [EnableQuery]
        public SingleResult<Usuarios> GetUsuarios([FromODataUri] int key)
        {
            return SingleResult.Create(db.Usuarios.Where(usuarios => usuarios.IdUsuario == key));
        }

        // PUT: odata/Usuarios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Usuarios> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuarios usuarios = await db.Usuarios.FindAsync(key);
            if (usuarios == null)
            {
                return NotFound();
            }

            patch.Put(usuarios);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(usuarios);
        }

        // POST: odata/Usuarios
        public async Task<IHttpActionResult> Post(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuarios);
            await db.SaveChangesAsync();

            return Created(usuarios);
        }

        // PATCH: odata/Usuarios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Usuarios> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuarios usuarios = await db.Usuarios.FindAsync(key);
            if (usuarios == null)
            {
                return NotFound();
            }

            patch.Patch(usuarios);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(usuarios);
        }

        // DELETE: odata/Usuarios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Usuarios usuarios = await db.Usuarios.FindAsync(key);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
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

        private bool UsuariosExists(int key)
        {
            return db.Usuarios.Count(e => e.IdUsuario == key) > 0;
        }
    }
}
