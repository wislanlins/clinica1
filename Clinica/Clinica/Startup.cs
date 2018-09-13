using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clinica.Startup))]
namespace Clinica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
