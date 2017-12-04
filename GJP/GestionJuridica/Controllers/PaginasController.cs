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
    builder.EntitySet<Paginas>("Paginas");
    builder.EntitySet<Permisos>("Permisos"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PaginasController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Paginas
        [EnableQuery]
        public IQueryable<Paginas> GetPaginas()
        {
            return db.Paginas;
        }

        // GET: odata/Paginas(5)
        [EnableQuery]
        public SingleResult<Paginas> GetPaginas([FromODataUri] int key)
        {
            return SingleResult.Create(db.Paginas.Where(paginas => paginas.IdPagina == key));
        }

        // PUT: odata/Paginas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Paginas> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Paginas paginas = db.Paginas.Find(key);
            if (paginas == null)
            {
                return NotFound();
            }

            patch.Put(paginas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginasExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(paginas);
        }

        // POST: odata/Paginas
        public IHttpActionResult Post(Paginas paginas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paginas.Add(paginas);
            db.SaveChanges();

            return Created(paginas);
        }

        // PATCH: odata/Paginas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Paginas> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Paginas paginas = db.Paginas.Find(key);
            if (paginas == null)
            {
                return NotFound();
            }

            patch.Patch(paginas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginasExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(paginas);
        }

        // DELETE: odata/Paginas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Paginas paginas = db.Paginas.Find(key);
            if (paginas == null)
            {
                return NotFound();
            }

            db.Paginas.Remove(paginas);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Paginas(5)/Permisos
        [EnableQuery]
        public IQueryable<Permisos> GetPermisos([FromODataUri] int key)
        {
            return db.Paginas.Where(m => m.IdPagina == key).SelectMany(m => m.Permisos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaginasExists(int key)
        {
            return db.Paginas.Count(e => e.IdPagina == key) > 0;
        }
    }
}
