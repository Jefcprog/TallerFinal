using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using TallerFinal.DTO.CONF;

namespace TallerFinal.DAL.CONF
{
    public class ParticipacionDbContext : DbContext
    {
        public DbSet<Participacion> Participaciones { get; set; }

        public ParticipacionDbContext() : base(GetOptions()) { }

        private static DbContextOptions<ParticipacionDbContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TallerFinalDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'TallerFinalDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<ParticipacionDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la tabla y las relaciones
            modelBuilder.Entity<Participacion>().ToTable("participaciones");

            // Definición de las claves primarias
            modelBuilder.Entity<Participacion>().HasKey(p => p.IdParticipacion);

            // Propiedades adicionales
            modelBuilder.Entity<Participacion>()
                .Property(p => p.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<Participacion>()
                .Property(p => p.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<Participacion>()
                .Property(p => p.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<Participacion>()
                .Property(p => p.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            modelBuilder.Entity<Participacion>()
                .Property(p => p.Estado)
                .IsRequired();

            // Configurar las relaciones de claves foráneas
            modelBuilder.Entity<Participacion>()
                .HasOne(p => p.IdConferenciaNavigation)
                .WithMany()
                .HasForeignKey(p => p.IdConferencia)
                .OnDelete(DeleteBehavior.Cascade);  // Define el comportamiento de eliminación

            modelBuilder.Entity<Participacion>()
                .HasOne(p => p.IdParticipanteNavigation)
                .WithMany()
                .HasForeignKey(p => p.IdParticipante)
                .OnDelete(DeleteBehavior.Cascade);  // Define el comportamiento de eliminación
        }
    }
}
