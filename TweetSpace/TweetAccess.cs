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


namespace TweetSpace
{
    class TweetAccess
    {
        public static Boolean location { get; set; }
        public static double lat { get; set; }
        public static double longi { get; set; }
        public static double r { get; set; }
        public static void stuff()
        {
            test();
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

        public static void test()
        {
            Auth.SetUserCredentials("vzdJU1JzERp4U29LNj0ojgeq9", "m4OJXaSfKyeRJIhUAFqDn6zPR3FsipQbckStPwEERNxgPzUs2W",
                "4807340086-Of26PfbUiE2vokwgVbBu0ckaJuugsywurvYZ0aL", "zecE50XS1XBuViE4euLgoIUwvvWjUYeJa5ByTWJVnSWqi");
            var searchParameter = new TweetSearchParameters("*");
            searchParameter.Lang = Language.English;
            searchParameter.MaximumNumberOfResults = 100000;
            var tweets = Search.SearchTweets(searchParameter);
            StreamWriter file = new StreamWriter("test.txt");
            List<Tweetinvi.Logic.Tweet> asdf = new List<Tweetinvi.Logic.Tweet>();
            using (var sequenceEnum = tweets.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    asdf.Add((Tweetinvi.Logic.Tweet)sequenceEnum.Current);
                }
            }
            Console.WriteLine(asdf[234].Coordinates);
            Console.WriteLine(asdf[234].Hashtags[0]);
            Console.WriteLine(asdf[234].CreatedBy.Name);
            Console.WriteLine(asdf[234].CreatedBy.ScreenName);
            Console.ReadKey();
            file.Close();
        }

        public static void stream()
        {
            Auth.SetUserCredentials("vzdJU1JzERp4U29LNj0ojgeq9", "m4OJXaSfKyeRJIhUAFqDn6zPR3FsipQbckStPwEERNxgPzUs2W",
                "4807340086-Of26PfbUiE2vokwgVbBu0ckaJuugsywurvYZ0aL", "zecE50XS1XBuViE4euLgoIUwvvWjUYeJa5ByTWJVnSWqi");
            var stream = Tweetinvi.Stream.CreateSampleStream();
            stream.AddTweetLanguageFilter("en");
            stream.TweetReceived += (sender, args) =>
            {
                Console.WriteLine(args.Tweet);
            };
            stream.StartStream();
        }
    }
}
