using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaSin.model;

namespace SaSin.ADMIN
{
    public partial class loaimonan : System.Web.UI.Page
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

            GridView1.DataSource = db.LOAIMONs.ToList();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string loaimon = TextBox_loaimon.Text;

            if (loaimon.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập tên loại món ăn  ! ')</script>");
            }
            else
            {
                try
                {
                    var ttdk = new LOAIMON();
                    ttdk.TenLoaiMon = TextBox_loaimon.Text;


                    db.LOAIMONs.Add(ttdk);

                    var a = db.SaveChanges();
                    load_Data();
                    if (a > 0)
                    {
                        tb_maloaimon.Text = "";
                        TextBox_loaimon.Text = "";

                        Response.Write("<script>alert('Bạn đã thêm thành công ! ')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Bạn đã thêm không thành công ! ')</script>");
                    }
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('Vui lòng nhập đúng đúng dữ liệu ! ')</script>");
                }
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string ten = TextBox_loaimon.Text;
            if (ten.Equals(""))
            {
                Response.Write("<script>alert('Vui Lòng nhập tên loại món ăn  ')</script>");
                TextBox_loaimon.Focus();
            }
            else
            {
                var cv = new LOAIMON() {MaLoaiMon = int.Parse(tb_maloaimon.Text), TenLoaiMon = TextBox_loaimon.Text};
                db.LOAIMONs.AddOrUpdate(cv);
                db.SaveChanges();
                load_Data();
                tb_maloaimon.Text = "";
                TextBox_loaimon.Text = "";
                Button1.Enabled = true;
                btnupdate.Enabled = false;
            }
        }

        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }
        
        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaLoaiMon");
            var maloai = int.Parse(hd.Value);
            try
            {
                LOAIMON lm = db.LOAIMONs.FirstOrDefault(c => c.MaLoaiMon == maloai);
                db.LOAIMONs.Remove(lm);
                db.SaveChanges();
                load_Data();
                tb_maloaimon.Text = "";
                TextBox_loaimon.Text = "";
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
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaLoaiMon");
            var maloai = int.Parse(hd.Value);
            LOAIMON lm = db.LOAIMONs.FirstOrDefault(c => c.MaLoaiMon == maloai);
            tb_maloaimon.Text = lm.MaLoaiMon.ToString();
            TextBox_loaimon.Text = lm.TenLoaiMon;
            
        }

       
    }
}