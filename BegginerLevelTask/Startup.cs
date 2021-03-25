using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BegginerLevelTask.Startup))]
namespace BegginerLevelTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
