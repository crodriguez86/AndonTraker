using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class AndonErrorLogBLL
    {
        public string _error { get; set; }
        public List<AndonErrorLog> GetAll()
        {
            try
            {
                AndonErrorLogDAL objDAL = new AndonErrorLogDAL();
                return objDAL.GetAll();
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
        public AndonErrorLog GetById(int id)
        {
            try
            {
                AndonErrorLogDAL objDAL = new AndonErrorLogDAL();
                return objDAL.GetById(id);
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
        public int Insert(AndonErrorLog obj)
        {
            try
            {
                AndonErrorLogDAL objDAL = new AndonErrorLogDAL();
                return objDAL.Insert(obj);
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
                return -1;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
                return -1;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                AndonErrorLogDAL objDAL = new AndonErrorLogDAL();
                return objDAL.Delete(id);
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
        public bool DeleteAll()
        {
            try
            {
                AndonErrorLogDAL objDAL = new AndonErrorLogDAL();
                return objDAL.DeleteAll();
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
        public bool DeleteFromDates(DateTime from, DateTime to)
        {
            try
            {
                if (to < from)
                {
                    throw new Exception("Date from must be greater than date to");
                }
                AndonErrorLogDAL objDAL = new AndonErrorLogDAL();
                return objDAL.DeleteFromDates(from, to);
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
        public List<AndonErrorLog> GetAllFromDates(DateTime from, DateTime to)
        {
            try
            {
                if (to < from)
                {
                    throw new Exception("Date from must be greater than date to");
                }
                AndonErrorLogDAL objDAL = new AndonErrorLogDAL();
                return objDAL.GetAllFromDates(from, to);
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
