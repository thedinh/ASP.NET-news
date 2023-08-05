using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Models;
using System.Reflection;

public partial class ChiTiet : System.Web.UI.Page
{
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        string Ma = Request.QueryString["Ma"];
        ChiTietNoiDung.DataSource = LayDuLieu("baiViet where MaBaiViet = '" + Ma + "'");
        ChiTietNoiDung.DataBind();
        TinLienQuan.DataSource = LayBaiVietLienQuan(Convert.ToInt32(Ma.ToString()));
        TinLienQuan.DataBind();
        TinMoiNhat.DataSource = LayNhungBaiVietMoiNhat();
        TinMoiNhat.DataBind();
        NoiDungBinhLuan.DataSource = LayBinhLuan(Convert.ToInt32(Ma));
        NoiDungBinhLuan.DataBind();
    }
    protected void SubmitBinhLuan_Click1(object sender, EventArgs e)
    {

        string MabaiViet = Request.QueryString["Ma"];
        if (Request.Cookies["Auth_Id"] != null )
        {
            int MaNguoiDung = Convert.ToInt32(Request.Cookies["Auth_Id"].Value);
            DateTime ngaydang = DateTime.Now;
            string NoiDungBinhLuan = txtNoiDungBinhLuan.Text;
            bool status = ThemDuLieuBinhLuan(NoiDungBinhLuan, ngaydang, MaNguoiDung, Convert.ToInt32(MabaiViet));
        if (status)
        {
            Response.Redirect("chitiet.aspx?Ma=" + MabaiViet + "");
        }
        }
        else
        {
            Response.Redirect("DangNhap.aspx");
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
    public DataSet LayBaiVietLienQuan(int MaDanhMuc)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("select top 5 BaiViet.*,DanhMuc.TenDanhMuc from baiviet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc where BaiViet.MaDanhMuc = '" + MaDanhMuc + "'", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
    public DataSet LayNhungBaiVietMoiNhat()
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            string query = "select top 5 BaiViet.*,DanhMuc.TenDanhMuc from baiviet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc ORDER BY NgayDang DESC\r\n";
            SqlCommand cmd = new SqlCommand(query, con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
    public DataSet LayBinhLuan(int mabaiviet)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            string query = "select BinhLuan.*,NguoiDung.* from BinhLuan inner join NguoiDung on BinhLuan.MaNguoiDung = NguoiDung.MaNguoiDung where MaBaiViet = '" + mabaiviet + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
    public bool ThemDuLieuBinhLuan(string noidung, DateTime ngaydang, int manguoidung, int mabaiviet)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("sp_InsertBinhLuan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@noidung", noidung);
            cmd.Parameters.AddWithValue("@ngaydang", ngaydang);
            cmd.Parameters.AddWithValue("@manguoidung", manguoidung);
            cmd.Parameters.AddWithValue("@mabaiviet", mabaiviet);
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
}