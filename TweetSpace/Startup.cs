using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TweetSpace.Startup))]
namespace TweetSpace
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
