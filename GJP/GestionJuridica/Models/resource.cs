namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("resource")]
    public partial class resource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resource()
        {
            permission = new HashSet<permission>();
            resource11 = new HashSet<resource>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_resource { get; set; }

        [Column("resource")]
        [Required]
        [StringLength(50)]
        public string resource1 { get; set; }

        public long parent { get; set; }

        public bool hereditary { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permission> permission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resource> resource11 { get; set; }

        public virtual resource resource2 { get; set; }
    }
}
