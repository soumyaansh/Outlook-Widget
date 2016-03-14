using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _OutlookAddIn1.Model;

namespace _OutlookAddIn1
{
    class UserProfile
    {

        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
        public CreatedBy createdBy { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object avatarUrl { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public object defaultWorkspaceId { get; set; }
        public string enterpriseId { get; set; }
        public bool autoAccept { get; set; }
        public string locale { get; set; }
        public string timezone { get; set; }
        public object phoneNumber { get; set; }
        public object address { get; set; }
        public bool changeAutoAccept { get; set; }
        public object leaderBoardPts { get; set; }
        public string mailToWitId { get; set; }
        public Role role { get; set; }
        public List<UserPackage> userPackages { get; set; }
        public List<ComboWit> comboWit { get; set; }
        public object userGroupAssoc { get; set; }
        public List<UserWorkspace> userWorkspaces { get; set; }
        public object secondaryEmails { get; set; }
        public object rollupGroupDetailsVos { get; set; }
        public string loginDate { get; set; }
        public object fontFamily { get; set; }
        public object fontSize { get; set; }
        public object fontColor { get; set; }
        public object contentStyle { get; set; }
        public object dragBehaviour { get; set; }
        public object appSettings { get; set; }
        public object widgetSettings { get; set; }
       // public Int64 desktopAlert { get; set; }
        //public int emailAlert { get; set; }
        public List<string> features { get; set; }

    }
}
