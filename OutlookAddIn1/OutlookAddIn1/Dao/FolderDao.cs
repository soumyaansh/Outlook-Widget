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

namespace _OutlookAddIn1
{
    class FolderDao
    {

        
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
        public String connectionUserDBPath = null;

        public FolderDao(String path) {
            connectionUserDBPath = "Data Source=" + path + "\\userDB.sqlite;Version=3;";
        }


        public void saveAllFolders(List<Folder> folders)
        {
            if (folders != null && folders.Count != 0)
            {
                foreach (var folder in folders)
                {
                    saveFolder(folder);
                }
            }
        }


        public void saveFolder(Folder folder) {

            var workspaceInsertQuery = Resource.ResourceManager.GetString("folders_insert");
            sql_con = new SQLiteConnection(connectionUserDBPath);
            sql_cmd = new SQLiteCommand(workspaceInsertQuery, sql_con);

            sql_cmd.Parameters.Add("@id", DbType.String);
            sql_cmd.Parameters["@id"].Value = folder.id;

            sql_cmd.Parameters.Add("@name", DbType.String);
            sql_cmd.Parameters["@name"].Value = folder.name;

            sql_cmd.Parameters.Add("@type", DbType.String);
            sql_cmd.Parameters["@type"].Value = folder.type;

            sql_cmd.Parameters.Add("@workspace_id", DbType.String);
            sql_cmd.Parameters["@workspace_id"].Value = folder.workspaceId;

            sql_cmd.Parameters.Add("@enterprise_id", DbType.String);
            sql_cmd.Parameters["@enterprise_id"].Value = folder.enterpriseId;

            sql_cmd.Parameters.Add("@folderType", DbType.String);
            sql_cmd.Parameters["@folderType"].Value = folder.folderType;

            sql_cmd.Parameters.Add("@parentId", DbType.String);
            sql_cmd.Parameters["@parentId"].Value = folder.parentId;

            sql_cmd.Parameters.Add("@children", DbType.String);
            sql_cmd.Parameters["@children"].Value = folder.children;

            sql_cmd.Parameters.Add("@hasChildren", DbType.String);
            sql_cmd.Parameters["@hasChildren"].Value = folder.hasChildren;

            sql_cmd.Parameters.Add("@updateNumber", DbType.String);
            sql_cmd.Parameters["@updateNumber"].Value = folder.updateNumber;

            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();

        }


        public List<Folder> getFolders(String workspaceId) {

            List<Folder> folders;
            var folderSelectQuery = Resource.ResourceManager.GetString("folders_select");
            sql_con = new SQLiteConnection(connectionUserDBPath);
            sql_cmd = new SQLiteCommand("select * from folders where workspace_id=@workspace_id and parentId is null", sql_con);

            sql_cmd.Parameters.Add("@workspace_id", DbType.String);
            sql_cmd.Parameters["@workspace_id"].Value = workspaceId;

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();


            folders = new List<Folder>();
            while (reader.Read())
            {

                Folder ws = new Folder();
                ws.id = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                ws.name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                ws.type = StringUtils.ConvertFromDBVal<string>(reader["type"]);
                ws.workspaceId = StringUtils.ConvertFromDBVal<string>(reader["workspace_id"]);
                ws.enterpriseId = StringUtils.ConvertFromDBVal<string>(reader["enterprise_id"]);
                ws.folderType = StringUtils.ConvertFromDBVal<string>(reader["folderType"]);
                ws.parentId = StringUtils.ConvertFromDBVal<string>(reader["parentId"]);
                ws.children = StringUtils.ConvertFromDBVal<string>(reader["children"]);
                folders.Add(ws);
            }

            sql_con.Close();
            return folders;
        }


        public List<String> getFolderNames(String workspaceId)
        {

            List<String> folders;
            var folderSelectQuery = Resource.ResourceManager.GetString("folders_select");
            sql_con = new SQLiteConnection(connectionUserDBPath);
            sql_cmd = new SQLiteCommand("select * from folders where workspace_id=@workspace_id", sql_con);

            sql_cmd.Parameters.Add("@workspace_id", DbType.String);
            sql_cmd.Parameters["@workspace_id"].Value = workspaceId;

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();


            folders = new List<String>();
            while (reader.Read())
            {

                Folder ws = new Folder();
                ws.id = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                ws.name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                folders.Add(ws.name);
            }

            sql_con.Close();
            return folders;
        }


        public List<TreeNode> getFolderNodes(String workspaceId)
        {

            List<TreeNode> folders;
            var folderSelectQuery = Resource.ResourceManager.GetString("folders_select");
            sql_con = new SQLiteConnection(connectionUserDBPath);
            sql_cmd = new SQLiteCommand("select * from folders where workspace_id=@workspace_id", sql_con);

            sql_cmd.Parameters.Add("@workspace_id", DbType.String);
            sql_cmd.Parameters["@workspace_id"].Value = workspaceId;

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();


            folders = new List<TreeNode>();
            while (reader.Read())
            {

                Folder ws = new Folder();
                ws.id = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                ws.name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                TreeNode node = new TreeNode(ws.name);
                folders.Add(node);
            }

            sql_con.Close();
            return folders;
        }


        public List<Folder> getChildFolders(String parentFolderId)
        {

            List<Folder> folders;
           
            sql_con = new SQLiteConnection(connectionUserDBPath);
            sql_cmd = new SQLiteCommand("select * from folders where parentId=@parentId", sql_con);

            sql_cmd.Parameters.Add("@parentId", DbType.String);
            sql_cmd.Parameters["@parentId"].Value = parentFolderId;

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();


            folders = new List<Folder>();
            while (reader.Read())
            {

                Folder folder = new Folder();
                folder.id = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                folder.name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                folder.enterpriseId = StringUtils.ConvertFromDBVal<string>(reader["enterprise_id"]);
                folder.parentId = StringUtils.ConvertFromDBVal<string>(reader["parentId"]);

                folders.Add(folder);
            }

            sql_con.Close();
            return folders;
        }

    }
}
