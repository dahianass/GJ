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
using System.Web.Http.Description;
using GestionJuridica.Models;
using GestionJuridica.Dto;

namespace GestionJuridica.Controllers
{
    public class PdtesReporteController : ApiController
    {
        private ModelJuridica db = new ModelJuridica();

        // GET: api/PdtesReporte
        public List<PdtesDto> GetPdtes()
        {
            var objResult = (from actividad in db.Pdtes
                             join formulario in db.Formulario on actividad.IdFormulario equals formulario.IdFormulario
                             join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                             join Contrato in db.Contratos on proyecto.IdContratos equals Contrato.IdContrato
                             join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                             where actividad.FechaRecordatorio > DateTime.Now
                             select new PdtesDto
                             {
                                 NombreCliente = formulario.Demandado,
                                 Contrato = Contrato.Contrato,
                                 Proyecto = proyecto.NombreProyecto,
                                 Cproceso = formulario.CodProceso,
                                 MunicipioP = municipioP.Nombre,
                                 JuzgadoF = formulario.JuzgadoConocimiento,
                                 Radicado = formulario.Radicado,
                                 Demandante = formulario.Demandante,
                                 Demandado = formulario.Demandado,
                                 Estadoprocesal = (from Ef in db.EstadosFormulario
                                                   join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstadoProcesal equals EstadosProcesalesF.IdEstados
                                                   where Ef.IdEstadoFormulario == formulario.IdFormulario
                                                   orderby Ef.FechaCumplimiento
                                                   select EstadosProcesalesF.Nombre).FirstOrDefault(),
                                 Fechapendiente = actividad.FechaRecordatorio,
                                 IdFormulario = actividad.IdFormulario,
                                 Actividad = actividad.Actividad,
                                 Observacion = actividad.Observacion
                             });

            return objResult.ToList();
        }

        // GET: api/PdtesReporte/5
        [ResponseType(typeof(Pdtes))]
        public IHttpActionResult GetPdtes(int id)
        {
            Pdtes pdtes = db.Pdtes.Find(id);
            if (pdtes == null)
            {
                return NotFound();
            }

            return Ok(pdtes);
        }

        // PUT: api/PdtesReporte/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPdtes(int id, Pdtes pdtes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pdtes.IdPdte)
            {
                return BadRequest();
            }

            db.Entry(pdtes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdtesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PdtesReporte
        [ResponseType(typeof(Pdtes))]
        public async Task<IHttpActionResult> PostPdtes(Pdtes pdtes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pdtes.Add(pdtes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pdtes.IdPdte }, pdtes);
        }

        // DELETE: api/PdtesReporte/5
        [ResponseType(typeof(Pdtes))]
        public async Task<IHttpActionResult> DeletePdtes(int id)
        {
            Pdtes pdtes = await db.Pdtes.FindAsync(id);
            if (pdtes == null)
            {
                return NotFound();
            }

            db.Pdtes.Remove(pdtes);
            await db.SaveChangesAsync();

            return Ok(pdtes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PdtesExists(int id)
        {
            return db.Pdtes.Count(e => e.IdPdte == id) > 0;
        }
    }
}