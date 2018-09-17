using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

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
                cmd.CommandText = "Select Count(Employee) from Employee";
                cmd.Connection = con;
                con.Open();
                int TotalPows = (int)cmd.ExecuteScalar();
                //GridView1.DataSource = cmd.ExecuteReader();
                //GridView1.DataBind();
                Response.Write("Total Rows = "+ TotalPows.ToString());
            }
            //Response.Write("hello");
        }
    }
}

Web.config/App.config
<connectionStrings>
    <add name="DBCS" connectionString="Data Source=.;database = Sample;Integrated Security=SSPI" providerName="System.Data.SqlClient" />
</connectionStrings>