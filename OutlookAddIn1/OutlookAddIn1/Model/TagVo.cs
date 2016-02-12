using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    class TagVo
    {
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
        public CreatedBy createdBy { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string id { get; set; }
        public string groupId { get; set; }
        public string name { get; set; }
        public string enterpriseId { get; set; }
        public string source { get; set; }
        public string type { get; set; }
        public int sequenceNumber { get; set; }
    }
}
