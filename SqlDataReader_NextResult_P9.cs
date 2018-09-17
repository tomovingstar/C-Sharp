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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Employee; Select * from Employee;";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    ProductsGridView.DataSourse = rdr;
                    ProductsGridView.DataBind();

                    while (rdr.NextResult())
                    {
                        CategoriesGridView.DataSource = rdr;
                        CategoriesGridView.DataBind();
                    }
                   
                }
                //cmd.ExecuteReader();
                
                //Response.Write("hello");
            }
            Response.Write("hello");
        }
    }
}