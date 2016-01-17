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
            Chart1.Series["Series2"].ChartType = SeriesChartType.Line;
            
            Chart1.Series["Series2"].XValueType = ChartValueType.DateTime;
            System.DateTime x;


            for (int i = 0; i < 20; i++)
            {
                x = new System.DateTime(2016, 1, 1+i);
                Chart1.Series["Series2"].Points.AddXY(x.ToOADate(), rnd.Next(50));
            }

            Chart1.Series["Series2"].ChartArea = "ChartArea1";
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
        }
             
    }
}
    
