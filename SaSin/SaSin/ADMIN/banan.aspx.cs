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
    public partial class banan : System.Web.UI.Page
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
           
            GridView1.DataSource = db.BAN_AN.ToList();
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           string banso = TextBox_banso.Text;
           string soghe = TextBox_banso.Text;
           if (banso.Equals("") || soghe.Equals(""))
           {
               Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
           else
           {
               try
               {
                   var ttdk = new BAN_AN();
                   ttdk.BanSo = TextBox_banso.Text;
                   ttdk.SoGhe = int.Parse(TextBox_soghe.Text);

                   db.BAN_AN.Add(ttdk);

                   var a = db.SaveChanges();
                   load_Data();
                   if (a > 0)
                   {
                       tb_maban.Text = "";
                       TextBox_banso.Text = "";
                       TextBox_soghe.Text = "";
                       Response.Write("<script>alert('Bạn đã thêm thành công ! ')</script>");
                   }
                   else
                   {
                       Response.Write("<script>alert('Bạn đã thêm không thành công ! ')</script>");
                   }
                }
               catch (Exception exception)
               {
                   Response.Write("<script>alert('Vui lòng nhập đúng bàn số hoặc số ghế ! ')</script>");
                }
           }
            

        }

        
        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaBan");
            var maban = int.Parse(hd.Value);
            try
            {
                BAN_AN ban = db.BAN_AN.FirstOrDefault(c => c.MaBan == maban);
                db.BAN_AN.Remove(ban);
                db.SaveChanges();
                load_Data();
                tb_maban.Text = "";
                TextBox_banso.Text = "";
                TextBox_soghe.Text = "";
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
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaBan");
            var maban = int.Parse(hd.Value);
            BAN_AN ban = db.BAN_AN.FirstOrDefault(c => c.MaBan == maban);
            tb_maban.Text = ban.MaBan.ToString();
            TextBox_banso.Text = ban.BanSo;
            TextBox_soghe.Text = ban.SoGhe.ToString();
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string banso = TextBox_banso.Text;
            string soghe = TextBox_banso.Text;
            if (banso.Equals("") || soghe.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin ! ')</script>");
            }
            else
            {
                try
                {
                    var ban = new BAN_AN { MaBan = int.Parse(tb_maban.Text), BanSo = TextBox_banso.Text, SoGhe = int.Parse(TextBox_soghe.Text) };
                    db.BAN_AN.AddOrUpdate(ban);
                    db.SaveChanges();
                    load_Data();
                    tb_maban.Text = "";
                    TextBox_banso.Text = "";
                    TextBox_soghe.Text = "";
                    var a = db.SaveChanges();
                    load_Data();
                    Response.Write("<script>alert('Bạn đã sửa thành công ! ')</script>");
                    Button1.Enabled = true;
                    btnupdate.Enabled = false;
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('Vui lòng nhập đúng bàn số hoặc số ghế ! ')</script>");
                }
            }



            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

       
    }
}