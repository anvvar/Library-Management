using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    string username= TextBox1.Text.Trim();
                    string password= TextBox2.Text.Trim() ;

                    string query = "SELECT * FROM admin_login_tbl WHERE username = @Username AND password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username",username) ;
                        cmd.Parameters.AddWithValue("@Password",password);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Response.Write("<script>alert('Successful login');</script>");
                                Session["username"] = dr.GetValue(0).ToString();
                                Session["fullname"] = dr.GetValue(2).ToString();
                                Session["role"] = "admin";
//                                Session["status"] = dr.GetValue(10).ToString();
                            }
                            Response.Redirect("homepage.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid credentials');</script>");
                        }

                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



    }
}