namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EstadosProcesales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadosProcesales()
        {
            EstadosTipos = new HashSet<EstadosTipos>();
            EstadosTipos1 = new HashSet<EstadosTipos>();
            EstadosTipos2 = new HashSet<EstadosTipos>();
            EstadosTipos3 = new HashSet<EstadosTipos>();
            EstadosTipos4 = new HashSet<EstadosTipos>();
            EstadosTipos5 = new HashSet<EstadosTipos>();
        }

        [Key]
        public int IdEstados { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int? Terminos { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosTipos> EstadosTipos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosTipos> EstadosTipos1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosTipos> EstadosTipos2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosTipos> EstadosTipos3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosTipos> EstadosTipos4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosTipos> EstadosTipos5 { get; set; }
    }
}
