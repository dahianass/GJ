namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("action")]
    public partial class action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public action()
        {
            role_by_action = new HashSet<role_by_action>();
        }

        [Key]
        public int id_action { get; set; }

        [Column("action")]
        [Required]
        [StringLength(50)]
        public string action1 { get; set; }

        [Required]
        [StringLength(255)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role_by_action> role_by_action { get; set; }
    }
}
