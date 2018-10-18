namespace Law.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Propiedades de usuario agragadas
        public Guid PersonaId { get; set; }  // 
        public virtual Persona Persona { get; set; }
        public bool IsDisable { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }


        public System.Data.Entity.DbSet<Law.Models.Persona> Personas { get; set; }
        public System.Data.Entity.DbSet<Law.Models.TEstado> TEstados { get; set; }
        public System.Data.Entity.DbSet<Law.Models.Estado> Estados { get; set; }
        public System.Data.Entity.DbSet<Law.Models.TProyecto> TProyectos { get; set; }
        public System.Data.Entity.DbSet<Law.Models.TOrganismo> TOrganismos { get; set; }
        public System.Data.Entity.DbSet<Law.Models.Pais> Paises { get; set; }
        public System.Data.Entity.DbSet<Law.Models.Organismo> Organismo { get; set; }
    }
}