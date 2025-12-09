using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class AndonPanelViewBLL
    {
        public string _error { get; set; }
        public List<AndonPanelView> GetAll()
        {
            try
            {
                AndonPanelViewDAL objDAL = new AndonPanelViewDAL();
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
        public AndonPanelView GetById(int id)
        {
            try
            {
                AndonPanelViewDAL objDAL = new AndonPanelViewDAL();
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
        public int Insert(AndonPanelView obj)
        {
            try
            {
                AndonPanelViewDAL objDAL = new AndonPanelViewDAL();
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
        public bool Update(AndonPanelView obj)
        {
            try
            {
                AndonPanelViewDAL objDAL = new AndonPanelViewDAL();
                return objDAL.Update(obj);
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
        public bool Delete(int id)
        {
            try
            {
                AndonPanelViewDAL objDAL = new AndonPanelViewDAL();
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
        public List<AndonPanelView> GetAllByIdGroup(int idGroup)
        {
            try
            {
                AndonPanelViewDAL objDAL = new AndonPanelViewDAL();
                return objDAL.GetAllByIdGroup(idGroup);
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
