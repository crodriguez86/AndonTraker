using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonHistory
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string line { get; set; }
        public string type { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public int idLine { get; set; }
        public int idType { get; set; }
        public int idMsg { get; set; }
        public string colorMonitor { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? endRepairDate { get; set; }
        public string endTime { get; set; }
        public string endRepairTime { get; set; }
        public string responseAverageSec { get; set; }
        public string topLineSupport { get; set; }
        public string topResponseSec { get; set; }
    }
}
