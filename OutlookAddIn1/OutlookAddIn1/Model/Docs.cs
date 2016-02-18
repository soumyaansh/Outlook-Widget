using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    public class Docs
    {

        public string docId { get; set; }
        public string fileName { get; set; }
        public string mimeType { get; set; }
        public string size { get; set; }
        public string creator { get; set; }
        public string creationDate { get; set; }
        public string witId { get; set; }
        public string localPath { get; set; }
        public string containerPath { get; set; }

    }
}
