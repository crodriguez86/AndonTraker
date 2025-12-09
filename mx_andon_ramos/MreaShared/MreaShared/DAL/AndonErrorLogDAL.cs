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
    public class AndonErrorLogDAL
    {
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<AndonErrorLog> GetAll()
        {
            List<AndonErrorLog> list = new List<AndonErrorLog>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_error_log order by id_error desc";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj        = new AndonErrorLog();
                    obj.idError    = Convert.ToInt32(reader["id_error"]);
                    obj.message    = reader["message"]     == DBNull.Value ? null : Convert.ToString(reader["message"]);
                    obj.stackTrace = reader["stack_trace"] == DBNull.Value ? null : Convert.ToString(reader["stack_trace"]);
                    obj.ipAddress  = reader["ip_address"]  == DBNull.Value ? null : Convert.ToString(reader["ip_address"]);
                    obj.deviceName = reader["device_name"] == DBNull.Value ? null : Convert.ToString(reader["device_name"]);
                    obj.idApp      = reader["andon_app"]   == DBNull.Value ? 0 : Convert.ToInt32(reader["andon_app"]);
                    obj.errorDate  = reader["error_date"]  == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["error_date"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public AndonErrorLog GetById(int id)
        {
            AndonErrorLog obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_error_log where id_error = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj            = new AndonErrorLog();
                    obj.idError    = Convert.ToInt32(reader["id_error"]);
                    obj.message    = reader["message"]     == DBNull.Value ? null : Convert.ToString(reader["message"]);
                    obj.stackTrace = reader["stack_trace"] == DBNull.Value ? null : Convert.ToString(reader["stack_trace"]);
                    obj.ipAddress  = reader["ip_address"]  == DBNull.Value ? null : Convert.ToString(reader["ip_address"]);
                    obj.deviceName = reader["device_name"] == DBNull.Value ? null : Convert.ToString(reader["device_name"]);
                    obj.idApp      = reader["andon_app"]   == DBNull.Value ? 0 : Convert.ToInt32(reader["andon_app"]);
                    obj.errorDate  = reader["error_date"]  == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["error_date"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }

        public int Insert(AndonErrorLog obj)
        {
            int id = 0;
            string sql = "INSERT INTO adn.andon_error_log(message, stack_trace, id_address, device_name, andon_app, error_date) values(@v1, @v2, @v3, @v4, @v5, getdate())";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.message ?? SqlString.Null);
                command.Parameters.AddWithValue("@v2", obj.stackTrace ?? SqlString.Null);
                command.Parameters.AddWithValue("@v3", obj.ipAddress ?? SqlString.Null);
                command.Parameters.AddWithValue("@v4", obj.deviceName ?? SqlString.Null);
                command.Parameters.AddWithValue("@v5", obj.idApp);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        
        public bool Delete(int id)
        {
            bool valid = false;
            string sql = "delete adn.andon_error_log WHERE [id_error] = @id";
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
        public bool DeleteAll()
        {
            bool valid = false;
            string sql = "delete adn.andon_error_log";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool DeleteFromDates(DateTime from, DateTime to)
        {
            bool valid = false;
            string sql = "delete adn.andon_error_log where error_date between @v1 and @v2";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", from);
                command.Parameters.AddWithValue("@v2", to);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public List<AndonErrorLog> GetAllFromDates(DateTime from, DateTime to)
        {
            List<AndonErrorLog> list = new List<AndonErrorLog>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_error_log where error_date between @v1 and @v2 order by id_error desc";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", from);
                command.Parameters.AddWithValue("@v2", to);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonErrorLog();
                    obj.idError = Convert.ToInt32(reader["id_error"]);
                    obj.message = reader["message"] == DBNull.Value ? null : Convert.ToString(reader["message"]);
                    obj.stackTrace = reader["stack_trace"] == DBNull.Value ? null : Convert.ToString(reader["stack_trace"]);
                    obj.ipAddress = reader["ip_address"] == DBNull.Value ? null : Convert.ToString(reader["ip_address"]);
                    obj.deviceName = reader["device_name"] == DBNull.Value ? null : Convert.ToString(reader["device_name"]);
                    obj.idApp = reader["andon_app"] == DBNull.Value ? 0 : Convert.ToInt32(reader["andon_app"]);
                    obj.errorDate = reader["error_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["error_date"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
    }
}
