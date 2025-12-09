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
    public class AndonTypeDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<AndonType> getAndonType(AndonType andonType)
        {
            string queryString;
            List<AndonType> list = new List<AndonType>();
            if (andonType.idType == 0)
            {
                queryString = "select T.*, B.name as name_bg, C.name as name_text, BM.name as name_bg_monitor, F.font as font_production, F2.font as font_monitor from " + schema + ".andon_type T inner join " + schema + ".andon_color_bg B on B.id_bg = T.id_bg inner join " + schema + ".andon_color_text C on C.id_text = T.id_text left join " + schema + ".andon_color_bg BM on BM.id_bg = T.id_bg_monitor left join " + schema + ".andon_fontsize F on F.id_font = T.id_font left join " + schema + ".andon_fontsize F2 on F2.id_font = T.id_font2";
            }
            else
            {
                queryString = "select T.*, B.name as name_bg, C.name as name_text, BM.name as name_bg_monitor, F.font as font_production, F2.font as font_monitor from " + schema + ".andon_type T inner join " + schema + ".andon_color_bg B on B.id_bg = T.id_bg inner join " + schema + ".andon_color_text C on C.id_text = T.id_text left join " + schema + ".andon_color_bg BM on BM.id_bg = T.id_bg_monitor left join " + schema + ".andon_fontsize F on F.id_font = T.id_font left join " + schema + ".andon_fontsize F2 on F2.id_font = T.id_font2 where T.id_type = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (andonType.idType != 0)
                    command.Parameters.AddWithValue("@id", andonType.idType);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonType obj = new AndonType();
                    obj.idType = Convert.ToInt32(reader["id_type"]);
                    obj.name = Convert.ToString(reader["name"]);
                    obj.idBg = Convert.ToInt32(reader["id_bg"]);
                    obj.idText = Convert.ToInt32(reader["id_text"]);
                    obj.nameBg = Convert.ToString(reader["name_bg"]);
                    obj.nameText = Convert.ToString(reader["name_text"]);
                    obj.idFontProduction = Convert.ToInt32(reader["id_font"]);
                    obj.nameFontProduction = Convert.ToString(reader["font_production"]);
                    obj.idFontMonitor = Convert.ToInt32(reader["id_font2"]);
                    obj.nameFontMonitor = Convert.ToString(reader["font_monitor"]);
                    obj.showProduction = Convert.ToBoolean(reader["show_production"]);
                    obj.showMonitor = Convert.ToBoolean(reader["show_monitor"]);
                    obj.showSpare1 = Convert.ToBoolean(reader["show_spare1"]);
                    obj.showSpare2 = Convert.ToBoolean(reader["show_spare2"]);
                    obj.idBgMonitor = Convert.ToInt32(reader["id_bg_monitor"]);
                    obj.nameMonitorBg = Convert.ToString(reader["name_bg_monitor"]);
                    obj.isBinary = reader["is_binary"] == DBNull.Value ? false : Convert.ToBoolean(reader["is_binary"]);
                    obj.timeLimitLv2 = reader["str_limit_lv2"] == DBNull.Value ? null : Convert.ToString(reader["str_limit_lv2"]);
                    obj.timeLimitLv3 = reader["str_limit_lv3"] == DBNull.Value ? null : Convert.ToString(reader["str_limit_lv3"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public int insertAndonType(AndonType andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_type(name,id_bg,id_text,id_font,show_production,show_monitor,show_spare1,show_spare2,id_bg_monitor,id_font2,is_binary,str_limit_lv2,str_limit_lv3) output inserted.id_type VALUES(@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,0,@v11,@v12)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@v2", andon.idBg);
                command.Parameters.AddWithValue("@v3", andon.idText);
                command.Parameters.AddWithValue("@v4", andon.idFontProduction);
                command.Parameters.AddWithValue("@v5", andon.showProduction);
                command.Parameters.AddWithValue("@v6", andon.showMonitor);
                command.Parameters.AddWithValue("@v7", andon.showSpare1);
                command.Parameters.AddWithValue("@v8", andon.showSpare2);
                command.Parameters.AddWithValue("@v9", andon.idBgMonitor);
                command.Parameters.AddWithValue("@v10", andon.idFontMonitor);
                command.Parameters.AddWithValue("@v11", andon.timeLimitLv2 ?? SqlString.Null);
                command.Parameters.AddWithValue("@v12", andon.timeLimitLv3 ?? SqlString.Null);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateAndonType(AndonType andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_type SET name = @v1, id_bg = @v2, id_text = @v3, id_font = @v4, show_production = @v5, show_monitor = @v6, show_spare1 = @v7, show_spare2 = @v8, id_bg_monitor = @v9, id_font2 = @v10,str_limit_lv2 = @v11,str_limit_lv3 = @v12 WHERE id_type = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.name);
                command.Parameters.AddWithValue("@v2", andon.idBg);
                command.Parameters.AddWithValue("@v3", andon.idText);
                command.Parameters.AddWithValue("@v4", andon.idFontProduction);
                command.Parameters.AddWithValue("@v5", andon.showProduction);
                command.Parameters.AddWithValue("@v6", andon.showMonitor);
                command.Parameters.AddWithValue("@v7", andon.showSpare1);
                command.Parameters.AddWithValue("@v8", andon.showSpare2);
                command.Parameters.AddWithValue("@v9", andon.idBgMonitor);
                command.Parameters.AddWithValue("@v10", andon.idFontMonitor);
                command.Parameters.AddWithValue("@v11", andon.timeLimitLv2 ?? SqlString.Null);
                command.Parameters.AddWithValue("@v12", andon.timeLimitLv3 ?? SqlString.Null);
                command.Parameters.AddWithValue("@id", andon.idType);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteAndonType(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_type WHERE id_type = @id";
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
    }
}
