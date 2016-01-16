using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TweetSpace
{
    public partial class About : Page
    {
        Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (StreamReader _testData = new StreamReader(Server.MapPath("~/data.txt"), true))
            {
                ListBox1.Items.Add(_testData.ReadToEnd());
            }    
        }
    }
}