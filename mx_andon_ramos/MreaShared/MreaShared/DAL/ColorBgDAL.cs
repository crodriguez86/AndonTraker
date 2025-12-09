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
    public class ColorBgDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<ColorBg> getColorBg(ColorBg ColorBg)
        {
            string queryString;
            List<ColorBg> list = new List<ColorBg>();
            if (ColorBg.idBg == 0)
            {
                queryString = "select * from " + schema + ".andon_color_bg";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_color_bg where id_bg = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (ColorBg.idBg != 0)
                    command.Parameters.AddWithValue("@id", ColorBg.idBg);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ColorBg obj = new ColorBg();
                    obj.idBg = Convert.ToInt32(reader["id_bg"]);
                    obj.name = Convert.ToString(reader["name"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public int insertColorBg(ColorBg andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_color_bg(name) output inserted.id_bg VALUES(@v1)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateColorBg(ColorBg andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_color_bg SET name = @v1 WHERE id_bg = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@id", andon.idBg);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteColorBg(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_color_bg WHERE id_bg = @id";
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
        public List<ColorBg> searchColorBg(ColorBg obj)
        {
            string queryString;
            List<ColorBg> list = new List<ColorBg>();
            queryString = "select * from " + schema + ".andon_color_bg where name = @val";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@val", obj.name);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ColorBg obj2 = new ColorBg();
                    obj.idBg = Convert.ToInt32(reader["id_bg"]);
                    obj.name = Convert.ToString(reader["name"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
    }
}
