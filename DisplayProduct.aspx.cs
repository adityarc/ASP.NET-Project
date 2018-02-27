using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;
namespace WebApplication2
{
    public partial class DisplayProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Insert obj = new Insert();
                DataList1.DataSource = obj.DisplayAllProduct();
                DataList1.DataBind();  //binds data to the source
            }
        }
    }
}
