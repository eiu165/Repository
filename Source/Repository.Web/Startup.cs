using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Repository.Web.Startup))]
namespace Repository.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
