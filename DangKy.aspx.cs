using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        //HttpCookie cookie = new HttpCookie("Auth_ID");
        //cookie.Value = "abc"; 
        //cookie.Expires = DateTime.Now.AddHours(3);
        //Response.SetCookie(cookie);
       
    }
    public string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    public DataSet LayDuLieu(string table)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenbang", table);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
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
    protected void BtnDangKy_Click(object sender, EventArgs e)
    {
        string Username = username.Value;
        string email = emailaddress.Value;
        string pass = password.Value;
        int count = LayDuLieu("Nguoidung where Email = '"+email+"'").Tables[0].Rows.Count;
        if(count == 0)
        {
            bool status = DangKy(Username, email, pass,1);
            if (status)
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Đăng ký thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
            }
            else
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Có lỗi xảy ra',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

            }
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Email đã tồn tại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }
    }
}