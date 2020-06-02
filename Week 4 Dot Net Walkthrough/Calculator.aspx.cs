using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week_4_Dot_Net_Walkthrough
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Not appearing
            Console.WriteLine("Page loaded");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Adding number");
            decimal i = Convert.ToDecimal(TextBox1.Text);
            decimal j = Convert.ToDecimal(TextBox2.Text);
            string k = TextBox4.Text;
            decimal r = 0.0m;
            switch (k)
            {
                case "*":
                    r = i * j;
                    break;
                case "/":
                    r = i / j;
                    break;
                case "-":
                    r = i - j;
                    break;
                case "+":
                    r = i + j;
                    break;
                default:
                    r = i + j;
                    break;
            }

            TextBox3.Text = r.ToString();
        }
    }
}