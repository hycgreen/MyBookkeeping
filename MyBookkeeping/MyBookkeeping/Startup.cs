using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBookkeeping.Startup))]
namespace MyBookkeeping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}