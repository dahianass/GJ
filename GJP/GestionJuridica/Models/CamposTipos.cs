namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CamposTipos
    {
        [Key]
        public int IdCamposTipos { get; set; }

        public int IdCampos { get; set; }

        public int IdTiposProcesos { get; set; }

        public bool Active { get; set; }

        public virtual CamposAdicionales CamposAdicionales { get; set; }

        public virtual CamposAdicionales CamposAdicionales1 { get; set; }

        public virtual CamposAdicionales CamposAdicionales2 { get; set; }

        public virtual CamposAdicionales CamposAdicionales3 { get; set; }

        public virtual CamposAdicionales CamposAdicionales4 { get; set; }

        public virtual CamposAdicionales CamposAdicionales5 { get; set; }
    }
}
