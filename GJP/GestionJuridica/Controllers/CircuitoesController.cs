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
    builder.EntitySet<Circuito>("Circuitoes");
    builder.EntitySet<Distrito>("Distrito"); 
    builder.EntitySet<Municipio>("Municipio"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CircuitoesController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Circuitoes
        [EnableQuery]
        public IQueryable<Circuito> GetCircuitoes()
        {
            return db.Circuito;
        }

        // GET: odata/Circuitoes(5)
        [EnableQuery]
        public SingleResult<Circuito> GetCircuito([FromODataUri] int key)
        {
            return SingleResult.Create(db.Circuito.Where(circuito => circuito.IdCircuito == key));
        }

        // PUT: odata/Circuitoes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Circuito> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Circuito circuito = await db.Circuito.FindAsync(key);
            if (circuito == null)
            {
                return NotFound();
            }

            patch.Put(circuito);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircuitoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(circuito);
        }

        // POST: odata/Circuitoes
        public async Task<IHttpActionResult> Post(Circuito circuito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Circuito.Add(circuito);
            await db.SaveChangesAsync();

            return Created(circuito);
        }

        // PATCH: odata/Circuitoes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Circuito> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Circuito circuito = await db.Circuito.FindAsync(key);
            if (circuito == null)
            {
                return NotFound();
            }

            patch.Patch(circuito);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircuitoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(circuito);
        }

        // DELETE: odata/Circuitoes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Circuito circuito = await db.Circuito.FindAsync(key);
            if (circuito == null)
            {
                return NotFound();
            }

            db.Circuito.Remove(circuito);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Circuitoes(5)/Distrito
        [EnableQuery]
        public SingleResult<Distrito> GetDistrito([FromODataUri] int key)
        {
            return SingleResult.Create(db.Circuito.Where(m => m.IdCircuito == key).Select(m => m.Distrito));
        }

        // GET: odata/Circuitoes(5)/Municipio
        [EnableQuery]
        public IQueryable<Municipio> GetMunicipio([FromODataUri] int key)
        {
            return db.Circuito.Where(m => m.IdCircuito == key).SelectMany(m => m.Municipio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CircuitoExists(int key)
        {
            return db.Circuito.Count(e => e.IdCircuito == key) > 0;
        }
    }
}
