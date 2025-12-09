using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class FontsizeBLL
    {
        public string _error { get; set; }

        public List<AndonFontsize> getAndonFontsize(AndonFontsize obj)
        {
            try
            {
                List<AndonFontsize> list = new List<AndonFontsize>();
                FontsizeDAL andonDAL = new FontsizeDAL();
                list = andonDAL.getAndonFontsize(obj);
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
        public int insertAndonFontsize(AndonFontsize andon)
        {
            try
            {
                FontsizeDAL andonDAL = new FontsizeDAL();
                int id = andonDAL.insertAndonFontsize(andon);
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
        public bool updateAndonFontsize(AndonFontsize andon)
        {
            try
            {
                FontsizeDAL andonDAL = new FontsizeDAL();
                bool valid = andonDAL.updateAndonFontsize(andon);
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
        public bool deleteAndonFontsize(int id)
        {
            try
            {
                FontsizeDAL andonDAL = new FontsizeDAL();
                bool valid = andonDAL.deleteAndonFontsize(id);
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
        public List<AndonFontsize> searchAndonFontsize(AndonFontsize obj)
        {
            try
            {
                List<AndonFontsize> list = new List<AndonFontsize>();
                FontsizeDAL andonDAL = new FontsizeDAL();
                list = andonDAL.searchAndonFontsize(obj);
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
