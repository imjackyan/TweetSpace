using Microsoft.Owin;
using Owin;
using System;
using System.IO;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Streaminvi;

[assembly: OwinStartupAttribute(typeof(TweetSpace.Startup))]
namespace TweetSpace
{
    public partial class Startup {
        private static String tweetSep = "'+J8F";
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/tweetSmall.txt";
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            Auth.SetUserCredentials("vzdJU1JzERp4U29LNj0ojgeq9", "m4OJXaSfKyeRJIhUAFqDn6zPR3FsipQbckStPwEERNxgPzUs2W",
    "4807340086-Of26PfbUiE2vokwgVbBu0ckaJuugsywurvYZ0aL", "zecE50XS1XBuViE4euLgoIUwvvWjUYeJa5ByTWJVnSWqi");
            if (!File.Exists(path)){
                StreamWriter file = new StreamWriter(path);
                ISampleStream streamNoLoc = Tweetinvi.Stream.CreateSampleStream();
                streamNoLoc.AddTweetLanguageFilter("en");
                streamNoLoc.TweetReceived += (sender, args) =>
                {
                    file.Write(new TweetObj(args.Tweet.Text, args.Tweet.CreatedBy.Name, args.Tweet.CreatedBy.ScreenName,
                        args.Tweet.CreatedAt, args.Tweet.Coordinates, args.Tweet.Place, args.Tweet.Hashtags).ToString() + tweetSep);
                };
                streamNoLoc.StartStreamAsync();
            }
        }
    }
}
