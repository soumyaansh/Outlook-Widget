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
using _OutlookAddIn1.Utilities;

namespace _OutlookAddIn1
{
    class UserDBConnector
    {
        public  String userName = null;
        public  String appPath = null;
        private UserService userService;
        private UserProfileService userProfileService;
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        public UserDBConnector(String username) {
            userName = username;
        }

        public bool isDataBaseExists()
        {

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "wpoutlookwidget" + @"\" + userName.ToString().GetHashCode() + @"\");

            if (!Directory.Exists(path))
            {
                return false;
            }
            else {
                return true;
            }
        }


        private void ExecuteUserDBQuery(string txtQuery,String path)
        {
            String connectionUserDBPath = "Data Source=" + path + "\\userDB.sqlite;Version=3;";
            sql_con = new SQLiteConnection(connectionUserDBPath);
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        public String prepareAppLocalSchema()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "wpoutlookwidget" +@"\" +userName.ToString().GetHashCode() + @"\");
          

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
               
            }

            // saving into properties settings as a global variable
            Common.path = path;
            appPath = path;
            return path;
        }


        public void prepareUserDBSchema(RootObject rootObj)
        {
            String path = prepareAppLocalSchema();
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
                this.ExecuteUserDBQuery(commentQuery, path);
                this.ExecuteUserDBQuery(contactsQuery, path);

                this.ExecuteUserDBQuery(contentExpiryQuery, path);
                this.ExecuteUserDBQuery(docsQuery, path);
                this.ExecuteUserDBQuery(eventRecordsQuery, path);
                this.ExecuteUserDBQuery(foldersQuery, path);

                this.ExecuteUserDBQuery(groupContactsuery, path);
                this.ExecuteUserDBQuery(groupsQuery, path);
                this.ExecuteUserDBQuery(notificationActionsQuery, path);
                this.ExecuteUserDBQuery(notificationsQuery, path);
                this.ExecuteUserDBQuery(packageQuery, path);

                this.ExecuteUserDBQuery(packageFeatureQuery, path);
                this.ExecuteUserDBQuery(socialMediaQuery, path);
                this.ExecuteUserDBQuery(tagGroupsQuery, path);
                this.ExecuteUserDBQuery(tagsQuery, path);
                this.ExecuteUserDBQuery(topWitsQuery, path);

                this.ExecuteUserDBQuery(userDefaultsQuery, path);
                this.ExecuteUserDBQuery(userPackagesuery, path);
                this.ExecuteUserDBQuery(witAttachmentQuery, path);
                this.ExecuteUserDBQuery(witTagsQuery, path);

                this.ExecuteUserDBQuery(witsQuery, path);
                this.ExecuteUserDBQuery(witsUsageQuery, path);
                this.ExecuteUserDBQuery(witsUsageGraphDataQuery, path);
                this.ExecuteUserDBQuery(witsUsageGraphsQuery, path);

                this.ExecuteUserDBQuery(userWorkspacesQuery, path);
                this.ExecuteUserDBQuery(createdbyQuery, path);
                this.ExecuteUserDBQuery(modifiedbyQuery, path);
                this.ExecuteUserDBQuery(permissionQuery, path);

                // insert values 

            }
            else { }

        }


    }
}
