using Microsoft.Owin;
using Owin;
using System;
using Tweetinvi;

[assembly: OwinStartupAttribute(typeof(TweetSpace.Startup))]
namespace TweetSpace
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            Auth.SetUserCredentials("vzdJU1JzERp4U29LNj0ojgeq9", "m4OJXaSfKyeRJIhUAFqDn6zPR3FsipQbckStPwEERNxgPzUs2W",
    "4807340086-Of26PfbUiE2vokwgVbBu0ckaJuugsywurvYZ0aL", "zecE50XS1XBuViE4euLgoIUwvvWjUYeJa5ByTWJVnSWqi");
            
        }
    }
}
