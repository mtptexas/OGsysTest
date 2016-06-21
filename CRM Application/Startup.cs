using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM_Application.Startup))]
namespace CRM_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
