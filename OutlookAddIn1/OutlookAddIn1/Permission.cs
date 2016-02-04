using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace _OutlookAddIn1
{
    class Permission
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } [Indexed]
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string authority { get; set; }
    }
}
