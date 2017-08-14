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
        }

        [Key]
        public int IdEstados { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int? Terminos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadosTipos> EstadosTipos { get; set; }
    }
}
