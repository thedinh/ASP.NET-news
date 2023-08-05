using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebService.Models;

public partial class DangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Auth_Status"] != null && Request.Cookies["Auth_Status"].Value == "true")
        {
            Response.Cookies["Auth_Status"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth_Type"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth_Id"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth_Info"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth_Name"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth_Avatar"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("/Admin");
        }
    }
}