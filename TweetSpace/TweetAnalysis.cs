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
            DateTime periodBound = initialTime.Add(timeInterval);
            for(int i = 0; i < numInts; i++)
            {
                final.Add(new List<TweetObj>());
            }
            for (int i = 0; i < tweets.Count; i++)
            {
                final[Convert.ToInt32((tweets[i].time - initialTime).TotalSeconds / timeInterval.TotalSeconds)].Add(tweets[i]);
            }
            
            return final;
        }

        public static List<Double> countKeywords(List<List<TweetObj>> tweets, String[] keywords, bool percentage)
        {
            List<Double> counts = new List<Double>();
            for (int i = 0; i < tweets.Count; i++)
            {
                counts.Add(double.Parse((filterTweets(tweets[i], keywords).Count)));
                if (percentage)
                {
                    counts[i] = counts[i] / tweets[i].Count;
                }
            }
            return counts;
        }
    }
}