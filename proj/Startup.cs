using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proj.Startup))]
namespace proj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
