using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    public class Folder
    {

        public string id { get; set; }
        public string enterpriseId { get; set; }
        public string workspaceId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public object parentId { get; set; }
        public object children { get; set; }
        public bool hasChildren { get; set; }
        public int updateNumber { get; set; }
        public string folderType { get; set; }
        public LoggedInUserPermission loggedInUserPermission { get; set; }

    }
}
