namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Circuito")]
    public partial class Circuito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Circuito()
        {
            Municipio = new HashSet<Municipio>();
            Municipio1 = new HashSet<Municipio>();
            Municipio2 = new HashSet<Municipio>();
            Municipio3 = new HashSet<Municipio>();
            Municipio4 = new HashSet<Municipio>();
            Municipio5 = new HashSet<Municipio>();
        }

        [Key]
        public int IdCircuito { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int IdDistrito { get; set; }

        public virtual Distrito Distrito { get; set; }

        public virtual Distrito Distrito1 { get; set; }

        public virtual Distrito Distrito2 { get; set; }

        public virtual Distrito Distrito3 { get; set; }

        public virtual Distrito Distrito4 { get; set; }

        public virtual Distrito Distrito5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipio1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipio2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipio3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipio4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipio5 { get; set; }
    }
}
