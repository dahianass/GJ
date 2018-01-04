using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Utilities
{
    public class procesosDto
    {
        public string NombreCliente { get; set; }
        public string Contrato { get; set; }
        public string Proyecto { get; set; }
        public string Cproceso { get; set; }
        public string MunicipioP { get; set; }
        public string JuzgadoF { get; set; }
        public string Radicado { get; set; }
        public string Demandante { get; set; }
        public string Demandado { get; set; }
        public string Estadoprocesal { get; set; }
        public int IdFormulario { get; set; }
        public string TipoProceso { get; set; }
        public string Responsable { get; set; }
        public string ResponsableSucesor { get; set; }

    }
}