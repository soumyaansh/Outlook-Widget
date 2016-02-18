using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    public class LoggedInUserPermission
    {
        public LoggedInUserPermission() { }
        public int? mask { get; set; }
        public bool owner { get; set; }
        public bool canFurtherShare { get; set; }
        public bool canComment { get; set; }
        public bool canEditWits { get; set; }
        public bool canEditFolderAndWits { get; set; }
        public bool canRead { get; set; }
       
 
    }
}
