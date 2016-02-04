using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    class Role
    {
        public string id { get; set; }
        public string name { get; set; }
        public string enterpriseId { get; set; }
        public List<Permission> permissions { get; set; }
        public string description { get; set; }
    }
}
