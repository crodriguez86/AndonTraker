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
    public class EmailByLevelDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<EmailByLevel> getEmailByLevel(EmailByLevel obj)
        {
            string queryString;
            List<EmailByLevel> list = new List<EmailByLevel>();
            if (obj.idExl == 0)
            {
                queryString = "select EXL.*, E.email from " + schema + ".andon_emailxlevel EXL inner join " + schema + ".andon_email E on E.id_email = EXL.id_email";
            }
            else
            {
                queryString = "select EXL.*, E.email, T.name from " + schema + ".andon_emailxlevel EXL inner join " + schema + ".andon_email E on E.id_email = EXL.id_email where EXL.id_exl = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (obj.idExl != 0)
                    command.Parameters.AddWithValue("@id", obj.idExl);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EmailByLevel obj2 = new EmailByLevel();
                    obj2.idExl = Convert.ToInt32(reader["id_exl"]);
                    obj2.idLevel = Convert.ToInt32(reader["p_level"]);
                    obj2.idEmail = Convert.ToInt32(reader["id_email"]);
                    obj2.nameEmail = Convert.ToString(reader["email"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
        public int insertEmailByLevel(EmailByLevel andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_emailxlevel(p_level,id_email) output inserted.id_exl VALUES(@v1,@v2)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.idLevel);
                command.Parameters.AddWithValue("@v2", andon.idEmail);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateEmailByLevel(EmailByLevel andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_emailxlevel SET p_level = @v1, id_email = @v2 WHERE id_exl = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.idLevel);
                command.Parameters.AddWithValue("@v2", andon.idEmail);
                command.Parameters.AddWithValue("@id", andon.idExl);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteEmailByLevel(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_emailxlevel WHERE id_exl = @id";
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
        public bool findEmailByLevel(int idLevel, int idEmail)
        {
            bool found = false;
            string queryString;
            queryString = "select * from " + schema + ".andon_emailxlevel where p_level = @v1 and id_email = @v2";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@v1", idLevel);
                command.Parameters.AddWithValue("@v2", idEmail);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    found = true;
                }
                reader.Close();
            }
            return found;
        }
        public List<EmailByLevel> searchEmailByLevel(int id, int option)
        {
            if (option < 1 || option > 2)
                throw new Exception("Opcion no valida");
            List<EmailByLevel> list = new List<EmailByLevel>();
            string queryString = "";
            if (option == 1)//Buscar por nivel
                queryString = "select EXL.*, E.email from " + schema + ".andon_emailxlevel EXL inner join " + schema + ".andon_email E on E.id_email = EXL.id_email where p_level = @v1";
            else if (option == 2)//Burcar por email
                queryString = "select EXL.*, E.email from " + schema + ".andon_emailxlevel EXL inner join " + schema + ".andon_email E on E.id_email = EXL.id_email where id_email = @v1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@v1", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EmailByLevel obj2 = new EmailByLevel();
                    obj2.idExl = Convert.ToInt32(reader["id_exl"]);
                    obj2.idLevel = Convert.ToInt32(reader["p_level"]);
                    obj2.idEmail = Convert.ToInt32(reader["id_email"]);
                    obj2.nameEmail = Convert.ToString(reader["email"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
    }
}
