using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweetSpace
{
    public partial class step2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button5.Visible = false;
            Button4.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "Loading...";      
            TweetAccess.searchTweets();
            Label1.Text = "Loaded: " + TweetAccess.tweetList.Count;
            Button3.Enabled = false;            
            Button1.Enabled = false;
            Button5.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button2.Enabled = false;
            Button1.Enabled = false;
            Button4.Visible = true;
            TweetAccess.stream(this.Label1);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {            
            Button5.Visible = true;
            Button4.Visible = false;
        }

    }
}