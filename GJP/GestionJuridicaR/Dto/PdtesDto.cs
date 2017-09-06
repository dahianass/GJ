using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Dto
{
    public class PdtesDto
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
        public DateTime Fechapendiente { get; set; }
        public int IdFormulario { get; set; }
        public string Actividad { get; set; }
        public string Observacion { get; set; }
    }
}