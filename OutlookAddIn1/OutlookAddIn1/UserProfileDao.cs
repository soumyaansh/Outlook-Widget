using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace _OutlookAddIn1
{
    class UserProfileDao
    {

        public String path = "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget";
        public String connectionMainDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\mainDB.sqlite;Version=3;";
        public String connectionUserDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\userDB.sqlite;Version=3;";
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;

        public String getUser(String userName) {
            
            string userGetQuery = "select username from user_profiles where username=@userName";
            var userVal = "";
            try
            {
                sql_con = new SQLiteConnection(connectionMainDBPath);
                sql_con.Open();

                sql_cmd = new SQLiteCommand(userGetQuery, sql_con);
                sql_cmd.Parameters.Add("@username", DbType.String);
                sql_cmd.Parameters["@username"].Value = userName;

                SQLiteDataReader reader = sql_cmd.ExecuteReader();

                while (reader.Read())
                {
                    userVal = reader[0].ToString();
                }

                sql_con.Close();
            }
            catch (Exception e) {            
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
            }

            return userVal;
        }

        public void updateUser(RootObject rootObj) {

        }

        public void saveUserProfile(RootObject rootObj)
        {

            UserProfile user = rootObj.userProfile;
            var userProfileinsertQuery = Resource.ResourceManager.GetString("user_profiles_insert");

            SQLiteConnection sql_con = new SQLiteConnection(connectionMainDBPath);
            SQLiteCommand command = new SQLiteCommand(userProfileinsertQuery, sql_con);

            command.Parameters.Add("@username", DbType.String);
            command.Parameters["@username"].Value = user.email;

            command.Parameters.Add("@user_fname", DbType.String);
            command.Parameters["@user_fname"].Value = user.firstName;

            command.Parameters.Add("@user_lname", DbType.String);
            command.Parameters["@user_lname"].Value = user.lastName;

            // l

            command.Parameters.Add("@avatar_url", DbType.String);
            command.Parameters["@avatar_url"].Value = user.avatarUrl;

            command.Parameters.Add("@timestamp", DbType.String);
            command.Parameters["@timestamp"].Value = user.createdDate;

            command.Parameters.Add("@company", DbType.String);
            command.Parameters["@company"].Value = user.email;

            command.Parameters.Add("@avatar_file_path", DbType.String);
            command.Parameters["@avatar_file_path"].Value = user.email;

            sql_con.Open();
            command.ExecuteNonQuery();
            sql_con.Close();

        }


    }
}
