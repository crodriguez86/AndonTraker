using MreaShared.DAL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MreaShared.BLL
{
    public class UserBLL
    {
        public string _error { get; set; }
        public List<Users> GetAll()
        {
            try
            {
                UserDAL objDAL = new UserDAL();
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
        public Users GetById(int id)
        {
            try
            {
                UserDAL objDAL = new UserDAL();
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
        public Users GetByNoEmployee(string noEmployee)
        {
            try
            {
                UserDAL objDAL = new UserDAL();
                return objDAL.GetByNoEmployee(noEmployee);
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
        public int Insert(Users obj)
        {
            try
            {
                obj.AuthPass = Sha1(obj.AuthPass);
                UserDAL objDAL = new UserDAL();
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
        public bool Update(Users obj)
        {
            try
            {
                obj.AuthPass = Sha1(obj.AuthPass);
                UserDAL objDAL = new UserDAL();
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
        public bool UpdateLastLoginDate(Users obj)
        {
            try
            {
                UserDAL objDAL = new UserDAL();
                return objDAL.UpdateLastLoginDate(obj);
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
                UserDAL objDAL = new UserDAL();
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
        public bool ValidUserByEmployeeAndPassword(string noNomina, string password)
        {
            try
            {
                UserDAL objDAL = new UserDAL();
                return objDAL.ValidUserByEmployeeAndPassword(noNomina, Sha1(password));
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
        private string Sha1(string password)
        {
            string sha1 = string.Empty;
            System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);

            foreach (byte b in hashBytes)
            {
                sha1 += b.ToString("X2");
            }
            return sha1;
        }
    }
}
