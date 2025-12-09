using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class Andon
    {
        public int idLine { get; set; }
        public int idAndonValue { get; set; }
        public string nameLine { get; set; }
        public int idMessage { get; set; }
        public int tagValue { get; set; }
        public string message { get; set; }
        public int idType { get; set; }
        public string nameType { get; set; }
        public int idBackground { get; set; }
        public string nameBackground { get; set; }
        public int idText { get; set; }
        public string nameText { get; set; }
        public int idfont1 { get; set; }
        public int idfont2 { get; set; }
        public int idfont3 { get; set; }
        public int font { get; set; }//Para pantallas en produccion
        public int? font2 { get; set; }//Para Monitor
        public int? font3 { get; set; }//Para Monitor (Mensajes slider)
        public int idPlc { get; set; }
        public string namePlc { get; set; }
        public string tagName { get; set; }
        public int idFontProd { get; set; }
        public int idFontMon { get; set; }
        public int fontProd { get; set; }
        public int fontMon { get; set; }
        public bool? IsBinary { get; set; }
        public string timeElapsed { get; set; }
        public string timeLimitLv2 { get; set; }
        public string timeLimitLv3 { get; set; }
    }
}
