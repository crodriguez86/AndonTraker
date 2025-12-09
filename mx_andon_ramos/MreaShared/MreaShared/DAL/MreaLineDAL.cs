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
    public class MreaLineDAL
    {
        private string schema = Convert.ToString(ConfigurationManager.AppSettings["schema"]);
        private string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connection1"]);

        public List<MreaLine> getMreaLine(MreaLine objM)
        {
            string queryString;
            List<MreaLine> list = new List<MreaLine>();
            if (objM.idLine == 0)
            {
                queryString = "select * from " + schema + ".mrea_linea";
            }
            else
            {
                queryString = "select * from " + schema + ".mrea_linea where id_linea = @id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                if (objM.idLine != 0)
                    command.Parameters.AddWithValue("@id", objM.idLine);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MreaLine obj = new MreaLine();
                    obj.idLine = Convert.ToInt32(reader["id_linea"]);
                    obj.name = Convert.ToString(reader["nombre"]);
                    obj.desc = Convert.ToString(reader["descripcion"]);
                    obj.idZone = Convert.ToInt32(reader["id_zona"]);
                    list.Add(obj);
                }
                reader.Close();
            }
            return list;
        }
        public int insertMreaLine(MreaLine andon)
        {
            int id = 0;
            string sql = "insert into " + schema + ".mrea_linea(nombre,descripcion,id_zona) output inserted.id_linea VALUES(@nm,@dc,@iz)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nm", andon.name);
                command.Parameters.AddWithValue("@dc", andon.desc);
                command.Parameters.AddWithValue("@iz", andon.idZone);
                connection.Open();
                id = (int)command.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return id;
        }
        public bool updateMreaLine(MreaLine andon)
        {
            bool valid = false;
            string sql = "UPDATE " + schema + ".mrea_linea SET nombre = @nm, descripcion = @dc, id_zona = @iz WHERE id_linea = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nm", andon.name);
                command.Parameters.AddWithValue("@dc", andon.desc);
                command.Parameters.AddWithValue("@iz", andon.idZone);
                command.Parameters.AddWithValue("@id", andon.idLine);
                connection.Open();
                valid = command.ExecuteNonQuery() > 0 ? true : false;

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return valid;
        }
        public bool deleteMreaLine(int id)
        {
            bool valid = false;
            string sql = "delete " + schema + ".mrea_linea WHERE id_linea = @id";
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
