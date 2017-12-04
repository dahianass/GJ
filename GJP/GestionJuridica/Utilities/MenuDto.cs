using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Utilities
{
    public class MenuDto
    {
        public long id_user { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public List<PermisosDto> permisos { get; set; }
        
    }
}