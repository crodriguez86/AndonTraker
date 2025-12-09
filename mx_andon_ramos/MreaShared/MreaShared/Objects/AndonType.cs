using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonType
    {
        public int idType { get; set; }
        public string name { get; set; }
        public int idBg { get; set; }
        public int idText { get; set; }
        public string nameBg { get; set; }
        public string nameText { get; set; }
        public int idFontProduction { get; set; }
        public string nameFontProduction { get; set; }
        public int idFontMonitor { get; set; }
        public string nameFontMonitor { get; set; }
        public bool showProduction { get; set; }
        public bool showMonitor { get; set; }
        public bool showSpare1 { get; set; }
        public bool showSpare2 { get; set; }
        public int idBgMonitor { get; set; }
        public string nameMonitorBg { get; set; }
        public bool isBinary { get; set; }
        public string timeLimitLv2 { get; set; }
        public string timeLimitLv3 { get; set; }
    }
}
