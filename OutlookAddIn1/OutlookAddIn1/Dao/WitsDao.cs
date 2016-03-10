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
using _OutlookAddIn1.Model;
using _OutlookAddIn1.Utilities;
using _OutlookAddIn1.Dao;
using _OutlookAddIn1.Rest;
using System.Threading;

namespace _OutlookAddIn1
{
    class WitsDao
    {

        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
       

        public void saveAllWits(List<Wits> wits)
        {         
            foreach (var wit in wits)
            {
                // create new thread for every wit creation to improve the loading time
                Thread thread = new Thread(() => saveWitsAndAttachmentDeatials(wit));
                thread.Start();               
            }
        }


        private void saveWitsAndAttachmentDeatials(Wits wit) {
            WitsDao witDao = new WitsDao();
            witDao.saveWits(wit);

            RestClientWits restWit = new RestClientWits();
            if (restWit.getWitsInfo(wit.id) != null)
            {
                AttachmentDao attachmentDao = new AttachmentDao();
                attachmentDao.saveWitAttachments(restWit.getWitsInfo(wit.id));
            }
        }

        public void saveSingleWit(Wits wit)
        {
            WitsDao witDao = new WitsDao();
            witDao.saveWits(wit);
            AttachmentDao attachmentDao = new AttachmentDao();

            RestClientWits restWit = new RestClientWits();
            attachmentDao.saveWitAttachments(restWit.getWitsInfo(wit.id));

        }

        public void deleteWit(String witId) {

            try
            {
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand("delete from wits where id=@id", sql_con);

                sql_cmd.Parameters.Add("@id", DbType.String);
                sql_cmd.Parameters["@id"].Value = witId;

                sql_con.Open();
                SQLiteDataReader reader = sql_cmd.ExecuteReader();

            }
            catch (SQLiteException e){ throw e;} finally{sql_con.Close();}

        }

        public List<Docs> getDocsOfWit(String witId)
        {
            List<Docs> docs = null;
            try
            {
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand("select * from docs where wit_id=@wit_id", sql_con);

                sql_cmd.Parameters.Add("@wit_id", DbType.String);
                sql_cmd.Parameters["@wit_id"].Value = witId;

                sql_con.Open();
                SQLiteDataReader reader = sql_cmd.ExecuteReader();

                docs = new List<Docs>();
                while (reader.Read())
                {
                    Docs doc = new Docs();
                    doc.docId = StringUtils.ConvertFromDBVal<string>(reader["doc_id"]);
                    doc.fileName = StringUtils.ConvertFromDBVal<string>(reader["file_name"]);
                    doc.localPath = StringUtils.ConvertFromDBVal<string>(reader["local_path"]);
                    docs.Add(doc);

                }


            
            }
            catch (SQLiteException e) {  throw e; }
            finally { sql_con.Close(); }

            return docs;

        }       

      

        public List<Wits> getWits(String parentFolderId)
        {

            List<Wits> wits;

            try { 

            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand("select * from wits where parent_id=@parent_id", sql_con);

            sql_cmd.Parameters.Add("@parent_id", DbType.String);
            sql_cmd.Parameters["@parent_id"].Value = parentFolderId;

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();

            wits = new List<Wits>();
            while (reader.Read())
            {
                Wits wit = new Wits();
                wit.id = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                wit.name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                wits.Add(wit);
            }
        }
            catch (SQLiteException e) {  throw e; }
            finally { sql_con.Close(); }
            return wits;
        }


        public List<Wits> getAllWits(String parentFolderId)
        {

            List<Wits> wits;
            try { 
            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand("select * from wits where parent_id=@parent_id", sql_con);

            sql_cmd.Parameters.Add("@parent_id", DbType.String);
            sql_cmd.Parameters["@parent_id"].Value = parentFolderId;

            sql_con.Open();
            SQLiteDataReader reader = sql_cmd.ExecuteReader();

            wits = new List<Wits>();
            while (reader.Read())
            {
                Wits wit = new Wits();
                wit.id = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                wit.name = StringUtils.ConvertFromDBVal<string>(reader["name"]);

                wits.Add(wit);
            }
        }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
            return wits;
        }

        public Wits getWit(String witId)
        {
            Wits wit;

            try {
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand("select * from wits where id=@id", sql_con);

                sql_cmd.Parameters.Add("@id", DbType.String);
                sql_cmd.Parameters["@id"].Value = witId;

                sql_con.Open();
                SQLiteDataReader reader = sql_cmd.ExecuteReader();

                wit = new Wits();
                while (reader.Read())
                {

                    wit.id = StringUtils.ConvertFromDBVal<string>(reader["id"]);
                    wit.name = StringUtils.ConvertFromDBVal<string>(reader["name"]);
                    wit.type = StringUtils.ConvertFromDBVal<string>(reader["type"]);
                    wit.desc = StringUtils.ConvertFromDBVal<string>(reader["desc"]);
                    wit.content = StringUtils.ConvertFromDBVal<string>(reader["content"]);

                }
            }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
            
            return wit;

        }


       

        public void saveWits(Wits wits)
        {
            try { 

            var workspaceInsertQuery = Resource.ResourceManager.GetString("wits_insert");
            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand(workspaceInsertQuery, sql_con);

            sql_cmd.Parameters.Add("@id", DbType.String);
            sql_cmd.Parameters["@id"].Value = wits.id;

            sql_cmd.Parameters.Add("@name", DbType.String);
            sql_cmd.Parameters["@name"].Value = wits.name;

            sql_cmd.Parameters.Add("@type", DbType.String);
            sql_cmd.Parameters["@type"].Value = wits.type;

            sql_cmd.Parameters.Add("@workspace_id", DbType.String);
            sql_cmd.Parameters["@workspace_id"].Value = wits.workspaceId;

            sql_cmd.Parameters.Add("@enterprise_id", DbType.String);
            sql_cmd.Parameters["@enterprise_id"].Value = wits.enterpriseId;

            sql_cmd.Parameters.Add("@witType", DbType.String);
            sql_cmd.Parameters["@witType"].Value = wits.witType;

            sql_cmd.Parameters.Add("@parent_id", DbType.String);
            sql_cmd.Parameters["@parent_id"].Value = wits.parentId;

            sql_cmd.Parameters.Add("@children", DbType.String);
            sql_cmd.Parameters["@children"].Value = wits.children;

            sql_cmd.Parameters.Add("@hasChildren", DbType.String);
            sql_cmd.Parameters["@hasChildren"].Value = wits.hasChildren;

            sql_cmd.Parameters.Add("@updateNumber", DbType.String);
            sql_cmd.Parameters["@updateNumber"].Value = wits.updateNumber;

            sql_cmd.Parameters.Add("@ratingCount", DbType.String);
            sql_cmd.Parameters["@ratingCount"].Value = wits.ratingCount;

            sql_cmd.Parameters.Add("@ratingAggregation", DbType.String);
            sql_cmd.Parameters["@ratingAggregation"].Value = wits.ratingAggregation;

            sql_cmd.Parameters.Add("@desc", DbType.String);
            sql_cmd.Parameters["@desc"].Value = wits.desc;

            sql_cmd.Parameters.Add("@content", DbType.String);
            sql_cmd.Parameters["@content"].Value = wits.content;

            sql_cmd.Parameters.Add("@isFavorite", DbType.String);
            sql_cmd.Parameters["@isFavorite"].Value = wits.isFavorite;

            sql_cmd.Parameters.Add("@witType", DbType.String);
            sql_cmd.Parameters["@witType"].Value = wits.witType;

            sql_cmd.Parameters.Add("@status", DbType.String);
            sql_cmd.Parameters["@status"].Value = wits.status;

            sql_cmd.Parameters.Add("@label", DbType.String);
            sql_cmd.Parameters["@label"].Value = wits.label;


            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
        }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }

        }


    }
}
