using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class ZoneBLL
    {
        public string _error { get; set; }

        public List<Zone> getZone(Zone obj)
        {
            try
            {
                List<Zone> list = new List<Zone>();
                ZoneDAL andonDAL = new ZoneDAL();
                list = andonDAL.getZone(obj);
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
        public int insertZone(Zone andon)
        {
            try
            {
                ZoneDAL andonDAL = new ZoneDAL();
                int id = andonDAL.insertZone(andon);
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
        public bool updateZone(Zone andon)
        {
            try
            {
                ZoneDAL andonDAL = new ZoneDAL();
                bool valid = andonDAL.updateZone(andon);
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
        public bool deleteZone(int id)
        {
            try
            {
                ZoneDAL andonDAL = new ZoneDAL();
                bool valid = andonDAL.deleteZone(id);
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
        public List<Zone> searchZone(Zone obj)
        {
            try
            {
                List<Zone> list = new List<Zone>();
                ZoneDAL andonDAL = new ZoneDAL();
                list = andonDAL.searchZone(obj);
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
