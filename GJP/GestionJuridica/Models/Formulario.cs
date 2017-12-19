namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Formulario")]
    public partial class Formulario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formulario()
        {
            CamposFormulario = new HashSet<CamposFormulario>();
            CamposFormulario1 = new HashSet<CamposFormulario>();
            CamposFormulario2 = new HashSet<CamposFormulario>();
            CamposFormulario3 = new HashSet<CamposFormulario>();
            CamposFormulario4 = new HashSet<CamposFormulario>();
            CamposFormulario5 = new HashSet<CamposFormulario>();
            Documentos = new HashSet<Documentos>();
            Documentos1 = new HashSet<Documentos>();
            Documentos2 = new HashSet<Documentos>();
            Documentos3 = new HashSet<Documentos>();
            Documentos4 = new HashSet<Documentos>();
            Documentos5 = new HashSet<Documentos>();
            EstadosFormulario = new HashSet<EstadosFormulario>();
            EstadosFormulario1 = new HashSet<EstadosFormulario>();
            EstadosFormulario2 = new HashSet<EstadosFormulario>();
            EstadosFormulario3 = new HashSet<EstadosFormulario>();
            EstadosFormulario4 = new HashSet<EstadosFormulario>();
            EstadosFormulario5 = new HashSet<EstadosFormulario>();
            EstadosFormulario6 = new HashSet<EstadosFormulario>();
            EstadosFormulario7 = new HashSet<EstadosFormulario>();
            EstadosFormulario8 = new HashSet<EstadosFormulario>();
            EstadosFormulario9 = new HashSet<EstadosFormulario>();
            EstadosFormulario10 = new HashSet<EstadosFormulario>();
            EstadosFormulario11 = new HashSet<EstadosFormulario>();
            EstadosFormulario12 = new HashSet<EstadosFormulario>();
            EstadosFormulario13 = new HashSet<EstadosFormulario>();
            EstadosFormulario14 = new HashSet<EstadosFormulario>();
            EstadosFormulario15 = new HashSet<EstadosFormulario>();
            EstadosFormulario16 = new HashSet<EstadosFormulario>();
            EstadosFormulario17 = new HashSet<EstadosFormulario>();
            Historia = new HashSet<Historia>();
            Historia1 = new HashSet<Historia>();
            Historia2 = new HashSet<Historia>();
            Historia3 = new HashSet<Historia>();
            Historia4 = new HashSet<Historia>();
            Historia5 = new HashSet<Historia>();
            Pdtes = new HashSet<Pdtes>();
        }

        [Key]
        public int IdFormulario { get; set; }

        [Required]
        [StringLength(500)]
        public string CodProceso { get; set; }

        public int IdProyecto { get; set; }

        public int IdPersona { get; set; }

        [Required]
        [StringLength(500)]
        public string Demandante { get; set; }

        [Required]
        [StringLength(500)]
        public string Demandado { get; set; }

        [StringLength(200)]
        public string Radicado { get; set; }

        [StringLength(500)]
        public string JuzgadoConocimiento { get; set; }

        [StringLength(500)]
        public string Juez { get; set; }

        public int IdMunicipio { get; set; }

        public int Estimativo { get; set; }

        public int? IdTIpoProceso { get; set; }

        public int Responsable { get; set; }

        public int ResponsableSucesor { get; set; }

        [StringLength(500)]
        public string CampoAdicional { get; set; }

        [StringLength(500)]
        public string CampoAdicional2 { get; set; }

        [Required]
        [StringLength(500)]
        public string Cuantia { get; set; }

        public double Avaluo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CamposFormulario> CamposFormulario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CamposFormulario> CamposFormulario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CamposFormulario> CamposFormulario2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CamposFormulario> CamposFormulario3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CamposFormulario> CamposFormulario4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CamposFormulario> CamposFormulario5 { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario8 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario9 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario10 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario11 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario12 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario13 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario14 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario15 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario16 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario17 { get; set; }

        public virtual Municipio Municipio { get; set; }

        public virtual Municipio Municipio1 { get; set; }

        public virtual Municipio Municipio2 { get; set; }

        public virtual Municipio Municipio3 { get; set; }

        public virtual Municipio Municipio4 { get; set; }

        public virtual Municipio Municipio5 { get; set; }

        public virtual Proyectos Proyectos { get; set; }

        public virtual Proyectos Proyectos1 { get; set; }

        public virtual Proyectos Proyectos2 { get; set; }

        public virtual Proyectos Proyectos3 { get; set; }

        public virtual Proyectos Proyectos4 { get; set; }

        public virtual Proyectos Proyectos5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pdtes> Pdtes { get; set; }
    }
}
