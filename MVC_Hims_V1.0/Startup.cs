using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Hims_V1._0.Startup))]
namespace MVC_Hims_V1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
