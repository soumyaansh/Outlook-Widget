using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using System.Data.SqlClient;
using System.IO;

namespace _OutlookAddIn1
{
    class UserDBConnector
    {
        private UserService userService;
        private UserProfileService userProfileService;

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        String path = "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget";
        String connectionUserDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\userDB.sqlite;Version=3;";

        private void ExecuteUserDBQuery(string txtQuery)
        {
            sql_con = new SQLiteConnection(connectionUserDBPath);
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

       


        public void prepareUserDBSchema(RootObject rootObj)
        {

            userService = new UserService();
            userProfileService = new UserProfileService();

            if (!File.Exists(path + "\\userDB.sqlite"))
            {

                SQLiteConnection.CreateFile(path + "\\userDB.sqlite");

                // create table queries
                var commentQuery = Resource.ResourceManager.GetString("comments");
                var contactsQuery = Resource.ResourceManager.GetString("contacts");
                var contentExpiryQuery = Resource.ResourceManager.GetString("content_expiry");
                var docsQuery = Resource.ResourceManager.GetString("docs");
                var eventRecordsQuery = Resource.ResourceManager.GetString("event_records");
                var foldersQuery = Resource.ResourceManager.GetString("folders");

                var groupContactsuery = Resource.ResourceManager.GetString("group_contacts");
                var groupsQuery = Resource.ResourceManager.GetString("groups");
                var notificationActionsQuery = Resource.ResourceManager.GetString("notification_actions");
                var notificationsQuery = Resource.ResourceManager.GetString("notifications");

                var packageQuery = Resource.ResourceManager.GetString("package");
                var packageFeatureQuery = Resource.ResourceManager.GetString("package_feature");
                var socialMediaQuery = Resource.ResourceManager.GetString("socialmedia");
                var tagGroupsQuery = Resource.ResourceManager.GetString("taggroups");
                var tagsQuery = Resource.ResourceManager.GetString("tags");

                var topWitsQuery = Resource.ResourceManager.GetString("top_wits");
                var userDefaultsQuery = Resource.ResourceManager.GetString("user_defaults");
                var userPackagesuery = Resource.ResourceManager.GetString("user_package");
                var witAttachmentQuery = Resource.ResourceManager.GetString("wit_attachments");
                var witTagsQuery = Resource.ResourceManager.GetString("wit_tags");
                
                var witsQuery = Resource.ResourceManager.GetString("wits");
                var witsUsageQuery = Resource.ResourceManager.GetString("wits_usage");
                var witsUsageGraphDataQuery = Resource.ResourceManager.GetString("witsusagegraph_data");
                var witsUsageGraphsQuery = Resource.ResourceManager.GetString("wits_usagegraphs");

                var userWorkspacesQuery = Resource.ResourceManager.GetString("userworkspaces");
                var createdbyQuery = Resource.ResourceManager.GetString("createdby");
                var modifiedbyQuery = Resource.ResourceManager.GetString("modifiedby");
                var permissionQuery = Resource.ResourceManager.GetString("permission");
                

                // create table 
                this.ExecuteUserDBQuery(commentQuery);
                this.ExecuteUserDBQuery(contactsQuery);
                
                this.ExecuteUserDBQuery(contentExpiryQuery);
                this.ExecuteUserDBQuery(docsQuery);
                this.ExecuteUserDBQuery(eventRecordsQuery);
                this.ExecuteUserDBQuery(foldersQuery);

                this.ExecuteUserDBQuery(groupContactsuery);
                this.ExecuteUserDBQuery(groupsQuery);
                this.ExecuteUserDBQuery(notificationActionsQuery);
                this.ExecuteUserDBQuery(notificationsQuery);
                this.ExecuteUserDBQuery(packageQuery);

                this.ExecuteUserDBQuery(packageFeatureQuery);
                this.ExecuteUserDBQuery(socialMediaQuery);
                this.ExecuteUserDBQuery(tagGroupsQuery);
                this.ExecuteUserDBQuery(tagsQuery);
                this.ExecuteUserDBQuery(topWitsQuery);

                this.ExecuteUserDBQuery(userDefaultsQuery);
                this.ExecuteUserDBQuery(userPackagesuery);
                this.ExecuteUserDBQuery(witAttachmentQuery);
                this.ExecuteUserDBQuery(witTagsQuery);
                
                this.ExecuteUserDBQuery(witsQuery);
                this.ExecuteUserDBQuery(witsUsageQuery);
                this.ExecuteUserDBQuery(witsUsageGraphDataQuery);
                this.ExecuteUserDBQuery(witsUsageGraphsQuery);

                this.ExecuteUserDBQuery(userWorkspacesQuery);
                this.ExecuteUserDBQuery(createdbyQuery);
                this.ExecuteUserDBQuery(modifiedbyQuery);
                this.ExecuteUserDBQuery(permissionQuery);

                // insert values 

            }
            else { }

        }


    }
}
