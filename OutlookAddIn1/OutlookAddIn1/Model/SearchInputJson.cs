using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    class SearchInputJson
    {
        public int max { get; set; }
        public List<object> aggregateFields { get; set; }
        public List<object> witType { get; set; }
        public List<object> workspaceIds { get; set; }
        public List<object> searchFields { get; set; }
        public string dateBegin { get; set; }
        public string dateEnd { get; set; }
        public string searchTerm { get; set; }
        public List<object> filterByFolderId { get; set; }
        public List<object> filterByTagId { get; set; }
        public List<object> witIds { get; set; }
        public List<object> labelIds { get; set; }

    }
}
