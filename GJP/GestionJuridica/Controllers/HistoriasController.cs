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
    builder.EntitySet<Historia>("Historias");
    builder.EntitySet<Formulario>("Formulario"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class HistoriasController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Historias
        [EnableQuery]
        public IQueryable<Historia> GetHistorias()
        {
            return db.Historia;
        }

        // GET: odata/Historias(5)
        [EnableQuery]
        public SingleResult<Historia> GetHistoria([FromODataUri] int key)
        {
            return SingleResult.Create(db.Historia.Where(historia => historia.IdHistoria == key));
        }

        // PUT: odata/Historias(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Historia> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Historia historia = db.Historia.Find(key);
            if (historia == null)
            {
                return NotFound();
            }

            patch.Put(historia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historia);
        }

        // POST: odata/Historias
        public IHttpActionResult Post(Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Historia.Add(historia);
            db.SaveChanges();

            return Created(historia);
        }

        // PATCH: odata/Historias(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Historia> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Historia historia = db.Historia.Find(key);
            if (historia == null)
            {
                return NotFound();
            }

            patch.Patch(historia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historia);
        }

        // DELETE: odata/Historias(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Historia historia = db.Historia.Find(key);
            if (historia == null)
            {
                return NotFound();
            }

            db.Historia.Remove(historia);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Historias(5)/Formulario
        [EnableQuery]
        public SingleResult<Formulario> GetFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Historia.Where(m => m.IdHistoria == key).Select(m => m.Formulario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoriaExists(int key)
        {
            return db.Historia.Count(e => e.IdHistoria == key) > 0;
        }
    }
}
