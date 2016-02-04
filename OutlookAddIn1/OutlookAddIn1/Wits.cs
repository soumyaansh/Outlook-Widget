using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    class Wits
    {
        public string id { get; set; }
        public string enterpriseId { get; set; }
        public string workspaceId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string parentId { get; set; }
        public object children { get; set; }
        public bool hasChildren { get; set; }
        public int updateNumber { get; set; }
        public int ratingCount { get; set; }
        public int ratingAggregation { get; set; }
        public string desc { get; set; }
        public bool isFavorite { get; set; }
        public string witType { get; set; }
        public object status { get; set; }
        public List<AttachmentDetail> attachmentDetails { get; set; }
        public object label { get; set; }
        public LoggedInUserPermission loggedInUserPermission { get; set; }

    }
}
