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
                               Nombre = usu.name,
                               Cargo = usu.Cargo,
                               permisos = (from perm in db.Permisos
                                           join pag in db.Paginas on perm.IdPagina equals pag.IdPagina
                                           where perm.IdRol == usu.IdRol
                                           select new PermisosDto
                                           {
                                               IdPagina = perm.IdPagina.Value,
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
    }
}
