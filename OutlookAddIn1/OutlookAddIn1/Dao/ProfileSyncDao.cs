using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using _OutlookAddIn1.Model;
using _OutlookAddIn1.Rest;
using _OutlookAddIn1.Auth;
using _OutlookAddIn1.Utilities;
using _OutlookAddIn1.Service;
using System.Windows.Forms;
using System.Globalization;

namespace _OutlookAddIn1.Dao
{
    class ProfileSyncDao
    {

        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;

        public void saveProfileSyncTime(String status)
        {
            var accesstokenInsertQuery = Resource.ResourceManager.GetString("profileSyncEvent_insert");
            sql_con = new SQLiteConnection(Common.localDatabasePath, true);
            sql_cmd = new SQLiteCommand(accesstokenInsertQuery, sql_con);

            sql_cmd.Parameters.AddWithValue("@id", GUIDGenerator.getUUID());
            sql_cmd.Parameters.AddWithValue("@lastsynctime", Common.lastLocalDBSyncTime.ToString());
            sql_cmd.Parameters.AddWithValue("@status", status);

            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }


        // check the last sync time 
        private String getLastProfileSyncTime()
        {

            DateTime lastSynctime;
            String lastSynctimeString = null;
            try
            {
                sql_con = new SQLiteConnection(Common.localDatabasePath, true);
                sql_cmd = new SQLiteCommand("select * from profileSyncEvent ORDER BY lastsynctime DESC LIMIT 1 ", sql_con);
                sql_cmd.Parameters.AddWithValue("@status", "success");


                sql_con.Open();
                SQLiteDataReader reader = sql_cmd.ExecuteReader();
                while (reader.Read())
                {
                    var lastSync = StringUtils.ConvertFromDBVal<string>(reader["lastsynctime"]);
                    DateTime dt = Convert.ToDateTime(lastSync);
                    lastSynctimeString = String.Format("{0:yyyy-MM-ddTHH:mm:ss.000Z}", dt.AddHours(-1));
                }
            }
             
            catch (SQLiteException e) { throw e; }
            finally { sql_con.Close(); }

            return lastSynctimeString;

        }


        public void startProfileSync() {

            // below the user sync code will come
            AccessTokenDao tokenDao = new AccessTokenDao();
            RestProfileSync restSync = new RestProfileSync();

            // check when the last sync happened
            var lastSyncTime = getLastProfileSyncTime();

            // get the sync events
            ProfileSyncObject syncObj = restSync.SyncEvent(tokenDao.getAccessToken(Common.userName), lastSyncTime);


            checkProfileSyncEvents(syncObj);

        }

       private void createWitSync(String refrenceNodeId)
        {
            WitsService witService = new WitsService();
            witService.saveNewWit(refrenceNodeId); // refrenceNodeId is the wit id

        }

        private void createFolderSync(String refrenceNodeId)
        {
            FolderService folderService = new FolderService();
            folderService.saveNewFolder(refrenceNodeId); // refrenceNodeId is the folder id
        }

        private void deleteFolderSync(String refrenceNodeId)
        {
            FolderService folderService = new FolderService();
            folderService.deleteFolder(refrenceNodeId); // refrenceNodeId is the folder id
        }

        private void deleteWitSync(String refrenceNodeId)
        {
            WitsService witService = new WitsService();
            witService.deleteWit(refrenceNodeId); // refrenceNodeId is the wit id
        }


        private void checkProfileSyncEvents(ProfileSyncObject syncObj) {

            if (syncObj != null && syncObj.syncs != null && syncObj.syncs.Count > 0) {

                List<ProfileSync> syncs = syncObj.syncs;
                SyncEventCode syncCode = SyncEventCode.NULL;

                foreach (ProfileSync sync in syncs) {

                    try {
                        syncCode = ParseEnum<SyncEventCode>(sync.syncEventType);
                    } catch (System.ArgumentException eventCodeException) {

                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    switch (syncCode)
                    {
                        case SyncEventCode.WIT_CREATED:
                            createWitSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.WIT_UPDATED:
                            createWitSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.WIT_COPIED:
                            createWitSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.WIT_MOVED:
                            createWitSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.WIT_SHARED:
                            createWitSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.WIT_UNSHARED:
                            deleteWitSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.WIT_DELETED:
                            deleteWitSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.NEW_FOLDER_CREATED:
                            createFolderSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.FOLDER_DELETED:
                            deleteFolderSync(sync.refrenceNodeId);
                            break;
                      
                        case SyncEventCode.FOLDER_UPDATED:
                            createFolderSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.FOLDER_COPIED:
                            createFolderSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.FOLDER_MOVED:
                            createFolderSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.FOLDER_SHARED:
                            createFolderSync(sync.refrenceNodeId);
                            break;

                        case SyncEventCode.FOLDER_UNSHARED:
                            deleteFolderSync(sync.refrenceNodeId);
                            break;

                    }

                }

            }
   
        }


        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

    }
}
