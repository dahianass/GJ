using GestionJuridica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionJuridica.Utilities;

namespace GestionJuridica.Controllers
{
    public class LoginController : Controller
    {
        private ModelJuridica db = new ModelJuridica();
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Login
        public JsonResult Index(string correo, string password)
        {
            Rpta obj = new Rpta();
            var usuario = (from usu in db.user
                           where usu.Active == true && usu.email == correo
                           select new MenuDto
                           {
                               id_user = usu.id_user,
                               Password = usu.Password,
                               IdRol = usu.IdRol,
                               permisos = (from perm in db.Permisos
                                           join pag in db.Paginas on perm.IdPagina equals pag.IdPagina
                                           where perm.IdRol == usu.IdRol
                                           select new PermisosDto
                                           {
                                               IdPagina = perm.IdPagina,
                                               NombreP = pag.Nombre,
                                               descripcion = pag.Descripcion,
                                               Editar = perm.Editar,
                                           }).ToList()

                           }).FirstOrDefault();

            if (usuario != null)
            {
                var id = Convert.ToInt32(usuario.IdRol);
                var pass = Encrypt.Decrypt(usuario.Password);
                if (pass == password)
                {
                    obj.error = false;
                    obj.result = true;
                    obj.obj = usuario;
                    obj.message = "Ingreso correcto";

                }
                else
                {
                    obj.error = true;
                    obj.result = false;
                    obj.message = "Correo electronico ó contraseña no coincide";
                }
            }
            else
            {
                obj.error = true;
                obj.result = false;
                obj.message = "Usuario no existe";
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //    // GET: Login/Details/5
        //    public ActionResult Details(int id)
        //    {
        //        return View();
        //    }

        //    // GET: Login/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Login/Create
        //    [HttpPost]
        //    public ActionResult Create(FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add insert logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: Login/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Login/Edit/5
        //    [HttpPost]
        //    public ActionResult Edit(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add update logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: Login/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Login/Delete/5
        //    [HttpPost]
        //    public ActionResult Delete(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add delete logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}
