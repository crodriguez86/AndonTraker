using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MreaShared.DAL;
using MreaShared.Objects;

namespace MreaShared.BLL
{
    public class MreaLineBLL
    {
        public string _error { get; set; }

        public List<MreaLine> getMreaLine(MreaLine obj)
        {
            try
            {
                List<MreaLine> list = new List<MreaLine>();
                MreaLineDAL andonDAL = new MreaLineDAL();
                list = andonDAL.getMreaLine(obj);
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
        public int insertMreaLine(MreaLine andon)
        {
            try
            {
                MreaLineDAL andonDAL = new MreaLineDAL();
                int id = andonDAL.insertMreaLine(andon);
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
        public bool updateMreaLine(MreaLine andon)
        {
            try
            {
                MreaLineDAL andonDAL = new MreaLineDAL();
                bool valid = andonDAL.updateMreaLine(andon);
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
        public bool deleteMreaLine(int id)
        {
            try
            {
                MreaLineDAL andonDAL = new MreaLineDAL();
                bool valid = andonDAL.deleteMreaLine(id);
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
