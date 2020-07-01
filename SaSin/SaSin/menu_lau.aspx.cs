using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaSin.model;

namespace SaSin
{
    public partial class menu_lau : System.Web.UI.Page
    {
        NHAHANGEntities db = new NHAHANGEntities();

        public List<MONAN> lstmonanlau = new List<MONAN>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Load_MonAn();

            }
        }

        void Load_MonAn()
        {
            lstmonanlau = db.MONANs.Where(x => x.MaLoaiMon == 3).ToList();
        }
    }
}