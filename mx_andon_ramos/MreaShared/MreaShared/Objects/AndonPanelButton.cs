using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class AndonPanelButton
    {
        public int IdButton { get; set; }
        public string ButtonName { get; set; }
        public int? IdMsg { get; set; }
        public int? ButtonColumn { get; set; }
        public int? ButtonRow { get; set; }
        public bool? ButtonState { get; set; }
        public bool? IsBinary { get; set; }
        public int? IdPanel { get; set; }
        public int? IdTag { get; set; }
        public int? TagValue { get; set; }
        public int? IdType { get; set; }
        public string NameType { get; set; }
        public string BgName { get; set; }
        public string TxName { get; set; }
        public string Msg { get; set; }
        public string ButtonTowerIp { get; set; }
        public short? ButtonTowerConfig { get; set; }
        public string ButtonTowerConfigName { get; set; }
        public string ButtonTowerCommand { get; set; }
        public string ButtonTowerCommand2 { get; set; }
    }
}
