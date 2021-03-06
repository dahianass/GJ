namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pdtes
    {
        [Key]
        public int IdPdte { get; set; }

        public int IdUsuario { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Cargo { get; set; }

        public int? IdEstado { get; set; }

        public int IdFormulario { get; set; }
        
        public string Correo { get; set; }

        [Required]
        public string Observacion { get; set; }

        [Required]
        [StringLength(500)]
        public string Actividad { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaRecordatorio { get; set; }

        public virtual Formulario Formulario { get; set; }
    }
}
