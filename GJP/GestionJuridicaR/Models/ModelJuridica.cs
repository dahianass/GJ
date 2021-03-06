namespace GestionJuridicaR.Models
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
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<smlv> smlv { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<TipoProcesos> TipoProcesos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposFormulario)
                .WithRequired(e => e.CamposAdicionales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos)
                .WithRequired(e => e.CamposAdicionales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo)
                .WithRequired(e => e.Chequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Circuito>()
                .HasMany(e => e.Municipio)
                .WithRequired(e => e.Circuito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contratos>()
                .HasMany(e => e.Proyectos)
                .WithRequired(e => e.Contratos)
                .HasForeignKey(e => e.IdContratos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distrito>()
                .HasMany(e => e.Circuito)
                .WithRequired(e => e.Distrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosFormulario>()
                .HasMany(e => e.ChequeoFormulario)
                .WithRequired(e => e.EstadosFormulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos)
                .WithRequired(e => e.EstadosProcesales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.CamposFormulario)
                .WithRequired(e => e.Formulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.EstadosFormulario)
                .WithRequired(e => e.Formulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Historia)
                .WithRequired(e => e.Formulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formulario>()
                .HasMany(e => e.Pdtes)
                .WithRequired(e => e.Formulario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Formulario)
                .WithRequired(e => e.Municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.Juzgado)
                .WithRequired(e => e.Municipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Naturaleza>()
                .HasMany(e => e.Juzgado)
                .WithRequired(e => e.Naturaleza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paginas>()
                .HasMany(e => e.Permisos)
                .WithRequired(e => e.Paginas)
                .HasForeignKey(e => e.fk_IdPagina)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyectos>()
                .HasMany(e => e.Formulario)
                .WithRequired(e => e.Proyectos)
                .HasForeignKey(e => e.IdProyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Permisos)
                .WithRequired(e => e.Rol)
                .HasForeignKey(e => e.fk_IdRol)
                .WillCascadeOnDelete(false);
        }
    }
}
