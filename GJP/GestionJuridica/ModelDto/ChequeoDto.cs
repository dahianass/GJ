using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Dto
{
    public class ChequeoDto
    {
        public int IdChequeoTipo { get; set; }

        public int IdChequeo { get; set; }

        public int IdTiposProcesos { get; set; }

        public string Nombre { get; set; }
    }
}