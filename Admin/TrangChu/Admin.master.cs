using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Auth_Name"] != null && Request.Cookies["Auth_Type"] != null)
        {
            Auth_Name.Text = Request.Cookies["Auth_Name"].Value;
            if (Request.Cookies["Auth_Type"].Value == "sa")
            {
                Auth_Type.Text = "Admin";
            }
        }
        if (Request.Cookies["Auth_Status"] == null || Request.Cookies["Auth_Status"].Value != "true")
        {

            Response.Redirect("../DangNhap.aspx");
        }
    }
}
