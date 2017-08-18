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
        }

        [Key]
        public int IdCircuito { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int IdDistrito { get; set; }

        public virtual Distrito Distrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
