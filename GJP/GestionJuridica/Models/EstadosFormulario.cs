namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EstadosFormulario")]
    public partial class EstadosFormulario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadosFormulario()
        {
            Documentos = new HashSet<Documentos>();
            Documentos1 = new HashSet<Documentos>();
            Documentos2 = new HashSet<Documentos>();
            Documentos3 = new HashSet<Documentos>();
            Documentos4 = new HashSet<Documentos>();
            Documentos5 = new HashSet<Documentos>();
        }

        [Key]
        public int IdEstadoFormulario { get; set; }


        [Column("IdEstadoProcesal")]
        public int IdEstados { get; set; }

        public int IdFormulario { get; set; }

        [Required]
        public string Obsevacion { get; set; }

        public int Cumplido { get; set; }

        public DateTime? FechaCumplimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos5 { get; set; }

        public virtual Formulario Formulario { get; set; }

        public virtual Formulario Formulario1 { get; set; }

        public virtual Formulario Formulario2 { get; set; }

        public virtual Formulario Formulario3 { get; set; }

        public virtual Formulario Formulario4 { get; set; }

        public virtual Formulario Formulario5 { get; set; }

        public virtual Formulario Formulario6 { get; set; }

        public virtual Formulario Formulario7 { get; set; }

        public virtual Formulario Formulario8 { get; set; }

        public virtual Formulario Formulario9 { get; set; }

        public virtual Formulario Formulario10 { get; set; }

        public virtual Formulario Formulario11 { get; set; }

        public virtual Formulario Formulario12 { get; set; }

        public virtual Formulario Formulario13 { get; set; }

        public virtual Formulario Formulario14 { get; set; }

        public virtual Formulario Formulario15 { get; set; }

        public virtual Formulario Formulario16 { get; set; }

        public virtual Formulario Formulario17 { get; set; }
    }
}
