using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonValues
    {
        public int idAv { get; set; }
        public int idPlc { get; set; }
        public int? andonValue { get; set; }
        public DateTime? andonDate { get; set; }
        public string tagName { get; set; }
        public string plcName { get; set; }


    }
}
