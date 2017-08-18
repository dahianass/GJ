namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Juzgado")]
    public partial class Juzgado
    {
        [Key]
        public int IdJuzgado { get; set; }

        public int IdTipoJuzgado { get; set; }

        public int IdMunicipio { get; set; }

        public bool Circuito { get; set; }

        [StringLength(200)]
        public string Descripción { get; set; }

        [StringLength(200)]
        public string Juez { get; set; }

        public virtual Municipio Municipio { get; set; }

        public virtual TipoJuzgado TipoJuzgado { get; set; }
    }
}
