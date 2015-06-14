using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autores.Startup))]
namespace Autores
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
