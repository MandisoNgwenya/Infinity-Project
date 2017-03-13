using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfinityProject.Startup))]
namespace InfinityProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
