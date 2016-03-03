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
using UserContext;
using _OutlookAddIn1.Utilities;

namespace _OutlookAddIn1.Auth
{
    class AccessTokenDao
    {

        public String connectionUserDBPath = null;
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
        public AccessTokenDao(String path)
        {
            connectionUserDBPath = "Data Source=" + path + "\\userDB.sqlite;Version=3;Journal Mode=Off;Legacy Format=True";
        }

        public void saveAccessToken(AccessToken token)
        {

            var accesstokenInsertQuery = Resource.ResourceManager.GetString("socialmedia_insert");
            sql_con = new SQLiteConnection(connectionUserDBPath, true);
            sql_cmd = new SQLiteCommand(accesstokenInsertQuery, sql_con);

            sql_cmd.Parameters.Add("@id", DbType.String);
            sql_cmd.Parameters["@id"].Value = Common.userName;

            sql_cmd.Parameters.Add("@socialMediaType", DbType.String);
            sql_cmd.Parameters["@socialMediaType"].Value = token.tokenType;

            sql_cmd.Parameters.Add("@user_oauth_token", DbType.String);
            sql_cmd.Parameters["@user_oauth_token"].Value = token.tokenValue;

            sql_cmd.Parameters.Add("@is_user_oauth_done", DbType.Int16);
            sql_cmd.Parameters["@is_user_oauth_done"].Value = 1;

            sql_cmd.Parameters.Add("@user_oauth_token_expire_in", DbType.UInt64);
            sql_cmd.Parameters["@user_oauth_token_expire_in"].Value = 1;

            sql_cmd.Parameters.Add("@user_oauth_token_secret_key", DbType.String);
            sql_cmd.Parameters["@user_oauth_token_secret_key"].Value = token.tokenValue;

            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();

        }


        public String getAccessToken()
        {

            sql_con = new SQLiteConnection(connectionUserDBPath, true);
            sql_cmd = new SQLiteCommand("select * from socialmedia where socialMediaType=@type", sql_con);

            sql_cmd.Parameters.Add("@type", DbType.String);
            sql_cmd.Parameters["@type"].Value = "bearer";

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            String token = "";
            while (reader.Read())
            {
                token = StringUtils.ConvertFromDBVal<String>(reader["user_oauth_token"]);
            }

            sql_con.Close();
            return token;
        }


    } 
}
