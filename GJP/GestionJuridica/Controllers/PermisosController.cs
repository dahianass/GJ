using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GestionJuridica.Models;

namespace GestionJuridica.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using GestionJuridica.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Permisos>("Permisos");
    builder.EntitySet<Paginas>("Paginas"); 
    builder.EntitySet<Rol>("Rol"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PermisosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Permisos
        [EnableQuery]
        public IQueryable<Permisos> GetPermisos()
        {
            return db.Permisos;
        }

        // GET: odata/Permisos(5)
        [EnableQuery]
        public SingleResult<Permisos> GetPermisos([FromODataUri] int key)
        {
            return SingleResult.Create(db.Permisos.Where(permisos => permisos.IdPermiso == key));
        }

        // PUT: odata/Permisos(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Permisos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permisos permisos = db.Permisos.Find(key);
            if (permisos == null)
            {
                return NotFound();
            }

            patch.Put(permisos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(permisos);
        }

        // POST: odata/Permisos
        public IHttpActionResult Post(Permisos permisos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Permisos.Add(permisos);
            db.SaveChanges();

            return Created(permisos);
        }

        // PATCH: odata/Permisos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Permisos> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permisos permisos = db.Permisos.Find(key);
            if (permisos == null)
            {
                return NotFound();
            }

            patch.Patch(permisos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(permisos);
        }

        // DELETE: odata/Permisos(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Permisos permisos = db.Permisos.Find(key);
            if (permisos == null)
            {
                return NotFound();
            }

            db.Permisos.Remove(permisos);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Permisos(5)/Paginas
        [EnableQuery]
        public SingleResult<Paginas> GetPaginas([FromODataUri] int key)
        {
            return SingleResult.Create(db.Permisos.Where(m => m.IdPermiso == key).Select(m => m.Paginas));
        }

        // GET: odata/Permisos(5)/Rol
        [EnableQuery]
        public SingleResult<Rol> GetRol([FromODataUri] int key)
        {
            return SingleResult.Create(db.Permisos.Where(m => m.IdPermiso == key).Select(m => m.Rol));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermisosExists(int key)
        {
            return db.Permisos.Count(e => e.IdPermiso == key) > 0;
        }
    }
}
