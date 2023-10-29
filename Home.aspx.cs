using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwitterApp;

namespace TwitterApp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string enteredUsername = Session["Username"] as string;

            if (string.IsNullOrEmpty(enteredUsername) && !IsPostBack)
            {
                enteredUsername = Request.QueryString["username"];
                Session["Username"] = enteredUsername;
            }

            if (!string.IsNullOrEmpty(enteredUsername))
            {
                DataAgent DA = new DataAgent();

                Response.Write("<table style='border: 0px solid black;'>");


                // Parameters for the "getTweet" operation
                SqlParameter[] P = new SqlParameter[1];
                SqlParameter P0 = new SqlParameter();
                P0.ParameterName = "@userName";
                P0.SqlDbType = System.Data.SqlDbType.NVarChar;
                P0.Value = enteredUsername;
                P[0] = P0;

                // Start a new table row
                Response.Write("<tr>");
                Response.Write("</td>");
                Response.Write("<td style='width: 2%;'>");
                // Retrieve and display the tweet data in the first column
                Response.Write("<td  style='width: 10%;'>");
                

                string u = DA.getUsers("active_users", null, enteredUsername);
                Response.Write(u);


                Response.Write("</td>");
                Response.Write("<td style='width: 8%;'>");
                Response.Write("</td>");
                // Parameters for the "active_users" operation
                // Retrieve and display the active users data in the second column
                Response.Write("<td>");

                string h = DA.getHTML("getTweet", P);
                Response.Write(h);


                Response.Write("</td>");
                Response.Write("<td style='width: 13%;'>");
                Response.Write("</td>");
                // Parameters for the "getfollow" operation
                SqlParameter[] Po = new SqlParameter[1];
                SqlParameter P1 = new SqlParameter();
                P1.ParameterName = "@userName";
                P1.SqlDbType = System.Data.SqlDbType.NVarChar;
                P1.Value = enteredUsername;
                Po[0] = P1;

                // Retrieve and display the follow data in the third column
                Response.Write("<td>");
                string f = DA.getHTML("getfollow", Po);
                Response.Write(f);
                Response.Write("</td>");
                Response.Write("<td style='width: 13%;'>");
                Response.Write("</td>");
                // Parameters for the "GetUserTweets" operation
                SqlParameter[] CC = new SqlParameter[1];
                SqlParameter CC0 = new SqlParameter();
                CC0.ParameterName = "@userName";
                CC0.SqlDbType = System.Data.SqlDbType.NVarChar;
                CC0.Value = enteredUsername;
                CC[0] = CC0;

                // Retrieve and display the user's tweets in the fourth column
                Response.Write("<td>");
                string t = DA.getHTML("GetUserTweets", CC);
                Response.Write(t);
                Response.Write("</td>");
                Response.Write("<td style='width: 13%;'>");
                Response.Write("</td>");
                // End the table row
                Response.Write("</tr>");

                Response.Write("</table>");
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = Request.QueryString["username"];

            DataAgent DA = new DataAgent();

            SqlParameter[] P = new SqlParameter[2];

            SqlParameter P0 = new SqlParameter();
            P0.ParameterName = "@enteredUsername";
            P0.SqlDbType = System.Data.SqlDbType.NVarChar;
            P0.Value = enteredUsername;
            P[0] = P0;

            SqlParameter P1 = new SqlParameter();
            P1.ParameterName = "@newTweet";
            P1.SqlDbType = System.Data.SqlDbType.NVarChar;
            P1.Value = this.tweet.Text;
            P[1] = P1;


            DA.Exec("addTweet", P);
            //new_load();
            Response.Redirect("Home.aspx");
        }

        private void new_load()
        {
            string enteredUsername = Request.QueryString["username"];


            DataAgent DA = new DataAgent();

            SqlParameter[] P = new SqlParameter[1];

            SqlParameter P0 = new SqlParameter();
            P0.ParameterName = "@userName";
            P0.SqlDbType = System.Data.SqlDbType.NVarChar;
            P0.Value = enteredUsername;
            P[0] = P0;

            Response.Clear();
            string h = DA.getHTML("getTweet", P);
            Response.Write(h);

            string u = DA.getUsers("active_users", null, enteredUsername);
            Response.Write(u);



        }
    }
}
