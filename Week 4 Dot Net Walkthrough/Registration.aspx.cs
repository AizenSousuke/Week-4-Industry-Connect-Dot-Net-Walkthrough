using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Week_4_Dot_Net_Walkthrough.Services;

namespace Week_4_Dot_Net_Walkthrough
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bRegister_Click(object sender, EventArgs e)
        {
            string gender = "";
            //Response.Write("Your Name is " + tbName.Text + ". ");
            if (rbMale.Checked)
            {
                //Response.Write("Your Gender: " + rbMale.Text + ". ");
                gender = "Male";
            }
            if (rbFemale.Checked)
            {
                //Response.Write("Your Gender: " + rbFemale.Text + ". ");
                gender = "Female";
            }
            if (rbNotApplicable.Checked)
            {
                //Response.Write("Your Gender: " + rbNotApplicable.Text + ". ");
                gender = "NA";
            }

            //Response.Write("You know " + (cbDotNet.Checked ? cbDotNet.Text : "") + (cbSQL.Checked ? " and " + cbSQL.Text : "."));
            //Response.Write("You live in: " + list.SelectedValue + ". \n\n");

            // Save data to database here

            SQLConnectionUsingADO sql = new SQLConnectionUsingADO();
            sql.Init();
            sql.Open();
            sql.Create(tbName.Text, tbEmail.Text, gender, (cbDotNet.Checked ? cbDotNet.Text : "") + (cbSQL.Checked && cbDotNet.Checked ? "&" : "") + (cbSQL.Checked ? cbSQL.Text : ""), list.Text);
            sql.ExecuteNonQuery();
            sql.Close();

            Response.Write("You have registered successfully!");
            Response.Write("\n\n");

            //string connectionString = @"Data Source=THEACCELERATOR;Initial Catalog=Week6Database;Integrated Security=True";
            //SqlConnection connection = new SqlConnection(connectionString);
            //SqlCommand sqlCommand = new SqlCommand();

            //sqlCommand.CommandText = "SQL Command";
            //sqlCommand.CommandType = CommandType.Text;
            //sqlCommand.Connection = connection;

            //connection.Open();
            //sqlCommand.ExecuteNonQuery();
            //connection.Close();


        }

        protected void bUpdate_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (rbMale.Checked)
            {
                //Response.Write("Your Gender: " + rbMale.Text + ". ");
                gender = "Male";
            }
            if (rbFemale.Checked)
            {
                //Response.Write("Your Gender: " + rbFemale.Text + ". ");
                gender = "Female";
            }
            if (rbNotApplicable.Checked)
            {
                //Response.Write("Your Gender: " + rbNotApplicable.Text + ". ");
                gender = "NA";
            }
            // Save data to database here

            SQLConnectionUsingADO sql = new SQLConnectionUsingADO();
            sql.Init();
            sql.Open();
            sql.Update(tbName.Text, tbEmail.Text, gender, (cbDotNet.Checked ? cbDotNet.Text : "") + (cbSQL.Checked && cbDotNet.Checked ? "&" : "") + (cbSQL.Checked ? cbSQL.Text : ""), list.Text);
            sql.ExecuteNonQuery();
            sql.Close();

            Response.Write("Your details has been updated. \n\n");
        }

        protected void bFetch_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text.Length > 0)
            {
                // Get data from database here

                SQLConnectionUsingADO sql = new SQLConnectionUsingADO();
                sql.Init();
                sql.Open();
                ArrayList data = sql.Get(tbEmail.Text);
                sql.Close();
                if (data.Count > 0)
                {
                    tbName.Text = data[1].ToString();
                    switch (data[3].ToString())
                    {
                        case "Male":
                            rbMale.Checked = true;
                            rbFemale.Checked = false;
                            rbNotApplicable.Checked = false;
                            break;
                        case "Female":
                            rbMale.Checked = false;
                            rbFemale.Checked = true;
                            rbNotApplicable.Checked = false;
                            break;
                        default:
                            rbFemale.Checked = false;
                            rbFemale.Checked = false;
                            rbNotApplicable.Checked = true;
                            break;
                    }
                    list.SelectedValue = data[5].ToString();
                    Response.Write("Loaded past data.");
                }
                else
                {
                    Response.Write("No past data.");
                }
            }
            else
            {
                Response.Write("Enter an email to check.");
            }
        }
    }
}