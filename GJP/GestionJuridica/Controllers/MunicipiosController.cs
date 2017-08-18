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
    builder.EntitySet<Municipio>("Municipios");
    builder.EntitySet<Circuito>("Circuito"); 
    builder.EntitySet<Juzgado>("Juzgado"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MunicipiosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Municipios
        [EnableQuery]
        public IQueryable<Municipio> GetMunicipios()
        {
            return db.Municipio;
        }

        // GET: odata/Municipios(5)
        [EnableQuery]
        public SingleResult<Municipio> GetMunicipio([FromODataUri] int key)
        {
            return SingleResult.Create(db.Municipio.Where(municipio => municipio.IdMunicipio == key));
        }

        // PUT: odata/Municipios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Municipio> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Municipio municipio = await db.Municipio.FindAsync(key);
            if (municipio == null)
            {
                return NotFound();
            }

            patch.Put(municipio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(municipio);
        }

        // POST: odata/Municipios
        public async Task<IHttpActionResult> Post(Municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Municipio.Add(municipio);
            await db.SaveChangesAsync();

            return Created(municipio);
        }

        // PATCH: odata/Municipios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Municipio> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Municipio municipio = await db.Municipio.FindAsync(key);
            if (municipio == null)
            {
                return NotFound();
            }

            patch.Patch(municipio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(municipio);
        }

        // DELETE: odata/Municipios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Municipio municipio = await db.Municipio.FindAsync(key);
            if (municipio == null)
            {
                return NotFound();
            }

            db.Municipio.Remove(municipio);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Municipios(5)/Circuito
        [EnableQuery]
        public SingleResult<Circuito> GetCircuito([FromODataUri] int key)
        {
            return SingleResult.Create(db.Municipio.Where(m => m.IdMunicipio == key).Select(m => m.Circuito));
        }

        // GET: odata/Municipios(5)/Juzgado
        [EnableQuery]
        public IQueryable<Juzgado> GetJuzgado([FromODataUri] int key)
        {
            return db.Municipio.Where(m => m.IdMunicipio == key).SelectMany(m => m.Juzgado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MunicipioExists(int key)
        {
            return db.Municipio.Count(e => e.IdMunicipio == key) > 0;
        }
    }
}
