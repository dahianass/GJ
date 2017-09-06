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
            EstadosFormulario = new HashSet<EstadosFormulario>();
            Historia = new HashSet<Historia>();
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

        [Required]
        [StringLength(500)]
        public string Cuantia { get; set; }

        public double Avaluo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CamposFormulario> CamposFormulario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosFormulario> EstadosFormulario { get; set; }

        public virtual Municipio Municipio { get; set; }

        public virtual Proyectos Proyectos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pdtes> Pdtes { get; set; }
    }
}
