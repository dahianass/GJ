namespace GestionJuridicaR.Models
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
            ChequeoFormulario = new HashSet<ChequeoFormulario>();
            Pdtes = new HashSet<Pdtes>();
        }

        [Key]
        public int IdEstadoFormulario { get; set; }

        public int IdEstadoProcesal { get; set; }

        public int IdFormulario { get; set; }

        [Required]
        public string Obsevacion { get; set; }

        public bool Cumplido { get; set; }

        public DateTime? FechaCumplimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChequeoFormulario> ChequeoFormulario { get; set; }

        public virtual Formulario Formulario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pdtes> Pdtes { get; set; }
    }
}
