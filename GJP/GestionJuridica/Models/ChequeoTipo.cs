namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChequeoTipo")]
    public partial class ChequeoTipo
    {
        [Key]
        public int IdChequeoTipo { get; set; }

        public int IdChequeo { get; set; }

        public int IdTiposProcesos { get; set; }

        public virtual Chequeo Chequeo { get; set; }
    }
}
