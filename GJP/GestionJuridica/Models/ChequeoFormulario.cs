namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChequeoFormulario")]
    public partial class ChequeoFormulario
    {
        [Key]
        public int IdCheqeoF { get; set; }

        public int IdEstadoFormulario { get; set; }

        public int? IdChequeo { get; set; }

        public virtual EstadosFormulario EstadosFormulario { get; set; }
    }
}
