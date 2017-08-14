using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using GestionJuridica.Models;

namespace GestionJuridica
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<EstadosTipos>("EstadosTipos");
            builder.EntitySet<EstadosProcesales>("EstadosProcesales");
            builder.EntitySet<TipoProcesos>("TipoProcesos");
            builder.EntitySet<CamposTipos>("CamposTipos");
            builder.EntitySet<ChequeoTipo>("ChequeoTipoes");
            builder.EntitySet<Chequeo>("Chequeos");
            builder.EntitySet<CamposAdicionales>("CamposAdicionales");
            builder.EntitySet<Usuarios>("Usuarios");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
