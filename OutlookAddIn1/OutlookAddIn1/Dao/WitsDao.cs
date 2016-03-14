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

namespace _OutlookAddIn1
{
    class WitsDao
    {

        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
        RestClientWits restWit = new RestClientWits();

        // save collection of wits with wit attachments
        public void saveAllWits(List<Wits> wits)
        {
           
            foreach (var Wits in wits)
            {
                saveWits(Wits);
                if (restWit.getWitsInfo(Wits.id) != null)
                {
                    saveWitAttachments(restWit.getWitsInfo(Wits.id));
                }
            }
        }

        // Wit attachment is the table which will hold the attachment details
        // This does not download the actual attachments
        public void saveWitAttachments(List<AttachmentDetail> witsAttachments)
        {
            if (witsAttachments != null && witsAttachments.Count>0) {

                foreach (var witsAtt in witsAttachments)
                {
                    saveWitAttachment((AttachmentDetail)witsAtt);
                }
            }
            
        }

        // This method is used for Sync (WIT_CREATED,WIT_SHARED,WIT_COPIED..)
        public void saveSingleWit(Wits wit)
        {
            saveWits(wit);
            saveWitAttachments(restWit.getWitsInfo(wit.id));

        }

        // This method is used for Sync (WIT_MOVED,WIT_DELETED,WIT_UNSHARED)
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

        // save the attachment details to the db
        public void saveWitAttachment(AttachmentDetail witsAttachment)
        {
            try { 

            var witAttachmentsQuery = Resource.ResourceManager.GetString("wit_attachments_insert");
            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand(witAttachmentsQuery, sql_con);

            sql_cmd.Parameters.Add("@id", DbType.String);
            sql_cmd.Parameters["@id"].Value = Utilities.GUIDGenerator.getGUID();

            sql_cmd.Parameters.Add("@file_id", DbType.String);
            sql_cmd.Parameters["@file_id"].Value = witsAttachment.fileId;

            sql_cmd.Parameters.Add("@wit_id", DbType.String);
            sql_cmd.Parameters["@wit_id"].Value = witsAttachment.witId;

            sql_cmd.Parameters.Add("@file_name", DbType.String);
            sql_cmd.Parameters["@file_name"].Value = witsAttachment.fileName;

            sql_cmd.Parameters.Add("@file_mime_type", DbType.String);
            sql_cmd.Parameters["@file_mime_type"].Value = witsAttachment.fileMimeType;

            sql_cmd.Parameters.Add("@file_association_id", DbType.String);
            sql_cmd.Parameters["@file_association_id"].Value = witsAttachment.fileAssociationId;

            sql_cmd.Parameters.Add("@seq_number", DbType.String);
            sql_cmd.Parameters["@seq_number"].Value = witsAttachment.seqNumber;

            sql_cmd.Parameters.Add("@is_inline", DbType.String);
            sql_cmd.Parameters["@is_inline"].Value = witsAttachment.inline;

            sql_cmd.Parameters.Add("@source", DbType.String);
            sql_cmd.Parameters["@source"].Value = witsAttachment.source;

            sql_cmd.Parameters.Add("@extention", DbType.String);
            sql_cmd.Parameters["@extention"].Value = witsAttachment.extention;

            sql_cmd.Parameters.Add("@fileSize", DbType.String);
            sql_cmd.Parameters["@fileSize"].Value = witsAttachment.fileSize;

            sql_cmd.Parameters.Add("@attachment_type", DbType.String);
            sql_cmd.Parameters["@attachment_type"].Value = witsAttachment.attachmentType;


            sql_con.Open();
            sql_cmd.ExecuteNonQuery();

        }
            catch (SQLiteException e) {  throw e; }
            finally { sql_con.Close(); }
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

        // not implemented/used
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

        //Get wits details
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


        // Save wits 
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
