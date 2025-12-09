using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class ColorBgBLL
    {
        public string _error { get; set; }

        public List<ColorBg> getColorBg(ColorBg obj)
        {
            try
            {
                List<ColorBg> list = new List<ColorBg>();
                ColorBgDAL andonDAL = new ColorBgDAL();
                list = andonDAL.getColorBg(obj);
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
        public int insertColorBg(ColorBg andon)
        {
            try
            {
                ColorBgDAL andonDAL = new ColorBgDAL();
                int id = andonDAL.insertColorBg(andon);
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
        public bool updateColorBg(ColorBg andon)
        {
            try
            {
                ColorBgDAL andonDAL = new ColorBgDAL();
                bool valid = andonDAL.updateColorBg(andon);
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
        public bool deleteColorBg(int id)
        {
            try
            {
                ColorBgDAL andonDAL = new ColorBgDAL();
                bool valid = andonDAL.deleteColorBg(id);
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
        public List<ColorBg> searchColorBg(ColorBg obj)
        {
            try
            {
                List<ColorBg> list = new List<ColorBg>();
                ColorBgDAL andonDAL = new ColorBgDAL();
                list = andonDAL.searchColorBg(obj);
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
