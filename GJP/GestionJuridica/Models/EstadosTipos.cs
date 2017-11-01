namespace GestionJuridica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EstadosTipos
    {
        [Key]
        public int IdEstadosTipos { get; set; }

        public int IdEstados { get; set; }

        public int IdTiposProcesos { get; set; }

        public virtual EstadosProcesales EstadosProcesales { get; set; }
    }
}
