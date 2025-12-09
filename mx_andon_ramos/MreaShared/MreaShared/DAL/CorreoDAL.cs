using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MreaShared.DAL
{
    public class CorreoDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<Correos> getMailsByType(int idType)
        {
            List<Correos> list = new List<Correos>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 8;
                command.Parameters.Add("@idType", SqlDbType.Int).Value = idType;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Correos objCorreo = new Correos();
                    objCorreo.id = Convert.ToInt32(reader["id_email"]);
                    objCorreo.id_type = Convert.ToInt32(reader["id_type"]);
                    objCorreo.correo = Convert.ToString(reader["email"]);
                    list.Add(objCorreo);
                }
                reader.Close();
            }
            return list;
        }
        public List<Correos> getMailsByZone(int idZone)
        {
            List<Correos> list = new List<Correos>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 9;
                command.Parameters.Add("@idZone", SqlDbType.Int).Value = idZone;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Correos objCorreo = new Correos();
                    objCorreo.id = Convert.ToInt32(reader["id_email"]);
                    objCorreo.id_type = Convert.ToInt32(reader["id_zone"]);
                    objCorreo.correo = Convert.ToString(reader["email"]);
                    list.Add(objCorreo);
                }
                reader.Close();
            }
            return list;
        }
        public List<Correos> getMailsByLevel(int level, int idType)
        {
            List<Correos> list = new List<Correos>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 14;
                command.Parameters.Add("@level", SqlDbType.Int).Value = level;
                command.Parameters.Add("@idType", SqlDbType.Int).Value = idType;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Correos objCorreo = new Correos();
                    objCorreo.id = Convert.ToInt32(reader["id_email"]);
                    objCorreo.level = Convert.ToInt32(reader["p_level"]);
                    objCorreo.correo = Convert.ToString(reader["email"]);
                    list.Add(objCorreo);
                }
                reader.Close();
            }
            return list;
        }

        public List<Correos> getCorreos(Correos obj)
        {
            string queryString;
            List<Correos> list = new List<Correos>();
            if (!String.IsNullOrWhiteSpace(obj.correo))
            {
                queryString = "SELECT E.*,STUFF((SELECT '; ' + CONVERT(varchar, EXL.p_level) FROM adn.andon_emailxlevel EXL WHERE E.id_email = EXL.id_email FOR XML PATH('')), 1, 1, '') level_email FROM adn.andon_email E where E.email like @email";
            }
            else if (obj.id == 0)
            {
                queryString = "SELECT E.*,STUFF((SELECT '; ' + CONVERT(varchar, EXL.p_level) FROM adn.andon_emailxlevel EXL WHERE E.id_email = EXL.id_email FOR XML PATH('')), 1, 1, '') level_email FROM adn.andon_email E";
            }
            else
            {
                queryString = "SELECT E.*,STUFF((SELECT '; ' + CONVERT(varchar, EXL.p_level) FROM adn.andon_emailxlevel EXL WHERE E.id_email = EXL.id_email FOR XML PATH('')), 1, 1, '') level_email FROM adn.andon_email E where E.id_email = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (!String.IsNullOrWhiteSpace(obj.correo))
                    command.Parameters.AddWithValue("@email", "%" + obj.correo + "%");
                else if (obj.id != 0)
                    command.Parameters.AddWithValue("@id", obj.id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Correos obj2 = new Correos();
                    obj2.id = Convert.ToInt32(reader["id_email"]);
                    obj2.correo = Convert.ToString(reader["email"]);
                    obj2.levelEmail = reader["level_email"] == DBNull.Value ? "None" : Convert.ToString(reader["level_email"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
        public int insertCorreos(Correos andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_email(email) output inserted.id_email VALUES(@v1)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.correo);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateCorreos(Correos andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_email SET email = @v1 WHERE id_email = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.correo);
                command.Parameters.AddWithValue("@id", andon.id);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteCorreos(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_email WHERE id_email = @id";
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
        public List<Correos> searchCorreos(Correos obj)
        {
            string queryString;
            List<Correos> list = new List<Correos>();
            queryString = "select * from " + schema + ".andon_email where email = @val";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@val", obj.correo);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Correos obj2 = new Correos();
                    obj2.id = Convert.ToInt32(reader["id_email"]);
                    obj2.correo = Convert.ToString(reader["email"]);
                    list.Add(obj2);
                }
                reader.Close();
            }
            return list;
        }
    }
}
