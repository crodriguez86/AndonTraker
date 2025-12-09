using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class ColorTextBLL
    {
        public string _error { get; set; }

        public List<ColorText> getColorText(ColorText obj)
        {
            try
            {
                List<ColorText> list = new List<ColorText>();
                ColorTextDAL andonDAL = new ColorTextDAL();
                list = andonDAL.getColorText(obj);
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
        public int insertColorText(ColorText andon)
        {
            try
            {
                ColorTextDAL andonDAL = new ColorTextDAL();
                int id = andonDAL.insertColorText(andon);
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
        public bool updateColorText(ColorText andon)
        {
            try
            {
                ColorTextDAL andonDAL = new ColorTextDAL();
                bool valid = andonDAL.updateColorText(andon);
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
        public bool deleteColorText(int id)
        {
            try
            {
                ColorTextDAL andonDAL = new ColorTextDAL();
                bool valid = andonDAL.deleteColorText(id);
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
        public List<ColorText> searchColorText(ColorText obj)
        {
            try
            {
                List<ColorText> list = new List<ColorText>();
                ColorTextDAL andonDAL = new ColorTextDAL();
                list = andonDAL.searchColorText(obj);
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
