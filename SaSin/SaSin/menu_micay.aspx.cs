using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaSin.model;

namespace SaSin.pageuser
{
    public partial class menu_micay : System.Web.UI.Page
    {
        NHAHANGEntities db = new NHAHANGEntities();

        public List<MONAN> lstmonanMyCay = new List<MONAN>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Load_MonAn();

            }
        }

        void Load_MonAn()
        {
            lstmonanMyCay = db.MONANs.Where(x=>x.MaLoaiMon== 2).ToList();
        }
    }
}