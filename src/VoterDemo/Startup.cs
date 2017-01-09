using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoterDemo.Startup))]
namespace VoterDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
