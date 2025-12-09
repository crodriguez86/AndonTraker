using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MreaShared.DAL;
using MreaShared.Objects;

namespace MreaShared.BLL
{
    public class AndonValueBLL
    {
        public string _error { get; set; }

        public List<AndonValues> getAndonValues(AndonValues obj)
        {
            try
            {
                List<AndonValues> list = new List<AndonValues>();
                AndonValueDAL andonDAL = new AndonValueDAL();
                list = andonDAL.getAndonValues(obj);
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
        public int insertAndonValues(AndonValues andon)
        {
            try
            {
                AndonValueDAL andonDAL = new AndonValueDAL();
                int id = andonDAL.insertAndonValue(andon);
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
        public bool updateAndonValues(AndonValues andon)
        {
            try
            {
                AndonValueDAL andonDAL = new AndonValueDAL();
                bool valid = andonDAL.updateAndonValue(andon);
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
        public bool deleteAndonValues(int id)
        {
            try
            {
                AndonValueDAL andonDAL = new AndonValueDAL();
                bool valid = andonDAL.deleteAndonValue(id);
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
        public AndonValues GetAndonValueByTagname(string tagname)
        {
            try
            {
                AndonValues andonValue = new AndonValues();
                AndonValueDAL andonDAL = new AndonValueDAL();
                andonValue = andonDAL.GetAndonValueByTagname(tagname);
                return andonValue;
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
