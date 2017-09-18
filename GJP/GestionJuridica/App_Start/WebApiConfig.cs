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
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<EstadosTipos>("EstadosTipos");
            builder.EntitySet<EstadosProcesales>("EstadosProcesales");
            builder.EntitySet<TipoProcesos>("TipoProcesos");
            builder.EntitySet<CamposTipos>("CamposTipos");
            builder.EntitySet<ChequeoTipo>("ChequeoTipoes");
            builder.EntitySet<Chequeo>("Chequeos");
            builder.EntitySet<CamposAdicionales>("CamposAdicionales");
            builder.EntitySet<Usuarios>("Usuarios");
            builder.EntitySet<Personas>("Personas");
            builder.EntitySet<Distrito>("Distritoes");
            builder.EntitySet<Circuito>("Circuitoes");
            builder.EntitySet<Municipio>("Municipios"); 
            builder.EntitySet<Juzgado>("Juzgadoes");
            builder.EntitySet<Proyectos>("Proyectos");
            builder.EntitySet<Contratos>("Contratos");
            builder.EntitySet<Formulario>("Formularios");
            builder.EntitySet<EstadosFormulario>("EstadosFormularios");
            builder.EntitySet<Historia>("Historias");
            builder.EntitySet<ChequeoFormulario>("ChequeoFormularios");
            builder.EntitySet<Auditoria>("Auditorias");
            builder.EntitySet<Naturaleza>("Naturalezas");
            builder.EntitySet<smlv>("smlvs");
            builder.EntitySet<CamposFormulario>("CamposFormularios");
            builder.EntitySet<Pdtes>("PdtesActividades");
            builder.EntitySet<Documentos>("Documentos");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
