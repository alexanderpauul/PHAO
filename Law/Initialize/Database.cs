namespace Law.Initialize
{
    using Law.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Database
    {
        public Database()
        {
        }

        private static ApplicationUserManager _userManager;
        public static ApplicationUserManager UserManager
        {
            get
            {
                ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private static RoleManager<IdentityRole> _roleManager;
        public static RoleManager<IdentityRole> RoleManager
        {
            get
            {
                RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
                return _roleManager;
            }
            private set
            {
                _roleManager = value;
            }
        }

        private const string ROLE_ADMINISTRATOR = "Administrator";
        private const string USER_PASSWORD = "@lexi7i9PHA0";
        private const string USER_NAME = "alexanderpauul";
        private const string USER_EMAIL = "alexanderpauul@hotmail.com";

        public static void Initial(ApplicationDbContext context)
        {
            if (!RoleManager.RoleExists(ROLE_ADMINISTRATOR))
            {
                var result = RoleManager.Create(new IdentityRole(ROLE_ADMINISTRATOR));
            }

            var persona = context.Personas
                            .SqlQuery("SELECT * FROM Personas")
                            .FirstOrDefault();

            if (persona == null)
            {
                persona = context.Personas.Add(new Persona
                {
                    PersonaId = Guid.NewGuid(),
                    Nombre = "Alexander",
                    PrimerApellido = "Paulino",
                    SegundoApellido = null,
                    ECivilId = 0,
                    EstadoId = 1
                });

                context.SaveChanges();
            }
            
            var user = UserManager.FindByName(USER_NAME);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = USER_NAME,
                    Email = USER_EMAIL,
                    EmailConfirmed = true,
                    IsDisable = false,
                    PersonaId = persona.PersonaId 
                };

                IdentityResult userResult = UserManager.Create(user, USER_PASSWORD);
                if (userResult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, ROLE_ADMINISTRATOR);
                }
            }
        }

        public static void Default(ApplicationDbContext context)
        {
            var user = UserManager.FindByName(USER_NAME);

            var tEstado = context.TEstados
                                 .SqlQuery("SELECT * FROM TEstados")
                                 .FirstOrDefault();

            if (tEstado == null)
            {
                tEstado = context.TEstados.Add(new TEstado
                {
                    DscTEstado = "General",
                    Habilitado = true,
                    UserId = user.Id,
                    Registro = DateTime.Now,
                    Modificacion = DateTime.Now,
                    Identificador = Guid.NewGuid()
                });
            }

            var estados = new List<Estado>
            {
                new Estado
                {
                    TEstadoId = tEstado.TEstadoId,
                    DscEstado = "Activo",
                    Habilitado = true,
                    UserId = user.Id,
                    Registro = DateTime.Now,
                    Modificacion = DateTime.Now,
                    Identificador = Guid.NewGuid()
                },
                new Estado
                {
                    TEstadoId = tEstado.TEstadoId,
                    DscEstado = "Inactivo",
                    Habilitado = true,
                    UserId = user.Id,
                    Registro = DateTime.Now,
                    Modificacion = DateTime.Now,
                    Identificador = Guid.NewGuid()
                }
            };

            var estado = context.Estados
                     .SqlQuery("SELECT * FROM Estados")
                     .FirstOrDefault();

            if (estado == null)
            {
                context.Estados.AddRange(estados);
            }

            context.SaveChanges();
        }
    }
}