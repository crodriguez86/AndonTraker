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
    public class EmailByTypeDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<EmailByType> getEmailByType(EmailByType obj)
        {
            string queryString;
            List<EmailByType> list = new List<EmailByType>();
            if (obj.idExt == 0)
            {
                queryString = "select EXT.*, E.email, T.name from " + schema + ".andon_emailxtype EXT inner join " + schema + ".andon_email E on E.id_email = EXT.id_email inner join " + schema + ".andon_type T on T.id_type = EXT.id_type";
            }
            else
            {
                queryString = "select EXT.*, E.email, T.name from " + schema + ".andon_emailxtype EXT inner join " + schema + ".andon_email E on E.id_email = EXT.id_email inner join " + schema + ".andon_type T on T.id_type = EXT.id_type where EXT.id_ext = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (obj.idExt != 0)
                    command.Parameters.AddWithValue("@id", obj.idExt);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EmailByType obj2 = new EmailByType();
                    obj2.idExt = Convert.ToInt32(reader["id_ext"]);
                    obj2.idType = Convert.ToInt32(reader["id_type"]);
                    obj2.idEmail = Convert.ToInt32(reader["id_email"]);
                    obj2.nameEmail = Convert.ToString(reader["email"]);
                    obj2.nameType = Convert.ToString(reader["name"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
        public int insertEmailByType(EmailByType andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_emailxtype(id_type,id_email) output inserted.id_ext VALUES(@v1,@v2)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.idType);
                command.Parameters.AddWithValue("@v2", andon.idEmail);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateEmailByType(EmailByType andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_emailxtype SET id_type = @v1, id_email = @v2 WHERE id_ext = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.idType);
                command.Parameters.AddWithValue("@v2", andon.idEmail);
                command.Parameters.AddWithValue("@id", andon.idExt);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteEmailByType(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_emailxtype WHERE id_ext = @id";
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
        public bool findEmailByType(int idType, int idEmail)
        {
            bool found = false;
            string queryString;
            queryString = "select * from " + schema + ".andon_emailxtype where id_type = @v1 and id_email = @v2";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@v1", idType);
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
        public List<EmailByType> searchEmailByType(int id, int option)
        {
            if (option < 1 || option > 2)
                throw new Exception("Opcion no valida");
            string queryString = "";
            List<EmailByType> list = new List<EmailByType>();
            if (option == 1)//Buscar por tipo
                queryString = "select EXT.*, E.email, T.name,STUFF((SELECT '; ' + CONVERT(varchar, EXL.p_level) FROM adn.andon_emailxlevel EXL WHERE E.id_email = EXL.id_email FOR XML PATH('')), 1, 1, '') level_email from adn.andon_emailxtype EXT inner join adn.andon_email E on E.id_email = EXT.id_email inner join adn.andon_type T on T.id_type = EXT.id_type where EXT.id_type = @v1";
            else if(option == 2)//Burcar por email
                queryString = "select EXT.*, E.email, T.name,STUFF((SELECT '; ' + CONVERT(varchar, EXL.p_level) FROM adn.andon_emailxlevel EXL WHERE E.id_email = EXL.id_email FOR XML PATH('')), 1, 1, '') level_email from adn.andon_emailxtype EXT inner join adn.andon_email E on E.id_email = EXT.id_email inner join adn.andon_type T on T.id_type = EXT.id_type where EXT.id_email = @v1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@v1", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EmailByType obj2 = new EmailByType();
                    obj2.idExt = Convert.ToInt32(reader["id_ext"]);
                    obj2.idType = Convert.ToInt32(reader["id_type"]);
                    obj2.idEmail = Convert.ToInt32(reader["id_email"]);
                    obj2.nameEmail = Convert.ToString(reader["email"]);
                    obj2.nameType = Convert.ToString(reader["name"]);
                    obj2.levelEmail = reader["level_email"] == DBNull.Value ? "None" : Convert.ToString(reader["level_email"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
    }
}
