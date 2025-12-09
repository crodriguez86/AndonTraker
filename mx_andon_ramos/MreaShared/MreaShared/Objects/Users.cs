using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MreaShared.Objects
{
    public class Users
    {
        public int IdAuth { get; set; }
        public string NoEmployee { get; set; }
        public string AuthPass { get; set; }
        public string AuthName { get; set; }
        public DateTime? AuthLastLogin { get; set; }
    }
}
