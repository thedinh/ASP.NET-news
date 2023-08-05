using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Admin_Default : System.Web.UI.Page
{
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
        DanhSachBaiViet.DataSource = LayDuLieu("BaiViet order by MaBaiViet desc");
        DanhSachBaiViet.DataBind();
        if (DanhSachBaiViet.Rows.Count < 1)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Chưa có dữ liệu',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {
            DanhSachBaiViet.UseAccessibleHeader = true;
            DanhSachBaiViet.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
        string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
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
}