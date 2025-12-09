using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonErrorLog
    {
        public int idError { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }
        public string ipAddress { get; set; }
        public string deviceName { get; set; }
        public int idApp { get; set; }
        public DateTime? errorDate { get; set; }
    }
}
