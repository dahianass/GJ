namespace GestionJuridicaR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Municipio")]
    public partial class Municipio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Municipio()
        {
            Formulario = new HashSet<Formulario>();
            Juzgado = new HashSet<Juzgado>();
        }

        [Key]
        public int IdMunicipio { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int IdCircuito { get; set; }

        public virtual Circuito Circuito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Juzgado> Juzgado { get; set; }
    }
}
