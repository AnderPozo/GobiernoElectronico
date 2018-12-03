using System.Data.Entity;
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventoOrganizador>()
                .HasKey(eo => new { eo.EventoId, eo.OrganizadorId });

            modelBuilder.Entity<EventoOrganizador>()
                .HasRequired(eo => eo.Evento)
                .WithMany(e => e.EventoOrganizadores)
                .HasForeignKey(eo => eo.EventoId);

            modelBuilder.Entity<EventoOrganizador>()
                .HasRequired(eo => eo.Organizador)
                .WithMany(o => o.EventoOrganizadores)
                .HasForeignKey(eo => eo.OrganizadorId);
            

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}