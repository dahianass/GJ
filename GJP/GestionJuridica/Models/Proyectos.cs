namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proyectos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyectos()
        {
            Formulario = new HashSet<Formulario>();
            Formulario1 = new HashSet<Formulario>();
            Formulario2 = new HashSet<Formulario>();
            Formulario3 = new HashSet<Formulario>();
            Formulario4 = new HashSet<Formulario>();
            Formulario5 = new HashSet<Formulario>();
        }

        [Key]
        public int IdProyectos { get; set; }

        public int IdContratos { get; set; }

        [Required]
        [StringLength(50)]
        public string CodigoProyecto { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreProyecto { get; set; }

        public int? Interventor { get; set; }

        public int? Representador { get; set; }

        public virtual Contratos Contratos { get; set; }

        public virtual Contratos Contratos1 { get; set; }

        public virtual Contratos Contratos2 { get; set; }

        public virtual Contratos Contratos3 { get; set; }

        public virtual Contratos Contratos4 { get; set; }

        public virtual Contratos Contratos5 { get; set; }

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
    }
}
