namespace GestionJuridica.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelJuridica : DbContext
    {
        public ModelJuridica()
            : base("name=ModelJuridica")
        {
        }

        public virtual DbSet<action> action { get; set; }
        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<CamposAdicionales> CamposAdicionales { get; set; }
        public virtual DbSet<CamposFormulario> CamposFormulario { get; set; }
        public virtual DbSet<CamposTipos> CamposTipos { get; set; }
        public virtual DbSet<Chequeo> Chequeo { get; set; }
        public virtual DbSet<ChequeoFormulario> ChequeoFormulario { get; set; }
        public virtual DbSet<ChequeoTipo> ChequeoTipo { get; set; }
        public virtual DbSet<Circuito> Circuito { get; set; }
        public virtual DbSet<Contratos> Contratos { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<EstadosFormulario> EstadosFormulario { get; set; }
        public virtual DbSet<EstadosProcesales> EstadosProcesales { get; set; }
        public virtual DbSet<EstadosTipos> EstadosTipos { get; set; }
        public virtual DbSet<Formulario> Formulario { get; set; }
        public virtual DbSet<Historia> Historia { get; set; }
        public virtual DbSet<Juzgado> Juzgado { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Naturaleza> Naturaleza { get; set; }
        public virtual DbSet<Paginas> Paginas { get; set; }
        public virtual DbSet<Pdtes> Pdtes { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<permission> permission { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<resource> resource { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<smlv> smlv { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<TipoProcesos> TipoProcesos { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<action>()
                .Property(e => e.action1)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposFormulario)
                .WithRequired(e => e.CamposAdicionales)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposFormulario1)
                .WithRequired(e => e.CamposAdicionales1)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposFormulario2)
                .WithRequired(e => e.CamposAdicionales2)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposFormulario3)
                .WithRequired(e => e.CamposAdicionales3)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposFormulario4)
                .WithRequired(e => e.CamposAdicionales4)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposFormulario5)
                .WithRequired(e => e.CamposAdicionales5)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos)
                .WithRequired(e => e.CamposAdicionales)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos1)
                .WithRequired(e => e.CamposAdicionales1)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos2)
                .WithRequired(e => e.CamposAdicionales2)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos3)
                .WithRequired(e => e.CamposAdicionales3)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos4)
                .WithRequired(e => e.CamposAdicionales4)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos5)
                .WithRequired(e => e.CamposAdicionales5)
                .HasForeignKey(e => e.IdCampos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo)
                .WithRequired(e => e.Chequeo)
                .HasForeignKey(e => e.IdChequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo1)
                .WithRequired(e => e.Chequeo1)
                .HasForeignKey(e => e.IdChequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo2)
                .WithRequired(e => e.Chequeo2)
                .HasForeignKey(e => e.IdChequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo3)
                .WithRequired(e => e.Chequeo3)
                .HasForeignKey(e => e.IdChequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo4)
                .WithRequired(e => e.Chequeo4)
                .HasForeignKey(e => e.IdChequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo5)
                .WithRequired(e => e.Chequeo5)
                .HasForeignKey(e => e.IdChequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Circuito>()
                .HasMany(e => e.Municipio)
                .WithRequired(e => e.Circuito)
                .HasForeignKey(e => e.IdCircuito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Circuito>()
                .HasMany(e => e.Municipio1)
                .WithRequired(e => e.Circuito1)
                .HasForeignKey(e => e.IdCircuito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Circuito>()
                .HasMany(e => e.Municipio2)
                .WithRequired(e => e.Circuito2)
                .HasForeignKey(e => e.IdCircuito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Circuito>()
                .HasMany(e => e.Municipio3)
                .WithRequired(e => e.Circuito3)
                .HasForeignKey(e => e.IdCircuito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Circuito>()
                .HasMany(e => e.Municipio4)
                .WithRequired(e => e.Circuito4)
                .HasForeignKey(e => e.IdCircuito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Circuito>()
                .HasMany(e => e.Municipio5)
                .WithRequired(e => e.Circuito5)
                .HasForeignKey(e => e.IdCircuito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contratos>()
                .HasMany(e => e.Proyectos)
                .WithRequired(e => e.Contratos)
                .HasForeignKey(e => e.IdContratos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contratos>()
                .HasMany(e => e.Proyectos1)
                .WithRequired(e => e.Contratos1)
                .HasForeignKey(e => e.IdContratos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contratos>()
                .HasMany(e => e.Proyectos2)
                .WithRequired(e => e.Contratos2)
                .HasForeignKey(e => e.IdContratos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contratos>()
                .HasMany(e => e.Proyectos3)
                .WithRequired(e => e.Contratos3)
                .HasForeignKey(e => e.IdContratos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contratos>()
                .HasMany(e => e.Proyectos4)
                .WithRequired(e => e.Contratos4)
                .HasForeignKey(e => e.IdContratos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contratos>()
                .HasMany(e => e.Proyectos5)
                .WithRequired(e => e.Contratos5)
                .HasForeignKey(e => e.IdContratos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Circuito)
                .WithRequired(e => e.Distrito)
                .HasForeignKey(e => e.IdDistrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Circuito1)
                .WithRequired(e => e.Distrito1)
                .HasForeignKey(e => e.IdDistrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Circuito2)
                .WithRequired(e => e.Distrito2)
                .HasForeignKey(e => e.IdDistrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Circuito3)
                .WithRequired(e => e.Distrito3)
                .HasForeignKey(e => e.IdDistrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Circuito4)
                .WithRequired(e => e.Distrito4)
                .HasForeignKey(e => e.IdDistrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Circuito5)
                .WithRequired(e => e.Distrito5)
                .HasForeignKey(e => e.IdDistrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosFormulario>()
                .HasMany(e => e.Documentos)
                .WithOptional(e => e.EstadosFormulario)
                .HasForeignKey(e => e.IdEstadoFormulario);

            modelBuilder.Entity<EstadosFormulario>()
                .HasMany(e => e.Documentos1)
                .WithOptional(e => e.EstadosFormulario1)
                .HasForeignKey(e => e.IdEstadoFormulario);

            modelBuilder.Entity<EstadosFormulario>()
                .HasMany(e => e.Documentos2)
                .WithOptional(e => e.EstadosFormulario2)
                .HasForeignKey(e => e.IdEstadoFormulario);

            modelBuilder.Entity<EstadosFormulario>()
                .HasMany(e => e.Documentos3)
                .WithOptional(e => e.EstadosFormulario3)
                .HasForeignKey(e => e.IdEstadoFormulario);

            modelBuilder.Entity<EstadosFormulario>()
                .HasMany(e => e.Documentos4)
                .WithOptional(e => e.EstadosFormulario4)
                .HasForeignKey(e => e.IdEstadoFormulario);

            modelBuilder.Entity<EstadosFormulario>()
                .HasMany(e => e.Documentos5)
                .WithOptional(e => e.EstadosFormulario5)
                .HasForeignKey(e => e.IdEstadoFormulario);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos)
                .WithRequired(e => e.EstadosProcesales)
                .HasForeignKey(e => e.IdEstados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos1)
                .WithRequired(e => e.EstadosProcesales1)
                .HasForeignKey(e => e.IdEstados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos2)
                .WithRequired(e => e.EstadosProcesales2)
                .HasForeignKey(e => e.IdEstados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos3)
                .WithRequired(e => e.EstadosProcesales3)
                .HasForeignKey(e => e.IdEstados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos4)
                .WithRequired(e => e.EstadosProcesales4)
                .HasForeignKey(e => e.IdEstados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos5)
                .WithRequired(e => e.EstadosProcesales5)
                .HasForeignKey(e => e.IdEstados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.CamposFormulario)
                .WithRequired(e => e.Formulario)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.CamposFormulario1)
                .WithRequired(e => e.Formulario1)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.CamposFormulario2)
                .WithRequired(e => e.Formulario2)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.CamposFormulario3)
                .WithRequired(e => e.Formulario3)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.CamposFormulario4)
                .WithRequired(e => e.Formulario4)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.CamposFormulario5)
                .WithRequired(e => e.Formulario5)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Documentos)
                .WithOptional(e => e.Formulario)
                .HasForeignKey(e => e.IdFormulario);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Documentos1)
                .WithOptional(e => e.Formulario1)
                .HasForeignKey(e => e.IdFormulario);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Documentos2)
                .WithOptional(e => e.Formulario2)
                .HasForeignKey(e => e.IdFormulario);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Documentos3)
                .WithOptional(e => e.Formulario3)
                .HasForeignKey(e => e.IdFormulario);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Documentos4)
                .WithOptional(e => e.Formulario4)
                .HasForeignKey(e => e.IdFormulario);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Documentos5)
                .WithOptional(e => e.Formulario5)
                .HasForeignKey(e => e.IdFormulario);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario)
                .WithRequired(e => e.Formulario)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario1)
                .WithRequired(e => e.Formulario1)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario2)
                .WithRequired(e => e.Formulario2)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario3)
                .WithRequired(e => e.Formulario3)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario4)
                .WithRequired(e => e.Formulario4)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario5)
                .WithRequired(e => e.Formulario5)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario6)
                .WithRequired(e => e.Formulario6)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario7)
                .WithRequired(e => e.Formulario7)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario8)
                .WithRequired(e => e.Formulario8)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario9)
                .WithRequired(e => e.Formulario9)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario10)
                .WithRequired(e => e.Formulario10)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario11)
                .WithRequired(e => e.Formulario11)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario12)
                .WithRequired(e => e.Formulario12)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario13)
                .WithRequired(e => e.Formulario13)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario14)
                .WithRequired(e => e.Formulario14)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario15)
                .WithRequired(e => e.Formulario15)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario16)
                .WithRequired(e => e.Formulario16)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario17)
                .WithRequired(e => e.Formulario17)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Historia)
                .WithRequired(e => e.Formulario)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Historia1)
                .WithRequired(e => e.Formulario1)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Historia2)
                .WithRequired(e => e.Formulario2)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Historia3)
                .WithRequired(e => e.Formulario3)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Historia4)
                .WithRequired(e => e.Formulario4)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Historia5)
                .WithRequired(e => e.Formulario5)
                .HasForeignKey(e => e.IdFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Pdtes)
                .WithRequired(e => e.Formulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Formulario)
                .WithRequired(e => e.Municipio)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Formulario1)
                .WithRequired(e => e.Municipio1)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Formulario2)
                .WithRequired(e => e.Municipio2)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Formulario3)
                .WithRequired(e => e.Municipio3)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Formulario4)
                .WithRequired(e => e.Municipio4)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Formulario5)
                .WithRequired(e => e.Municipio5)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Juzgado)
                .WithRequired(e => e.Municipio)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Juzgado1)
                .WithRequired(e => e.Municipio1)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyectos>()
                .HasMany(e => e.Formulario)
                .WithRequired(e => e.Proyectos)
                .HasForeignKey(e => e.IdProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyectos>()
                .HasMany(e => e.Formulario1)
                .WithRequired(e => e.Proyectos1)
                .HasForeignKey(e => e.IdProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyectos>()
                .HasMany(e => e.Formulario2)
                .WithRequired(e => e.Proyectos2)
                .HasForeignKey(e => e.IdProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyectos>()
                .HasMany(e => e.Formulario3)
                .WithRequired(e => e.Proyectos3)
                .HasForeignKey(e => e.IdProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyectos>()
                .HasMany(e => e.Formulario4)
                .WithRequired(e => e.Proyectos4)
                .HasForeignKey(e => e.IdProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyectos>()
                .HasMany(e => e.Formulario5)
                .WithRequired(e => e.Proyectos5)
                .HasForeignKey(e => e.IdProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.resource1)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.permission)
                .WithRequired(e => e.resource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.resource11)
                .WithRequired(e => e.resource2)
                .HasForeignKey(e => e.parent);

            modelBuilder.Entity<role>()
                .Property(e => e.role1)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.permission)
                .WithRequired(e => e.role)
                .WillCascadeOnDelete(false);
        }
    }
}
