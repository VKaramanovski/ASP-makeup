using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class WebForm1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = @" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\vladimir\source\repos\WebSite2\WebSite2\App_Data\bazaASP.mdf; Integrated Security = True";
        SqlConnection conn = new SqlConnection(connectionString);
       

        conn.Open();
        string check_usr = "select count(*) from Students where username = '" + userBox.Text + "'";
        SqlCommand cmd = new SqlCommand(check_usr, conn);
        int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        conn.Close();

        if (temp == 1)
        {
            conn.Open();
            string check_pass = "select password from Students where username = '" + userBox.Text + "'";
            SqlCommand cmd_pass = new SqlCommand(check_pass, conn);
            string password = cmd_pass.ExecuteScalar().ToString();

            if (password == passBox.Text)
            {
                Session["New"] = userBox.Text;
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                Response.Write("Pass is incorect");
            }
        }
        else
        {
            Response.Write("Username is incorect");
        }
    }

}