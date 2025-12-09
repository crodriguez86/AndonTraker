using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class AndonPanelGroupBLL
    {
        public string _error { get; set; }
        public List<AndonPanelGroup> GetAll()
        {
            try
            {
                AndonPanelGroupDAL objDAL = new AndonPanelGroupDAL();
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
        public AndonPanelGroup GetById(int id)
        {
            try
            {
                AndonPanelGroupDAL objDAL = new AndonPanelGroupDAL();
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
        public int Insert(AndonPanelGroup obj)
        {
            try
            {
                AndonPanelGroupDAL objDAL = new AndonPanelGroupDAL();
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
        public bool Update(AndonPanelGroup obj)
        {
            try
            {
                AndonPanelGroupDAL objDAL = new AndonPanelGroupDAL();
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
                AndonPanelGroupDAL objDAL = new AndonPanelGroupDAL();
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
        public AndonPanelGroup GetGroupByIdPanel(int idPanel)
        {
            try
            {
                AndonPanelGroupDAL objDAL = new AndonPanelGroupDAL();
                return objDAL.GetGroupByIdPanel(idPanel);
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
