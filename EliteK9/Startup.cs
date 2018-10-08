using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EliteK9.Startup))]
namespace EliteK9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
