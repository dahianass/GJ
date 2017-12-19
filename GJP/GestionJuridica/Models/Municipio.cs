namespace GestionJuridica.Models
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
            Formulario1 = new HashSet<Formulario>();
            Formulario2 = new HashSet<Formulario>();
            Formulario3 = new HashSet<Formulario>();
            Formulario4 = new HashSet<Formulario>();
            Formulario5 = new HashSet<Formulario>();
            Juzgado = new HashSet<Juzgado>();
            Juzgado1 = new HashSet<Juzgado>();
        }

        [Key]
        public int IdMunicipio { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int IdCircuito { get; set; }

        public virtual Circuito Circuito { get; set; }

        public virtual Circuito Circuito1 { get; set; }

        public virtual Circuito Circuito2 { get; set; }

        public virtual Circuito Circuito3 { get; set; }

        public virtual Circuito Circuito4 { get; set; }

        public virtual Circuito Circuito5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Juzgado> Juzgado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Juzgado> Juzgado1 { get; set; }
    }
}
