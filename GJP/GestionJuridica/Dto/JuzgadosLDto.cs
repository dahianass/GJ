using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Dto
{
    public class JuzgadosLDto
    {
        public int IdJuzgado { get; set; }

        public int IdMunicipio { get; set; }

        public bool CircuitoV { get; set; }

        public string Juez { get; set; }

        public string Juzgado { get; set; }

        public int idNaturaleza { get; set; }

        public string Naturaleza { get; set; }
    }
}