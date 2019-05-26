using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATMMvc.Startup))]
namespace ATMMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
