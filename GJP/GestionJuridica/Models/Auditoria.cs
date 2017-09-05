namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Auditoria")]
    public partial class Auditoria
    {
        [Key]
        public int IdAuditoria { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(200)]
        public string Accion { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
