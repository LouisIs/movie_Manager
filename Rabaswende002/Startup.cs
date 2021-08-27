using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(Rabaswende002.Startup))]

namespace Rabaswende002
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
        }
    }
}
