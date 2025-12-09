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
    public class AndonPinsDAL
    {
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<AndonPins> GetAll()
        {
            List<AndonPins> list = new List<AndonPins>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_pins";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj       = new AndonPins();
                    obj.IdPin     = Convert.ToInt32(reader["id_pin"]);
                    obj.PinCode   = reader["pin_code"] == DBNull.Value ? null : Convert.ToString(reader["pin_code"]);
                    obj.PinDesc   = reader["pin_desc"] == DBNull.Value ? null : Convert.ToString(reader["pin_desc"]);
                    obj.PinActive = reader["pin_active"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["pin_active"]);
                    obj.IdZone    = reader["id_zone"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_zone"]);
                    obj.IdType    = reader["id_type"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_type"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public AndonPins GetById(int id)
        {
            AndonPins obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_pins where id_pin = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj           = new AndonPins();
                    obj.IdPin     = Convert.ToInt32(reader["id_pin"]);
                    obj.PinCode   = reader["pin_code"] == DBNull.Value ? null : Convert.ToString(reader["pin_code"]);
                    obj.PinDesc   = reader["pin_desc"] == DBNull.Value ? null : Convert.ToString(reader["pin_desc"]);
                    obj.PinActive = reader["pin_active"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["pin_active"]);
                    obj.IdZone    = reader["id_zone"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_zone"]);
                    obj.IdType    = reader["id_type"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_type"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }

        public int Insert(AndonPins obj)
        {
            int id = 0;
            string sql = "INSERT INTO adn.andon_pins ([pin_code],[pin_desc],[pin_active],[id_zone],[id_type]) OUTPUT INSERTED.id_pin VALUES (@v1,@v2,@v3,@v4,@v5)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.PinCode);
                command.Parameters.AddWithValue("@v2", obj.PinDesc);
                command.Parameters.AddWithValue("@v3", obj.PinActive);
                command.Parameters.AddWithValue("@v4", obj.IdZone);
                command.Parameters.AddWithValue("@v5", obj.IdType);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool Update(AndonPins obj)
        {
            bool valid = false;
            string sql = "UPDATE adn.andon_pins SET [pin_code] = @v1,[pin_desc] = @v2,[pin_active] = @v3,[id_zone] = @v4,[id_type] = @v5 WHERE id_pin = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.PinCode);
                command.Parameters.AddWithValue("@v2", obj.PinDesc);
                command.Parameters.AddWithValue("@v3", obj.PinActive);
                command.Parameters.AddWithValue("@v4", obj.IdZone);
                command.Parameters.AddWithValue("@v5", obj.IdType);
                command.Parameters.AddWithValue("@id", obj.IdPin);

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
            string sql = "delete adn.andon_pins WHERE [id_pin] = @id";
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
        public bool ValidCodeByIdMsg(int idMsg, string code)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select P.pin_code from adn.andon_msg M " +
                    "inner join adn.andon_pins P on M.id_type = P.id_type " +
                    "inner join adn.mrea_linea L on L.id_linea = M.id_linea " +
                    "inner join adn.mrea_zona Z on Z.id_zona = L.id_zona and P.id_zone = L.id_zona " +
                    "where M.id_msg = @v1 and P.pin_code = @v2 and P.pin_active = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", idMsg);
                command.Parameters.AddWithValue("@v2", code);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    found = true;
                    break;
                }
                reader.Close();
            }
            return found;
        }
        public bool CheckPinActiveByIdMsg(int idMsg)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select P.pin_code from adn.andon_msg M " +
                    "inner join adn.andon_pins P on M.id_type = P.id_type " +
                    "inner join adn.mrea_linea L on L.id_linea = M.id_linea " +
                    "inner join adn.mrea_zona Z on Z.id_zona = L.id_zona and P.id_zone = L.id_zona " +
                    "where M.id_msg = @v1 and P.pin_active = 1";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", idMsg);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    found = true;
                    break;
                }
                reader.Close();
            }
            return found;
        }
        public bool ValidOperatorCodeByIdMsg(int idMsg, string code)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select P.* from adn.andon_msg M " +
                    "inner join adn.mrea_linea L on L.id_linea = M.id_linea " +
                    "inner join adn.andon_pins P on L.id_zona = P.id_zone " +
                    "where M.id_msg = @v1 and P.pin_active = 1 and P.id_type is null and P.pin_code = @v2";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", idMsg);
                command.Parameters.AddWithValue("@v2", code);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    found = true;
                    break;
                }
                reader.Close();
            }
            return found;
        }
    }
}
