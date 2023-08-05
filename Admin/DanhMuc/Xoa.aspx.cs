using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DanhMuc_Xoa : System.Web.UI.Page
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
    public void XoaDuLieu(string tenbang, string dieukien)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenbang", tenbang);
            cmd.Parameters.AddWithValue("@dieukien", dieukien);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        bool isNumber = IsNumeric(MaDanhMuc);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaDanhMuc"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }

        if (!String.IsNullOrEmpty(Request.QueryString["MaDanhMuc"]))
        {
            int count = LayDuLieu("danhmuc where MaDanhMuc = '" + MaDanhMuc + "' ").Tables[0].Rows.Count;
            if (count > 0)
            {
                XoaDuLieu("DanhMuc", "MaDanhMuc = '" + MaDanhMuc + "'");
                Session["DeleteStatus"] = "ok";
                Response.Redirect("DanhSach.aspx");
            }
            else
            {
                Response.Redirect("../404.aspx");
            }
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xoa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }

    }
}