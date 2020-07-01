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
                var tk = db.NHANVIENs.FirstOrDefault(c=>c.UserName ==TextBox_username.Text && c.PassWork ==TextBox_pass.Text);
                
                if (tk != null)
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