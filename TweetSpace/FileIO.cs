using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetSpace
{
    class FileIO
    {
        private static String tweetSep = "'+J8F";
        public static void write(List<TweetObj> tweets, String path)
        {
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < tweets.Count; i++)
            {
                file.Write(tweets[i].ToString() + tweetSep);
            }
            file.Close();
        }

        public static List<TweetObj> read(String path)
        {
            List<TweetObj> tweets = new List<TweetObj>();
            String lines = File.ReadAllText(path);
            String[] text = lines.Split(new String[] { tweetSep }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length; i++)
            {
                tweets.Add(new TweetObj(text[i]));
            }
            return tweets;
        }
    }
}
