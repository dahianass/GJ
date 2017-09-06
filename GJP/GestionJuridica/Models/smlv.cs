namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smlv")]
    public partial class smlv
    {
        [Key]
        public int Idsmlv { get; set; }

        public int Valor { get; set; }

        public int Ano { get; set; }
    }
}
