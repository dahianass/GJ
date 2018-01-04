using GestionJuridica.Dto;
using GestionJuridica.Models;
using GestionJuridica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using GestionJuridica.ModelDto;

namespace GestionJuridica.Controllers
{
    public class AlgoritmosController : Controller
    {
        private ModelJuridica db = new ModelJuridica();
        // GET: Algoritmos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Algoritmos/Details/5
        public ActionResult Details(int id)
        {
            return null;
        }

        //// POST: Algoritmos/Cuantia
        //[HttpPost]
        //public ActionResult Cuantia(CuantiaDto obj) {
        //    return null;
        //}

        // GET: Algoritmos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Algoritmos/Chequeo(1)
        public JsonResult chequeo(int id) {
            var objChequeo = (from cheqTipo in db.ChequeoTipo
                              join cheq in db.Chequeo on cheqTipo.IdChequeo equals cheq.IdChequeo
                              where cheqTipo.IdTiposProcesos == id
                              select new ChequeoDto
                              {
                                  IdChequeo = cheqTipo.IdChequeo,
                                  IdChequeoTipo = cheqTipo.IdChequeoTipo,
                                  IdTiposProcesos = cheqTipo.IdTiposProcesos,
                                  Nombre = cheq.Nombre,
                              }).ToList();

            return Json(objChequeo, JsonRequestBehavior.AllowGet);
        }

        // POST: Algoritmos/Cuantia
        [HttpPost]
        public JsonResult Cuantia(CuantiaDto collection)
        {
            try
            {
                var cuantia = string.Empty;
                smlv salario = db.smlv.Where(e => e.Ano == collection.fechaAno).FirstOrDefault();
                int valorS = salario.Valor;
                if (valorS > 0)
                {
                    if (collection.valor <= (valorS * 40))
                    {
                        cuantia = "MÍNIMA";
                    }
                    else if (collection.valor > (valorS * 40) && collection.valor <= (valorS * 150))
                    {
                        cuantia = "MENOR";
                    }
                    else if (collection.valor > (valorS * 150))
                    {
                        cuantia = "MAYOR";
                    }
                } else {
                    cuantia = "{mesage:'no hay un valor para el año'" + collection.fechaAno + "}";
                }
                return Json(cuantia);
            }
            catch
            {
                return Json("{mesage:'se encontro una exepción'}");
            }
        }

        // POST: Algoritmos/Juzgados
        [HttpPost]
        public JsonResult Juzgados(JuzgadosDto collection)
        {
            try
            {
                List<JuzgadosLDto> objResult = new List<JuzgadosLDto>();
                if ((collection.Cuantia == "MÍNIMA") || (collection.Cuantia == "Mínima") || (collection.Cuantia.ToLower() == "mínima") || (collection.Cuantia.ToLower() == "minima"))
                {
                    objResult = (from Juzg in db.Juzgado
                                 join natura in db.Naturaleza on Juzg.IdNaturaleza equals natura.IdNaturaleza
                                 where Juzg.IdMunicipio == collection.idMunicipio
                                 select new JuzgadosLDto
                                 {
                                     IdJuzgado = Juzg.IdJuzgado,
                                     IdMunicipio = Juzg.IdMunicipio,
                                     Circuito = Juzg.Circuito,
                                     Juez = Juzg.Juez,
                                     NombreJuzgado = Juzg.NombreJuzgado,
                                     IdNaturaleza = Juzg.IdNaturaleza,
                                     Naturaleza = natura.Nombre,
                                 }).ToList();
                }
                else
                {
                    var circuito = db.Municipio.ToList().Find(x => x.IdMunicipio == collection.idMunicipio).IdCircuito;

                    objResult = (from mun in db.Municipio
                                 join Juzg in db.Juzgado on mun.IdMunicipio equals Juzg.IdMunicipio
                                 join natura in db.Naturaleza on Juzg.IdNaturaleza equals natura.IdNaturaleza
                                 where mun.IdCircuito == circuito && Juzg.Circuito == true
                                 select new JuzgadosLDto
                                 {
                                     IdJuzgado = Juzg.IdJuzgado,
                                     IdMunicipio = Juzg.IdMunicipio,
                                     Circuito = Juzg.Circuito,
                                     Juez = Juzg.Juez,
                                     NombreJuzgado = Juzg.NombreJuzgado,
                                     IdNaturaleza = Juzg.IdNaturaleza,
                                     Naturaleza = natura.Nombre,
                                 }).ToList();
                }
                return Json(objResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        //POST: Algoritmos/GuardarPermisos
        [HttpPost]
        public JsonResult GuardarPermisos(List<Permisos> listPermisos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpException(404, "Item Not Found");
                }
                var query = db.Permisos.AsEnumerable().Where(r => r.IdRol == listPermisos.First().IdRol);
                foreach (var item in query.ToList())
                {
                    db.Permisos.Remove(item);
                }
                foreach (var item in listPermisos)
                {
                    db.Permisos.Add(item);
                    db.SaveChanges();

                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new HttpException(404, "Item Not Found");
            }

        }

        // GET: Algoritmos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Algoritmos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Algoritmos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Algoritmos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Algoritmos/CorreosInterventores/1
        public JsonResult CorreosInterventores(int id)
        {
            try
            {
                var correo = (from form in db.Formulario
                              join proy in db.Proyectos on form.IdProyecto equals proy.IdProyectos
                              where form.IdFormulario == id
                              select new EmailInterventores()
                              {
                                  InterventorJuridico = (from person in db.Personas where person.IdPersona == proy.Interventor select person.Correo).FirstOrDefault(),
                                  InterventorTecnico = (from person in db.Personas where person.IdPersona == proy.Representador select person.Correo).FirstOrDefault()
                              }).ToList();

                return Json(correo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        // GET: Algoritmos/CorreosAdmin
        public JsonResult CorreosAdmin()
        {
            try
            {
                var correo = (from users in db.user
                              join rols in db.Rol on users.IdRol equals rols.IdRol
                              where rols.IdRol == 1
                              select users.email).ToList();

                return Json(correo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        // GET: Algoritmos/CorreosAbogados
        public JsonResult CorreosAbogados()
        {
            try
            {
                var correo = (from users in db.user
                              join rols in db.Rol on users.IdRol equals rols.IdRol
                              where rols.IdRol == 2
                              select users.email).ToList();
                
                return Json(correo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        //TODO: Activar el job
        // GET: Algoritmos/EnviarRecordatorios
        public JsonResult EnviarRecordatorios()
        {
            try
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


                var correos = (from users in db.user
                              join rols in db.Rol on users.IdRol equals rols.IdRol
                              where (rols.IdRol == 2 || rols.IdRol == 1)
                              select users.email).ToList();               

                foreach (var item in objResuldt)
                {
                    SendEmail.SendAlerta(correos, "El proceso " + item.Cproceso + " tiene un pendiente.",
                        "El proceso " + item.Cproceso.Replace("\n", " ") + " del demandado " + item.Demandado.Replace("\n"," ") + ", con el radicado " + item.Radicado.Replace("\n", " ") + " ubicado en el municipio de " + item.MunicipioP.Replace("\n", " ") + " en el juzgado " + item.JuzgadoF.Replace("\n", " ") + ", tiene programado:\n\n" + item.Actividad + ": " + item.Observacion);
                }
                return Json(objResuldt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        public ActionResult Test()
        {          
            LogFile.Save(GetType().Name, MethodBase.GetCurrentMethod().Name, "Hds");
            return Json("Jsle", JsonRequestBehavior.AllowGet);
        }
    }
}
