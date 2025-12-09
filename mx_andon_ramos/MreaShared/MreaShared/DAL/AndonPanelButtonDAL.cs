using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace MreaShared.DAL
{
    public class AndonPanelButtonDAL
    {
        private string _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<AndonPanelButton> GetAll()
        {
            List<AndonPanelButton> list = new List<AndonPanelButton>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_button";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonPanelButton();
                    obj.IdButton = Convert.ToInt32(reader["id_button"]);
                    obj.ButtonName = reader["button_name"] == DBNull.Value ? null : Convert.ToString(reader["button_name"]);
                    obj.IdMsg = reader["id_msg"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_msg"]);
                    obj.ButtonColumn = reader["button_column"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_column"]);
                    obj.ButtonRow = reader["button_row"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_row"]);
                    obj.ButtonState = reader["button_state"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["button_state"]);
                    obj.IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    obj.IdPanel = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);
                    obj.ButtonTowerIp = reader["button_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_ip"]);
                    obj.ButtonTowerConfig = reader["button_tower_config"] == DBNull.Value ? null : (short?)Convert.ToInt16(reader["button_tower_config"]);
                    obj.ButtonTowerCommand = reader["button_tower_command"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command"]);
                    obj.ButtonTowerCommand2 = reader["button_tower_command_2"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command_2"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public AndonPanelButton GetById(int id)
        {
            AndonPanelButton obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_button where id_button = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonPanelButton();
                    obj.IdButton = Convert.ToInt32(reader["id_button"]);
                    obj.ButtonName = reader["button_name"] == DBNull.Value ? null : Convert.ToString(reader["button_name"]);
                    obj.IdMsg = reader["id_msg"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_msg"]);
                    obj.ButtonColumn = reader["button_column"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_column"]);
                    obj.ButtonRow = reader["button_row"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_row"]);
                    obj.ButtonState = reader["button_state"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["button_state"]);
                    obj.IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    obj.IdPanel = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);
                    obj.ButtonTowerIp = reader["button_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_ip"]);
                    obj.ButtonTowerConfig = reader["button_tower_config"] == DBNull.Value ? null : (short?)Convert.ToInt16(reader["button_tower_config"]);
                    obj.ButtonTowerCommand = reader["button_tower_command"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command"]);
                    obj.ButtonTowerCommand2 = reader["button_tower_command_2"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command_2"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }

        public int Insert(AndonPanelButton obj)
        {
            int id = 0;
            string sql = "INSERT INTO adn.andon_button ([button_name],[id_msg],[button_column],[button_row],[button_state],[is_binary],[id_panel],button_tower_ip,button_tower_config,button_tower_command,button_tower_command_2) OUTPUT INSERTED.id_button VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@v11)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.ButtonName);
                command.Parameters.AddWithValue("@v2", obj.IdMsg);
                command.Parameters.AddWithValue("@v3", obj.ButtonColumn);
                command.Parameters.AddWithValue("@v4", obj.ButtonRow);
                command.Parameters.AddWithValue("@v5", obj.ButtonState);
                command.Parameters.AddWithValue("@v6", obj.IsBinary);
                command.Parameters.AddWithValue("@v7", obj.IdPanel);

                command.Parameters.AddWithValue("@v8", obj.ButtonTowerIp ?? SqlString.Null);
                command.Parameters.AddWithValue("@v9", obj.ButtonTowerConfig ?? SqlInt16.Null);
                command.Parameters.AddWithValue("@v10", obj.ButtonTowerCommand ?? SqlString.Null);
                command.Parameters.AddWithValue("@v11", obj.ButtonTowerCommand2 ?? SqlString.Null);

                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool Update(AndonPanelButton obj)
        {
            bool valid = false;
            string sql = "UPDATE adn.andon_button SET [button_name] = @v1,[id_msg] = @v2,[button_column] = @v3,[button_row] = @v4,[button_state] = @v5,[is_binary] = @v6,[id_panel] = @v7, [button_tower_ip] = @v8,[button_tower_config] = @v9,[button_tower_command] = @v10,[button_tower_command_2] = @v11 WHERE id_button = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", obj.ButtonName);
                command.Parameters.AddWithValue("@v2", obj.IdMsg);
                command.Parameters.AddWithValue("@v3", obj.ButtonColumn);
                command.Parameters.AddWithValue("@v4", obj.ButtonRow);
                command.Parameters.AddWithValue("@v5", obj.ButtonState);
                command.Parameters.AddWithValue("@v6", obj.IsBinary);
                command.Parameters.AddWithValue("@v7", obj.IdPanel);

                command.Parameters.AddWithValue("@v8", obj.ButtonTowerIp ?? SqlString.Null);
                command.Parameters.AddWithValue("@v9", obj.ButtonTowerConfig ?? SqlInt16.Null);
                command.Parameters.AddWithValue("@v10", obj.ButtonTowerCommand ?? SqlString.Null);
                command.Parameters.AddWithValue("@v11", obj.ButtonTowerCommand2 ?? SqlString.Null);

                command.Parameters.AddWithValue("@id", obj.IdButton);

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
            string sql = "delete adn.andon_button WHERE [id_button] = @id";
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

        public List<AndonPanelButton> GetAllByIdPanel(int idPanel)
        {
            List<AndonPanelButton> list = new List<AndonPanelButton>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select B.*, M.id_av, M.msg, M.tag_value, T.id_type, T.name as name_type, BG.name as bg_name, TX.name as tx_name from [adn].[andon_button] B "+
                            " inner join adn.andon_msg M on M.id_msg = B.id_msg"+
                            " inner join adn.andon_type T on T.id_type = M.id_type"+
                            " inner join adn.andon_color_bg BG on T.id_bg = BG.id_bg"+
                            " inner join adn.andon_color_text TX on TX.id_text = T.id_text"+
                            " where id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPanel);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonPanelButton();
                    obj.IdButton = Convert.ToInt32(reader["id_button"]);
                    obj.ButtonName = reader["button_name"] == DBNull.Value ? null : Convert.ToString(reader["button_name"]);
                    obj.IdMsg = reader["id_msg"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_msg"]);
                    obj.ButtonColumn = reader["button_column"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_column"]);
                    obj.ButtonRow = reader["button_row"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_row"]);
                    obj.ButtonState = reader["button_state"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["button_state"]);
                    obj.IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    obj.IdPanel = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);
                    obj.IdTag = reader["id_av"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_av"]);
                    obj.TagValue = reader["tag_value"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["tag_value"]);

                    obj.IdType = reader["id_type"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_type"]);
                    obj.NameType = reader["name_type"] == DBNull.Value ? null : Convert.ToString(reader["name_type"]);
                    obj.BgName = reader["bg_name"] == DBNull.Value ? null : Convert.ToString(reader["bg_name"]);
                    obj.TxName = reader["tx_name"] == DBNull.Value ? null : Convert.ToString(reader["tx_name"]);
                    obj.Msg = reader["msg"] == DBNull.Value ? null : Convert.ToString(reader["msg"]);

                    obj.ButtonTowerIp = reader["button_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_ip"]);
                    obj.ButtonTowerConfig = reader["button_tower_config"] == DBNull.Value ? null : (short?)Convert.ToInt16(reader["button_tower_config"]);
                    obj.ButtonTowerCommand = reader["button_tower_command"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command"]);
                    obj.ButtonTowerCommand2 = reader["button_tower_command_2"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command_2"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public bool UpdateState(int id, bool state)
        {
            bool valid = false;
            string sql = "UPDATE adn.andon_button SET [button_state] = @v1 WHERE id_button = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", state);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public List<AndonPanelButton> GetAllActiveButtons(int idPanel)
        {
            List<AndonPanelButton> list = new List<AndonPanelButton>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select B.*, M.id_av, M.tag_value from [adn].[andon_button] B inner join adn.andon_msg M on M.id_msg = B.id_msg where B.button_state = 1 and B.id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPanel);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonPanelButton();
                    obj.IdButton = Convert.ToInt32(reader["id_button"]);
                    obj.ButtonName = reader["button_name"] == DBNull.Value ? null : Convert.ToString(reader["button_name"]);
                    obj.IdMsg = reader["id_msg"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_msg"]);
                    obj.ButtonColumn = reader["button_column"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_column"]);
                    obj.ButtonRow = reader["button_row"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_row"]);
                    obj.ButtonState = reader["button_state"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["button_state"]);
                    obj.IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    obj.IdPanel = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);
                    obj.IdTag = reader["id_av"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_av"]);
                    obj.TagValue = reader["tag_value"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["tag_value"]);

                    obj.ButtonTowerIp = reader["button_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_ip"]);
                    obj.ButtonTowerConfig = reader["button_tower_config"] == DBNull.Value ? null : (short?)Convert.ToInt16(reader["button_tower_config"]);
                    obj.ButtonTowerCommand = reader["button_tower_command"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command"]);
                    obj.ButtonTowerCommand2 = reader["button_tower_command_2"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command_2"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public AndonPanelButton GetByIdWithMsg(int id)
        {
            AndonPanelButton obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select B.*, M.id_av, M.msg, M.tag_value, T.id_type, T.name as name_type, BG.name as bg_name, TX.name as tx_name , T.is_binary from [adn].[andon_button] B " +
                            " inner join adn.andon_msg M on M.id_msg = B.id_msg" +
                            " inner join adn.andon_type T on T.id_type = M.id_type" +
                            " inner join adn.andon_color_bg BG on T.id_bg = BG.id_bg" +
                            " inner join adn.andon_color_text TX on TX.id_text = T.id_text" +
                            " where id_button = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonPanelButton();
                    obj.IdButton = Convert.ToInt32(reader["id_button"]);
                    obj.ButtonName = reader["button_name"] == DBNull.Value ? null : Convert.ToString(reader["button_name"]);
                    obj.IdMsg = reader["id_msg"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_msg"]);
                    obj.ButtonColumn = reader["button_column"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_column"]);
                    obj.ButtonRow = reader["button_row"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_row"]);
                    obj.ButtonState = reader["button_state"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["button_state"]);
                    obj.IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    obj.IdPanel = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);
                    obj.IdTag = reader["id_av"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_av"]);
                    obj.TagValue = reader["tag_value"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["tag_value"]);

                    obj.IdType = reader["id_type"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_type"]);
                    obj.NameType = reader["name_type"] == DBNull.Value ? null : Convert.ToString(reader["name_type"]);
                    obj.BgName = reader["bg_name"] == DBNull.Value ? null : Convert.ToString(reader["bg_name"]);
                    obj.TxName = reader["tx_name"] == DBNull.Value ? null : Convert.ToString(reader["tx_name"]);
                    obj.Msg = reader["msg"] == DBNull.Value ? null : Convert.ToString(reader["msg"]);

                    obj.ButtonTowerIp = reader["button_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_ip"]);
                    obj.ButtonTowerConfig = reader["button_tower_config"] == DBNull.Value ? null : (short?)Convert.ToInt16(reader["button_tower_config"]);
                    obj.ButtonTowerCommand = reader["button_tower_command"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command"]);
                    obj.ButtonTowerCommand2 = reader["button_tower_command_2"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command_2"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }
        public List<Andon> GetAllAndonMsgWithBinary()
        {
            List<Andon> list = new List<Andon>();
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT " +
                            "M.id_msg, " +
                            "M.msg + '-' + T.name + '-' + L.nombre as msg_format, " +
                            "M.msg, " +
                            "T.id_type, " +
                            "L.id_linea, " +
                            "L.nombre as name_line, " +
                            "T.name as name_type, " +
                            "T.is_binary " +
                            "FROM adn.andon_msg M " +
                            "INNER JOIN adn.andon_type T ON T.id_type = M.id_type " +
                            "INNER JOIN adn.mrea_linea L ON L.id_linea = M.id_linea";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idMessage = Convert.ToInt32(reader["id_msg"]);
                    objAndon.nameText = reader["msg_format"] == DBNull.Value ? null : Convert.ToString(reader["msg_format"]);
                    objAndon.message = reader["msg"] == DBNull.Value ? null : Convert.ToString(reader["msg"]);
                    objAndon.idLine = reader["id_linea"] == DBNull.Value ? -1 : (int)Convert.ToInt32(reader["id_linea"]);
                    objAndon.idType = reader["id_type"] == DBNull.Value ? -1 : (int)Convert.ToInt32(reader["id_type"]);
                    objAndon.nameLine = reader["name_line"] == DBNull.Value ? null : Convert.ToString(reader["name_line"]);
                    objAndon.nameType = reader["name_type"] == DBNull.Value ? null : Convert.ToString(reader["name_type"]);
                    objAndon.IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public bool MsgIsBinary(int idMsg)
        {
            bool isBinary = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT " +
                            "M.id_msg, " +
                            "M.msg, T.id_type, " +
                            "L.nombre as name_line, " +
                            "T.name as name_type, " +
                            "T.is_binary " +
                            "FROM adn.andon_msg M " +
                            "INNER JOIN adn.andon_type T ON T.id_type = M.id_type " +
                            "INNER JOIN adn.mrea_linea L ON L.id_linea = M.id_linea " +
                            "where id_msg = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idMsg);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bool? IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    if (IsBinary == true)
                    {
                        isBinary = true;
                    }
                    break;
                }
                reader.Close();
            }
            return isBinary;
        }
        public bool CheckColumnRowByPanel(int idPanel, int bc, int br)
        {
            bool repeated = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_button where button_column = @bc and button_row = @br and id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@bc", bc);
                command.Parameters.AddWithValue("@br", br);
                command.Parameters.AddWithValue("@id", idPanel);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    repeated = true;
                    break;
                }
                reader.Close();
            }
            return repeated;
        }
        public bool CheckIdMsgByPanel(int idPanel, int idMsg)
        {
            bool repeated = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_button where id_msg = @idMsg and id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idMsg", idMsg);
                command.Parameters.AddWithValue("@id", idPanel);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    repeated = true;
                    break;
                }
                reader.Close();
            }
            return repeated;
        }
        public AndonPanelButton GetButtonNameByPanel(int idPanel, string buttonName)
        {
            AndonPanelButton obj = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from adn.andon_button where button_name = @bn and id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@bn", buttonName);
                command.Parameters.AddWithValue("@id", idPanel);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonPanelButton();
                    obj.IdButton = Convert.ToInt32(reader["id_button"]);
                    obj.ButtonName = reader["button_name"] == DBNull.Value ? null : Convert.ToString(reader["button_name"]);
                    obj.IdMsg = reader["id_msg"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_msg"]);
                    obj.ButtonColumn = reader["button_column"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_column"]);
                    obj.ButtonRow = reader["button_row"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["button_row"]);
                    obj.ButtonState = reader["button_state"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["button_state"]);
                    obj.IsBinary = reader["is_binary"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(reader["is_binary"]);
                    obj.IdPanel = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);

                    obj.ButtonTowerIp = reader["button_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_ip"]);
                    obj.ButtonTowerConfig = reader["button_tower_config"] == DBNull.Value ? null : (short?)Convert.ToInt16(reader["button_tower_config"]);
                    obj.ButtonTowerCommand = reader["button_tower_command"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command"]);
                    obj.ButtonTowerCommand2 = reader["button_tower_command_2"] == DBNull.Value ? null : Convert.ToString(reader["button_tower_command_2"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }
        public string GetGlobalIpTower(int idPanel)
        {
            string IpTower = string.Empty;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select top 1 G.group_tower_ip from adn.andon_button B " +
                            "inner join adn.andon_panel_view V on B.id_panel = V.id_panel " +
                            "inner join adn.andon_panel_group G on G.id_group = V.id_group " +
                            "where B.id_panel = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPanel);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IpTower = reader["group_tower_ip"] == DBNull.Value ? null : Convert.ToString(reader["group_tower_ip"]);
                    break;
                }
                reader.Close();
            }
            return IpTower;
        }
    }
}
