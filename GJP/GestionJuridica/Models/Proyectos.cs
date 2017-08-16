namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proyectos
    {
        [Key]
        public int IdProyectos { get; set; }

        public int IdContratos { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreProyecto { get; set; }

        [Required]
        [StringLength(500)]
        public string DescripcionProyecto { get; set; }
    }
}
