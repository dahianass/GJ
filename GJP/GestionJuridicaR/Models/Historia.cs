namespace GestionJuridicaR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historia")]
    public partial class Historia
    {
        [Key]
        public int IdHistoria { get; set; }

        public int IdUsuario { get; set; }

        public int? IdEstadoFormulario { get; set; }

        public int IdFormulario { get; set; }

        [Required]
        public string Observacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Formulario Formulario { get; set; }
    }
}
