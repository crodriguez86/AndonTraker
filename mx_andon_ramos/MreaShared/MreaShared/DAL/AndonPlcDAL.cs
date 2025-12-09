using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace MreaShared.DAL
{
    public class AndonPlcDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<AndonPlc> getAndonPlc(AndonPlc andonPlc)
        {
            string queryString;
            List<AndonPlc> list = new List<AndonPlc>();
            if (andonPlc.idPlc == 0)
            {
                queryString = "select * from " + schema + ".andon_plc";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_plc where id_plc = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (andonPlc.idPlc != 0)
                    command.Parameters.AddWithValue("@id", andonPlc.idPlc);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonPlc obj = new AndonPlc();
                    obj.idPlc = Convert.ToInt32(reader["id_plc"]);
                    obj.name = Convert.ToString(reader["name"]);
                    obj.ip = Convert.ToString(reader["ip"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public int insertAndonPlc(AndonPlc andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_plc(name, ip) output inserted.id_plc VALUES(@v1,@v2)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@v2", andon.ip);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateAndonPlc(AndonPlc andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_plc SET name = @v1, ip = @v2 WHERE id_plc = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@v2", andon.ip);
                command.Parameters.AddWithValue("@id", andon.idPlc);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteAndonPlc(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_plc WHERE id_plc = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
    }
}
