using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class CustomerAccessPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUname.Text =  (Request.QueryString["id"] as string);

            if (!Page.IsPostBack)
            {
                if(Session["UserID"] == null)
                {
                    Response.Redirect("LoginForm.aspx");
                }
                Insert obj = new Insert();
                DataList1.DataSource = obj.DisplayAllProduct();
                DataList1.DataBind();  //binds data to the source
            }
        }

        protected void cmdSignOut_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID");
            // Session.Abandon();
            if (Session["UserID"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

        
    }
}