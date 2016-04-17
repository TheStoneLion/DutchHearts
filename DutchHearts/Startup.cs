using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DutchHearts.Startup))]
namespace DutchHearts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
