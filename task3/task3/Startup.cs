using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(task3.Startup))]
namespace task3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
