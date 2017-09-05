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
    builder.EntitySet<Formulario>("Formularios");
    builder.EntitySet<EstadosFormulario>("EstadosFormulario"); 
    builder.EntitySet<Historia>("Historia"); 
    builder.EntitySet<Municipio>("Municipio"); 
    builder.EntitySet<Pdtes>("Pdtes"); 
    builder.EntitySet<Proyectos>("Proyectos"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class FormulariosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/Formularios
        [EnableQuery]
        public IQueryable<Formulario> GetFormularios()
        {
            return db.Formulario;
        }

        // GET: odata/Formularios(5)
        [EnableQuery]
        public SingleResult<Formulario> GetFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Formulario.Where(formulario => formulario.IdFormulario == key));
        }

        // PUT: odata/Formularios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Formulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Formulario formulario = await db.Formulario.FindAsync(key);
            if (formulario == null)
            {
                return NotFound();
            }

            patch.Put(formulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(formulario);
        }

        // POST: odata/Formularios
        public async Task<IHttpActionResult> Post(Formulario formulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Formulario.Add(formulario);
            await db.SaveChangesAsync();

            return Created(formulario);
        }

        // PATCH: odata/Formularios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Formulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Formulario formulario = await db.Formulario.FindAsync(key);
            if (formulario == null)
            {
                return NotFound();
            }

            patch.Patch(formulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(formulario);
        }

        // DELETE: odata/Formularios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Formulario formulario = await db.Formulario.FindAsync(key);
            if (formulario == null)
            {
                return NotFound();
            }

            db.Formulario.Remove(formulario);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Formularios(5)/EstadosFormulario
        [EnableQuery]
        public IQueryable<EstadosFormulario> GetEstadosFormulario([FromODataUri] int key)
        {
            return db.Formulario.Where(m => m.IdFormulario == key).SelectMany(m => m.EstadosFormulario);
        }

        // GET: odata/Formularios(5)/Historia
        [EnableQuery]
        public IQueryable<Historia> GetHistoria([FromODataUri] int key)
        {
            return db.Formulario.Where(m => m.IdFormulario == key).SelectMany(m => m.Historia);
        }

        // GET: odata/Formularios(5)/Municipio
        [EnableQuery]
        public SingleResult<Municipio> GetMunicipio([FromODataUri] int key)
        {
            return SingleResult.Create(db.Formulario.Where(m => m.IdFormulario == key).Select(m => m.Municipio));
        }

        // GET: odata/Formularios(5)/Pdtes
        [EnableQuery]
        public IQueryable<Pdtes> GetPdtes([FromODataUri] int key)
        {
            return db.Formulario.Where(m => m.IdFormulario == key).SelectMany(m => m.Pdtes);
        }

        // GET: odata/Formularios(5)/Proyectos
        [EnableQuery]
        public SingleResult<Proyectos> GetProyectos([FromODataUri] int key)
        {
            return SingleResult.Create(db.Formulario.Where(m => m.IdFormulario == key).Select(m => m.Proyectos));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormularioExists(int key)
        {
            return db.Formulario.Count(e => e.IdFormulario == key) > 0;
        }
    }
}
