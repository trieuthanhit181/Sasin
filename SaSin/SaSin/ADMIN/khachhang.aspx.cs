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
            }

            load_Data();
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

        protected void HiddenFieldMaKH_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaKH");
            var makh = int.Parse(hd.Value);
            KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == makh);
            db.KHACHHANGs.Remove(kh);
            db.SaveChanges();
            load_Data();
            
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
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

                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('Vui lòng nhập đúng THÔNG TIN ! ')</script>");
                }
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox txtMaKH = ((TextBox)(GridView1.Rows[GridView1.EditIndex]).Cells[1].Controls[0]);
            string txtTenKH = (row.FindControl("txtTenKH") as TextBox).Text;
            string txtDiaChi = (row.FindControl("txtDiaChi") as TextBox).Text;
            string txtSDT = (row.FindControl("txtSDT") as TextBox).Text;
           
            var kh = new KHACHHANG { TenKH = txtTenKH, DiaChi = txtDiaChi ,SDT = txtSDT, MaKH = int.Parse(txtMaKH.Text) };
            db.KHACHHANGs.AddOrUpdate(kh);
            load_Data();
        }
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var a = "11";
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var a = "11";
        }
    }
}