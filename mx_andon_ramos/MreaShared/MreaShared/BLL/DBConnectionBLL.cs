using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MreaShared.DAL;

namespace MreaShared.BLL
{
    public class DBConnectionBLL
    {
        public bool CheckConnection()
        {
            DBConnectionDAL objCon = new DBConnectionDAL();
            return objCon.CheckConnectionDB();
        }
    }
}
