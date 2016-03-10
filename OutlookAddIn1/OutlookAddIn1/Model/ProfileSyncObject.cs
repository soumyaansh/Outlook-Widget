using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
    class ProfileSyncObject
    {

        public string timeOfLastSyncEvent { get; set; }
        public List<ProfileSync> syncs { get; set; }

    }
}
