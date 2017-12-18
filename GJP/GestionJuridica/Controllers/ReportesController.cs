using GestionJuridica.Dto;
using GestionJuridica.Models;
using GestionJuridica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionJuridica.Controllers
{
    public class ReportesController : Controller
    {
        private ModelJuridica db = new ModelJuridica();
        // GET: Reportes
        public JsonResult GetPdtes()
        {
            var objResult = from actividad in db.Pdtes
                             join formulario in db.Formulario on actividad.IdFormulario equals formulario.IdFormulario
                             join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                             join contrato in db.Contratos on proyecto.IdContratos equals contrato.IdContrato
                             join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                             where actividad.FechaRecordatorio > DateTime.Now
                             select new PdtesDto
                             {
                                 NombreCliente = formulario.Demandado,
                                 Contrato = contrato.CodContrato,
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
                             };

            var objResuldt = objResult.ToList();
            return Json(objResuldt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult todosProcesos()
        {
            var objResult = from actividad in db.Pdtes
                            join formulario in db.Formulario on actividad.IdFormulario equals formulario.IdFormulario
                            join Tproceso in db.TipoProcesos on formulario.IdTIpoProceso equals Tproceso.IdTiposProcesos
                            join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                            join contrato in db.Contratos on proyecto.IdContratos equals contrato.IdContrato
                            join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                            join person in db.Personas  on formulario.Responsable equals person.IdPersona
                            select new procesosDto
                            {
                                NombreCliente = formulario.Demandado,
                                Contrato = contrato.CodContrato,
                                Proyecto = proyecto.NombreProyecto,
                                Cproceso = formulario.CodProceso,
                                MunicipioP = municipioP.Nombre,
                                JuzgadoF = formulario.JuzgadoConocimiento,
                                Radicado = formulario.Radicado,
                                Demandante = formulario.Demandante,
                                Demandado = formulario.Demandado,
                                tipoProceso = Tproceso.Nombre,
                                Estadoprocesal = (from Ef in db.EstadosFormulario
                                                  join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstadoProcesal equals EstadosProcesalesF.IdEstados
                                                  where Ef.IdEstadoFormulario == formulario.IdFormulario
                                                  orderby Ef.FechaCumplimiento
                                                  select EstadosProcesalesF.Nombre).FirstOrDefault(),
                                Responsable = person.Nombre,
                                IdFormulario = actividad.IdFormulario,
                       
                            };

            var objResuldt = objResult.ToList();
            return Json(objResuldt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult todosProcesosXResponsable(int responsable)
        {
            var objResult = from actividad in db.Pdtes
                            join formulario in db.Formulario on actividad.IdFormulario equals formulario.IdFormulario
                            join Tproceso in db.TipoProcesos on formulario.IdTIpoProceso equals Tproceso.IdTiposProcesos
                            join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                            join contrato in db.Contratos on proyecto.IdContratos equals contrato.IdContrato
                            join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                            join person in db.Personas on formulario.Responsable equals person.IdPersona
                            join per in db.Personas on formulario.Responsable equals per.IdPersona
                            where formulario.Responsable == responsable
                            select new procesosDto
                            {
                                NombreCliente = formulario.Demandado,
                                Contrato = contrato.CodContrato,
                                Proyecto = proyecto.NombreProyecto,
                                Cproceso = formulario.CodProceso,
                                MunicipioP = municipioP.Nombre,
                                JuzgadoF = formulario.JuzgadoConocimiento,
                                Radicado = formulario.Radicado,
                                Demandante = formulario.Demandante,
                                Demandado = formulario.Demandado,
                                tipoProceso = Tproceso.Nombre,
                                Estadoprocesal = (from Ef in db.EstadosFormulario
                                                  join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstadoProcesal equals EstadosProcesalesF.IdEstados
                                                  where Ef.IdEstadoFormulario == formulario.IdFormulario
                                                  orderby Ef.FechaCumplimiento
                                                  select EstadosProcesalesF.Nombre).FirstOrDefault(),
                                Responsable = person.Nombre,
                                ResponsableSucesor = per.Nombre,
                                IdFormulario = actividad.IdFormulario,

                            };

            var objResuldt = objResult.ToList();
            return Json(objResuldt, JsonRequestBehavior.AllowGet);
        }
    }
}


