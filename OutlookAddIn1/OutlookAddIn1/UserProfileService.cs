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
    class UserProfileService
    {

        private UserProfileDao userProfileDao = new UserProfileDao();
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        
       
        String path = "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget";
        String connectionMainDBPath = "Data Source="+ "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\mainDB.sqlite;Version=3;";
        String connectionUserDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\userDB.sqlite;Version=3;";          

        public void saveUserProfile(RootObject rootObj) {
            userProfileDao.saveUserProfile(rootObj);
        }

    }
}
