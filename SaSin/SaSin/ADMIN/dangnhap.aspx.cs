using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaSin.model;

namespace SaSin.ADMIN
{
    public partial class dangnhap : System.Web.UI.Page
    {
        NHAHANGEntities db = new NHAHANGEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox_username.Text;
            string pass = TextBox_username.Text;
            if (username.Equals("") || pass.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=NHAHANG;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM NHANVIEN WHERE UserName='" + TextBox_username.Text +
                                                       "'AND PassWork='" + TextBox_pass.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["name"] = TextBox_username.Text;
                    Session["allow"] = true;
                    Response.Redirect("homeadmin.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Username / Password không đúng')</script>");
                }
            }
            

            

        }
    }
}