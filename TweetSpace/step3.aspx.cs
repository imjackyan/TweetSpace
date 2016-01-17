using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication1
{
    public partial class step3 : System.Web.UI.Page
    {
        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add(rnd.Next().ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Chart1.Series.Add("Series2");
            Chart1.Series["Series2"].ChartType = SeriesChartType.Column;
            for(int i = 0;i<10;i++){
                Chart1.Series["Series2"].Points.AddXY(i,rnd.Next(50));
            }
            Chart1.Series["Series2"].ChartArea = "ChartArea1";
        }
             
    }
}
    
