using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoccerTrainingManager.Startup))]
namespace SoccerTrainingManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
