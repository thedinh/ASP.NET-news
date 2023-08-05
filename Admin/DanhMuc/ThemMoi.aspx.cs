using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

    
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool ThemDuLieuDanhMuc(string tendanhmuc)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("sp_InsertDanhMuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        bool status = ThemDuLieuDanhMuc(TenDanhMuc.Text.ToString());
        if (status == true)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
    }

    protected void SubmitBack_Click(object sender, EventArgs e)
    {
        bool status = ThemDuLieuDanhMuc(TenDanhMuc.Text.ToString());
        if (status == true)
        {
            Response.Redirect("DanhSach.aspx");
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
    }
    private void ClearControls()
    {
        foreach (Control c in Page.Controls)
        {
            foreach (Control ctrl in c.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
            }
        }
    }
}