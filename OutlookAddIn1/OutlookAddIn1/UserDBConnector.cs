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
             
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        public UserDBConnector(String username) {
            Common.userName = username;
            init();
        }

        public String init()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "wpoutlookwidget" + @"\" + Common.userName.ToString().GetHashCode() + @"\");

           
            // saving into properties settings as a global variable
            Common.localProfilePath = path;
            return path;
        }

        public bool isDataBaseExists()
        {

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "wpoutlookwidget" + @"\" + Common.userName.ToString().GetHashCode() + @"\");

            if (!Directory.Exists(path))
            {
                return false;
            }
            else {
                return true;
            }
        }

        public void createLocalUserProfileFolder()
        {

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "wpoutlookwidget" + @"\" + Common.userName.ToString().GetHashCode() + @"\");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
        }




        private void ExecuteUserDBQuery(string txtQuery,String path)
        {
            String connectionUserDBPath = "Data Source=" + path + "\\userDB.sqlite";
            sql_con = new SQLiteConnection(connectionUserDBPath,true);
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

       

        public String usePath() {

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "wpoutlookwidget" + @"\" + Common.userName.ToString().GetHashCode() + @"\");
            
            return path;
        }


        public void prepareUserDBSchema(RootObject rootObj)
        {

            createLocalUserProfileFolder();

            if (!File.Exists(Common.localProfilePath + "\\userDB.sqlite"))
            {

                SQLiteConnection.CreateFile(Common.localProfilePath + "\\userDB.sqlite");

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
                this.ExecuteUserDBQuery(commentQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(contactsQuery, Common.localProfilePath);

                this.ExecuteUserDBQuery(contentExpiryQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(docsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(eventRecordsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(foldersQuery, Common.localProfilePath);

                this.ExecuteUserDBQuery(groupContactsuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(groupsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(notificationActionsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(notificationsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(packageQuery, Common.localProfilePath);

                this.ExecuteUserDBQuery(packageFeatureQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(socialMediaQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(tagGroupsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(tagsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(topWitsQuery, Common.localProfilePath);

                this.ExecuteUserDBQuery(userDefaultsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(userPackagesuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(witAttachmentQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(witTagsQuery, Common.localProfilePath);

                this.ExecuteUserDBQuery(witsQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(witsUsageQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(witsUsageGraphDataQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(witsUsageGraphsQuery, Common.localProfilePath);

                this.ExecuteUserDBQuery(userWorkspacesQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(createdbyQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(modifiedbyQuery, Common.localProfilePath);
                this.ExecuteUserDBQuery(permissionQuery, Common.localProfilePath);

            }
            else { }

        }


    }
}
