using GestionJuridica.Dto;
using GestionJuridica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // POST: Algoritmos/Create
        [HttpPost]
        public JsonResult Cuantia(CuantiaDto collection)
        {
            try
            {

                var cuantia="";
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
                    cuantia = "{mesage:'no hay un valor para el año'"+collection.fechaAno+"}";
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
                if ((collection.Cuantia == "MÍNIMA")||(collection.Cuantia =="Mínima") || (collection.Cuantia.ToLower() == "mínima") || (collection.Cuantia.ToLower() == "minima"))
                {
                    objResult = (from Juzg in db.Juzgado
                                 join natura in db.Naturaleza on Juzg.IdNaturaleza equals natura.IdNaturaleza
                                 where Juzg.IdMunicipio == collection.idMunicipio
                                 select new JuzgadosLDto
                                 {
                                     IdJuzgado = Juzg.IdJuzgado,
                                     IdMunicipio = Juzg.IdMunicipio,
                                     CircuitoV = Juzg.Circuito,
                                     Juez = Juzg.Juez,
                                     Juzgado = Juzg.Juzgado1,
                                     idNaturaleza = Juzg.IdNaturaleza,
                                     Naturaleza = natura.Nombre,
                                 }).ToList();
                }
                else
                {
                    Municipio circuito = (from mun in db.Municipio
                                          where mun.IdMunicipio == collection.idMunicipio
                                          select new Municipio
                                          {
                                              IdCircuito = mun.IdCircuito
                                          }).FirstOrDefault();

                    objResult = (from mun in db.Municipio
                                 join Juzg in db.Juzgado on mun.IdMunicipio equals Juzg.IdMunicipio
                                 join natura in db.Naturaleza on Juzg.IdNaturaleza equals natura.IdNaturaleza
                                 where mun.IdCircuito == circuito.IdCircuito && Juzg.Circuito == true
                                 select new JuzgadosLDto
                                 {
                                     IdJuzgado = Juzg.IdJuzgado,
                                     IdMunicipio = Juzg.IdMunicipio,
                                     CircuitoV = Juzg.Circuito,
                                     Juez = Juzg.Juez,
                                     Juzgado = Juzg.Juzgado1,
                                     idNaturaleza = Juzg.IdNaturaleza,
                                     Naturaleza = natura.Nombre,
                                 }).ToList();
                }
                return Json(objResult,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
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
                // TODO: Add update logic here

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
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
