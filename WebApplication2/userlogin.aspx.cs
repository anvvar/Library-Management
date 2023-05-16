using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // user login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                string username=TextBox1.Text.Trim();
                string password=TextBox2.Text.Trim();

                SqlConnection con = new SqlConnection(strcon);
                con.Open();


            string query = "SELECT COUNT(*) FROM member_master_tbl  WHERE member_id = @Username AND password = @Password";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
                int count =(int)cmd.ExecuteScalar();
             if (count>0)
                {
                    Session["LoggedIn"]=true;
                    Response.Redirect("userprofile.aspx");
                }
             else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }


            }
        catch (Exception ex) {
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("signuppage.aspx");
        }
    }
}



   