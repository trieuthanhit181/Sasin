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
    public partial class nhanvien : System.Web.UI.Page
    {
        private static string idmacv;
        NHAHANGEntities db = new NHAHANGEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                load_Data();
                load_Datadropdown();
                btnupdate.Enabled = false;
            }
        }

        private void load_Datadropdown()
        {
            //load DropDownList1 chucvu
            var dt = db.CHUCVUs.ToList();
            DropDownList_chucvu.DataTextField = "TenCV";
            DropDownList_chucvu.DataValueField = "MaCV";
            DropDownList_chucvu.DataSource = dt;
            DropDownList_chucvu.DataBind();
        }
        private void load_Data()
        {
            var dsnhanvien = from nv in db.NHANVIENs
                join cv in db.CHUCVUs on nv.MaCV equals cv.MaCV
                select new
                {
                    MaNV = nv.MaNV,
                    TenNV = nv.TenNV,
                    NgaySinh = nv.NgaySinh,
                    DiaChi = nv.DiaChi,
                    SDT = nv.SDT,
                    UserName = nv.UserName,
                    PassWork = nv.PassWork,
                    TenCV = cv.TenCV,

                };

            GridView1.DataSource = null;
            GridView1.DataSource = dsnhanvien.ToList();
            GridView1.DataBind();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime ngsinh;
            string ten = TextBox_ten.Text;
            string diachi = TextBox_diachi.Text;
            string sdt = TextBox_sdt.Text;
            string username = TextBox_taikhoan.Text;
            string pass = TextBox_pass.Text;
            string macv = DropDownList_chucvu.SelectedValue;
            
            string ngaysinh = TextBox_ngsinh.Text;
            ngsinh = Convert.ToDateTime(ngaysinh);

            if (ten.Equals("") || diachi.Equals("") || sdt.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
            else
            {
                try
                {
                    var ttdk = new NHANVIEN();
                    ttdk.TenNV = ten;
                    ttdk.DiaChi = TextBox_diachi.Text;
                    ttdk.NgaySinh = ngsinh;
                    ttdk.UserName = username;
                    ttdk.PassWork = pass;
                    ttdk.MaCV = int.Parse(macv);
                    ttdk.SDT = TextBox_sdt.Text;

                    db.NHANVIENs.Add(ttdk);

                    var a = db.SaveChanges();
                    load_Data();
                    if (a > 0)
                    {
                        TextBox_taikhoan.Text = "";
                        TextBox_pass.Text = "";
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
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaNV");
            var manv = int.Parse(hd.Value);
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(c => c.MaNV == manv);
            db.NHANVIENs.Remove(nv);
            db.SaveChanges();
            load_Data();

        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {

            Button1.Enabled = false;
            btnupdate.Enabled = true;

            LinkButton lb = (LinkButton) sender;
            HiddenField hd = (HiddenField) lb.FindControl("HiddenFieldMaNV");
            var manv = int.Parse(hd.Value);
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(c => c.MaNV == manv);
            Txt_ma.Text = nv.MaNV.ToString();
            TextBox_ten.Text = nv.TenNV;
            TextBox_diachi.Text = nv.DiaChi;
            TextBox_sdt.Text = nv.SDT;
            TextBox_taikhoan.Text = nv.UserName;
            TextBox_pass.Text = nv.PassWork;
            TextBox_ngsinh.Text = Convert.ToDateTime(nv.NgaySinh).ToString("yyyy-MM-dd");
            DropDownList_chucvu.ClearSelection(); //making sure the previous selection has been cleared
            DropDownList_chucvu.Items.FindByValue(nv.MaCV.ToString()).Selected = true;

            TextBox_taikhoan.Enabled = false;
            TextBox_pass.Enabled = false;

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            DateTime ngsinh;
            string ten = TextBox_ten.Text;
            string diachi = TextBox_diachi.Text;
            string sdt = TextBox_sdt.Text;
            string username = TextBox_taikhoan.Text;
            string pass = TextBox_pass.Text;
            string macv = DropDownList_chucvu.SelectedItem.Value;
            string tencv = DropDownList_chucvu.SelectedItem.Text;
            string ngaysinh = TextBox_ngsinh.Text;
            
            if (ten.Equals("") || diachi.Equals("") || sdt.Equals("")||ngaysinh.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
            else
            {
                try
                {
                    ngsinh = Convert.ToDateTime(ngaysinh);
                    var NV = new NHANVIEN { MaNV = int.Parse(Txt_ma.Text), TenNV = ten, DiaChi = diachi, SDT =sdt, UserName = username,PassWork = pass,NgaySinh = ngsinh,MaCV =int.Parse(macv) };
                       
                    db.NHANVIENs.AddOrUpdate(NV);
                    db.SaveChanges();
                    load_Data();
                    Txt_ma.Text = "";
                    TextBox_sdt.Text = "";
                    TextBox_diachi.Text = "";
                    TextBox_ten.Text = "";
                    TextBox_taikhoan.Text = "";
                    TextBox_pass.Text = "";
                    var a = db.SaveChanges();
                    load_Data();
                    Response.Write("<script>alert('Bạn đã sửa thành công ! ')</script>");

                    Button1.Enabled = true;
                    btnupdate.Enabled = false;
                    TextBox_taikhoan.Enabled = true;
                    TextBox_pass.Enabled = true;
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