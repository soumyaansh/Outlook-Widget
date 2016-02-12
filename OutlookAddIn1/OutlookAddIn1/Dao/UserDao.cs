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
    class UserDao
    {
        public String path = "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget";
        public String connectionMainDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\mainDB.sqlite;Version=3;";
        public String connectionUserDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\userDB.sqlite;Version=3;";
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;


        public void saveUser(RootObject rootObj)
        {
            UserProfile user = rootObj.userProfile;
            var usersinsertQuery = Resource.ResourceManager.GetString("users_insert");
            sql_con = new SQLiteConnection(connectionMainDBPath);
            sql_cmd = new SQLiteCommand(usersinsertQuery, sql_con);

            sql_cmd.Parameters.Add("@username", DbType.String);
            sql_cmd.Parameters["@username"].Value = user.email;

            sql_cmd.Parameters.Add("@user_fname", DbType.String);
            sql_cmd.Parameters["@user_fname"].Value = user.firstName;

            sql_cmd.Parameters.Add("@user_lname", DbType.String);
            sql_cmd.Parameters["@user_lname"].Value = user.lastName;

            sql_cmd.Parameters.Add("@password", DbType.String);
            sql_cmd.Parameters["@password"].Value = user.email;

            // l

            sql_cmd.Parameters.Add("@last_login", DbType.String);
            sql_cmd.Parameters["@last_login"].Value = user.email;

            sql_cmd.Parameters.Add("@is_remember_password", DbType.String);
            sql_cmd.Parameters["@is_remember_password"].Value = user.email;

            sql_cmd.Parameters.Add("@db_path", DbType.String);
            sql_cmd.Parameters["@db_path"].Value = user.email;

            // 2

            // every login, accessToken will get change 
            sql_cmd.Parameters.Add("@user_ticket", DbType.String);
            sql_cmd.Parameters["@user_ticket"].Value = user.email;

            sql_cmd.Parameters.Add("@avatar_url", DbType.String);
            sql_cmd.Parameters["@avatar_url"].Value = user.avatarUrl;

            sql_cmd.Parameters.Add("@last_sync_datetime", DbType.String);
            sql_cmd.Parameters["@last_sync_datetime"].Value = user.email;

            sql_cmd.Parameters.Add("@avatar_file_path", DbType.String);
            sql_cmd.Parameters["@avatar_file_path"].Value = user.email;

            // 3

            sql_cmd.Parameters.Add("@is_active", DbType.String);
            sql_cmd.Parameters["@is_active"].Value = user.status;

            sql_cmd.Parameters.Add("@mailtowit_id", DbType.String);
            sql_cmd.Parameters["@mailtowit_id"].Value = user.mailToWitId;

            sql_cmd.Parameters.Add("@enterprise_id", DbType.String);
            sql_cmd.Parameters["@enterprise_id"].Value = user.enterpriseId;


            // 4

            //sql_cmd.Parameters.Add("@userworkspaces", DbType.Byte);
            //command.Parameters["@userworkspaces"].Value = (List<UserWorkspace>)user.userWorkspaces;
            //sql_cmd.Parameters["@userworkspaces"].Value = null;

            //sql_cmd.Parameters.Add("@user_roles", DbType.Byte);
            //command.Parameters["@user_roles"].Value = (Role)user.role;
            //sql_cmd.Parameters["@user_roles"].Value = null;

            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();

        }
    }
}
