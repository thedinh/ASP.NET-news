using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Models;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Reflection;

public partial class Admin_Default : System.Web.UI.Page
{
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

    public bool IsNumeric(string input)
    {
        bool isNumber = int.TryParse(input, out _);
        return isNumber;
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
    public bool CapNhatDuLieuNguoiDung(int manguoidung, string TenNguoiDung, string MatKhau, int VaiTro)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("UPDATE NguoiDung SET TenNguoiDung = N'"+ TenNguoiDung + "',MatKhau = '"+ MatKhau + "',VaiTro = '"+ VaiTro + "' where MaNguoiDung = '"+ manguoidung + "'", con);
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
        var MaNguoiDung = Request.QueryString["MaNguoiDung"];
        bool isNumber = IsNumeric(MaNguoiDung);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaNguoiDung"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["MaNguoiDung"]))
            {
                DataSet NguoiDung = LayDuLieu("NguoiDung where MaNguoiDung = '" + MaNguoiDung + "' ");
                int count = NguoiDung.Tables[0].Rows.Count;
                if (count > 0)
                {
                    txtTenNguoiDung.Text = NguoiDung.Tables[0].Rows[0]["TenNguoiDung"].ToString();
                    Email.Text = NguoiDung.Tables[0].Rows[0]["Email"].ToString();
                    password.Text = NguoiDung.Tables[0].Rows[0]["MatKhau"].ToString();
                    HinhAnh.Text =  NguoiDung.Tables[0].Rows[0]["HinhDaiDien"].ToString();
                    NgaySinh.Value = NguoiDung.Tables[0].Rows[0]["NgaySinh"].ToString();
                    DiaChi.Text = NguoiDung.Tables[0].Rows[0]["DiaChi"].ToString();
                    sodienthoai.Value = NguoiDung.Tables[0].Rows[0]["SDT"].ToString();
                    GioiTinh.Value = NguoiDung.Tables[0].Rows[0]["GioiTinh"].ToString();
                    VaiTro.Text = NguoiDung.Tables[0].Rows[0]["VaiTro"].ToString();
                }
                else
                {
                    Response.Redirect("../404.aspx");
                }
            }
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        var MaNguoiDung = Request.QueryString["MaNguoiDung"];
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var hinhanh = HinhAnh.Text.ToString();
        var ngaysinh = NgaySinh.Value.ToString();
        var diachi = DiaChi.Text.ToString();
        var sdt = sodienthoai.Value;
        var gioitinh = GioiTinh.Value;
        var vaitro = VaiTro.Text.ToString();
        bool status = CapNhatDuLieuNguoiDung(Convert.ToInt32(MaNguoiDung),tennguoidung, pass, Convert.ToInt32(vaitro));

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
        var MaNguoiDung = Request.QueryString["MaNguoiDung"];
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var hinhanh = HinhAnh.Text.ToString();
        var ngaysinh = NgaySinh.Value.ToString();
        var diachi = DiaChi.Text.ToString();
        var sdt = sodienthoai.Value;
        var gioitinh = GioiTinh.Value;
        var vaitro = VaiTro.Text.ToString();
        bool status = CapNhatDuLieuNguoiDung(Convert.ToInt32(MaNguoiDung), tennguoidung, pass, Convert.ToInt32(vaitro));

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