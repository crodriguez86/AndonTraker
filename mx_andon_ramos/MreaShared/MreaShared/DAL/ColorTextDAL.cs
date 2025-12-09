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
    public class ColorTextDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<ColorText> getColorText(ColorText colorText)
        {
            string queryString;
            List<ColorText> list = new List<ColorText>();
            if (colorText.idText == 0)
            {
                queryString = "select * from " + schema + ".andon_color_text";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_color_text where id_text = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (colorText.idText != 0)
                    command.Parameters.AddWithValue("@id", colorText.idText);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ColorText obj = new ColorText();
                    obj.idText = Convert.ToInt32(reader["id_text"]);
                    obj.name = Convert.ToString(reader["name"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public int insertColorText(ColorText andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_color_text(name) output inserted.id_text VALUES(@v1)";
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
        public bool updateColorText(ColorText andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_color_text SET name = @v1 WHERE id_text = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@id", andon.idText);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteColorText(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_color_text WHERE id_text = @id";
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
        public List<ColorText> searchColorText(ColorText obj)
        {
            string queryString;
            List<ColorText> list = new List<ColorText>();
            queryString = "select * from " + schema + ".andon_color_text where name = @val";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@val", obj.name);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ColorText obj2 = new ColorText();
                    obj.idText = Convert.ToInt32(reader["id_text"]);
                    obj.name = Convert.ToString(reader["name"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
    }
}
