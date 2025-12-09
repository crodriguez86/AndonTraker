using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonConfig
    {
        public int idConfig { get; set; }
        public int startApp { get; set; }
        public int? idLine { get; set; }
        public int? startScreen { get; set; }
        public int? smZone { get; set; }
        public int? smDivs { get; set; }
        public string hostname { get; set; }
        public bool startAlways { get; set; }
        public DateTime? lastUpdate { get; set; }
        public string application { get; set; }
        public string line { get; set; }
        public int? idPanelGroup { get; set; }
        public string config { get; set; }

    }
}
