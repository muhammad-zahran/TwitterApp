using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterApp
{
    public partial class addfollow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string follow = Request.QueryString["K"];


            string user = Request.QueryString["P"];


            DataAgent DA = new DataAgent();

            SqlParameter[] P = new SqlParameter[2];

            SqlParameter P0 = new SqlParameter();
            P0.ParameterName = "@follow";
            P0.SqlDbType = System.Data.SqlDbType.NVarChar;
            P0.Value = follow;
            P[0] = P0;

            SqlParameter P1 = new SqlParameter();
            P1.ParameterName = "@userName";
            P1.SqlDbType = System.Data.SqlDbType.NVarChar;
            P1.Value = user;
            P[1] = P1;


            DA.Exec("InsertData", P);
            Response.Redirect("Home.aspx");

        }

    }
}