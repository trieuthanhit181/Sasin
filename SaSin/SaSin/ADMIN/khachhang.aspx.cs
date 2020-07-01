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
    public partial class khachhang : System.Web.UI.Page
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

            GridView1.DataSource = db.KHACHHANGs.ToList();
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ten = TextBox_ten.Text;
            string diachi = TextBox_diachi.Text;
            string sdt = TextBox_sdt.Text;
            if (ten.Equals("") || diachi.Equals("")||sdt.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
            else
            {
                try
                {
                    var ttdk = new KHACHHANG();
                    ttdk.TenKH = TextBox_ten.Text;
                    ttdk.DiaChi = TextBox_diachi.Text;
                    ttdk.SDT = TextBox_sdt.Text;

                    db.KHACHHANGs.Add(ttdk);

                    var a = db.SaveChanges();
                    load_Data();
                    if (a > 0)
                    {
                        TextBox_ten.Text = "";
                        TextBox_diachi.Text = "";
                        TextBox_sdt.Text = "";
                        Response.Write("<script>alert('Bạn đã thêm thành công ! ')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Bạn đã thêm không thành công ! ')</script>");
                    }
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('Vui lòng nhập đúng thông tin ! ')</script>");
                }
            }
        }

       

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaKH");
            var makh = int.Parse(hd.Value);
            try
            {
                KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == makh);
                db.KHACHHANGs.Remove(kh);
                db.SaveChanges();
                load_Data();
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
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaKH");
            var makh = int.Parse(hd.Value);
            KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == makh);
            Txt_ma.Text = kh.MaKH.ToString();
            TextBox_ten.Text = kh.TenKH;
            TextBox_diachi.Text = kh.DiaChi;
            TextBox_sdt.Text = kh.SDT;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string ten = TextBox_ten.Text;
            string diachi = TextBox_diachi.Text;
            string sdt = TextBox_sdt.Text;
            if (ten.Equals("") || diachi.Equals("") || sdt.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
            else
            {
                try
                {
                    var KH = new KHACHHANG { MaKH = int.Parse(Txt_ma.Text), TenKH = TextBox_ten.Text, DiaChi = TextBox_diachi.Text,SDT = TextBox_sdt.Text};
                    db.KHACHHANGs.AddOrUpdate(KH);
                    db.SaveChanges();
                    load_Data();
                    Txt_ma.Text = "";
                    TextBox_sdt.Text = "";
                    TextBox_diachi.Text = "";
                    TextBox_ten.Text = "";
                    var a = db.SaveChanges();
                    load_Data();
                    Response.Write("<script>alert('Bạn đã sửa thành công ! ')</script>");
                    Button1.Enabled = true;
                    btnupdate.Enabled = false;
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('Vui lòng nhập đúng THÔNG TIN ! ')</script>");
                }
            }
        }
       

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

       
    }
}