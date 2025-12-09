using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MreaShared.DAL;
using MreaShared.Objects;

namespace MreaShared.BLL
{
    public class AndonTypeBLL
    {
        public string _error { get; set; }

        public List<AndonType> getAndonType(AndonType obj)
        {
            try
            {
                List<AndonType> list = new List<AndonType>();
                AndonTypeDAL andonDAL = new AndonTypeDAL();
                list = andonDAL.getAndonType(obj);
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
        public int insertAndonType(AndonType andon)
        {
            try
            {
                AndonTypeDAL andonDAL = new AndonTypeDAL();
                int id = andonDAL.insertAndonType(andon);
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
        public bool updateAndonType(AndonType andon)
        {
            try
            {
                AndonTypeDAL andonDAL = new AndonTypeDAL();
                bool valid = andonDAL.updateAndonType(andon);
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
        public bool deleteAndonType(int id)
        {
            try
            {
                AndonTypeDAL andonDAL = new AndonTypeDAL();
                bool valid = andonDAL.deleteAndonType(id);
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
    }
}
