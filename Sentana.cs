﻿using System;

public class Sentana
{
    public string[] negWords { get; set; }
    public double[] negScores { get; set; }
    public string[] posWords { get; set; }
    public double[] posScores { get; set; }

    public Sentana()
	{
        string[] negList = System.IO.File.ReadAllLines(@"C:\Users\Regaria\Desktop\Sentana\TweetSpace\TweetSpace\sentana_data\tweet-.txt");
        string[] posList = System.IO.File.ReadAllLines(@"C:\Users\Regaria\Desktop\Sentana\TweetSpace\TweetSpace\sentana_data\tweet+.txt");

        this.negWords = new string[negList.Length];
        this.negScores = new double[negList.Length];

        this.posWords = new string[posList.Length];
        this.posScores = new double[posList.Length];

        for (int i = 0; i < this.negList.Length; i++)
        {
            string[] property1 = negList[i].Split('\t');
            this.negWords[i] = property1[0];
            this.negScores[i] = Convert.ToDouble(property1[1]);
        }

        for (int i = 0; i < this.posList.Length; i++)
        {
            string[] property2 = posList[i].Split('\t');
            this.posWords[i] = property2[0];
            this.posScores[i] = Convert.ToDouble(property2[1]);
        }


    }
    public double scoreTweet(TweetObj tweet)
    {
        string[] token_tweet = tweet.text.split(' ');
        double score = 0;

        foreach (string token in token_tweet)
        {
            int f = find(this.negWords, token);
            if (f > -1)
            {
                score -= this.negScores[f];
            }
            f = find(this.posWords, token);
            if (f > -1)
            {
                score += this.posScores[f];
            }
        }
        return score;


    }
    public int find(string[] list, string token)
    {
        return Array.IndexOf(list, token);
    }


}
