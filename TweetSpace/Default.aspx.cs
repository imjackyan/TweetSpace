using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweetSpace
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            TweetAccess.wipeTweets();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TweetAccess.location = false;
            Response.Redirect("step2.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TweetAccess.location = true;
            TweetAccess.longi = Double.Parse(TextBox1.Text);
            TweetAccess.lat = Double.Parse(TextBox3.Text);
            TweetAccess.r = Double.Parse(TextBox2.Text);
            Response.Redirect("step2.aspx");
        }
    }
}