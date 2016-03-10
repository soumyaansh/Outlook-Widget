using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Model
{
   
        enum SyncEventCode
        {

            NULL,
            WIT_CREATED,
            WIT_SHARED,
            WIT_UNSHARED,
            WIT_UPDATED,
            WIT_DELETED,
            NEW_FOLDER_CREATED,
            FOLDER_SHARED,
            FOLDER_UNSHARED,
            PERMISSION_UPDATE,
            FOLDER_UPDATED,
            FOLDER_DELETED,
            FOLDER_MOVED,
            FOLDER_COPIED,
            SHARE_ACCEPT,
            SHARE_REJECT,
            LEAVE_SHARE,
            WIT_MOVED,
            WIT_COPIED,
            WIT_COMMENTS_UPDATED,
            NEW_TAG_GROUP_CREATED,
            NEW_TAG_CREATED

    }
    
}
