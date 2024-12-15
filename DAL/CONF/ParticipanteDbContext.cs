using TallerFinal.DTO.CONF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace TallerFinal.DAL.CONF
{
    public class ParticipanteDbContext : DbContext
    {
        public DbSet<Participante> Participantes { get; set; }

        public ParticipanteDbContext() : base(GetOptions()) { }

        private static DbContextOptions<ParticipanteDbContext> GetOptions()
        {
            // Obtener la cadena de conexión desde el archivo de configuración
            var connectionString = ConfigurationManager.ConnectionStrings["TallerFinalDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'TallerFinalDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<ParticipanteDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participante>().ToTable("conf_participante");

            modelBuilder.Entity<Participante>().HasKey(p => p.IdParticipante);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Compania)
                .HasMaxLength(100);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Telefono)
                .HasMaxLength(20);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Domicilio)
                .HasMaxLength(200);

            modelBuilder.Entity<Participante>()
                .Property(p => p.CallesTransversales)
                .HasMaxLength(100);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Ciudad)
                .HasMaxLength(100);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Region)
                .HasMaxLength(100);

            modelBuilder.Entity<Participante>()
                .Property(p => p.CodigoPostal)
                .HasMaxLength(10);

            modelBuilder.Entity<Participante>()
                .Property(p => p.Pais)
                .HasMaxLength(50);

            // Definición de columnas adicionales si es necesario
            modelBuilder.Entity<Participante>()
                .Property(p => p.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<Participante>()
                .Property(p => p.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<Participante>()
                .Property(p => p.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<Participante>()
                .Property(p => p.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            // Definir el estado como requerido
            modelBuilder.Entity<Participante>()
                .Property(p => p.Estado)
                .IsRequired();
        }
    }
}
