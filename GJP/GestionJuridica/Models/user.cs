namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Http;

    [Table("user")]
    public partial class user
    {
        [Key]
        [Column(Order = 0)]
        public long id_user { get; set; }

        [Column(Order = 1)]
        [StringLength(200)]
        public string name { get; set; }

        [Column(Order = 2)]
        [StringLength(30)]
        public string Documento { get; set; }


        [Column(Order = 3)]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRol { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [Column(Order = 5)]
        public bool Active { get; set; }

        public static implicit operator user(SingleResult<user> v)
        {
            throw new NotImplementedException();
        }
    }
}
