using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace TweetSpace
{
    public partial class step3 : System.Web.UI.Page
    {
        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Sentana sen = new Sentana();
            ListBox1.Items.Clear();
            string text = TextBox1.Text;
            List<TweetObj> tweets;
            if (text.Length > 0)
            {
                string[] keywords = text.Split(',');
                tweets = TweetAnalysis.filterTweets(TweetAccess.tweetList, keywords);
            }
            else
            {
                tweets = TweetAccess.tweetList;
            }
            for (int i = 0; i < tweets.Count; i++)
            {
                ListBox1.Items.Add(tweets[i].text);
            }
        }

        // TODO
        // blank search
        // file paths
        //best, worst
        // LARGE DATA SET
        // BUTTON ON FIRST PAGE
        // AZURE
        // SEARCH WORDS

        protected void Button2_Click(object sender, EventArgs e)
        {
            string text = TextBox1.Text;
            DateTime lowest = TweetAccess.tweetList[0].time;
            DateTime highest = TweetAccess.tweetList[0].time;
            for (int i = 0; i < TweetAccess.tweetList.Count; i++)
            {
                if (TweetAccess.tweetList[i].time < lowest)
                {
                    lowest = TweetAccess.tweetList[i].time;
                }
                if (TweetAccess.tweetList[i].time > highest)
                {
                    highest = TweetAccess.tweetList[i].time;
                }
            }
            int numInts = 15;
            TimeSpan timeInterval = new TimeSpan(((highest - lowest).Ticks) / numInts);

            if (DropDownList1.Items[1].Selected)
            {
                List<double> freq = new List<double>();
                string[] keywords = text.Split(',');
                freq = TweetAnalysis.countKeywords(TweetAnalysis.tweetSort(TweetAccess.tweetList, lowest, timeInterval, numInts), keywords, true);
                Chart1.Series.Add("Series2");
                Chart1.Series["Series2"].ChartType = SeriesChartType.Line;
                Chart1.Series["Series2"].XValueType = ChartValueType.Time;
                DateTime x = lowest;
                Chart1.Series["Series2"].Color = Color.Blue;
                for (int i = 0; i < numInts; i++)
                {
                    x = x.Add(timeInterval);
                    Chart1.Series["Series2"].Points.AddXY(x, freq[i]);
                }

                Chart1.Series["Series2"].ChartArea = "ChartArea1";
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            }
            else
            {
                Sentana sen = new Sentana();
                List<List<TweetObj>> sorted = TweetAnalysis.tweetSort(TweetAccess.tweetList, lowest, timeInterval, numInts);
                double[] scores = new double[sorted.Count];
                double lowestS = sen.scoreTweet(sorted[0][0]);
                string lowestT = sorted[0][0].text;
                double highestS = sen.scoreTweet(sorted[0][0]);
                string highestT = sorted[0][0].text;
                for (int i = 0; i < scores.Length; i++)
                {
                    double accum = 0;
                    for (int j = 0; j < sorted[i].Count; j++)
                    {
                        double score = sen.scoreTweet(sorted[i][j]);
                        accum += score;
                        if (score < lowestS)
                        {
                            lowestS = score;
                            lowestT = sorted[i][j].text;
                        }
                        if (score > highestS)
                        {
                            highestS = score;
                            highestT = sorted[i][j].text;
                        }
                    }
                    if (accum == 0)
                    {
                        scores[i] = 0;
                    }
                    else {
                        scores[i] = accum / (sorted[i].Count);
                    }
                }
                Chart1.Series.Add("Positivity");
                Chart1.Series["Positivity"].ChartType = SeriesChartType.Line;
                Chart1.Series["Positivity"].XValueType = ChartValueType.Time;
                Chart1.Series["Positivity"].Color = Color.Blue;
                for (int i = 0; i < numInts; i++)
                {
                    Chart1.Series["Positivity"].Points.AddXY(lowest + new TimeSpan(i * timeInterval.Ticks), scores[i]);
                }
                Chart1.Series["Positivity"].ChartArea = "ChartArea1";
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
                //System.Diagnostics.Debug.WriteLine(lowestT);
                //System.Diagnostics.Debug.WriteLine(highestT);
            }
        }
    }
}

