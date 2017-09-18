namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Documentos
    {
        [Key]
        public int IdDocumentos { get; set; }

        public int? IdFormulario { get; set; }

        public int? IdEstadoFormulario { get; set; }

        public string Url { get; set; }

        public DateTime? FechaGuardar { get; set; }

        public virtual EstadosFormulario EstadosFormulario { get; set; }

        public virtual Formulario Formulario { get; set; }
    }
}
