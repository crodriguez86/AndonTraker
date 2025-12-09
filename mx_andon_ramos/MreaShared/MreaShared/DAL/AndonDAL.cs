using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlTypes;

namespace MreaShared.DAL
{
    class AndonDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public Andon selectScreen(int idScreen)
        {
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 1;
                command.Parameters.Add("@idLine", SqlDbType.Int).Value = idScreen;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idLine         = Convert.ToInt32(reader["id_linea"]);
                    objAndon.idAndonValue   = Convert.ToInt32(reader["id_av"]);
                    objAndon.nameLine       = Convert.ToString(reader["name_line"]);
                    objAndon.idMessage      = Convert.ToInt32(reader["id_msg"]);
                    objAndon.tagValue       = Convert.ToInt32(reader["andon_value"]);
                    objAndon.message        = Convert.ToString(reader["msg"]);
                    objAndon.idType         = Convert.ToInt32(reader["id_type"]);
                    objAndon.nameType       = Convert.ToString(reader["name_type"]);
                    objAndon.idBackground   = Convert.ToInt32(reader["id_bg"]);
                    objAndon.nameBackground = Convert.ToString(reader["name_background"]);
                    objAndon.idText         = Convert.ToInt32(reader["id_text"]);
                    objAndon.nameText       = Convert.ToString(reader["name_text"]);
                    objAndon.font           = Convert.ToInt32(reader["font"]);
                    objAndon.font2          = reader["font2"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["font2"]);
                    objAndon.font3          = reader["font3"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["font3"]);
                    objAndon.fontProd       = Convert.ToInt32(reader["font_production"]);
                    objAndon.fontMon        = Convert.ToInt32(reader["font_monitor"]);
                    objAndon.timeElapsed    = reader["time_elapsed"] == DBNull.Value ? null : Convert.ToString(reader["time_elapsed"]);
                    objAndon.timeLimitLv2   = reader["time_limit_lv2"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv2"]);
                    objAndon.timeLimitLv3   = reader["time_limit_lv3"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv3"]);
                    break;
                }
                reader.Close();
            }
            return objAndon;
        }
        public List<Andon> selectAllScreens()
        {
            List<Andon> list = new List<Andon>();
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 2;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idLine         = Convert.ToInt32(reader["id_linea"]);
                    objAndon.idAndonValue   = Convert.ToInt32(reader["id_av"]);
                    objAndon.nameLine       = Convert.ToString(reader["name_line"]);
                    objAndon.idMessage      = Convert.ToInt32(reader["id_msg"]);
                    objAndon.tagValue       = Convert.ToInt32(reader["andon_value"]);
                    objAndon.message        = Convert.ToString(reader["msg"]);
                    objAndon.idType         = Convert.ToInt32(reader["id_type"]);
                    objAndon.nameType       = Convert.ToString(reader["name_type"]);
                    objAndon.idBackground   = Convert.ToInt32(reader["id_bg"]);
                    objAndon.nameBackground = Convert.ToString(reader["name_background"]);
                    objAndon.idText         = Convert.ToInt32(reader["id_text"]);
                    objAndon.nameText       = Convert.ToString(reader["name_text"]);
                    objAndon.font           = Convert.ToInt32(reader["font"]);
                    objAndon.font2          = reader["font2"] == DBNull.Value ? -1 : (int?)Convert.ToInt32(reader["font2"]);
                    objAndon.font3          = reader["font3"] == DBNull.Value ? -1 : (int?)Convert.ToInt32(reader["font3"]);
                    objAndon.fontProd       = Convert.ToInt32(reader["font_production"]);
                    objAndon.fontMon        = Convert.ToInt32(reader["font_monitor"]);
                    objAndon.timeElapsed    = reader["time_elapsed"] == DBNull.Value ? null : Convert.ToString(reader["time_elapsed"]);
                    objAndon.timeLimitLv2   = reader["time_limit_lv2"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv2"]);
                    objAndon.timeLimitLv3   = reader["time_limit_lv3"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv3"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public List<Andon> selectAllTypesAndonTracker()
        {
            List<Andon> list = new List<Andon>();
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 17;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idLine         = Convert.ToInt32(reader["id_linea"]);
                    objAndon.idAndonValue   = Convert.ToInt32(reader["id_av"]);
                    objAndon.nameLine       = Convert.ToString(reader["name_line"]);
                    objAndon.idMessage      = Convert.ToInt32(reader["id_msg"]);
                    objAndon.tagValue       = Convert.ToInt32(reader["andon_value"]);
                    objAndon.message        = Convert.ToString(reader["msg"]);
                    objAndon.idType         = Convert.ToInt32(reader["id_type"]);
                    objAndon.nameType       = Convert.ToString(reader["name_type"]);
                    objAndon.idBackground   = Convert.ToInt32(reader["id_bg"]);
                    objAndon.nameBackground = Convert.ToString(reader["name_background"]);
                    objAndon.idText         = Convert.ToInt32(reader["id_text"]);
                    objAndon.nameText       = Convert.ToString(reader["name_text"]);
                    objAndon.font           = Convert.ToInt32(reader["font"]);
                    objAndon.font2          = reader["font2"] == DBNull.Value ? -1 : (int?)Convert.ToInt32(reader["font2"]);
                    objAndon.font3          = reader["font3"] == DBNull.Value ? -1 : (int?)Convert.ToInt32(reader["font3"]);
                    objAndon.fontProd       = Convert.ToInt32(reader["font_production"]);
                    objAndon.fontMon        = Convert.ToInt32(reader["font_monitor"]);
                    objAndon.timeElapsed    = reader["time_elapsed"] == DBNull.Value ? null : Convert.ToString(reader["time_elapsed"]);
                    objAndon.timeLimitLv2   = reader["time_limit_lv2"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv2"]);
                    objAndon.timeLimitLv3   = reader["time_limit_lv3"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv3"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public void testAndon(int idAv, int tagValue)
        {
            string queryString = "update " + schema + ".andon_values set andon_value = @tagValue, andon_date = getdate() where id_av = @idAv";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idAv", idAv);
                command.Parameters.AddWithValue("@tagValue", tagValue);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        
        public List<Andon> getLines()
        {
            List<Andon> list = new List<Andon>();
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 3;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idLine = Convert.ToInt32(reader["id_linea"]);
                    objAndon.nameLine = Convert.ToString(reader["name_line"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public List<Andon> getMessages(int idLine, int idType)
        {
            List<Andon> list = new List<Andon>();
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 4;
                command.Parameters.Add("@idLine", SqlDbType.Int).Value = idLine;
                command.Parameters.Add("@idType", SqlDbType.Int).Value = idType;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idMessage    = Convert.ToInt32(reader["id_msg"]);
                    objAndon.tagValue     = Convert.ToInt32(reader["tag_value"]);
                    objAndon.idAndonValue = Convert.ToInt32(reader["id_av"]);
                    objAndon.message      = Convert.ToString(reader["andon_message"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }

        public int insertAndonHist(AndonHistory andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".AndonHist values(@date, @line, @type, @msg)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@date", andon.date);
                command.Parameters.AddWithValue("@line", andon.line);
                command.Parameters.AddWithValue("@type", andon.type);
                command.Parameters.AddWithValue("@msg", andon.msg);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return id;
        }
        public void inserAndonError(AndonErrorLog error)
        {
            string sql = "insert into " + schema + ".andon_error_log values(@mg, @st, @ip, @dn, @ap, @date)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mg", error.message);
                command.Parameters.AddWithValue("@st", error.stackTrace);
                command.Parameters.AddWithValue("@ip", error.ipAddress);
                command.Parameters.AddWithValue("@dn", error.deviceName);
                command.Parameters.AddWithValue("@ap", error.idApp);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public int insertAndon(Andon andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_msg output inserted.id_msg values(@idAv, @idLine, @tagValue, @msg, @idType, @idFont, @idFont2, @idFont3)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idAv", andon.idAndonValue);
                command.Parameters.AddWithValue("@idLine", andon.idLine);
                command.Parameters.AddWithValue("@tagValue", andon.tagValue);
                command.Parameters.AddWithValue("@msg", andon.message);
                command.Parameters.AddWithValue("@idType", andon.idType);
                command.Parameters.AddWithValue("@idFont", andon.font);
                command.Parameters.AddWithValue("@idFont2", andon.font2 ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@idFont3", andon.font3 ?? SqlInt32.Null);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateAndon(Andon andon)
        {
            bool valid = false;
            string sql = "UPDATE [" + schema + "].[andon_msg] SET [id_av] = @idAv ,[id_linea] = @idLine ,[tag_value] = @tagValue ,[msg] = @msg ,[id_type] = @idType ,[id_font] = @idFont ,[id_font2] = @idFont2 ,[id_font3] = @idFont3 WHERE id_msg = @idMsg";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idAv", andon.idAndonValue);
                command.Parameters.AddWithValue("@idLine", andon.idLine);
                command.Parameters.AddWithValue("@tagValue", andon.tagValue);
                command.Parameters.AddWithValue("@msg", andon.message);
                command.Parameters.AddWithValue("@idType", andon.idType);
                command.Parameters.AddWithValue("@idFont", andon.font);
                command.Parameters.AddWithValue("@idFont2", andon.font2 ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@idFont3", andon.font3 ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@idMsg", andon.idMessage);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public Andon getMessage(int idMsg)
        {
            string queryString;
            Andon objAndon = new Andon();
            queryString = "select * from " + schema + ".andon_msg AM inner join " + schema + ".andon_values AV on AM.id_av = AV.id_av where id_msg = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", idMsg);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon.idLine       = Convert.ToInt32(reader["id_linea"]);
                    objAndon.idAndonValue = Convert.ToInt32(reader["id_av"]);
                    objAndon.idMessage    = Convert.ToInt32(reader["id_msg"]);
                    objAndon.message      = Convert.ToString(reader["msg"]);
                    objAndon.tagValue     = Convert.ToInt32(reader["tag_value"]);
                    objAndon.idType       = Convert.ToInt32(reader["id_type"]);
                    objAndon.idPlc        = Convert.ToInt32(reader["id_plc"]);
                    objAndon.idfont1      = reader["id_font"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font"]);
                    objAndon.idfont2      = reader["id_font2"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font2"]);
                    objAndon.idfont3      = reader["id_font3"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font3"]);
                    break;
                }
                reader.Close();
            }
            return objAndon;
        }
        public List<AndonPlc> getAndonPlc(AndonPlc andonPlc)
        {
            string queryString;
            List<AndonPlc> list = new List<AndonPlc>();
            if (andonPlc.idPlc == 0)
            {
                queryString = "select * from " + schema + ".andon_plc";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_plc where id_plc = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if(andonPlc.idPlc != 0)
                    command.Parameters.AddWithValue("@id", andonPlc.idPlc);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonPlc obj = new AndonPlc();
                    obj.idPlc = Convert.ToInt32(reader["id_plc"]);
                    obj.name  = Convert.ToString(reader["name"]);
                    obj.ip    = Convert.ToString(reader["ip"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public List<AndonValues> getAndonValues(AndonValues andonValues)
        {
            string queryString;
            List<AndonValues> list = new List<AndonValues>();
            if (andonValues.idAv != 0)
            {
                queryString = "select * from " + schema + ".andon_values where id_av = @id";
            }
            else if(andonValues.idPlc != 0)
            {
                queryString = "select * from " + schema + ".andon_values where id_plc = @id";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_values";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (andonValues.idAv != 0)
                    command.Parameters.AddWithValue("@id", andonValues.idAv);
                if (andonValues.idPlc != 0)
                    command.Parameters.AddWithValue("@id", andonValues.idPlc);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonValues obj = new AndonValues();
                    obj.idAv       = Convert.ToInt32(reader["id_av"]);
                    obj.idPlc      = Convert.ToInt32(reader["id_plc"]);
                    obj.andonValue = reader["andon_value"] == DBNull.Value ? -1 : Convert.ToInt32(reader["andon_value"]);
                    obj.andonDate  = reader["andon_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["andon_date"]);
                    obj.tagName    = Convert.ToString(reader["tag_name"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public List<AndonType> getAndonTypes(AndonType andonType)
        {
            string queryString;
            List<AndonType> list = new List<AndonType>();
            if (andonType.idType == 0)
            {
                queryString = "select * from " + schema + ".andon_type";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_type where id_type = @id";
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
                    obj.name   = Convert.ToString(reader["name"]);
                    obj.idBg   = Convert.ToInt32(reader["id_bg"]);
                    obj.idText = Convert.ToInt32(reader["id_text"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public List<AndonFontsize> getAndonFonts(AndonFontsize andonFont)
        {
            string queryString;
            List<AndonFontsize> list = new List<AndonFontsize>();
            if (andonFont.idFont == 0)
            {
                queryString = "select * from " + schema + ".andon_fontsize";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_fontsize where id_font = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (andonFont.idFont != 0)
                    command.Parameters.AddWithValue("@id", andonFont.idFont);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonFontsize obj = new AndonFontsize();
                    obj.idFont = reader["id_font"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font"]);
                    obj.font   = reader["font"] == DBNull.Value ? -1 : Convert.ToInt32(reader["font"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public List<Andon> getAllMessages()
        {
            List<Andon> list = new List<Andon>();
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 10;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idLine         = Convert.ToInt32(reader["id_linea"]);
                    objAndon.idAndonValue   = Convert.ToInt32(reader["id_av"]);
                    objAndon.nameLine       = Convert.ToString(reader["name_line"]);
                    objAndon.idMessage      = Convert.ToInt32(reader["id_msg"]);
                    objAndon.tagValue       = Convert.ToInt32(reader["andon_value"]);
                    objAndon.message        = Convert.ToString(reader["msg"]);
                    objAndon.idType         = Convert.ToInt32(reader["id_type"]);
                    objAndon.nameType       = Convert.ToString(reader["name_type"]);
                    objAndon.idBackground   = Convert.ToInt32(reader["id_bg"]);
                    objAndon.nameBackground = Convert.ToString(reader["name_background"]);
                    objAndon.idText         = Convert.ToInt32(reader["id_text"]);
                    objAndon.nameText       = Convert.ToString(reader["name_text"]);
                    objAndon.idfont1        = reader["id_font1"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font1"]);
                    objAndon.idfont2        = reader["id_font2"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font2"]);
                    objAndon.idfont3        = reader["id_font3"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font3"]);
                    objAndon.font           = reader["font"] == DBNull.Value ? -1 : Convert.ToInt32(reader["font"]);
                    objAndon.font2          = reader["font2"] == DBNull.Value ? -1 : Convert.ToInt32(reader["font2"]);
                    objAndon.font3          = reader["font3"] == DBNull.Value ? -1 : Convert.ToInt32(reader["font3"]);
                    objAndon.idPlc          = Convert.ToInt32(reader["id_plc"]);
                    objAndon.namePlc        = Convert.ToString(reader["name_plc"]);
                    objAndon.tagName        = Convert.ToString(reader["tag_name"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public List<AndonValues> getSuperMarketValues(int zone)
        {
            List<AndonValues> list = new List<AndonValues>();
            AndonValues objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 11;
                command.Parameters.Add("@zone", SqlDbType.Int).Value = zone;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new AndonValues();
                    objAndon.idAv       = Convert.ToInt32(reader["id_av"]);
                    objAndon.andonValue = Convert.ToInt32(reader["andon_value"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public Andon getMessageSuperMarket(int idAv, int position)
        {
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 12;
                command.Parameters.Add("@idAV", SqlDbType.Int).Value = idAv;
                command.Parameters.Add("@tagValue", SqlDbType.Int).Value = position;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idLine = Convert.ToInt32(reader["id_linea"]);
                    objAndon.idAndonValue   = Convert.ToInt32(reader["id_av"]);
                    objAndon.nameLine       = Convert.ToString(reader["name_line"]);
                    objAndon.idMessage      = Convert.ToInt32(reader["id_msg"]);
                    objAndon.tagValue       = Convert.ToInt32(reader["andon_value"]);
                    objAndon.message        = Convert.ToString(reader["msg"]);
                    objAndon.idType         = Convert.ToInt32(reader["id_type"]);
                    objAndon.nameType       = Convert.ToString(reader["name_type"]);
                    objAndon.idBackground   = Convert.ToInt32(reader["id_bg"]);
                    objAndon.nameBackground = Convert.ToString(reader["name_background"]);
                    objAndon.idText         = Convert.ToInt32(reader["id_text"]);
                    objAndon.nameText       = Convert.ToString(reader["name_text"]);
                    objAndon.idfont1        = reader["id_font1"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font1"]);
                    objAndon.idfont2        = reader["id_font2"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font2"]);
                    objAndon.idfont3        = reader["id_font3"] == DBNull.Value ? -1 : Convert.ToInt32(reader["id_font3"]);
                    objAndon.font           = reader["font"] == DBNull.Value ? -1 : Convert.ToInt32(reader["font"]);
                    objAndon.font2          = reader["font2"] == DBNull.Value ? -1 : Convert.ToInt32(reader["font2"]);
                    objAndon.font3          = reader["font3"] == DBNull.Value ? -1 : Convert.ToInt32(reader["font3"]);
                    objAndon.idPlc          = Convert.ToInt32(reader["id_plc"]);
                    objAndon.namePlc        = Convert.ToString(reader["name_plc"]);
                    objAndon.fontProd       = Convert.ToInt32(reader["font_production"]);
                    objAndon.fontMon        = Convert.ToInt32(reader["font_monitor"]);
                    objAndon.timeElapsed    = reader["time_elapsed"] == DBNull.Value ? null : Convert.ToString(reader["time_elapsed"]);
                    objAndon.timeLimitLv2   = reader["time_limit_lv2"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv2"]);
                    objAndon.timeLimitLv3   = reader["time_limit_lv3"] == DBNull.Value ? null : Convert.ToString(reader["time_limit_lv3"]);
                }
                reader.Close();
            }
            return objAndon;
        }
        public Andon getConfigByIPAddress(string ipAddress)
        {
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 13;
                command.Parameters.Add("@ipAddress", SqlDbType.VarChar).Value = ipAddress;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idLine       = Convert.ToInt32(reader["id_config"]);
                    objAndon.idAndonValue = Convert.ToInt32(reader["id_line"]);
                    //objAndon.idMessage   = Convert.ToString(reader["ip_address"]);
                }
                reader.Close();
            }
            return objAndon;
        }
        public List<AndonApp> getAndonApp(AndonApp andon)
        {
            string queryString;
            List<AndonApp> list = new List<AndonApp>();
            if (andon.idApp == 0)
            {
                queryString = "select * from " + schema + ".andon_start_app";
            }
            else
            {
                queryString = "select * from " + schema + ".andon_start_app where id_app = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (andon.idApp != 0)
                    command.Parameters.AddWithValue("@id", andon.idApp);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonApp obj = new AndonApp();
                    obj.idApp = Convert.ToInt32(reader["id_app"]);
                    obj.name  = Convert.ToString(reader["name"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public List<Andon> getTagNamesByLineAndType(int idLine, int idType)
        {
            List<Andon> list = new List<Andon>();
            Andon objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 16;
                command.Parameters.Add("@idLine", SqlDbType.Int).Value = idLine;
                command.Parameters.Add("@idType", SqlDbType.Int).Value = idType;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new Andon();
                    objAndon.idAndonValue = Convert.ToInt32(reader["id_av"]);
                    objAndon.namePlc      = Convert.ToString(reader["name_plc"]);
                    objAndon.tagName      = Convert.ToString(reader["tag_name"]) + " / " + Convert.ToString(reader["name_plc"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        //---------------
        public int insertAndonConfig(AndonConfig andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_config(start_app,id_line,start_screen,sm_zone,sm_divs,hostname,start_always,id_panel,config) output inserted.id_config VALUES(@sa,@il,@ss,@sz,@sd,@hn,@al,@pg,@cf)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@sa", andon.startApp);
                command.Parameters.AddWithValue("@il", andon.idLine ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@ss", andon.startScreen);
                command.Parameters.AddWithValue("@sz", andon.smZone ?? 0);
                command.Parameters.AddWithValue("@sd", andon.smDivs ?? 0);
                command.Parameters.AddWithValue("@hn", andon.hostname);
                command.Parameters.AddWithValue("@al", andon.startAlways);
                command.Parameters.AddWithValue("@pg", andon.idPanelGroup ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@cf", andon.config ?? SqlString.Null);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateAndonConfig(AndonConfig andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_config SET start_app = @sa,id_line = @il,start_screen = @ss,sm_zone = @sz,sm_divs = @sd,hostname = @hn ,start_always = @al, last_update = @lu, id_panel = @pg, config = @cf WHERE id_config = @ic";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@sa", andon.startApp);
                command.Parameters.AddWithValue("@il", andon.idLine ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@ss", andon.startScreen ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@sz", andon.smZone ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@sd", andon.smDivs ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@hn", andon.hostname ?? SqlString.Null);
                command.Parameters.AddWithValue("@al", andon.startAlways);
                command.Parameters.AddWithValue("@ic", andon.idConfig);
                command.Parameters.AddWithValue("@pg", andon.idPanelGroup ?? SqlInt32.Null);
                command.Parameters.AddWithValue("@cf", andon.config ?? SqlString.Null);
                command.Parameters.AddWithValue("@lu", andon.lastUpdate ?? SqlDateTime.Null);

                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public List<AndonConfig> getAndonConfig(AndonConfig andon)
        {
            string queryString;
            List<AndonConfig> list = new List<AndonConfig>();
            if (andon.idConfig == 0)
            {
                queryString = "select C.*, S.name, L.nombre from " + schema + ".andon_config C inner join " + schema + ".andon_start_app S on S.id_app = C.start_app inner join " + schema + ".mrea_linea L on L.id_linea = C.id_line";
            }
            else
            {
                queryString = "select C.*, S.name, L.nombre from " + schema + ".andon_config C inner join " + schema + ".andon_start_app S on S.id_app = C.start_app inner join " + schema + ".mrea_linea L on L.id_linea = C.id_line where id_config = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (andon.idConfig != 0)
                    command.Parameters.AddWithValue("@id", andon.idConfig);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AndonConfig obj  = new AndonConfig();
                    obj.idConfig     = Convert.ToInt32(reader["id_config"]);
                    obj.startApp     = Convert.ToInt32(reader["start_app"]);
                    obj.idLine       = Convert.ToInt32(reader["id_line"]);
                    obj.startScreen  = Convert.ToInt32(reader["start_screen"]);
                    obj.smZone       = reader["sm_zone"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["sm_zone"]);
                    obj.smDivs       = reader["sm_divs"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["sm_divs"]);
                    obj.hostname     = Convert.ToString(reader["hostname"]);
                    obj.startAlways  = Convert.ToBoolean(reader["start_always"]);
                    obj.lastUpdate   = reader["last_update"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["last_update"]);
                    obj.application  = Convert.ToString(reader["name"]);
                    obj.line         = Convert.ToString(reader["nombre"]);
                    obj.idPanelGroup = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);
                    obj.config       = reader["config"] == DBNull.Value ? null : Convert.ToString(reader["config"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public AndonConfig getAndonConfigByHostname(string hostname)
        {
            string queryString;
            queryString = "select * from " + schema + ".andon_config where hostname = @hn";
            AndonConfig obj = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@hn", hostname);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonConfig();
                    obj.idConfig     = Convert.ToInt32(reader["id_config"]);
                    obj.startApp     = Convert.ToInt32(reader["start_app"]);
                    obj.idLine       = reader["id_line"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_line"]);
                    obj.startScreen  = Convert.ToInt32(reader["start_screen"]);
                    obj.smZone = reader["sm_zone"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["sm_zone"]);
                    obj.smDivs = reader["sm_divs"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["sm_divs"]);
                    obj.hostname     = Convert.ToString(reader["hostname"]);
                    obj.startAlways  = Convert.ToBoolean(reader["start_always"]);
                    obj.idPanelGroup = reader["id_panel"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_panel"]);
                    obj.config       = reader["config"] == DBNull.Value ? null : Convert.ToString(reader["config"]);
                }
                reader.Close();
            }
            return obj;
        }
        public List<AndonValues> getWarningValues()
        {
            List<AndonValues> list = new List<AndonValues>();
            AndonValues objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 13;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new AndonValues();
                    objAndon.idAv       = Convert.ToInt32(reader["id_av"]);
                    objAndon.andonValue = Convert.ToInt32(reader["andon_value"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public bool updateAndonConfigLastConnection(AndonConfig andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_config SET last_update = @lu WHERE hostname = @hn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@lu", andon.lastUpdate);
                command.Parameters.AddWithValue("@hn", andon.hostname);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteAndonConfig(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_config WHERE id_config = @id";
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
        public bool deleteAndonMessage(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_msg WHERE id_msg = @id";
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
        public List<AndonValues> GetSuperMarketValuesByZones(List<int> idZones)
        {
            List<AndonValues> list = new List<AndonValues>();
            AndonValues objAndon = null;
            var parameters = idZones.Select((idZone, indx) => new SqlParameter("@idZone_" + indx, SqlDbType.Int) { Value = idZone }).ToArray();
            string sql = "select distinct AV.id_av, AV.andon_value " +
                        "from adn.andon_values AV " +
                        "INNER join adn.andon_msg M on M.id_av = AV.id_av " +
                        "INNER JOIN adn.andon_type T ON T.id_type = M.id_type " +
                        "INNER JOIN adn.mrea_linea L ON L.id_linea = M.id_linea " +
                        $"where AV.andon_value <> 0 and T.name = 'SUPERMARKET' and L.id_zona in({string.Join(",", parameters.Select(x=>x.ParameterName))})";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddRange(parameters);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new AndonValues();
                    objAndon.idAv       = Convert.ToInt32(reader["id_av"]);
                    objAndon.andonValue = Convert.ToInt32(reader["andon_value"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
    }
}
