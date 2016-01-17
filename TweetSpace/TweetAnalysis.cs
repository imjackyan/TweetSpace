using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetSpace
{
    public class TweetAnalysis
    {
        public List<List<TweetObj>> Tweetsort(List<TweetObj> tweets, DateTime initialTime, TimeSpan timeInterval)
        {
            List<List<TweetObj>> final = new List<List<TweetObj>>();
            DateTime periodBound = initialTime.Add(timeInterval);
            bool run = true;

            while (run)
            {
                List<TweetObj> period = new List<TweetObj>();
                run = false;
                for (int i = 0; i < tweets.Count; i++)
                {
                    if (tweets[i].time.CompareTo(initialTime) >= 0 && tweets[i].time.CompareTo(periodBound) < 0)
                    {
                        period.Add(tweets[i]);
                        run = true;
                    }
                }
                final.Add(period);
                initialTime = initialTime.Add(timeInterval);
                periodBound = initialTime.Add(timeInterval);
            }

            return final;
        }
		public static List<TweetObj> filterTweets(List<TweetObj> tweets, String[] keywords)
        {
            List<TweetObj> containsKeywords = new List<TweetObj>();

            foreach (TweetObj tweet in tweets)
            {
                String[] token_tweet = tweet.text.split(' ');
                for (int j = 0; j < token_tweet.Length; j++)
                {
                    if (Array.IndexOf(keywords, token_tweet[j]) > -1)
                    {
                        //Add tweets[i] to new List of TweetObj
                        containsKeywords.Add(tweet);
                        break;
                    }
                }
            }

            return containsKeywords;

        }
    }
}