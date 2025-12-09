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
    public class AndonPanelGroupDAL
    {
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<AndonPanelGroup> GetAll()
        {
            List<AndonPanelGroup> list = new List<AndonPanelGroup>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select PG.*, L.nombre as name_line from adn.andon_panel_group PG inner join adn.mrea_linea L on L.id_linea = PG.id_line";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonPanelGroup();
                    obj.IdGroup = Convert.ToInt32(reader["id_group"]);
                    obj.GroupName = reader["group_name"] == DBNull.Value ? null : Convert.ToString(reader["group_name"]);
                    obj.GroupDesc = reader["group_desc"] == DBNull.Value ? null : Convert.ToString(reader["group_desc"]);
                    obj.IdLine =    reader["id_line"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_line"]);
                    obj.LineName = reader["name_line"] == DBNull.Value ? null : Convert.ToString(reader["name_line"]);
                    obj.GroupTowerIp = reader["group_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_ip"]);
                    obj.GroupTowerTestCommand = reader["group_tower_test_command"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_test_command"]);
                    obj.GroupTowerClearCommand = reader["group_tower_clear_command"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_clear_command"]);
                    obj.GroupTowerActive = reader["group_tower_active"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["group_tower_active"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public AndonPanelGroup GetById(int id)
        {
            AndonPanelGroup obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_panel_group where id_group = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonPanelGroup();
                    obj.IdGroup = Convert.ToInt32(reader["id_group"]);
                    obj.GroupName = reader["group_name"] == DBNull.Value ? null : Convert.ToString(reader["group_name"]);
                    obj.GroupDesc = reader["group_desc"] == DBNull.Value ? null : Convert.ToString(reader["group_desc"]);
                    obj.IdLine = reader["id_line"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_line"]);
                    obj.GroupTowerIp = reader["group_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_ip"]);
                    obj.GroupTowerTestCommand = reader["group_tower_test_command"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_test_command"]);
                    obj.GroupTowerClearCommand = reader["group_tower_clear_command"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_clear_command"]);
                    obj.GroupTowerActive = reader["group_tower_active"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["group_tower_active"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }

        public int Insert(AndonPanelGroup obj)
        {
            int id = 0;
            string sql = "INSERT INTO adn.andon_panel_group ([group_name],[group_desc],[id_line],group_tower_ip,group_tower_test_command,group_tower_active,group_tower_clear_command) OUTPUT INSERTED.id_group VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.GroupName);
                command.Parameters.AddWithValue("@v2", obj.GroupDesc);
                command.Parameters.AddWithValue("@v3", obj.IdLine);
                command.Parameters.AddWithValue("@v4", obj.GroupTowerIp ?? SqlString.Null);
                command.Parameters.AddWithValue("@v5", obj.GroupTowerTestCommand ?? SqlString.Null);
                command.Parameters.AddWithValue("@v6", obj.GroupTowerActive ?? SqlBoolean.Null);
                command.Parameters.AddWithValue("@v7", obj.GroupTowerClearCommand ?? SqlString.Null);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool Update(AndonPanelGroup obj)
        {
            bool valid = false;
            string sql = "UPDATE adn.andon_panel_group SET [group_name] = @v1,[group_desc] = @v2,[id_line] = @v3, [group_tower_ip] = @v4,[group_tower_test_command] = @v5,[group_tower_active] = @v6, [group_tower_clear_command] = @v7  WHERE id_group = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.GroupName);
                command.Parameters.AddWithValue("@v2", obj.GroupDesc);
                command.Parameters.AddWithValue("@v3", obj.IdLine);
                command.Parameters.AddWithValue("@v4", obj.GroupTowerIp ?? SqlString.Null);
                command.Parameters.AddWithValue("@v5", obj.GroupTowerTestCommand ?? SqlString.Null);
                command.Parameters.AddWithValue("@v6", obj.GroupTowerActive ?? SqlBoolean.Null);
                command.Parameters.AddWithValue("@v7", obj.GroupTowerClearCommand ?? SqlString.Null);
                command.Parameters.AddWithValue("@id", obj.IdGroup);

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
            string sql = "delete adn.andon_panel_group WHERE [id_group] = @id";
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
        public AndonPanelGroup GetGroupByIdPanel(int idPanel)
        {
            AndonPanelGroup obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select top 1 * from adn.andon_button B " +
                            "inner join adn.andon_panel_view V on B.id_panel = V.id_panel " +
                            "inner join adn.andon_panel_group G on G.id_group = V.id_group " +
                            "where B.id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPanel);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonPanelGroup();
                    obj.IdGroup = Convert.ToInt32(reader["id_group"]);
                    obj.GroupName = reader["group_name"] == DBNull.Value ? null : Convert.ToString(reader["group_name"]);
                    obj.GroupDesc = reader["group_desc"] == DBNull.Value ? null : Convert.ToString(reader["group_desc"]);
                    obj.IdLine = reader["id_line"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_line"]);
                    obj.GroupTowerIp = reader["group_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_ip"]);
                    obj.GroupTowerTestCommand = reader["group_tower_test_command"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_test_command"]);
                    obj.GroupTowerClearCommand = reader["group_tower_clear_command"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_clear_command"]);
                    obj.GroupTowerActive = reader["group_tower_active"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["group_tower_active"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }
    }
}
