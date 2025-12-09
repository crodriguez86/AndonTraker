using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MreaShared.Objects
{
    public class Correos
    {
        public int id { get; set; }
        public int id_type { get; set; }
        public string correo { get; set; }
        public int id_zona { get; set; }
        public int level { get; set; }
        public string levelEmail { get; set; }
    }
}
