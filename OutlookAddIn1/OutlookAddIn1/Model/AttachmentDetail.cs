using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    class AttachmentDetail
    {

        public AttachmentDetail() { }
        public string fileAssociationId { get; set; }
        public object fileId { get; set; }
        public string witId { get; set; }
        public string seqNumber { get; set; }
        public string fileName { get; set; }
        public string fileMimeType { get; set; }
        public object version { get; set; }
        public string source { get; set; }
        public string extention { get; set; }
        public object fileSize { get; set; }
        public string attachmentType { get; set; }
        public bool inline { get; set; }

    }
}
