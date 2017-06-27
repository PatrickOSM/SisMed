using Microsoft.Owin;
using Owin;
using SisMed.MVC;

[assembly: OwinStartup(typeof(Startup))]
namespace SisMed.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}