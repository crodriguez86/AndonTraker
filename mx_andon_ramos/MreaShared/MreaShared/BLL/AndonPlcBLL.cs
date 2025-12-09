using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class AndonPlcBLL
    {
        public string _error { get; set; }
        public List<AndonPlc> getAndonPlc(AndonPlc obj)
        {
            try
            {
                List<AndonPlc> list = new List<AndonPlc>();
                AndonPlcDAL andonDAL = new AndonPlcDAL();
                list = andonDAL.getAndonPlc(obj);
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
        public int insertAndonPlc(AndonPlc andon)
        {
            try
            {
                AndonPlcDAL andonDAL = new AndonPlcDAL();
                int id = andonDAL.insertAndonPlc(andon);
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
        public bool updateAndonPlc(AndonPlc andon)
        {
            try
            {
                AndonPlcDAL andonDAL = new AndonPlcDAL();
                bool valid = andonDAL.updateAndonPlc(andon);
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
        public bool deleteAndonPlc(int id)
        {
            try
            {
                AndonPlcDAL andonDAL = new AndonPlcDAL();
                bool valid = andonDAL.deleteAndonPlc(id);
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
