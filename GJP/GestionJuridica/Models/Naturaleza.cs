namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Naturaleza")]
    public partial class Naturaleza
    {
        [Key]
        public int IdNaturaleza { get; set; }

        [Required]
        [StringLength(500)]
        public string Nombre { get; set; }
    }
}
