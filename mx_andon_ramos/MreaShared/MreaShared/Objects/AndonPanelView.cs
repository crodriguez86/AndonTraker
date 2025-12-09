using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonPanelView
    {
        public int IdPanel { get; set; }
        public string PanelName { get; set; }
        public string PanelDesc { get; set; }
        public int? IdPlc { get; set; }
        public DateTime? PanelLastUpdate { get; set; }
        public int? IdGroup { get; set; }
        public int? PanelColumns { get; set; }
        public int? PanelRows { get; set; }
    }
}
