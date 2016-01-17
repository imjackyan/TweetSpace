using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetSpace
{
    public class TweetAnalysis
    {
        public static List<List<TweetObj>> tweetSort(List<TweetObj> tweets, DateTime initialTime, TimeSpan timeInterval, int numInts)
        {
            List<List<TweetObj>> final = new List<List<TweetObj>>();
            for(int i = 0; i < numInts; i++)
            {
                final.Add(new List<TweetObj>());
            }
            for (int i = 0; i < tweets.Count; i++)
            {
                if ((tweets[i].time) >= (initialTime + new TimeSpan(timeInterval.Ticks * numInts)))
                {
                    final[numInts - 1].Add(tweets[i]);
                }
                else
                {
                    if (Convert.ToInt32(Convert.ToDouble((tweets[i].time - initialTime).Ticks) / timeInterval.Ticks) >= numInts)
                    {
                        final[numInts - 1].Add(tweets[i]);
                    }
                    else {
                        final[Convert.ToInt32(Convert.ToDouble((tweets[i].time - initialTime).Ticks) / timeInterval.Ticks)].Add(tweets[i]);
                    }
                }
            }

            
            return final;
        }

        public static List<Double> countKeywords(List<List<TweetObj>> tweets, String[] keywords, bool percentage)
        {
            List<Double> counts = new List<Double>();
            for (int i = 0; i < tweets.Count; i++)
            {
                counts.Add(Convert.ToDouble((filterTweets(tweets[i], keywords).Count)));
                if (percentage)
                {
                    counts[i] = counts[i] / tweets[i].Count;
                }
            }
            return counts;
        }
		public static List<TweetObj> filterTweets(List<TweetObj> tweets, String[] keywords)
        {
            List<TweetObj> containsKeywords = new List<TweetObj>();
            for (int i = 0; i < keywords.Length; i++)
            {
                keywords[i] = keywords[i].ToLower();
            }
            
            foreach(TweetObj tweet in tweets)
            {
                foreach (String word in keywords)
                {
                    if (tweet.text.Contains(word))
                    {
                        containsKeywords.Add(tweet);
                        break;
                    }
                }
            }
            
            
            
            return containsKeywords;

        }
        //Unused method that only searches for keywords[i] as if it were an individual word
        public static List<TweetObj> filterTweetsTokened(List<TweetObj> tweets, String[] keywords)
        {
            List<TweetObj> containsKeywords = new List<TweetObj>();
            for (int i = 0; i < keywords.Length; i++)
            {
                keywords[i] = keywords[i].ToLower();
            }

            foreach (TweetObj tweet in tweets)
            {
                String[] token_tweet = tweet.text.Split(' ');
                for (int j = 0; j < token_tweet.Length; j++)
                {
                    if (Array.IndexOf(keywords, token_tweet[j].ToLower()) > -1)
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