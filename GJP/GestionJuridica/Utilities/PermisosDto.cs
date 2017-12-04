using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Utilities
{
    public class PermisosDto
    {
        public int IdPagina { get; set; }
        public string NombreP { get; set; }
        public string descripcion { get; set; }
        public Boolean Editar { get; set; }
    }
}