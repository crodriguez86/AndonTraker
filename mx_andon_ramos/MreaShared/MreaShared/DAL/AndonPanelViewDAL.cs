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
    public class AndonPanelViewDAL
    {
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<AndonPanelView> GetAll()
        {
            List<AndonPanelView> list = new List<AndonPanelView>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_panel_view";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonPanelView();
                    obj.IdPanel = Convert.ToInt32(reader["id_panel"]);
                    obj.PanelName = reader["panel_name"] == DBNull.Value ? null : Convert.ToString(reader["panel_name"]);
                    obj.PanelDesc = reader["panel_desc"] == DBNull.Value ? null : Convert.ToString(reader["panel_desc"]);
                    obj.IdPlc = reader["id_plc"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_plc"]);
                    obj.PanelLastUpdate = reader["panel_last_update"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["panel_last_update"]);
                    obj.IdGroup = reader["id_group"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_group"]);
                    obj.PanelColumns = reader["panel_columns"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["panel_columns"]);
                    obj.PanelRows = reader["panel_rows"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["panel_rows"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public AndonPanelView GetById(int id)
        {
            AndonPanelView obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_panel_view where id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonPanelView();
                    obj.IdPanel = Convert.ToInt32(reader["id_panel"]);
                    obj.PanelName = reader["panel_name"] == DBNull.Value ? null : Convert.ToString(reader["panel_name"]);
                    obj.PanelDesc = reader["panel_desc"] == DBNull.Value ? null : Convert.ToString(reader["panel_desc"]);
                    obj.IdPlc = reader["id_plc"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_plc"]);
                    obj.PanelLastUpdate = reader["panel_last_update"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["panel_last_update"]);
                    obj.IdGroup = reader["id_group"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_group"]);
                    obj.PanelColumns = reader["panel_columns"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["panel_columns"]);
                    obj.PanelRows = reader["panel_rows"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["panel_rows"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }

        public int Insert(AndonPanelView obj)
        {
            int id = 0;
            string sql = "INSERT INTO adn.andon_panel_view ([panel_name],[panel_desc],[id_plc],[panel_last_update],[id_group],[panel_columns],[panel_rows]) OUTPUT INSERTED.id_panel VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.PanelName);
                command.Parameters.AddWithValue("@v2", obj.PanelDesc);
                command.Parameters.AddWithValue("@v3", DBNull.Value);
                command.Parameters.AddWithValue("@v4", DBNull.Value);
                command.Parameters.AddWithValue("@v5", obj.IdGroup);
                command.Parameters.AddWithValue("@v6", obj.PanelColumns);
                command.Parameters.AddWithValue("@v7", obj.PanelRows);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool Update(AndonPanelView obj)
        {
            bool valid = false;
            string sql = "UPDATE adn.andon_panel_view SET [panel_name] = @v1,[panel_desc] = @v2,[id_plc] = @v3,[panel_last_update] = @v4,[id_group] = @v5,[panel_columns] = @v6,[panel_rows] = @v7 WHERE id_panel = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.PanelName);
                command.Parameters.AddWithValue("@v2", obj.PanelDesc);
                command.Parameters.AddWithValue("@v3", DBNull.Value);
                command.Parameters.AddWithValue("@v4", DBNull.Value);
                command.Parameters.AddWithValue("@v5", obj.IdGroup);
                command.Parameters.AddWithValue("@v6", obj.PanelColumns);
                command.Parameters.AddWithValue("@v7", obj.PanelRows);
                command.Parameters.AddWithValue("@id", obj.IdPanel);

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
            string sql = "delete adn.andon_panel_view WHERE [id_panel] = @id";
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

        public List<AndonPanelView> GetAllByIdGroup(int idGroup)
        {
            List<AndonPanelView> list = new List<AndonPanelView>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_panel_view where id_group = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idGroup);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonPanelView();
                    obj.IdPanel = Convert.ToInt32(reader["id_panel"]);
                    obj.PanelName = reader["panel_name"] == DBNull.Value ? null : Convert.ToString(reader["panel_name"]);
                    obj.PanelDesc = reader["panel_desc"] == DBNull.Value ? null : Convert.ToString(reader["panel_desc"]);
                    obj.IdPlc = reader["id_plc"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_plc"]);
                    obj.PanelLastUpdate = reader["panel_last_update"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["panel_last_update"]);
                    obj.IdGroup = reader["id_group"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_group"]);
                    obj.PanelColumns = reader["panel_columns"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["panel_columns"]);
                    obj.PanelRows = reader["panel_rows"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["panel_rows"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
    }
}
