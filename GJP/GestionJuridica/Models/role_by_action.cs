namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class role_by_action
    {
        [Key]
        public long id_role_by_action { get; set; }

        public int id_role { get; set; }

        public int id_action { get; set; }

        public virtual action action { get; set; }

        public virtual role role { get; set; }
    }
}
