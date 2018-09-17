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
                cmd.CommandText = "Select * from Employee";
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("ID");
                    table.Columns.Add("Name");
                    table.Columns.Add("Price");
                    table.Columns.Add("DiscountedPrice");

                    while (rdr.Read())
                    {
                        DataRow dataRow = table.NewRow();

                        int OriginalPrice = Convert.ToInt32(rdr["UnitPrice"]);
                        double DiscountedPrice = OriginalPrice * 0.9;

                        dataRow["ID"] = rdr["ProductID"];
                        dataRow["Name"] = rdr["ProductName"];
                        dataRow["Price"] = OriginalPrice;
                        dataRow["DiscountedPrice"] = DiscountedPrice;
                        table.Rows.Add(dataRow);
                    }

                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
                //cmd.ExecuteReader();
                
                //Response.Write("hello");
            }
            Response.Write("hello");
        }
    }
}

Web.config/App.config
<connectionStrings>
    <add name="DBCS" connectionString="Data Source=.;database = Sample;Integrated Security=SSPI" providerName="System.Data.SqlClient" />
</connectionStrings>