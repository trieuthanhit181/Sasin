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
            }

            load_Data();
        }
        private void load_Data()
        {
           
            GridView1.DataSource = db.BAN_AN.ToList();
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
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

        protected void HiddenFieldMaBan_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaBan");
            var maban = int.Parse(hd.Value);
            BAN_AN ban = db.BAN_AN.FirstOrDefault(c => c.MaBan == maban);
            db.BAN_AN.Remove(ban);
            db.SaveChanges();
            load_Data();
            tb_maban.Text = "";
            TextBox_banso.Text = "";
            TextBox_soghe.Text = "";
        }
        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
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
            var ban = new BAN_AN { MaBan = int.Parse(tb_maban.Text), BanSo = TextBox_banso.Text,SoGhe = int.Parse(TextBox_soghe.Text) };
            db.BAN_AN.AddOrUpdate(ban);
            db.SaveChanges();
            load_Data();
            tb_maban.Text = "";
            TextBox_banso.Text = "";
            TextBox_soghe.Text = "";
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox txtMaban = ((TextBox)(GridView1.Rows[GridView1.EditIndex]).Cells[1].Controls[0]);
            string txtBanSo = (row.FindControl("txtBanSo") as TextBox).Text;
            string txtSoGhe = (row.FindControl("txtSoGhe") as TextBox).Text;

            NHAHANGEntities db = new NHAHANGEntities();
            var ban = new BAN_AN {SoGhe = int.Parse(txtMaban.Text), BanSo = txtBanSo, MaBan = int.Parse(txtMaban.Text) };
            db.BAN_AN.AddOrUpdate(ban);
            load_Data();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var a = "11";
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var a = "11";
        }
    }
}