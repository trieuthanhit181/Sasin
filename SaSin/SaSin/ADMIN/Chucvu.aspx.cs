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
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=NHAHANG;Integrated Security=True");
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
            //SqlDataAdapter da = new SqlDataAdapter("select * from CHUCVU", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //GridView1.DataSourceID = null;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            
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

                    SqlCommand cmd = new SqlCommand("insert into CHUCVU(TenCV)values(N'" + TextBox1.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Đã thêm thành công')</script>");
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //Label txtMaCV = (Label)GridView1.Rows[e.RowIndex].FindControl("MaCV");
            //TextBox txtTenCV = GridView1.FindControl("TenCV") as TextBox;
            //TextBox txtMaCv = GridView1.FindControl("MaCV") as TextBox;
           // Label txtMaCV = (Label)GridView1.Rows[e.RowIndex].FindControl("MaCV");
           // TextBox txtTenCV = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TenCV");
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox txtMaCV = ((TextBox)(GridView1.Rows[GridView1.EditIndex]).Cells[1].Controls[0]);
            string txtTenCV = (row.FindControl("txtTenCV") as TextBox).Text;//(TextBox)row.Cells[2].Controls[0];

            NHAHANGEntities db = new NHAHANGEntities();
            var cv = new CHUCVU {TenCV = txtTenCV, MaCV = int.Parse(txtMaCV.Text)};
            db.CHUCVUs.AddOrUpdate(cv);
            load_Data();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = "11";
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var a = "11";
        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
           
            LinkButton lb = (LinkButton) sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaCV");
            var macv = int.Parse(hd.Value);
            CHUCVU cv = db.CHUCVUs.FirstOrDefault(c => c.MaCV == macv);
            db.CHUCVUs.Remove(cv);
            db.SaveChanges();
            load_Data();
            TextBox1.Text = "";
            TxtMaCV.Text = "";
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldMaCV");
            var macv = int.Parse(hd.Value);
            CHUCVU cv = db.CHUCVUs.FirstOrDefault(c => c.MaCV == macv);
            TxtMaCV.Text = cv.MaCV.ToString();
            TextBox1.Text = cv.TenCV;

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            var cv = new CHUCVU {MaCV = int.Parse(TxtMaCV.Text),TenCV = TextBox1.Text};
            db.CHUCVUs.AddOrUpdate(cv);
            db.SaveChanges();
            load_Data();
            TextBox1.Text = "";
            TxtMaCV.Text = "";
        }
    }
}