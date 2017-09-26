using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_603211_PROKHORENKO.Startup))]
namespace _603211_PROKHORENKO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
