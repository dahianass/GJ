using GestionJuridica.Models;
using GestionJuridica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Data
{
    public class PermisosDta
    {
        private ModelJuridica db = new ModelJuridica();
        public int deletePermisosRol(int idRol) {
            try
            {
                List<Permisos> LPermisos = db.Permisos.Where(x => x.IdRol == idRol).ToList();
                foreach (var permiso in LPermisos)
                {
                    db.Permisos.Remove(permiso);
                    db.SaveChanges();
                }
                

            }
            catch (Exception ex)
            {

                throw;
            }
            return 0;
        }
        public int CreatPermisos(List<Permisos> permisos)
        {
            try
            {
                foreach (var permiso in permisos)
                {
                    db.Permisos.Add(permiso);
                    db.SaveChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}