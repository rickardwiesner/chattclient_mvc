using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChattClient_MVC.Startup))]
namespace ChattClient_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
