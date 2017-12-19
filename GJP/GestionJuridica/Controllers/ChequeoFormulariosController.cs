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
    builder.EntitySet<ChequeoFormulario>("ChequeoFormularios");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ChequeoFormulariosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/ChequeoFormularios
        [EnableQuery]
        public IQueryable<ChequeoFormulario> GetChequeoFormularios()
        {
            return db.ChequeoFormulario;
        }

        // GET: odata/ChequeoFormularios(5)
        [EnableQuery]
        public SingleResult<ChequeoFormulario> GetChequeoFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.ChequeoFormulario.Where(chequeoFormulario => chequeoFormulario.IdCheqeoF == key));
        }

        // PUT: odata/ChequeoFormularios(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ChequeoFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChequeoFormulario chequeoFormulario = db.ChequeoFormulario.Find(key);
            if (chequeoFormulario == null)
            {
                return NotFound();
            }

            patch.Put(chequeoFormulario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeoFormulario);
        }

        // POST: odata/ChequeoFormularios
        public IHttpActionResult Post(ChequeoFormulario chequeoFormulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChequeoFormulario.Add(chequeoFormulario);
            db.SaveChanges();

            return Created(chequeoFormulario);
        }

        // PATCH: odata/ChequeoFormularios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ChequeoFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChequeoFormulario chequeoFormulario = db.ChequeoFormulario.Find(key);
            if (chequeoFormulario == null)
            {
                return NotFound();
            }

            patch.Patch(chequeoFormulario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeoFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chequeoFormulario);
        }

        // DELETE: odata/ChequeoFormularios(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ChequeoFormulario chequeoFormulario = db.ChequeoFormulario.Find(key);
            if (chequeoFormulario == null)
            {
                return NotFound();
            }

            db.ChequeoFormulario.Remove(chequeoFormulario);
            db.SaveChanges();

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

        private bool ChequeoFormularioExists(int key)
        {
            return db.ChequeoFormulario.Count(e => e.IdCheqeoF == key) > 0;
        }
    }
}
