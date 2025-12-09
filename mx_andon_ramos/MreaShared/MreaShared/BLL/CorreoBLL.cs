using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MreaShared.BLL
{
    public class CorreoBLL
    {
        public string _error { get; set; }

        public List<Correos> getMailsByType(int idType)
        {
            try
            {
                List<Correos> list = new List<Correos>();
                CorreoDAL correosDAL = new CorreoDAL();
                list = correosDAL.getMailsByType(idType);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return null;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return null;
            }
        }
        public List<Correos> getMailsByZone(int idZone)
        {
            try
            {
                List<Correos> list = new List<Correos>();
                CorreoDAL correosDAL = new CorreoDAL();
                list = correosDAL.getMailsByZone(idZone);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return null;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return null;
            }
        }
        public List<Correos> getMailsByLevel(int level, int idType)
        {
            try
            {
                List<Correos> list = new List<Correos>();
                CorreoDAL correosDAL = new CorreoDAL();
                list = correosDAL.getMailsByLevel(level, idType);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return null;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return null;
            }
        }
        public List<Correos> getCorreos(Correos obj)
        {
            try
            {
                List<Correos> list = new List<Correos>();
                CorreoDAL andonDAL = new CorreoDAL();
                list = andonDAL.getCorreos(obj);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return null;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return null;
            }
        }
        public int insertCorreos(Correos andon)
        {
            try
            {
                CorreoDAL andonDAL = new CorreoDAL();
                int id = andonDAL.insertCorreos(andon);
                return id;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return 0;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return 0;
            }
        }
        public bool updateCorreos(Correos andon)
        {
            try
            {
                CorreoDAL andonDAL = new CorreoDAL();
                bool valid = andonDAL.updateCorreos(andon);
                return valid;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return false;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return false;
            }
        }
        public bool deleteCorreos(int id)
        {
            try
            {
                CorreoDAL andonDAL = new CorreoDAL();
                bool valid = andonDAL.deleteCorreos(id);
                return valid;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return false;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return false;
            }
        }
        public List<Correos> searchCorreos(Correos obj)
        {
            try
            {
                List<Correos> list = new List<Correos>();
                CorreoDAL andonDAL = new CorreoDAL();
                list = andonDAL.searchCorreos(obj);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return null;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return null;
            }
        }
    }
}
