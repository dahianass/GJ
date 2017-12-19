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
        [Key]
        public int id_action { get; set; }

        [Column("action")]
        [Required]
        [StringLength(50)]
        public string action1 { get; set; }

        [Required]
        [StringLength(255)]
        public string description { get; set; }
    }
}
