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

    public bool IsNumeric(string input)
    {
        bool isNumber = int.TryParse(input, out _);
        return isNumber;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        bool isNumber = IsNumeric(MaDanhMuc);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaDanhMuc"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["MaDanhMuc"]))
            {
                DataSet DanhMuc = LayDuLieu("danhmuc where MaDanhMuc = '" + MaDanhMuc + "' ");
                int count = DanhMuc.Tables[0].Rows.Count;
                if (count > 0)
                {
                    txtTenDanhMuc.Text = DanhMuc.Tables[0].Rows[0]["TenDanhMuc"].ToString();
                }
                else
                {
                    Response.Redirect("../404.aspx");
                }
            }
        }
    }
    public bool CapNhatDuLieuDanhMuc(int madanhmuc, string tendanhmuc)
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("sp_updateDanhMuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
            cmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
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
    protected void Submit_Click(object sender, EventArgs e)
    {
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        var tendanhmuc = txtTenDanhMuc.Text.ToString();
        bool status = CapNhatDuLieuDanhMuc(Convert.ToInt32(MaDanhMuc), tendanhmuc);
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
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        var tendanhmuc = txtTenDanhMuc.Text.ToString();
        bool status = CapNhatDuLieuDanhMuc(Convert.ToInt32(MaDanhMuc), tendanhmuc);
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