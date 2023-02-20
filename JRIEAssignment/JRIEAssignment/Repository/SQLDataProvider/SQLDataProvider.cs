using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace JRIEAssignment.Repository.SQLDataProvider
{
    public class SQLDataProvider
    {
        private static string _connString = "Data Source=JABRANPC\\SQLEXPRESS;Initial Catalog = Assignment; Integrated Security=true;";

        protected DataTable GetData(string aSqlQuery)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    DataTable oTable = new DataTable("table");
                    // Creating the command object
                    SqlCommand cmd = new SqlCommand(aSqlQuery, connection);
                    // Opening Connection  
                    connection.Open();
                    using (var sdr = cmd.ExecuteReader())
                    {
                        oTable.Load(sdr);
                    }
                    connection.Close();
                    return oTable;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to load data " + e);
                return null;
            }
        }



    }
}
