using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class EmailByTypeBLL
    {
        public string _error { get; set; }

        public List<EmailByType> getEmailByType(EmailByType obj)
        {
            try
            {
                List<EmailByType> list = new List<EmailByType>();
                EmailByTypeDAL andonDAL = new EmailByTypeDAL();
                list = andonDAL.getEmailByType(obj);
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
        public int insertEmailByType(EmailByType andon)
        {
            try
            {
                EmailByTypeDAL andonDAL = new EmailByTypeDAL();
                int id = andonDAL.insertEmailByType(andon);
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
        public bool updateEmailByType(EmailByType andon)
        {
            try
            {
                EmailByTypeDAL andonDAL = new EmailByTypeDAL();
                bool valid = andonDAL.updateEmailByType(andon);
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
        public bool deleteEmailByType(int id)
        {
            try
            {
                EmailByTypeDAL andonDAL = new EmailByTypeDAL();
                bool valid = andonDAL.deleteEmailByType(id);
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
        public bool findEmailByType(int idType, int idEmail)
        {
            try
            {
                EmailByTypeDAL andonDAL = new EmailByTypeDAL();
                bool found = andonDAL.findEmailByType(idType, idEmail);
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
        public List<EmailByType> searchEmailByType(int id, int option)
        {
            try
            {
                List<EmailByType> list = new List<EmailByType>();
                EmailByTypeDAL andonDAL = new EmailByTypeDAL();
                list = andonDAL.searchEmailByType(id, option);
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
