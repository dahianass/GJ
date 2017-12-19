namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CamposFormulario")]
    public partial class CamposFormulario
    {
        [Key]
        public int IdCamposFormulario { get; set; }

        public int IdCampos { get; set; }

        public int IdFormulario { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public virtual CamposAdicionales CamposAdicionales { get; set; }

        public virtual CamposAdicionales CamposAdicionales1 { get; set; }

        public virtual CamposAdicionales CamposAdicionales2 { get; set; }

        public virtual CamposAdicionales CamposAdicionales3 { get; set; }

        public virtual CamposAdicionales CamposAdicionales4 { get; set; }

        public virtual CamposAdicionales CamposAdicionales5 { get; set; }

        public virtual Formulario Formulario { get; set; }

        public virtual Formulario Formulario1 { get; set; }

        public virtual Formulario Formulario2 { get; set; }

        public virtual Formulario Formulario3 { get; set; }

        public virtual Formulario Formulario4 { get; set; }

        public virtual Formulario Formulario5 { get; set; }
    }
}
