using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweetSpace
{
    public partial class step2 : System.Web.UI.Page
    {
        private static Boolean count = false;
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "Loading...";      
            TweetAccess.searchTweets();
            Label1.Text = "Loaded: " + TweetAccess.tweetList.Count;
            Button3.Enabled = false;            
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button5.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {            
            count = true;
            Button2.Enabled = false;
            Button1.Enabled = false;
            Button3.Enabled = false;
            Button4.Visible = true;
            TweetAccess.stream();            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("step3.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {            
            Button5.Visible = true;
            Button4.Visible = false;
            TweetAccess.stopStream();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (count)
            {
                //System.Diagnostics.Debug.WriteLine(TweetAccess.tweetList.Count.ToString());
                Label1.Text = "Loaded: " + TweetAccess.tweetList.Count.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Startup.path))
            {
                System.Diagnostics.Debug.WriteLine("Reading from File");
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button3.Enabled = false;
                Button4.Enabled = false;
                Button5.Visible = true;
                TweetAccess.tweetList = FileIO.read(Startup.path);
                Label1.Text = "Loaded: " + TweetAccess.tweetList.Count.ToString();
            }
        }
    }
}