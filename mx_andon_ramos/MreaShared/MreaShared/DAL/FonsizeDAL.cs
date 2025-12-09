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
    public class FontsizeDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<AndonFontsize> getAndonFontsize(AndonFontsize obj)
        {
            string queryString;
            List<AndonFontsize> list = new List<AndonFontsize>();
            if (obj.idFont == 0)
            {
                queryString = "select * from " + schema + ".andon_fontsize";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_fontsize where id_font = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (obj.idFont != 0)
                    command.Parameters.AddWithValue("@id", obj.idFont);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonFontsize obj2 = new AndonFontsize();
                    obj2.idFont = Convert.ToInt32(reader["id_font"]);
                    obj2.font = Convert.ToInt32(reader["font"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
        public int insertAndonFontsize(AndonFontsize andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_fontsize(font) output inserted.id_font VALUES(@v1)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.font);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateAndonFontsize(AndonFontsize andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_fontsize SET font = @v1 WHERE id_font = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.font);
                command.Parameters.AddWithValue("@id", andon.idFont);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteAndonFontsize(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_fontsize WHERE id_font = @id";
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
        public List<AndonFontsize> searchAndonFontsize(AndonFontsize obj)
        {
            string queryString;
            List<AndonFontsize> list = new List<AndonFontsize>();
            queryString = "select * from " + schema + ".andon_fontsize where font = @val";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@val", obj.font);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonFontsize obj2 = new AndonFontsize();
                    obj2.idFont = Convert.ToInt32(reader["id_font"]);
                    obj2.font = Convert.ToInt32(reader["font"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
    }
}
