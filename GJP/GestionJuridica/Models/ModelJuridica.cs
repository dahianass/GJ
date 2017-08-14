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

        public virtual DbSet<CamposAdicionales> CamposAdicionales { get; set; }
        public virtual DbSet<CamposTipos> CamposTipos { get; set; }
        public virtual DbSet<Chequeo> Chequeo { get; set; }
        public virtual DbSet<ChequeoTipo> ChequeoTipo { get; set; }
        public virtual DbSet<EstadosProcesales> EstadosProcesales { get; set; }
        public virtual DbSet<EstadosTipos> EstadosTipos { get; set; }
        public virtual DbSet<Paginas> Paginas { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<TipoProcesos> TipoProcesos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CamposAdicionales>()
                .HasMany(e => e.CamposTipos)
                .WithRequired(e => e.CamposAdicionales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chequeo>()
                .HasMany(e => e.ChequeoTipo)
                .WithRequired(e => e.Chequeo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadosProcesales>()
                .HasMany(e => e.EstadosTipos)
                .WithRequired(e => e.EstadosProcesales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paginas>()
                .HasMany(e => e.Permisos)
                .WithRequired(e => e.Paginas)
                .HasForeignKey(e => e.fk_IdPagina)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Permisos)
                .WithRequired(e => e.Rol)
                .HasForeignKey(e => e.fk_IdRol)
                .WillCascadeOnDelete(false);
        }
    }
}
