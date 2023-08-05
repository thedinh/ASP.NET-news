using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc : System.Web.UI.Page
{
    string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
 

    protected void Page_Load(object sender, EventArgs e)
    {
        string MaDanhMuc = Request.QueryString["Ma"];
        LayBaiVietTheoDanhMuc.DataSource = LoadDanhMuc(Convert.ToInt32(MaDanhMuc));
        LayBaiVietTheoDanhMuc.DataBind();
    }
    public DataSet LoadDanhMuc(int Madanhmuc)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            string query = "select * from BaiViet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc where BaiViet.MaDanhMuc = '" + Madanhmuc + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }
}