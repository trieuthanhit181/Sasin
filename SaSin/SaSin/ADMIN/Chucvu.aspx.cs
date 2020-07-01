using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using SaSin.model;

namespace SaSin.ADMIN
{
    public partial class Chucvu : System.Web.UI.Page
    {
       
        NHAHANGEntities db = new NHAHANGEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                load_Data();
                btnupdate.Enabled = false;
            }

            
        }
        private void load_Data()
        {
            
            
            GridView1.DataSource = db.CHUCVUs.ToList(); 
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string ten = TextBox1.Text;
            if (ten.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập tên chức vụ')</script>");

                TextBox1.Focus();//trỏ chuột về TextBox1
            }
            else
            {
                try
                {

                    var ttdk = new CHUCVU();
                    ttdk.TenCV = ten;
                    db.CHUCVUs.Add(ttdk);
                    var a = db.SaveChanges();
                    Response.Write("<script>alert('thêm thành công')</script>");
                    load_Data();
                   
                    TextBox1.Text = "";
                    TxtMaCV.Text = "";
                }
                catch
                {
                    Response.Write("<script>alert('Lỗi ')</script>");
                }
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

        
        
        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
           
            LinkButton lb = (LinkButton) sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaCV");
            var macv = int.Parse(hd.Value);

            try
            {
                CHUCVU cv = db.CHUCVUs.FirstOrDefault(c => c.MaCV == macv);
                db.CHUCVUs.Remove(cv);
                db.SaveChanges();
                load_Data();
                TextBox1.Text = "";
                TxtMaCV.Text = "";
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('Dữ liệu này đang được sử dụng không được xóa ')</script>");
            }

            
        }

       

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            btnupdate.Enabled = true;
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaCV");
            var macv = int.Parse(hd.Value);
            CHUCVU cv = db.CHUCVUs.FirstOrDefault(c => c.MaCV == macv);
            TxtMaCV.Text = cv.MaCV.ToString();
            TextBox1.Text = cv.TenCV;

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string ma =TxtMaCV.Text;
            string tencv = TextBox1.Text;
            if (tencv.Equals(""))
            {
                Response.Write("<script>alert('Vui Lòng nhập tên chức vụ ')</script>");
                TextBox1.Focus();
            }
            else
            {
                var cv = new CHUCVU { MaCV = int.Parse(TxtMaCV.Text), TenCV = TextBox1.Text };
                db.CHUCVUs.AddOrUpdate(cv);
                db.SaveChanges();
                Response.Write("<script>alert('sửa thành công')</script>");
                load_Data();
                TextBox1.Text = "";
                TxtMaCV.Text = "";
                Button1.Enabled = true;
                btnupdate.Enabled = false;
            }
            
        }
    }
}