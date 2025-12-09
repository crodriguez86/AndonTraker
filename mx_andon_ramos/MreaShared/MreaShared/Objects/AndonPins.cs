using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonPins
    {
        public int IdPin { get; set; }
        public string PinCode { get; set; }
        public string PinDesc { get; set; }
        public bool? PinActive { get; set; }
        public int? IdZone { get; set; }
        public int? IdType { get; set; }
    }
}
