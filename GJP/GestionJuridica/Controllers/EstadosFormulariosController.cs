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
using GestionJuridica.Utilities;

namespace GestionJuridica.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using GestionJuridica.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EstadosFormulario>("EstadosFormularios");
    builder.EntitySet<ChequeoFormulario>("ChequeoFormulario"); 
    builder.EntitySet<Formulario>("Formulario"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EstadosFormulariosController : ODataController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: odata/EstadosFormularios
        [EnableQuery]
        public IQueryable<EstadosFormulario> GetEstadosFormularios()
        {
            return db.EstadosFormulario;
        }

        // GET: odata/EstadosFormularios(5)
        [EnableQuery]
        public SingleResult<EstadosFormulario> GetEstadosFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.EstadosFormulario.Where(estadosFormulario => estadosFormulario.IdEstadoFormulario == key));
        }

        // PUT: odata/EstadosFormularios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<EstadosFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadosFormulario estadosFormulario = await db.EstadosFormulario.FindAsync(key);
            if (estadosFormulario == null)
            {
                return NotFound();
            }

            patch.Put(estadosFormulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estadosFormulario);
        }

        // POST: odata/EstadosFormularios
        public async Task<IHttpActionResult> Post(EstadosFormulario estadosFormulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadosFormulario.Add(estadosFormulario);
            await db.SaveChangesAsync();

            var subject = (from form in db.Formulario
                           where form.IdFormulario == estadosFormulario.IdFormulario
                           select form.CodProceso).FirstOrDefault();
            subject += " - " + (from Ep in db.EstadosProcesales
                                where Ep.IdEstados == estadosFormulario.IdEstados
                                select Ep.Nombre).FirstOrDefault();

            var correos = (from users in db.user
                           join rols in db.Rol on users.IdRol equals rols.IdRol
                           where (rols.IdRol == 2 || rols.IdRol == 1)
                           select users.email).ToList();

            CreateAppointment.Create(correos, subject, estadosFormulario.Obsevacion, estadosFormulario.FechaCumplimiento);

            return Created(estadosFormulario);
        }

        // PATCH: odata/EstadosFormularios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<EstadosFormulario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EstadosFormulario estadosFormulario = await db.EstadosFormulario.FindAsync(key);
            if (estadosFormulario == null)
            {
                return NotFound();
            }

            patch.Patch(estadosFormulario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosFormularioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estadosFormulario);
        }

        // DELETE: odata/EstadosFormularios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            EstadosFormulario estadosFormulario = await db.EstadosFormulario.FindAsync(key);
            if (estadosFormulario == null)
            {
                return NotFound();
            }

            db.EstadosFormulario.Remove(estadosFormulario);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// GET: odata/EstadosFormularios(5)/ChequeoFormulario
        //[EnableQuery]
        //public IQueryable<ChequeoFormulario> GetChequeoFormulario([FromODataUri] int key)
        //{
        //    return db.EstadosFormulario.Where(m => m.IdEstadoFormulario == key).SelectMany(m => m.ChequeoFormulario);
        //}

        // GET: odata/EstadosFormularios(5)/Formulario
        [EnableQuery]
        public SingleResult<Formulario> GetFormulario([FromODataUri] int key)
        {
            return SingleResult.Create(db.EstadosFormulario.Where(m => m.IdEstadoFormulario == key).Select(m => m.Formulario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadosFormularioExists(int key)
        {
            return db.EstadosFormulario.Count(e => e.IdEstadoFormulario == key) > 0;
        }
    }
}
