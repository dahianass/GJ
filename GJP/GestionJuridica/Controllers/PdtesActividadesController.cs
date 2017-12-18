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
    builder.EntitySet<Pdtes>("PdtesActividades");
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
        public IHttpActionResult Put([FromODataUri] int key, Delta<Pdtes> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pdtes pdtes = db.Pdtes.Find(key);
            if (pdtes == null)
            {
                return NotFound();
            }

            patch.Put(pdtes);

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult Post(Pdtes pdtes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pdtes.Add(pdtes);
            db.SaveChanges();

            return Created(pdtes);
        }

        // PATCH: odata/PdtesActividades(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Pdtes> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pdtes pdtes = db.Pdtes.Find(key);
            if (pdtes == null)
            {
                return NotFound();
            }

            patch.Patch(pdtes);

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Pdtes pdtes = db.Pdtes.Find(key);
            if (pdtes == null)
            {
                return NotFound();
            }

            db.Pdtes.Remove(pdtes);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
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
