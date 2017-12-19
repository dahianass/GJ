namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permisos
    {
        [Key]
        public int IdPermiso { get; set; }

        public int? IdRol { get; set; }

        public int? IdPagina { get; set; }

        public bool Editar { get; set; }

        public virtual Paginas Paginas { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
