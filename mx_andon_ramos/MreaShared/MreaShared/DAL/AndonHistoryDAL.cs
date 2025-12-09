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
    public class AndonHistoryDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);
        public List<AndonHistory> getAndonTodayCount()
        {
            List<AndonHistory> list = new List<AndonHistory>();
            AndonHistory objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 5;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new AndonHistory();
                    objAndon.count = Convert.ToInt32(reader["contador"]);
                    objAndon.type = Convert.ToString(reader["tipo"]);
                    objAndon.colorMonitor = Convert.ToString(reader["color_chart_monitor"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public List<AndonHistory> getAndonTodayCountByLine()
        {
            List<AndonHistory> list = new List<AndonHistory>();
            AndonHistory objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 6;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new AndonHistory();
                    objAndon.count = Convert.ToInt32(reader["contador"]);
                    objAndon.line = Convert.ToString(reader["linea"]);
                    list.Add(objAndon);
                }
                reader.Close();
            }
            return list;
        }
        public int insertAndonHist(Andon andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_history(fecha,idLine,idType,idMsg,end_date,end_repair_date) values(@date, @idLine, @idType, @idMsg, null,null)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@idLine", andon.idLine);
                command.Parameters.AddWithValue("@idType", andon.idType);
                command.Parameters.AddWithValue("@idMsg", andon.idMessage);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return id;
        }
        public AndonHistory GetLastAndonByLine(int idLine)
        {
            AndonHistory objAndon = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(schema + ".GetAndonDataV3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@option", SqlDbType.Int).Value = 15;
                command.Parameters.Add("@idLine", SqlDbType.Int).Value = idLine;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAndon = new AndonHistory();
                    objAndon.id = Convert.ToInt32(reader["id_hist"]);
                    objAndon.type = Convert.ToString(reader["name"]);
                    objAndon.date = Convert.ToDateTime(reader["fecha"]);
                    objAndon.idType = Convert.ToInt32(reader["id_type"]);
                }
                reader.Close();
            }
            return objAndon;
        }

        public AndonHistory GetLastAndonByType(int idType)
        {
            string queryString;
            queryString = "select top 1 * from " + schema + ".andon_history where idType = @idType order by id_hist desc";
            AndonHistory obj = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idType", idType);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonHistory();
                    obj.id = Convert.ToInt32(reader["id_hist"]);
                    obj.date = Convert.ToDateTime(reader["fecha"]);
                    obj.idLine = Convert.ToInt32(reader["idLine"]);
                    obj.idType = Convert.ToInt32(reader["idType"]);
                    obj.idMsg = Convert.ToInt32(reader["idMsg"]);
                    obj.endDate = reader["end_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["end_date"]);
                }
                reader.Close();
            }
            return obj;
        }

        public AndonHistory GetLastHistoryByIdMsg(int idMsg)
        {
            string queryString;
            queryString = "select top 1 * from " + schema + ".andon_history where idMsg = @idMsg order by id_hist desc";
            AndonHistory obj = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idMsg", idMsg);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonHistory();
                    obj.id = Convert.ToInt32(reader["id_hist"]);
                    obj.date = Convert.ToDateTime(reader["fecha"]);
                    obj.idLine = Convert.ToInt32(reader["idLine"]);
                    obj.idType = Convert.ToInt32(reader["idType"]);
                    obj.idMsg = Convert.ToInt32(reader["idMsg"]);
                    obj.endDate = reader["end_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["end_date"]);
                    obj.endRepairDate = reader["end_repair_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["end_repair_date"]);
                }
                reader.Close();
            }
            return obj;
        }
        public bool UpdateEndDate(AndonHistory andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_history SET end_date = @ed WHERE id_hist = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ed", andon.endDate);
                command.Parameters.AddWithValue("@id", andon.id);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        //Agregado 20 de junio del 2019
        public bool UpdateEndRepairDate(int id)
        {
            bool valid = false;
            string sql = "UPDATE adn.andon_history SET end_repair_date = getdate() WHERE id_hist = @id";
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
        public string GetTimeElapsedByIdMsg(int idMsg)
        {
            string queryString;
            queryString = "select top 1 Convert(varchar, GETDATE() - H.fecha, 108) as time_elapsed from " + schema + ".andon_history H where H.idMsg = @idMsg and H.end_date is null order by H.id_hist desc";
            string timeElapsed = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idMsg", idMsg);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    timeElapsed = reader["time_elapsed"] == DBNull.Value ? null : Convert.ToString(reader["time_elapsed"]);
                }
                reader.Close();
            }
            return timeElapsed;
        }
        public List<AndonHistory> GetAllFromDates(DateTime from, DateTime to)
        {
            List<AndonHistory> list = new List<AndonHistory>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "select " +
                            "H.id_hist  AS ID, " +
                            "H.fecha    AS FECHA, " +
                            "L.nombre   AS LINEA, " +
                            "T.name     AS DEPARTAMENTO, " +
                            "M.id_msg   AS ID_MSG, " +
                            "M.msg      AS MENSAJE, " +
                            "H.end_date AS FECHA_ENTREGA, " +
                            "Convert(varchar, H.end_date - H.fecha, 108) as HH_MM_SS, " +
                            "H.end_repair_date AS FECHA_REPARACION, " +
                            "Convert(varchar, H.end_repair_date - H.end_date, 108) as HH_MM_SS_REPAIR " +
                            "from adn.andon_history H " +
                            "inner join adn.andon_msg M on M.id_msg = H.idMsg " +
                            "inner join adn.mrea_linea L on L.id_linea = H.idLine " +
                            "inner join adn.andon_type T on H.idType = T.id_type " +
                            "where H.fecha between @v1 and @v2 " +
                            "order by H.id_hist desc";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", from);
                command.Parameters.AddWithValue("@v2", to);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj     = new AndonHistory();
                    obj.id      = Convert.ToInt32(reader["ID"]);
                    obj.date    = reader["FECHA"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA"]);
                    obj.line    = reader["LINEA"] == DBNull.Value ? null : Convert.ToString(reader["LINEA"]);
                    obj.type    = reader["DEPARTAMENTO"] == DBNull.Value ? null : Convert.ToString(reader["DEPARTAMENTO"]);
                    obj.idMsg   = reader["ID_MSG"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID_MSG"]);
                    obj.msg     = reader["MENSAJE"] == DBNull.Value ? null : Convert.ToString(reader["MENSAJE"]);
                    obj.endDate = reader["FECHA_ENTREGA"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["FECHA_ENTREGA"]);
                    obj.endTime = reader["HH_MM_SS"] == DBNull.Value ? null : Convert.ToString(reader["HH_MM_SS"]);
                    obj.endRepairDate = reader["FECHA_REPARACION"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["FECHA_REPARACION"]);
                    obj.endRepairTime = reader["HH_MM_SS_REPAIR"] == DBNull.Value ? null : Convert.ToString(reader["HH_MM_SS_REPAIR"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public List<AndonHistory> GetCountAndonFromDates(DateTime from, DateTime to)
        {
            List<AndonHistory> list = new List<AndonHistory>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "select " +
                            "Count(*) as contador, " +
                            "T.name as tipo, " +
                            "CB.name as color_chart_monitor, " +
                            "AVG(datediff(SECOND, fecha, end_date)) as response_average_sec, " +
                            "(select top 1 L2.nombre + ' (' + CONVERT(varchar, COUNT(*))+ ' times.)' from adn.andon_history H2 inner join adn.mrea_linea L2 on L2.id_linea = H2.idLine where H2.fecha between @v3 and @v4 and H2.idType = H.idType group by L2.nombre order by COUNT(*) desc) as top_line_support, " +
                            "(select top 1 CONVERT(varchar, datediff(SECOND, fecha, end_date)) + ' sec. (' + L2.nombre + ' ' + M2.msg + ')' from adn.andon_history H2 inner join adn.andon_msg M2 on M2.id_msg = H2.idMsg inner join adn.mrea_linea L2 on L2.id_linea = H2.idLine where H2.fecha between @v5 and @v6 and H2.idType = H.idType order by datediff(SECOND, fecha, end_date) desc) as top_response_sec " +
                            "from adn.andon_history H " +
                            "inner join adn.andon_type T on H.idType = T.id_type " +
                            "left join adn.andon_color_bg CB on CB.id_bg = T.id_bg_monitor " +
                            "where H.fecha between @v1 and @v2 " +
                            "group by T.name, CB.name, H.idType "+
                            "order by contador desc";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", from);
                command.Parameters.AddWithValue("@v2", to);
                command.Parameters.AddWithValue("@v3", from);
                command.Parameters.AddWithValue("@v4", to);
                command.Parameters.AddWithValue("@v5", from);
                command.Parameters.AddWithValue("@v6", to);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new AndonHistory();
                    obj.count = Convert.ToInt32(reader["contador"]);
                    obj.type = Convert.ToString(reader["tipo"]);
                    obj.colorMonitor = Convert.ToString(reader["color_chart_monitor"]);
                    obj.responseAverageSec = reader["response_average_sec"] == DBNull.Value ? null : Convert.ToString(reader["response_average_sec"]);
                    obj.topLineSupport = reader["top_line_support"] == DBNull.Value ? null : Convert.ToString(reader["top_line_support"]);
                    obj.topResponseSec = reader["top_response_sec"] == DBNull.Value ? null : Convert.ToString(reader["top_response_sec"]);

                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public bool UpdateAllOldAndonEnddates(int days)
        {
            //Actualizar todos los andon que despues cierta cantidad de dias (days) aun tengan end_date = null
            bool valid = false;
            string sql = "UPDATE adn.andon_history SET end_date = GETDATE() WHERE CONVERT(date,fecha) <= CONVERT(date, DATEADD(day,@days,GETDATE())) and end_date is null";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@days", days);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public AndonHistory GetLastHistoryByLineAndTag(int idLine, int idAv)
        {
            string queryString;
            queryString = "select top 1 H.* from adn.andon_history H inner join adn.andon_msg M on M.id_msg = H.idMsg inner join adn.andon_type T on T.id_type = H.idType where H.idLine = 5 and M.id_av = 14 and H.fecha is not null and H.end_date is not null and T.is_binary = 0 and H.end_repair_date is null order by H.id_hist desc";
            AndonHistory obj = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idL", idLine);
                command.Parameters.AddWithValue("@idA", idAv);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj = new AndonHistory();
                    obj.id = Convert.ToInt32(reader["id_hist"]);
                    obj.date = Convert.ToDateTime(reader["fecha"]);
                    obj.idLine = Convert.ToInt32(reader["idLine"]);
                    obj.idType = Convert.ToInt32(reader["idType"]);
                    obj.idMsg = Convert.ToInt32(reader["idMsg"]);
                    obj.endDate = reader["end_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["end_date"]);
                    obj.endRepairDate = reader["end_repair_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["end_repair_date"]);
                    break;
                }
                reader.Close();
            }
            return obj;
        }
    }
}
