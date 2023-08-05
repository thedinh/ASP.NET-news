using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //NextNews.DataSource = ServiceTinTuc.LayDanhSachBaiViet();
        //NextNews.DataBind();
        NextNews.DataSource = LayDanhSachBaiViet();
        NextNews.DataBind();
        carousel.DataSource = LayDanhSachBaiViet();
        carousel.DataBind();
    }
    public DataSet LayDanhSachBaiViet()
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("select BaiViet.*,DanhMuc.TenDanhMuc from baiviet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
}