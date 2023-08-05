using System;
using System.Collections.Generic;
using System.Configuration;
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
    //string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; // tạo kết nối tới sql bằng config

    protected void Page_Load(object sender, EventArgs e)
    {
      
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
    protected void BtnLienHe_Click(object sender, EventArgs e)
    {
        Response.Write("hehe");
    }

}