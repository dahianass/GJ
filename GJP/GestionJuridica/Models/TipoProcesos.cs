namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TipoProcesos
    {
        [Key]
        [Column(Order = 0)]
        public int IdTiposProcesos { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Nombre { get; set; }
    }
}
