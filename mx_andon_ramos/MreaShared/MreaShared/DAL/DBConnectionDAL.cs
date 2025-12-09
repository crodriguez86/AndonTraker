using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.DAL
{
    public class DBConnectionDAL
    {
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public bool CheckConnectionDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                return false;
            }

            return true;
        }
    }
}
