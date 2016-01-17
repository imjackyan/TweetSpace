using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;
using Tweetinvi.Core.Interfaces.Streaminvi;
using System.Web.UI.WebControls;

namespace TweetSpace
{
    class TweetAccess
    {
        public static Boolean location { get; set; }
        public static double lat { get; set; }
        public static double longi { get; set; }
        public static double r { get; set; }
        public static List<TweetObj> tweetList { get; set; }
        private static ISampleStream streamNoLoc = Tweetinvi.Stream.CreateSampleStream();
        private static IFilteredStream streamLoc = Tweetinvi.Stream.CreateFilteredStream();
        public static void stuff()
        {
            //test();
            //Console.Read();
            //List<TweetObj> tweetList = new List<TweetObj>();
            //Auth.SetUserCredentials("vzdJU1JzERp4U29LNj0ojgeq9", "m4OJXaSfKyeRJIhUAFqDn6zPR3FsipQbckStPwEERNxgPzUs2W",
            //    "4807340086-Of26PfbUiE2vokwgVbBu0ckaJuugsywurvYZ0aL", "zecE50XS1XBuViE4euLgoIUwvvWjUYeJa5ByTWJVnSWqi");
            //var searchParameter = new TweetSearchParameters(new GeoCode(-79.8667, 43.25, 5, DistanceMeasure.Miles));
            //searchParameter.Lang = Language.English;
            //searchParameter.MaximumNumberOfResults = 100000;
            //var tweets = Search.SearchTweets(searchParameter);
            //int a = 0;
            //using (var sequenceEnum = tweets.GetEnumerator())
            //{
            //    while (sequenceEnum.MoveNext())
            //    {
            //        //file.WriteLine(sequenceEnum.Current.Text + "   " + sequenceEnum.Current.CreatedAt);
            //        //Console.WriteLine(sequenceEnum.Current.Text + sequenceEnum.Current.CreatedAt);
            //        //Console.WriteLine(sequenceEnum.Current.CreatedAt.ToString());
            //        //a++;
            //        tweetList.Add(new TweetObj(sequenceEnum.Current.Text, sequenceEnum.Current.CreatedBy.Name, sequenceEnum.Current.CreatedBy.ScreenName,
            //            sequenceEnum.Current.CreatedAt, sequenceEnum.Current.Coordinates, sequenceEnum.Current.Place, sequenceEnum.Current.Hashtags));
            //        a++;
            //    }
            //}
            //Console.WriteLine(a);
            //for (int i = 0; i < tweetList.Count; i++)
            //{
            //    Console.WriteLine(new TweetObj(tweetList[i].ToString()).text);
            //}
            //FileIO.write(tweetList, "test.txt");
            //Console.Read();


            //List<TweetObj> tweets= FileIO.read("test.txt");
            //for (int i = 0; i<tweets.Count; i++)
            //{
            //    Console.WriteLine(tweets[i].text);
            //}
            //Console.ReadKey();

        }

        public static void searchTweets()
        {
            tweetList = new List<TweetObj>();
            TweetSearchParameters searchParameter;
            if (location)
            {
                searchParameter = new TweetSearchParameters(new GeoCode(longi, lat, r, DistanceMeasure.Kilometers));
            } else
            {
                searchParameter = new TweetSearchParameters("*");
            }            
            searchParameter.Lang = Language.English;
            searchParameter.MaximumNumberOfResults = 250;
            var tweets = Search.SearchTweets(searchParameter);
            using (var sequenceEnum = tweets.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    tweetList.Add(new TweetObj(sequenceEnum.Current.Text, sequenceEnum.Current.CreatedBy.Name, sequenceEnum.Current.CreatedBy.ScreenName,
                        sequenceEnum.Current.CreatedAt, sequenceEnum.Current.Coordinates, sequenceEnum.Current.Place, sequenceEnum.Current.Hashtags));
                }
            }
        }

        public static void stream()
        {
            tweetList = new List<TweetObj>();
            if (!location)
            {

                streamNoLoc.AddTweetLanguageFilter("en");
                streamNoLoc.TweetReceived += (sender, args) =>
                {
                    tweetList.Add(new TweetObj(args.Tweet.Text, args.Tweet.CreatedBy.Name, args.Tweet.CreatedBy.ScreenName,
                        args.Tweet.CreatedAt, args.Tweet.Coordinates, args.Tweet.Place, args.Tweet.Hashtags));
                };
                streamNoLoc.StartStreamAsync();
            }
            else
            {
                streamLoc.AddTweetLanguageFilter("en");
                streamLoc.AddLocation(new Coordinates(longi - r, lat-r), new Coordinates(longi + r, lat + r));
                streamLoc.MatchingTweetAndLocationReceived += (sender, args) =>
                {
                    tweetList.Add(new TweetObj(args.Tweet.Text, args.Tweet.CreatedBy.Name, args.Tweet.CreatedBy.ScreenName,
                        args.Tweet.CreatedAt, args.Tweet.Coordinates, args.Tweet.Place, args.Tweet.Hashtags));
                };
                streamLoc.StartStreamMatchingAllConditionsAsync();
            }
        }

        public static void stopStream()
        {
            if (location)
            {
                streamLoc.StopStream();
            }
            else
            {
                streamNoLoc.StopStream();
            }
        }

        public static void wipeTweets()
        {
            tweetList = new List<TweetObj>();
        }
        
    }
}
