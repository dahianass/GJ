namespace GestionJuridicaR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Personas
    {
        [Key]
        public int IdPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroIdentidad { get; set; }

        [Required]
        [StringLength(500)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Correo { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }
    }
}
