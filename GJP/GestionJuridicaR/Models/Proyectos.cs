namespace GestionJuridicaR.Models
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
        }

        [Key]
        public int IdProyectos { get; set; }

        public int IdContratos { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreProyecto { get; set; }

        [StringLength(500)]
        public string Interventor { get; set; }

        [StringLength(500)]
        public string Representador { get; set; }

        public virtual Contratos Contratos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulario> Formulario { get; set; }
    }
}
