using GestionJuridica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionJuridica.Dto
{
    public class JuzgadosLDto
    {
        public int IdJuzgado { get; set; }

        public int IdMunicipio { get; set; }

        public bool Circuito { get; set; }
        
        public string Juez { get; set; }
        
        public string NombreJuzgado { get; set; }

        public int IdNaturaleza { get; set; }

        public string Naturaleza { get; set; }
    }
}