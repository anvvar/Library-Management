using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    ShowUserButtons(true);
                    ShowAdminButtons(false);
                    LinkButton6.Visible =true; // admin login link button
                }
                else if (Session["role"] != null && Session["role"].ToString() == "user")
                {
                    ShowUserButtons(false);
                    ShowAdminButtons(false);
                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + (Session["username"] ?? "User").ToString();
                }
                else if (Session["role"].ToString() == "admin")
                {
                    ShowUserButtons(false);
                    ShowAdminButtons(true);
                   
                    LinkButton3.Visible = true;// logout link button
                   
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void ShowUserButtons(bool visible)
        {
            LinkButton1.Visible = visible; // user login link button
            LinkButton2.Visible = visible; // sign up link button
            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button
        }

        private void ShowAdminButtons(bool visible)
        {
            
            LinkButton8.Visible = visible; // book inventory link button
            LinkButton9.Visible = visible; // book issuing link button
            LinkButton10.Visible = visible; // member management link button
            LinkButton11.Visible = visible; // author management link button
            LinkButton12.Visible = visible; // publisher management link button
        }
    

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagment.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventorypage.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuingpage.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signuppage.aspx");
        }
        //logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button

            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button


            LinkButton6.Visible = true; // admin login link button
            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // publisher management link button
            LinkButton8.Visible = false; // book inventory link button
            LinkButton9.Visible = false; // book issuing link button
            LinkButton10.Visible = false; // member management link button
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            
        }
    }
}