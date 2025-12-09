using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class AndonPinsBLL
    {
        public string _error { get; set; }
        public List<AndonPins> GetAll()
        {
            try
            {
                AndonPinsDAL objDAL = new AndonPinsDAL();
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
        public AndonPins GetById(int id)
        {
            try
            {
                AndonPinsDAL objDAL = new AndonPinsDAL();
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
        public int Insert(AndonPins obj)
        {
            try
            {
                AndonPinsDAL objDAL = new AndonPinsDAL();
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
        public bool Update(AndonPins obj)
        {
            try
            {
                AndonPinsDAL objDAL = new AndonPinsDAL();
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
                AndonPinsDAL objDAL = new AndonPinsDAL();
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
        public bool ValidCodeByIdMsg(int idMsg, string code)
        {
            try
            {
                AndonPinsDAL objDAL = new AndonPinsDAL();
                return objDAL.ValidCodeByIdMsg(idMsg,code);
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
        public bool CheckPinActiveByIdMsg(int idMsg)
        {
            try
            {
                AndonPinsDAL objDAL = new AndonPinsDAL();
                return objDAL.CheckPinActiveByIdMsg(idMsg);
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
        /// <summary>
        /// Metodo para validar el pin de un operador.
        /// El pin o codigo esta divido por por zonas. La consulta busca el pin que coincida con la zona que tiene la linea del msj
        /// ademas, el valor del tipo debe ser nulo.
        /// </summary>
        /// <param name="idMsg">Id del mensaje Andon</param>
        /// <param name="code">Codigo con el que se va a comparar</param>
        /// <returns>True si el codigo coincide y False si el codigo no coincide.</returns>
        public bool ValidOperatorCodeByIdMsg(int idMsg, string code)
        {
            try
            {
                AndonPinsDAL objDAL = new AndonPinsDAL();
                return objDAL.ValidOperatorCodeByIdMsg(idMsg, code);
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
