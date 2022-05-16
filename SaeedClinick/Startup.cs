using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaeedClinick.Startup))]
namespace SaeedClinick
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
