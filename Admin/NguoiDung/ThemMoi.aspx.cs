using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NguoiDung_ThemMoi : System.Web.UI.Page
{
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

    public bool DangKy(string UserName, string email, string pass, int vaitro)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            string query = "Insert Into NguoiDung(TenNguoiDung,Email,MatKhau,VaiTro) values('" + UserName + "','" + email + "','" + pass + "','" + vaitro + "')";
            SqlCommand cmd = new SqlCommand(query, con);
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
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    private bool IsNumeric(string input)
    {
        bool isNumber = int.TryParse(input, out _);
        return isNumber;
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var vaitro = VaiTro.Text.ToString();
        bool status = DangKy(tennguoidung,email,pass,Convert.ToInt32(vaitro));

        if (status == true)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
    }

    protected void SubmitBack_Click(object sender, EventArgs e)
    {
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var vaitro = VaiTro.Text.ToString();
        bool status = DangKy(tennguoidung, email, pass, Convert.ToInt32(vaitro));

        if (status == true)
        {
            Response.Redirect("DanhSach.aspx");
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
    }
}
