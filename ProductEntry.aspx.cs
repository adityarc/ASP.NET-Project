using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("LoginForm.aspx");
                }
            }
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            string ProductName = txtPname.Text;
            int len = imgProduct.PostedFile.ContentLength;
            byte[] img = new byte[len];
            imgProduct.PostedFile.InputStream.Read(img, 0, len);
            int res = Insert.ProductAddData(ProductName, img, double.Parse(TxtPrice.Text), int.Parse(TxtQuantity.Text));
            if (res == 0)
                txtMsg.Text = "Product Not Added.";
            else
                txtMsg.Text = "Product Added Successfully.";

        }

        protected void cmdsignout_Click(object sender, EventArgs e)
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