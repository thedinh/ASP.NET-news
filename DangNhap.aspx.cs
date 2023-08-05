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
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        emailaddress.Value = "Dinh@gmail.com";
    }
    public int Authencation(string Email, string MatKhau, int VaiTro)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            string query = "SELECT count(*) FROM NguoiDung where Email = '" + Email + "' and MatKhau = '" + MatKhau + "' and VaiTro = '" + VaiTro + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
    }
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
    protected void BtnDangNhap_Click(object sender, EventArgs e)
    {
        string Email = emailaddress.Value;
        string MatKhau = password.Value;
        int CheckLogin = Authencation(Email, MatKhau, 1);
        if (CheckLogin == 1)
        {
            DataSet NguoiDung = LayDuLieu("nguoidung where email = '" + Email + "' ");
            string MaNguoiDung = NguoiDung.Tables[0].Rows[0]["MaNguoiDung"].ToString();
            string TenNguoiDung = NguoiDung.Tables[0].Rows[0]["TenNguoiDung"].ToString();
            string HinhDaiDien = NguoiDung.Tables[0].Rows[0]["HinhDaiDien"].ToString();

            HttpCookie Auth_Status = new HttpCookie("Auth_Status", "true");
            HttpCookie Auth_type = new HttpCookie("Auth_type", "user");
            HttpCookie Auth_Id = new HttpCookie("Auth_Id", MaNguoiDung);
            HttpCookie Auth_Name = new HttpCookie("Auth_Name", TenNguoiDung);
            HttpCookie Auth_Avatar = new HttpCookie("Auth_Avatar", HinhDaiDien);

            Response.Cookies.Add(Auth_Status);
            Response.Cookies.Add(Auth_type);
            Response.Cookies.Add(Auth_Id);
            Response.Cookies.Add(Auth_Name);
            Response.Cookies.Add(Auth_Avatar);


            Auth_Status.Expires = DateTime.Now.AddMonths(3);
            Auth_type.Expires = DateTime.Now.AddMonths(3);
            Auth_Id.Expires = DateTime.Now.AddMonths(3);
            Auth_Name.Expires = DateTime.Now.AddMonths(3);
            Auth_Avatar.Expires = DateTime.Now.AddMonths(3);


            Response.SetCookie(Auth_Status);
            Response.SetCookie(Auth_type);
            Response.SetCookie(Auth_Id);
            Response.SetCookie(Auth_Name);
            Response.SetCookie(Auth_Avatar);

            Response.Redirect("Default.aspx");

        }
        else if (CheckLogin == 0)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Sai Email hoặc mật khẩu',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Có lỗi xảy ra',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }
    }

}