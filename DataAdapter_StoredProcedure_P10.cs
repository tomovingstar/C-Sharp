using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string CS = "data source = L\\MSSQLSERVER01; database = Test; integrated security = SSPI";
            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                //SqlCommand cmd = new SqlCommand("Select * from Employee", con);
                //SqlDataAdapter da = new SqlDataAdapter("spGetProduct", con);
				SqlDataAdapter da = new SqlDataAdapter();
				da.SelectCommand = new SqlCommand("spGetProduct", con);
				da.SelectCommand.CommandType = CommandType.StoredProcedure;
				da.SelectCommand.Parameters.AddWithValue("@ProductID", 1)
                //da.CommandText = "Select * from Employee; Select * from Employee;";
                //da.Connection = con;
                DataSet ds = new DataSet();
                da.Fill(ds);
				//two data sets
                GridView1.DataSourse = ds.Tables["Table"];
                GridView1.DataBind();
				
				GridView2.DataSourse = ds.Tables["Table1"];
                GridView2.DataBind();

                //cmd.ExecuteReader();
                
                //Response.Write("hello");
            }
            Response.Write("hello");
        }
    }
}