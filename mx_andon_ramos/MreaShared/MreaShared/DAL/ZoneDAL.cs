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
    public class ZoneDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<Zone> getZone(Zone obj)
        {
            string queryString;
            List<Zone> list = new List<Zone>();
            if (obj.idZone == 0)
            {
                queryString = "select * from " + schema + ".mrea_zona";
            }
            else
            {
                queryString = "select * from " + schema + ".mrea_zona where id_zona = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (obj.idZone != 0)
                    command.Parameters.AddWithValue("@id", obj.idZone);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Zone obj2 = new Zone();
                    obj2.idZone = Convert.ToInt32(reader["id_zona"]);
                    obj2.name = Convert.ToString(reader["nombre"]);
                    obj2.desc = Convert.ToString(reader["descripcion"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
        public int insertZone(Zone andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".mrea_zona(nombre,descripcion) output inserted.id_zona VALUES(@v1,@v2)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@v2", andon.desc);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateZone(Zone andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".mrea_zona SET nombre = @v1, descripcion = @v2 WHERE id_zona = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@v2", andon.desc);
                command.Parameters.AddWithValue("@id", andon.idZone);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteZone(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".mrea_zona WHERE id_zona = @id";
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
        public List<Zone> searchZone(Zone obj)
        {
            string queryString;
            List<Zone> list = new List<Zone>();
            queryString = "select * from " + schema + ".mrea_zona where nombre = @val";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@val", obj.name);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Zone obj2 = new Zone();
                    obj2.idZone = Convert.ToInt32(reader["id_zona"]);
                    obj2.name = Convert.ToString(reader["nombre"]);
                    obj2.desc = Convert.ToString(reader["descripcion"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
    }
}
