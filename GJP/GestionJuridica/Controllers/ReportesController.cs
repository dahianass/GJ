using GestionJuridica.Dto;
using GestionJuridica.ModelDto;
using GestionJuridica.Models;
using GestionJuridica.Utilities;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GestionJuridica.Controllers
{
    public class ReportesController : Controller
    {
        private ModelJuridica db = new ModelJuridica();
        
        [HttpPost]
        public JsonResult GetPdtes(UserRolDto userRol)
        {
            try
            {
                if (userRol.IdRol == 1)
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
                                                          join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstados equals EstadosProcesalesF.IdEstados
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
                else
                {
                    var objResult = from actividad in db.Pdtes
                                    join formulario in db.Formulario on actividad.IdFormulario equals formulario.IdFormulario
                                    join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                                    join contrato in db.Contratos on proyecto.IdContratos equals contrato.IdContrato
                                    join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                                    where actividad.FechaRecordatorio > DateTime.Now && formulario.Responsable == userRol.IdUser
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
                                                          join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstados equals EstadosProcesalesF.IdEstados
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

                
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        public JsonResult RPTodosProcesos()
        {
            try
            {
                var objResult = from formulario in db.Formulario
                                join Tproceso in db.TipoProcesos on formulario.IdTIpoProceso equals Tproceso.IdTiposProcesos
                                join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                                join contrato in db.Contratos on proyecto.IdContratos equals contrato.IdContrato
                                join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                                join person in db.user on formulario.Responsable equals person.id_user
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
                                    TipoProceso = Tproceso.Nombre,
                                    Estadoprocesal = (from Ef in db.EstadosFormulario
                                                      join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstados equals EstadosProcesalesF.IdEstados
                                                      where Ef.IdEstadoFormulario == formulario.IdFormulario
                                                      orderby Ef.FechaCumplimiento
                                                      select EstadosProcesalesF.Nombre).FirstOrDefault(),
                                    Responsable = person.name,
                                    ResponsableSucesor = (from res in db.user where formulario.ResponsableSucesor == res.id_user select res.name).FirstOrDefault(),
                                     IdFormulario = formulario.IdFormulario
                                 };

                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        public JsonResult RPProcesosPorResponsable(int id)
        {
            try
            {
                var objResult = from formulario in db.Formulario
                                join Tproceso in db.TipoProcesos on formulario.IdTIpoProceso equals Tproceso.IdTiposProcesos
                                join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                                join contrato in db.Contratos on proyecto.IdContratos equals contrato.IdContrato
                                join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                                join person in db.user on formulario.Responsable equals person.id_user 
                                where person.id_user == id 
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
                                    TipoProceso = Tproceso.Nombre,
                                    Estadoprocesal = (from Ef in db.EstadosFormulario
                                                      join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstados equals EstadosProcesalesF.IdEstados
                                                      where Ef.IdEstadoFormulario == formulario.IdFormulario
                                                      orderby Ef.FechaCumplimiento
                                                      select EstadosProcesalesF.Nombre).FirstOrDefault(),
                                    Responsable = person.name,

                                    ResponsableSucesor = (from res in db.user where formulario.ResponsableSucesor == res.id_user select res.name).FirstOrDefault(),
                                    IdFormulario = formulario.IdFormulario
                                };

                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        } 

        public JsonResult RPContratosPorCliente(int id)
        {
            try
            {
                var objResult = from formulario in db.Formulario
                                join Tproceso in db.TipoProcesos on formulario.IdTIpoProceso equals Tproceso.IdTiposProcesos
                                join proyecto in db.Proyectos on formulario.IdProyecto equals proyecto.IdProyectos
                                join contrato in db.Contratos on proyecto.IdContratos equals contrato.IdContrato
                                join municipioP in db.Municipio on formulario.IdMunicipio equals municipioP.IdMunicipio
                                join person in db.user on formulario.Responsable equals person.id_user
                                where contrato.IdPersona == id
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
                                    TipoProceso = Tproceso.Nombre,
                                    Estadoprocesal = (from Ef in db.EstadosFormulario
                                                      join EstadosProcesalesF in db.EstadosProcesales on Ef.IdEstados equals EstadosProcesalesF.IdEstados
                                                      where Ef.IdEstadoFormulario == formulario.IdFormulario
                                                      orderby Ef.FechaCumplimiento
                                                      select EstadosProcesalesF.Nombre).FirstOrDefault(),
                                    Responsable = person.name,

                                    ResponsableSucesor = (from res in db.user where formulario.ResponsableSucesor == res.id_user select res.name).FirstOrDefault(),
                                    IdFormulario = formulario.IdFormulario
                                };

                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

    }
}


