using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.WebSockets;

namespace TwitterApp
{
    public class DataAgent
    {
        string CS = "Data Source=DESKTOP-TPMOEFU;Initial Catalog=\"Twitter App\";Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public void Exec(string SP, SqlParameter[] P)
        {
            SqlConnection CON = new SqlConnection();
            CON.ConnectionString = CS;
            CON.Open();

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = CON;
            CMD.CommandText = SP;
            CMD.CommandType = CommandType.StoredProcedure;

            if (P != null) CMD.Parameters.AddRange(P);

            CMD.ExecuteNonQuery();
        }

        public DataTable GetDT(string SP, SqlParameter[] P)
        {
            SqlConnection CON = new SqlConnection();
            CON.ConnectionString = CS;
            CON.Open();

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = CON;
            CMD.CommandText = SP;
            CMD.CommandType = CommandType.StoredProcedure;

            if (P != null) CMD.Parameters.AddRange(P);

            SqlDataAdapter ADP = new SqlDataAdapter();
            ADP.SelectCommand = CMD;
            DataSet ds = new DataSet();
            ADP.Fill(ds);

            return ds.Tables[0];
        }

        public string getHTML(string SP, SqlParameter[] P)
        {
            DataTable DT = GetDT(SP, P);
            StringBuilder html = new StringBuilder();

            html.Append("<html><table border='1'>");

            html.Append("<tr>");
            foreach (DataColumn COL in DT.Columns)
            {
                html.Append("<td><b>" + COL + "</b></td>");
            }
            //html.Append("<td><b>Edit</b></td>");
            //html.Append("<td><b>Delete</b></td>");

            html.Append("</tr>");

            foreach (DataRow dr in DT.Rows)
            {
                string k = dr[0].ToString();

                html.Append("<tr>");
                foreach (DataColumn COL in DT.Columns)
                {
                    html.Append("<td>" + dr[COL].ToString() + "</td>");
                }
                //html.Append("<td><a href='edit.aspx'>Edit</a></td>");
                //html.Append("<td><a href='del.aspx?K=" + k + "'>Del</a></td>");
                html.Append("</tr>");
            }
            html.Append("</table></html>");

            return html.ToString();
        }
        public string getUsers(string SP, SqlParameter[] P, string z)
        {
            DataTable DT = GetDT(SP, P);
            StringBuilder html = new StringBuilder();

            html.Append("<html><table border='1'><tr>");

            // Create column headers
            foreach (DataColumn COL in DT.Columns)
            {
                html.Append("<td><b>" + COL.ColumnName + "</b></td>");
            }

            html.Append("<td><b>Follow</b></td></tr>");

            // Generate rows
            foreach (DataRow dr in DT.Rows)
            {
                string userName = dr["userName"].ToString();
                string imgPath = dr["imgPath"].ToString();

                html.Append("<tr>");

                // Display user information, including the user's image
                foreach (DataColumn COL in DT.Columns)
                {
                    if (COL.ColumnName == "imgPath")
                    {
                        html.Append("<td><img src='" + imgPath + "' width='100' height='100'></td>");
                    }
                    else
                    {
                        html.Append("<td>" + dr[COL].ToString() + "</td>");
                    }
                }

                // Add the "Follow" link with parameters
                html.Append("<td><a href='addfollow.aspx?K=" + userName + "&P=" + z + "'>Follow</a></td>");
                html.Append("</tr>");
            }

            html.Append("</table></html>");

            return html.ToString();
        }


    }
}