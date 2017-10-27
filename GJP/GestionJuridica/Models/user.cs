namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [Key]
        public long id_user { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Required]
        [StringLength(30)]
        public string Documento { get; set; }

        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }

        public int IdRol { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}
