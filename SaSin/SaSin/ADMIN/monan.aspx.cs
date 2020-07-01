using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaSin.model;

namespace SaSin.ADMIN
{
    public partial class monan : System.Web.UI.Page
    {
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
            //load DropDownList1 loai món ăn
            var dt = db.LOAIMONs.ToList();
            DropDownList1.DataTextField = "TenLoaiMon";
            DropDownList1.DataValueField = "MaLoaiMon";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
        }
        private void load_Data()
        {
            var dsmon = from mon in db.MONANs
                join loaimon in db.LOAIMONs on mon.MaLoaiMon equals loaimon.MaLoaiMon
                select new
                {
                    MaMon = mon.MaMon,
                    TenMon = mon.TenMon,
                    DonGia = mon.DonGia,
                    DonViTinh = mon.DonViTinh,
                    HinhAnh = mon.HinhAnh,
                    MoTa = mon.MoTa,
                    TenLoaiMon = loaimon.TenLoaiMon,
                };

            GridView1.DataSource = null;
            GridView1.DataSource = dsmon.ToList();
            GridView1.DataBind();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string ten = TextBox_ten.Text;
            string dongia = TextBox_dongia.Text;
            string dvt = TextBox_dvt.Text;
            string hinhanh = StartUpLoad();
            string mota = TextBox_mota.Text;
            string maloaimon = DropDownList1.SelectedItem.Value;
            
            
            if (ten.Equals("") || dongia.Equals("") || dvt.Equals("")|| maloaimon.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
            else
            {
                try
                {
                    var ttdk = new MONAN();
                    ttdk.TenMon = ten;
                    ttdk.DonViTinh = TextBox_dvt.Text;
                    ttdk.DonGia =int.Parse(TextBox_dongia.Text);
                    ttdk.MoTa = TextBox_mota.Text;
                    ttdk.MaLoaiMon = int.Parse(DropDownList1.SelectedItem.Value) ;
                    ttdk.HinhAnh = FileUpload_hinhanh.FileName;
                   

                    db.MONANs.Add(ttdk);
                    var a = db.SaveChanges();
                    load_Data();

                    if (a > 0)
                    {
                        TextBox_dongia.Text = "";
                        TextBox_mota.Text = "";
                        TextBox_ten.Text = "";
                        TextBox_dvt.Text = "";
                       
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
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaMon");
            var mamon = int.Parse(hd.Value);
            MONAN mon = db.MONANs.FirstOrDefault(c => c.MaMon == mamon);
            db.MONANs.Remove(mon);
            db.SaveChanges();
            load_Data();
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            btnupdate.Enabled = true;

            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaMon");
            var mamon = int.Parse(hd.Value);
            MONAN mon = db.MONANs.FirstOrDefault(c => c.MaMon == mamon);
            Txt_ma.Text = mon.MaMon.ToString();
            TextBox_ten.Text = mon.TenMon;
            TextBox_dongia.Text = mon.DonGia.ToString();
            TextBox_dvt.Text = mon.DonViTinh;
            TextBox_mota.Text = mon.MoTa;
            //FileUpload_hinhanh.FileName = mon.HinhAnh.ToString();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string ten = TextBox_ten.Text;
            string dongia = TextBox_dongia.Text;
            string dvt = TextBox_dvt.Text;
            string hinhanh = StartUpLoad();
            string mota = TextBox_mota.Text;
            string maloaimon = DropDownList1.SelectedItem.Value;

            if (string.IsNullOrEmpty(hinhanh))
            {
                var mamon = int.Parse(Txt_ma.Text);
                var monan = db.MONANs.FirstOrDefault(x => x.MaMon == mamon);
                hinhanh = monan.HinhAnh;
            }

            if (ten.Equals("") || dongia.Equals("") || dvt.Equals("") || maloaimon.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
            else
            {
                try
                {

                    var mon = new MONAN();
                    mon.MaMon = int.Parse(Txt_ma.Text);
                    mon.TenMon = ten;
                    mon.DonViTinh = dvt;
                    mon.DonGia = decimal.Parse(dongia);
                    mon.MoTa = mota;
                    mon.HinhAnh = hinhanh;
                    mon.MaLoaiMon = int.Parse(maloaimon);

                    db.MONANs.AddOrUpdate(mon);
                    db.SaveChanges();
                    load_Data();
                    Txt_ma.Text = "";
                    TextBox_mota.Text = "";
                    TextBox_dongia.Text = "";
                    TextBox_ten.Text = "";
                    TextBox_dvt.Text = "";
                    
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
      
        private string StartUpLoad()
        {
            string url = null;
            string imgName = string.Empty;
            int imgSize = 0;
            string imgPath = string.Empty;
           
            //validates the posted file before saving  
            if (FileUpload_hinhanh.PostedFile != null && FileUpload_hinhanh.PostedFile.FileName != "")
            {
                //get the file name of the posted image           
                imgName = FileUpload_hinhanh.PostedFile.FileName;
                //sets the image path           
                imgPath = "images/sanpham/" + imgName;
                //get the size in bytes that  
                imgSize = FileUpload_hinhanh.FileBytes.Length; //FileUpload_hinhanh.PostedFile.ContentLength;

                // 10240 KB means 10MB, You can change the value based on your requirement  
                if (imgSize > 10240000)
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page),
                        "Alert", "alert('File is too big.')", true);
                }
                else
                {
                    string workingDirectory = Environment.CurrentDirectory;
                    // or: Directory.GetCurrentDirectory() gives the same result

                    // This will get the current PROJECT directory
                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string url1 = projectDirectory + imgPath;
                    //FileUpload_hinhanh.SaveAs(Server.MapPath(imgPath));
                    FileUpload_hinhanh.SaveAs(url1);
                    url = "~/" + imgPath;
                    //Image1.ImageUrl = "~/" + imgPath;
                    //Page.ClientScript.RegisterClientScriptBlock(typeof(Page),
                    //    "Alert", "alert('Image saved!')", true);
                }
                
            }

            return url;
        }

        

        
    }
}