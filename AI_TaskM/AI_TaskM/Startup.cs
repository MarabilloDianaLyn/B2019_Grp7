using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AI_TaskM.Startup))]
namespace AI_TaskM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
