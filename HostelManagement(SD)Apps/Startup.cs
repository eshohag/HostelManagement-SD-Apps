using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HostelManagement_SD_Apps.Startup))]
namespace HostelManagement_SD_Apps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
