using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace MreaShared.DAL
{
    public class UserDAL
    {
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<Users> GetAll()
        {
            List<Users> list = new List<Users>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.authorized_employees";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new Users();
                    obj.IdAuth = Convert.ToInt32(reader["id_auth"]);
                    obj.NoEmployee    = reader["no_nomina"]       == DBNull.Value ? null : Convert.ToString(reader["no_nomina"]);
                    obj.AuthPass      = reader["auth_pass"]       == DBNull.Value ? null : Convert.ToString(reader["auth_pass"]);
                    obj.AuthName      = reader["auth_name"]       == DBNull.Value ? null : Convert.ToString(reader["auth_name"]);
                    obj.AuthLastLogin = reader["auth_last_login"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["auth_last_login"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public Users GetById(int id)
        {
            Users obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.authorized_employees where id_auth = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new Users();
                    obj.IdAuth = Convert.ToInt32(reader["id_auth"]);
                    obj.NoEmployee = reader["no_nomina"]          == DBNull.Value ? null : Convert.ToString(reader["no_nomina"]);
                    obj.AuthPass = reader["auth_pass"]            == DBNull.Value ? null : Convert.ToString(reader["auth_pass"]);
                    obj.AuthName = reader["auth_name"]            == DBNull.Value ? null : Convert.ToString(reader["auth_name"]);
                    obj.AuthLastLogin = reader["auth_last_login"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["auth_last_login"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }
        public Users GetByNoEmployee(string noEmployee)
        {
            Users obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.authorized_employees where no_nomina = @ne";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ne", noEmployee);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new Users();
                    obj.IdAuth = Convert.ToInt32(reader["id_auth"]);
                    obj.NoEmployee = reader["no_nomina"] == DBNull.Value ? null : Convert.ToString(reader["no_nomina"]);
                    obj.AuthPass = reader["auth_pass"] == DBNull.Value ? null : Convert.ToString(reader["auth_pass"]);
                    obj.AuthName = reader["auth_name"] == DBNull.Value ? null : Convert.ToString(reader["auth_name"]);
                    obj.AuthLastLogin = reader["auth_last_login"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["auth_last_login"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }

        public int Insert(Users obj)
        {
            int id = 0;
            string sql = "INSERT INTO adn.authorized_employees (no_nomina,auth_pass,auth_name,auth_last_login) OUTPUT INSERTED.id_auth VALUES (@v1,@v2,@v3,@v4)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.NoEmployee ?? SqlString.Null);
                command.Parameters.AddWithValue("@v2", obj.AuthPass   ?? SqlString.Null);
                command.Parameters.AddWithValue("@v3", obj.AuthName   ?? SqlString.Null);
                command.Parameters.AddWithValue("@v4", DBNull.Value);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool Update(Users obj)
        {
            bool valid = false;
            string sql = string.Empty;
            if (obj.AuthLastLogin == null)
            {//Si la fecha viene null no actualizar ese campo en la base de datos
                sql = "UPDATE adn.authorized_employees SET [no_nomina] = @v1,[auth_pass] = @v2,[auth_name] = @v3 WHERE id_auth = @id";
            }
            else
            {
                sql = "UPDATE adn.authorized_employees SET [no_nomina] = @v1,[auth_pass] = @v2,[auth_name] = @v3, auth_last_login = @v4 WHERE id_auth = @id";
            }
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.NoEmployee    ?? SqlString.Null);
                command.Parameters.AddWithValue("@v2", obj.AuthPass      ?? SqlString.Null);
                command.Parameters.AddWithValue("@v3", obj.AuthName      ?? SqlString.Null);
                if (obj.AuthLastLogin != null)
                {
                    command.Parameters.AddWithValue("@v4", obj.AuthLastLogin);
                }
                command.Parameters.AddWithValue("@id", obj.IdAuth);

                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool UpdateLastLoginDate(Users obj)
        {
            bool valid = false;
            string sql = string.Empty;
            sql = "UPDATE adn.authorized_employees SET [auth_last_login] = @v1 WHERE id_auth = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.AuthLastLogin ?? SqlDateTime.Null);
                command.Parameters.AddWithValue("@id", obj.IdAuth);

                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool Delete(int id)
        {
            bool valid = false;
            string sql = "delete adn.authorized_employees WHERE [id_auth] = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
        public bool ValidUserByEmployeeAndPassword(string noNomina, string password)
        {
            bool valid = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.authorized_employees where no_nomina = @v1 and auth_pass = @v2";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", noNomina);
                command.Parameters.AddWithValue("@v2", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    valid = true;
                    break;
                }
                reader.Close();
            }
            return valid;
        }
    }
}
