using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Law.Startup))]
namespace Law
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
