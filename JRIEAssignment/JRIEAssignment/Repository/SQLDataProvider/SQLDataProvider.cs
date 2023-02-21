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
            
                    SqlCommand cmd = new SqlCommand(aSqlQuery, connection);            
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
                return null;
            }
        }

        protected Object Execute(string aSqlQuery)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {                    

                    SqlCommand cmd = new SqlCommand(aSqlQuery, connection);
                    connection.Open();
                    var id = cmd.ExecuteNonQuery();
                    connection.Close();
                    return id;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }



    }
}
