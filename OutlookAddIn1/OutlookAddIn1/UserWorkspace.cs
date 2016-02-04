using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    class UserWorkspace : UserContext.Userworkspace
    {
        public object createdDate { get; set; }
        public object modifiedDate { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public string enterpriseId { get; set; }
        public int sequenceNumber { get; set; }
    }
}
