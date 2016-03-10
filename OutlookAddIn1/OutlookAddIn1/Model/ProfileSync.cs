using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    class ProfileSync
    {
            public ProfileSync() { }
            public string refrenceNodeId { get; set; }
            public string syncEventType { get; set; }
            public string createdDate { get; set; }
            public string actorId { get; set; }
            public string recipientType { get; set; }
            public string RecipientId { get; set; }

        
    }
}
