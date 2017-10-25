namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("permission")]
    public partial class permission
    {
        [Key]
        public long id_permission { get; set; }

        public long id_user { get; set; }

        public int id_role { get; set; }

        public long id_resource { get; set; }

        public virtual resource resource { get; set; }

        public virtual role role { get; set; }

        public virtual user user { get; set; }
    }
}
