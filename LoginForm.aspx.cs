using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtusername.Text = Request.Cookies["UserName"].Value;
                    txtpassword.Attributes.Add("value", Request.Cookies["Password"].Value);
                }
            }
        }

        protected void cmdSignIn_Click(object sender, EventArgs e)
        {
            HttpCookie UserName = new HttpCookie("UserName");
            HttpCookie password = new HttpCookie("Password");
            if (chkUserID.Checked)
            {


                UserName.Value = txtusername.Text;
                //UserName.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(UserName);
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(7);


                password.Value = txtpassword.Text;
                //password.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(password);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(7);
            }
            else
            {
                UserName.Value = "";
                Response.Cookies.Add(UserName);
                password.Value = "";
                Response.Cookies.Add(password);
            }
            string Password = txtpassword.Text;
            string Username = txtusername.Text;

            int val = Models.Constraints.validate(Username, Password);
            if(val > 0)
            {
                Session["UserID"] = txtusername.Text;
                Response.Redirect("CustomerAccessPage1.aspx?id=" + Username);
            }
            else if(txtusername.Text == "admin" && txtpassword.Text == "password")
            {
                Session["UserID"] = txtusername.Text;
                Response.Redirect("ProductEntry.aspx");
            }
            else
            {
                txtMsg.Text = "Sign In Failed";
            }
        }
    }
}