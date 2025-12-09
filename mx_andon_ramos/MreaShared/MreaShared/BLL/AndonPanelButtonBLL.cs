using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class AndonPanelButtonBLL
    {
        public string _error { get; set; }
        public List<AndonPanelButton> GetAll()
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
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
        public AndonPanelButton GetById(int id)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
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
        public int Insert(AndonPanelButton obj)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
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
        public bool Update(AndonPanelButton obj)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
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
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
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
        public List<AndonPanelButton> GetAllByIdPanel(int idPanel)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.GetAllByIdPanel(idPanel);
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
        public bool UpdateState(int id, bool state)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.UpdateState(id, state);
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
        public List<AndonPanelButton> GetAllActiveButtons(int idPanel)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.GetAllActiveButtons(idPanel);
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
        public AndonPanelButton GetByIdWithMsg(int id)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.GetByIdWithMsg(id);
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
        public List<Andon> GetAllAndonMsgWithBinary()
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.GetAllAndonMsgWithBinary();
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
        public bool MsgIsBinary(int idMsg)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.MsgIsBinary(idMsg);
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

        public bool CheckColumnRowByPanel(int idPanel, int bc, int br)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.CheckColumnRowByPanel(idPanel, bc, br);
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
        public bool CheckIdMsgByPanel(int idPanel, int idMsg)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.CheckIdMsgByPanel(idPanel, idMsg);
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
        public AndonPanelButton GetButtonNameByPanel(int idPanel, string buttonName)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.GetButtonNameByPanel(idPanel, buttonName);
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
        public string GetGlobalIpTower(int idPanel)
        {
            try
            {
                AndonPanelButtonDAL objDAL = new AndonPanelButtonDAL();
                return objDAL.GetGlobalIpTower(idPanel);
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
