using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TwitterApp
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            SqlParameter[] P = new SqlParameter[1];
            DataAgent da = new DataAgent();

            SqlParameter P0 = new SqlParameter();
            P0.ParameterName = "UserName";
            P0.Value = enteredUsername;
            P0.SqlDbType = System.Data.SqlDbType.NVarChar;
            P[0] = P0;


            DataTable DT = da.GetDT("logTest", P);
           

            string storedPassword = DT.Rows[0]["passWord"].ToString();

            if (enteredPassword == storedPassword)
            {
               
                Response.Redirect("Home.aspx"); 
            }
            else
            {
            }
        }
    }
}
