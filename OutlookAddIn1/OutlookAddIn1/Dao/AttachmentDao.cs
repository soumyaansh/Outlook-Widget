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
using _OutlookAddIn1.Rest;
using System.Threading;

namespace _OutlookAddIn1.Dao
{
    class AttachmentDao
    {
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
        RestClientWits restWit = new RestClientWits();

        public List<AttachmentDetail> getWitAttachments()
        {
            List<AttachmentDetail> attachments;
            try
            {
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand("select * from wit_attachments", sql_con);

                sql_con.Open();
                SQLiteDataReader reader = sql_cmd.ExecuteReader();

                attachments = new List<AttachmentDetail>();
                while (reader.Read())
                {
                    AttachmentDetail attachment = new AttachmentDetail();
                    attachment.fileAssociationId = StringUtils.ConvertFromDBVal<string>(reader["file_association_id"]);
                    attachment.fileName = StringUtils.ConvertFromDBVal<string>(reader["file_name"]);
                    attachment.witId = StringUtils.ConvertFromDBVal<string>(reader["wit_id"]);
                    attachment.fileMimeType = StringUtils.ConvertFromDBVal<string>(reader["file_mime_type"]);
                    attachment.fileAssociationId = StringUtils.ConvertFromDBVal<string>(reader["file_association_id"]);
                    attachment.seqNumber = StringUtils.ConvertFromDBVal<string>(reader["seq_number"]);
                    attachment.extention = StringUtils.ConvertFromDBVal<string>(reader["extention"]);
                   
                    attachments.Add(attachment);
                }

            }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }

            return attachments;

        }

        public void saveWitAttachments(List<AttachmentDetail> witsAttachments)
        {
            if (witsAttachments != null && witsAttachments.Count > 0)
            {
                foreach (var witsAtt in witsAttachments)
                {
                    AttachmentDao attachmentDao = new AttachmentDao();
                    attachmentDao.saveWitAttachment((AttachmentDetail)witsAtt);
                }
            }
        }

        public void downloadAttachmentThreadGenerator(List<AttachmentDetail> witsAttachments)
        {
            if (witsAttachments != null && witsAttachments.Count > 0)
            {
                foreach (var witsAtt in witsAttachments)
                {
                    // create new thread for every attachment download
                    Thread thread = new Thread(() => downloadAttachment(witsAtt));
                    thread.Start();
                }
            }
        }

        // Download the attachments to the local folder
        public void downloadAttachment(AttachmentDetail witsAtt) {

            //save file in the folder structure locally
            RestClientAttachment restClientAttachment = new RestClientAttachment();
            restClientAttachment.getAttachment(witsAtt.witId, witsAtt.fileAssociationId, witsAtt.fileName, Common.localProfilePath);

        }

        // Saves the doc info into the db, it includes the name, mime and local path of the attchment files
        public void saveDocs(Docs docs)
        {
            try
            {

                var docsInsertQuery = Resource.ResourceManager.GetString("docs_insert");
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand(docsInsertQuery, sql_con);

                sql_cmd.Parameters.Add("@doc_id", DbType.String);
                sql_cmd.Parameters["@doc_id"].Value = docs.docId;

                sql_cmd.Parameters.Add("@file_name", DbType.String);
                sql_cmd.Parameters["@file_name"].Value = docs.fileName;

                sql_cmd.Parameters.Add("@mime_type", DbType.String);
                sql_cmd.Parameters["@mime_type"].Value = docs.mimeType;

                sql_cmd.Parameters.Add("@size", DbType.String);
                sql_cmd.Parameters["@size"].Value = docs.size;

                sql_cmd.Parameters.Add("@wit_id", DbType.String);
                sql_cmd.Parameters["@wit_id"].Value = docs.witId;

                sql_cmd.Parameters.Add("@local_path", DbType.String);
                sql_cmd.Parameters["@local_path"].Value = docs.localPath;

                sql_cmd.Parameters.Add("@container_dir_path", DbType.String);
                sql_cmd.Parameters["@container_dir_path"].Value = docs.containerPath;

                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
        }

        // This method will save the attachment details in the db, this does not saves actual attachments
        public void saveWitAttachment(AttachmentDetail witsAttachment)
        {
            try
            {

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
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }
        }
    }
}
