using System;
using System.Collections.Generic;
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

namespace _OutlookAddIn1
{
    class UserWorkspaceDao
    {
       
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;


        public void saveWorkspaces(List<UserWorkspace> workspaces)
        {
            foreach (var workspace in workspaces)
            {
                saveWorkspace(workspace);
            }
        }

        public void saveWorkspace(UserWorkspace workspace)
        {
            try { 
            var workspaceInsertQuery = Resource.ResourceManager.GetString("userworkspaces_insert");
            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand(workspaceInsertQuery, sql_con);

            sql_cmd.Parameters.Add("@id", DbType.String);
            sql_cmd.Parameters["@id"].Value = workspace.id;

            sql_cmd.Parameters.Add("@name", DbType.String);
            sql_cmd.Parameters["@name"].Value = workspace.name;

            sql_cmd.Parameters.Add("@enterpriseId", DbType.String);
            sql_cmd.Parameters["@enterpriseId"].Value = workspace.enterpriseId;

            sql_cmd.Parameters.Add("@sequenceNumber", DbType.Int16);
            sql_cmd.Parameters["@sequenceNumber"].Value = workspace.sequenceNumber;

            sql_cmd.Parameters.Add("@description", DbType.String);
            sql_cmd.Parameters["@description"].Value = workspace.description;

            sql_cmd.Parameters.Add("@createdDate", DbType.String);
            sql_cmd.Parameters["@createdDate"].Value = workspace.createdDate;

            sql_cmd.Parameters.Add("@modifiedDate", DbType.String);
            sql_cmd.Parameters["@modifiedDate"].Value = workspace.modifiedDate;

            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
        }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
        }


        public List<UserWorkspace> getWorkspaceList()
        {
            List<UserWorkspace> workspaces;
            try { 
            var workspaceInsertQuery = Resource.ResourceManager.GetString("userworkspaces_select");
            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand(workspaceInsertQuery, sql_con);

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();


            workspaces = new List<UserWorkspace>();
            while (reader.Read())
            {

                UserWorkspace ws = new UserWorkspace();
                ws.WorkspaceId = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                ws.Name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                ws.Description = StringUtils.ConvertFromDBVal<string>(reader["description"]);
                ws.EnterpriseId = StringUtils.ConvertFromDBVal<string>(reader["enterpriseId"]);
                ws.ModifiedDate = StringUtils.ConvertFromDBVal<string>(reader["modifiedDate"]);
                ws.CreatedDate = StringUtils.ConvertFromDBVal<string>(reader["createdDate"]);
                ws.SequenceNumber = StringUtils.ConvertFromDBVal<Int64>(reader["sequenceNumber"]);


                workspaces.Add(ws);
            }
        }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
            return workspaces;
        }

        public List<String> getWorkspaceNameList()
        {
            List<String> workspaces;
            try
            {
                var workspaceInsertQuery = Resource.ResourceManager.GetString("userworkspaces_select");
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand(workspaceInsertQuery, sql_con);

                sql_con.Open();
                SQLiteDataReader reader = sql_cmd.ExecuteReader();

                workspaces = new List<String>();
                while (reader.Read())
                {
                    UserWorkspace ws = new UserWorkspace();
                    ws.Name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                    workspaces.Add(ws.Name);
                }
            }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
            return workspaces;
        }

        public UserWorkspace getByName(String workspaceName)
        {
            UserWorkspace ws;
            try { 

            var workspaceInsertQuery = "select * from userworkspaces where name=@workspaceName";
            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand(workspaceInsertQuery, sql_con);

            sql_cmd.Parameters.Add("@workspaceName", DbType.String);
            sql_cmd.Parameters["@workspaceName"].Value = workspaceName;

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();
            ws = new UserWorkspace();

            // this will have only one record as the names should be unique
            while (reader.Read())
            {
                ws.WorkspaceId = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                ws.Name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                ws.Description = StringUtils.ConvertFromDBVal<string>(reader["description"]);
                ws.EnterpriseId = StringUtils.ConvertFromDBVal<string>(reader["enterpriseId"]);
                ws.ModifiedDate = StringUtils.ConvertFromDBVal<string>(reader["modifiedDate"]);
                ws.CreatedDate = StringUtils.ConvertFromDBVal<string>(reader["createdDate"]);
                ws.SequenceNumber = StringUtils.ConvertFromDBVal<Int64>(reader["sequenceNumber"]);
            }
        }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
            return ws;
        }


        public List<UserWorkspace> getWorkspaceNames()
        {
            List<UserWorkspace> workspaces;
            try
            {
                var workspaceInsertQuery = "select * from userworkspaces";
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand(workspaceInsertQuery, sql_con);

                sql_con.Open();
                SQLiteDataReader reader = sql_cmd.ExecuteReader();
                workspaces = new List<UserWorkspace>();
           
                while (reader.Read())
                {
                    UserWorkspace ws = new UserWorkspace();
                    ws.WorkspaceId = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                    ws.Name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                    workspaces.Add(ws);
                }
            }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
            return workspaces;
        }

    }
}
