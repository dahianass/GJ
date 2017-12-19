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

        public virtual EstadosFormulario EstadosFormulario1 { get; set; }

        public virtual EstadosFormulario EstadosFormulario2 { get; set; }

        public virtual EstadosFormulario EstadosFormulario3 { get; set; }

        public virtual EstadosFormulario EstadosFormulario4 { get; set; }

        public virtual EstadosFormulario EstadosFormulario5 { get; set; }

        public virtual Formulario Formulario { get; set; }

        public virtual Formulario Formulario1 { get; set; }

        public virtual Formulario Formulario2 { get; set; }

        public virtual Formulario Formulario3 { get; set; }

        public virtual Formulario Formulario4 { get; set; }

        public virtual Formulario Formulario5 { get; set; }
    }
}
