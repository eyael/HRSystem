using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatagoryExercise
{
    public partial class NewCatagory : System.Web.UI.Page
    {

        Crud cr = new Crud();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Catagory> cList = new List<Catagory>();
            DataTable dt = cr.GetCatagory();

            Catagory ca = new Catagory();

            foreach (DataRow drow in dt.Rows)
            {

                ca.id = int.Parse(drow["id"].ToString());
                ca.CategName = drow["CategName"].ToString();
                ca.Desc = drow["Desc"].ToString();
                cList.Add(ca);
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Catagory ca = new Catagory();

            ca.CategName = txt1.Text;
            ca.Desc = txt2.Text;
            string message = cr.InsertCatagory(ca);
        }
    }
}