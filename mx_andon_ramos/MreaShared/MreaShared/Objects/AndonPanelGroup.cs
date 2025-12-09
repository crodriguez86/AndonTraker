using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonPanelGroup
    {
        public int IdGroup { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public int? IdLine { get; set; }
        public string LineName { get; set; }
        public string GroupTowerIp { get; set; }
        public string GroupTowerTestCommand { get; set; }
        public string GroupTowerClearCommand { get; set; }
        public bool? GroupTowerActive { get; set; }
    }
}
