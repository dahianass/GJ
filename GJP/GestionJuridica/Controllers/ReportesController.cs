using GestionJuridica.Dto;
using GestionJuridica.Models;
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


        //// GET: Reportes/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Reportes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Reportes/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Reportes/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Reportes/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Reportes/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Reportes/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
