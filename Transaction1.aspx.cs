using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class Transaction1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["UserID"] == null)
                {
                    Response.Redirect("LoginForm.aspx");
                }
                
                Panel1.Visible = false;
                Panel2.Visible = false;
                int qty = int.Parse(Request.QueryString["qty"].ToString());
                double prc = double.Parse(Request.QueryString["prc"].ToString());
                double totalprice = qty * prc;
                double cgst = 0.09; double sgst = 0.09;
                double del = 150;
                double finalbill = (totalprice * ( 1 + (cgst + sgst))) + del;
                lblbase.Text = totalprice.ToString();
                Lblcgst.Text = cgst.ToString();
                Lblsgst.Text = sgst.ToString();
                Lbldel.Text = del.ToString();
                Lblfinal.Text = finalbill.ToString();

            }  
            
        }

        

        

        

        protected void lbtnNet_Click(object sender, EventArgs e)
        {
            if (chkagree.Checked)
            {
                int res = Insert.createorder(Session["UserID"].ToString(),int.Parse(Request.QueryString["PID"].ToString()),txtDeliveryAddress.Text,double.Parse(Lblfinal.Text));
                if(res == 1)
                {
                    lblOrder.Text = "Order Placed Successfully";
                }
                Response.Redirect("https://infinity.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&_ga=2.184443951.828010833.1519358601-1727937075.1519358601");
                
            }
        }

       

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (rbDebit.Checked)
            {
                Panel1.Visible = true;
            }
            if (rbNet.Checked)
            {
                Panel2.Visible = true;
                
            }
            
        }

        protected void cmdConfirm_Click(object sender, EventArgs e)
        {
            int res = Insert.createorder(Session["UserID"].ToString(), int.Parse(Request.QueryString["PID"].ToString()), txtDeliveryAddress.Text, double.Parse(Lblfinal.Text));
            if(res == 1)
            {
                lblOrder.Text = "Order Placed Successfully";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAccessPage1.aspx");

        }
    }
}