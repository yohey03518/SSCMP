using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Swim.Startup))]
namespace Swim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
