using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class EmailByType
    {
        public int idExt { get; set; }
        public int idType { get; set; }
        public int idEmail { get; set; }
        public string nameType { get; set; }
        public string nameEmail { get; set; }
        public string levelEmail { get; set; }
    }
}
