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
    public class AndonValueDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<AndonValues> getAndonValues(AndonValues andonValues)
        {
            string queryString;
            List<AndonValues> list = new List<AndonValues>();
            if (andonValues.idAv != 0)
            {
                queryString = "select AV.*, P.name from " + schema + ".andon_values AV inner join " + schema + ".andon_plc P on P.id_plc = AV.id_plc where AV.id_av = @id";
            }
            else if (andonValues.idPlc != 0)
            {
                queryString = "select AV.*, P.name from " + schema + ".andon_values AV inner join " + schema + ".andon_plc P on P.id_plc = AV.id_plc where AV.id_plc = @id";
            }
            else
            {
                queryString = "select AV.*, P.name from " + schema + ".andon_values AV inner join " + schema + ".andon_plc P on P.id_plc = AV.id_plc";
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
                    obj.idAv = Convert.ToInt32(reader["id_av"]);
                    obj.idPlc = Convert.ToInt32(reader["id_plc"]);
                    obj.andonValue = reader["andon_value"] == DBNull.Value ? -1 : Convert.ToInt32(reader["andon_value"]);
                    obj.andonDate = reader["andon_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["andon_date"]);
                    obj.tagName = Convert.ToString(reader["tag_name"]);
                    obj.plcName = Convert.ToString(reader["name"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public int insertAndonValue(AndonValues andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".andon_values(id_plc,andon_value,andon_date,tag_name) output inserted.id_av VALUES(@v1,@v2,@v3,@v4)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.idPlc);
                command.Parameters.AddWithValue("@v2", andon.andonValue);
                command.Parameters.AddWithValue("@v3", andon.andonDate);
                command.Parameters.AddWithValue("@v4", andon.tagName);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateAndonValue(AndonValues andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".andon_values SET id_plc = @v1, andon_value = @v2, andon_date = @v3, tag_name = @v4 WHERE id_av = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@v1", andon.idPlc);
                command.Parameters.AddWithValue("@v2", andon.andonValue);
                command.Parameters.AddWithValue("@v3", andon.andonDate);
                command.Parameters.AddWithValue("@v4", andon.tagName);
                command.Parameters.AddWithValue("@id", andon.idAv);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteAndonValue(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".andon_values WHERE id_av = @id";
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
        public AndonValues GetAndonValueByTagname(string tagname)
        {
            string queryString;
            AndonValues objAV = null;
            queryString = "select AV.*, P.name from adn.andon_values AV inner join adn.andon_plc P on P.id_plc = AV.id_plc where AV.tag_name = @tn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@tn", tagname);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    objAV = new AndonValues();
                    objAV.idAv = Convert.ToInt32(reader["id_av"]);
                    objAV.idPlc = Convert.ToInt32(reader["id_plc"]);
                    objAV.andonValue = reader["andon_value"] == DBNull.Value ? -1 : Convert.ToInt32(reader["andon_value"]);
                    objAV.andonDate = reader["andon_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["andon_date"]);
                    objAV.tagName = Convert.ToString(reader["tag_name"]);
                    objAV.plcName = Convert.ToString(reader["name"]);
                    break;
                }
                reader.Close();
            }
            return objAV;
        }
    }
}
