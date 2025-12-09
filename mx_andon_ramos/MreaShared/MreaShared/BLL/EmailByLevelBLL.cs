using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class EmailByLevelBLL
    {
        public string _error { get; set; }

        public List<EmailByLevel> getEmailByLevel(EmailByLevel obj)
        {
            try
            {
                List<EmailByLevel> list = new List<EmailByLevel>();
                EmailByLevelDAL andonDAL = new EmailByLevelDAL();
                list = andonDAL.getEmailByLevel(obj);
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
        public int insertEmailByLevel(EmailByLevel andon)
        {
            try
            {
                EmailByLevelDAL andonDAL = new EmailByLevelDAL();
                int id = andonDAL.insertEmailByLevel(andon);
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
        public bool updateEmailByLevel(EmailByLevel andon)
        {
            try
            {
                EmailByLevelDAL andonDAL = new EmailByLevelDAL();
                bool valid = andonDAL.updateEmailByLevel(andon);
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
        public bool deleteEmailByLevel(int id)
        {
            try
            {
                EmailByLevelDAL andonDAL = new EmailByLevelDAL();
                bool valid = andonDAL.deleteEmailByLevel(id);
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
        public bool findEmailByLevel(int idLevel, int idEmail)
        {
            try
            {
                EmailByLevelDAL andonDAL = new EmailByLevelDAL();
                bool found = andonDAL.findEmailByLevel(idLevel, idEmail);
                return found;
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
        public List<EmailByLevel> searchEmailByLevel(int id, int option)
        {
            try
            {
                List<EmailByLevel> list = new List<EmailByLevel>();
                EmailByLevelDAL andonDAL = new EmailByLevelDAL();
                list = andonDAL.searchEmailByLevel(id, option);
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
