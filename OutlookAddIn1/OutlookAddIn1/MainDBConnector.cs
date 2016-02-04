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
using System.Data.Linq;
using System.Linq;

namespace _OutlookAddIn1
{
    class MainDBConnector
    {

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private UserService userService;
        private UserProfileService userProfileService;
        private UserProfileDao userProfileDao;
        private UserDao userDao;
        String path = "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget";
        String connectionMainDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\mainDB.sqlite;Version=3;";


        public void testLinq() {

            var connection = new SQLiteConnection(connectionMainDBPath);
            var context = new DataContext(connection);

            //var permission = context.GetTable<Permission>();
            Console.ReadKey();

        }
        private void ExecuteMainDBQuery(string txtQuery)
        {
            sql_con = new SQLiteConnection(connectionMainDBPath);
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }


        public void prepareMainDBSchema(RootObject rootObj)
        {
            userService = new UserService();
            userProfileService = new UserProfileService();
            userProfileDao = new UserProfileDao();
            userDao = new UserDao();
            // it will first check if all the db tables are already available 
            // if its there then it will just do initial sync and update the data
            // else it will create all the tables and call the apis to insert the values

            // check if the database is already exists
            if (!File.Exists(path + "\\mainDB.sqlite"))
            {

                SQLiteConnection.CreateFile(path + "\\mainDB.sqlite");


                var usersQuery = Resource.ResourceManager.GetString("users");
                var usersprofilesQuery = Resource.ResourceManager.GetString("user_profiles");

                // create table 
                this.ExecuteMainDBQuery(usersprofilesQuery);
                this.ExecuteMainDBQuery(usersQuery);

                // insert values 
                userProfileService.saveUserProfile(rootObj);
                userService.saveUser(rootObj)


;
            }
            else {


                var username = userProfileDao.getUser(rootObj.userProfile.email);
                //MessageBox.Show(username);

                if (username == null)
                {
                    // new user, need to save
                    userDao.saveUser(rootObj);
                    userProfileDao.saveUserProfile(rootObj);
                }

            }



            // Retrieve the value of the string resource named "welcome".
            // The resource manager will retrieve the value of the  
            // localized resource using the caller's current culture setting.


        }
    }
}
