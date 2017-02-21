using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AulaMVC.Startup))]
namespace AulaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
