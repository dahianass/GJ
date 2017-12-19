using GestionJuridica.Data;
using GestionJuridica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionJuridica.Controllers
{
    public class ObjectosController : Controller
    {
        // GET: Objectos
        public ActionResult Index()
        {
            return View();
        }

        //Objectos/permisos
        [HttpPost]
        public JsonResult permisos(ListPermisosDto permisos)
        {
            Rpta objResul = new Rpta();
            try
            {
              
                PermisosDta objPermisos = new PermisosDta();
                int DeleteR = objPermisos.deletePermisosRol(permisos.ListPermisos[0].IdRol.Value);
                int SaveR = objPermisos.CreatPermisos(permisos.ListPermisos);

                if (SaveR == DeleteR)
                {
                    objResul.status = 200;
                    objResul.message = "Se actualizo los permisos";
                }
                else
                {
                    objResul.status = 200;
                    objResul.message = "Se actualizo los permisos";
                    objResul.answer = "Se actualizo";
                }

                return Json(objResul, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                objResul.status = 500;
                objResul.message = ex.Message;
                return Json(objResul, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}