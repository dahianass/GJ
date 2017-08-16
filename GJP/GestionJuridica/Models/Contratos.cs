namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contratos
    {
        [Key]
        public int IdContrato { get; set; }

        public int IdPersona { get; set; }

        [Required]
        [StringLength(500)]
        public string Contrato { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }
    }
}
