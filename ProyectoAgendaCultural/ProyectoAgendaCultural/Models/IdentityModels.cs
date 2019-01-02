using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoAgendaCultural.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Contructor
        public ApplicationDbContext()
            : base("AgendaCulturalDB", throwIfV1Schema: false)
        {
        }

        //Context de las entidades de la BD
        public DbSet<Provincia> ProvinciaDb { get; set; }
        public DbSet<Ciudad> CiudadDb { get; set; }
        public DbSet<Direccion> DireccionDb { get; set; }
        public DbSet<Categoria> CategoriaDb { get; set; }
        public DbSet<Lugar> LugarDb { get; set; }
        public DbSet<Evento> EventoDb { get; set; }
        public DbSet<Organizador> OrganizadorDb { get; set; }
        public DbSet<EventoOrganizador> EventoOrganizadorDb { get; set; }
        public DbSet<Artista> ArtistaDb { get; set; }
        public DbSet<Presentacion> PresentacionDb { get; set; }
        public DbSet<Participante> ParticipanteDb { get; set; }
        public DbSet<Calendario> CalendarioDb { get; set; }
        public DbSet<Asistencia> AsistenciaDb { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            /*
            modelBuilder.Entity<EventoOrganizador>()
                .HasKey(eo => new { eo.EventoId, eo.OrganizadorId });

            modelBuilder.Entity<EventoOrganizador>()
                .HasRequired(eo => eo.Evento)
                .WithMany(e => e.EventoOrganizadores)
                .HasForeignKey(eo => eo.EventoId);

            modelBuilder.Entity<EventoOrganizador>()
                .HasRequired(eo => eo.Organizador)
                .WithMany(o => o.EventoOrganizadores)
                .HasForeignKey(eo => eo.OrganizadorId); */

          /*  modelBuilder.Entity<Direccion>()
            .HasOptional(d => d.Lugares)
            .WithMany()
            .WillCascadeOnDelete(false);*/
        }

        public System.Data.Entity.DbSet<ProyectoAgendaCultural.Models.ClasesSP.SPEventos> SPEventos { get; set; }

        public System.Data.Entity.DbSet<ProyectoAgendaCultural.Models.ClasesSP.DetallarEvento> DetallarEventoes { get; set; }
    }
}