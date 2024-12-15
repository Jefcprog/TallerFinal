using TallerFinal.DTO.CONF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace TallerFinal.DAL.CONF
{
    public class ConferenciaDbContext : DbContext
    {
        public DbSet<Conferencia> Conferencias { get; set; }

        public ConferenciaDbContext() : base(GetOptions()) { }

        private static DbContextOptions<ConferenciaDbContext> GetOptions()
        {
            // Obtener la cadena de conexión desde el archivo de configuración
            var connectionString = ConfigurationManager.ConnectionStrings["TallerFinalDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'TallerFinalDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<ConferenciaDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conferencia>().ToTable("conf_conferencia");

            modelBuilder.Entity<Conferencia>().HasKey(c => c.IdConferencia);

            modelBuilder.Entity<Conferencia>()
                .Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Conferencia>()
                .Property(c => c.Fecha)
                .IsRequired();

            modelBuilder.Entity<Conferencia>()
                .Property(c => c.Lugar)
                .HasMaxLength(100);

            // Definición de columnas adicionales si es necesario
            modelBuilder.Entity<Conferencia>()
                .Property(c => c.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<Conferencia>()
                .Property(c => c.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<Conferencia>()
                .Property(c => c.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<Conferencia>()
                .Property(c => c.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            // Definir el estado como requerido
            modelBuilder.Entity<Conferencia>()
                .Property(c => c.Estado)
                .IsRequired();
        }
    }
}
