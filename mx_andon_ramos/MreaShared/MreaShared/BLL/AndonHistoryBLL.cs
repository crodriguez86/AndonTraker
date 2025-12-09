using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class AndonHistoryBLL
    {
        public string _error { get; set; }
        public int insertAndonHist(Andon andon)
        {
            try
            {
                int id = 0;
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                id = AndonHistoryDAL.insertAndonHist(andon);
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
        public List<AndonHistory> getAndonTodayCount()
        {
            try
            {
                List<AndonHistory> list = new List<AndonHistory>();
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                list = AndonHistoryDAL.getAndonTodayCount();
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
        public List<AndonHistory> getAndonTodayCountByLine()
        {
            try
            {
                List<AndonHistory> list = new List<AndonHistory>();
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                list = AndonHistoryDAL.getAndonTodayCountByLine();
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
        public AndonHistory GetLastAndonByLine(int idLine)
        {
            try
            {
                AndonHistory obj = new AndonHistory();
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                obj = AndonHistoryDAL.GetLastAndonByLine(idLine);
                return obj;
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
        public AndonHistory GetLastHistoryByIdMsg(int idMsg)
        {
            try
            {
                AndonHistory obj = new AndonHistory();
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                obj = AndonHistoryDAL.GetLastHistoryByIdMsg(idMsg);
                return obj;
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
        public bool UpdateEndDate(AndonHistory objHist)
        {
            try
            {
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                return AndonHistoryDAL.UpdateEndDate(objHist);
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
        public bool UpdateEndRepairDate(int id)
        {
            try
            {
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                return AndonHistoryDAL.UpdateEndRepairDate(id);
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
        public AndonHistory GetLastAndonByType(int idType)
        {
            try
            {
                AndonHistory obj = new AndonHistory();
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                obj = AndonHistoryDAL.GetLastAndonByType(idType);
                return obj;
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
        public string GetTimeElapsedByIdMsg(int idMsg)
        {
            try
            {
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                string timeElapsed = AndonHistoryDAL.GetTimeElapsedByIdMsg(idMsg);
                return timeElapsed;
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
        public List<AndonHistory> GetAllFromDates(DateTime from, DateTime to)
        {
            try
            {
                if (to < from)
                {
                    throw new Exception("Date from must be greater than date to");
                }
                AndonHistoryDAL objDAL = new AndonHistoryDAL();
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
        public List<AndonHistory> GetCountAndonFromDates(DateTime from, DateTime to)
        {
            try
            {
                if (to < from)
                {
                    throw new Exception("Date from must be greater than date to");
                }
                AndonHistoryDAL objDAL = new AndonHistoryDAL();
                return objDAL.GetCountAndonFromDates(from, to);
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
        public bool UpdateAllOldAndonEnddates(int days)
        {
            try
            {
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                return AndonHistoryDAL.UpdateAllOldAndonEnddates(days);
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
        public AndonHistory GetLastHistoryByLineAndTag(int idLine, int idAv)
        {
            try
            {
                AndonHistory obj = new AndonHistory();
                AndonHistoryDAL AndonHistoryDAL = new AndonHistoryDAL();
                obj = AndonHistoryDAL.GetLastHistoryByLineAndTag(idLine, idAv);
                return obj;
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
