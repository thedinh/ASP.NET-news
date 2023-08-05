using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BinhLuan_DanhSach : System.Web.UI.Page
{
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["DeleteStatus"] != null && Session["DeleteStatus"].ToString() == "ok")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xoa thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
            Session.Remove("DeleteStatus");
        }
        else if (Session["DeleteStatus"] != null && Session["DeleteStatus"].ToString() == "error")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xóa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            Session.Remove("DeleteStatus");
        }
        else if (Session["UpdateStatus"] != null && Session["UpdateStatus"].ToString() == "error")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            Session.Remove("UpdateStatus");
        }
        DanhSachBinhLuan.DataSource = LoadBinhLuan();
        DanhSachBinhLuan.DataBind();
        if (DanhSachBinhLuan.Rows.Count < 1)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Chưa có dữ liệu',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {

            DanhSachBinhLuan.UseAccessibleHeader = true;
            DanhSachBinhLuan.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    public DataSet LoadBinhLuan()
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            string query = "select BinhLuan.*,NguoiDung.TenNguoiDung,BaiViet.TieuDe from BinhLuan inner join NguoiDung on BinhLuan.MaNguoiDung = NguoiDung.MaNguoiDung inner join BaiViet on BinhLuan.MaBaiViet = BaiViet.MaBaiViet";
            SqlCommand cmd = new SqlCommand(query, con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
}