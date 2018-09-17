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
                cmd.Connection = con;
                //con.Open();

                cmd.CommandText = "spAddEmploee";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Employee", "ron");
                cmd.Parameters.AddWithValue("@ManagerID", 8);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@ID";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();

                cmd.ExecuteNonQuery();
                string EmpID = outputParameter.Value.ToString();
                Response.Write("ID = " + EmpID + "<br/>");
               
            }
            //Response.Write("hello");
        }
    }
}

Web.config/App.config
<connectionStrings>
    <add name="DBCS" connectionString="Data Source=.;database = Sample;Integrated Security=SSPI" providerName="System.Data.SqlClient" />
</connectionStrings>