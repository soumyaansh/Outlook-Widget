using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _OutlookAddIn1.Utilities;
using RestSharp;
using System.Windows.Forms;
using Newtonsoft.Json;
using _OutlookAddIn1.Model;
using _OutlookAddIn1.Dao;

namespace _OutlookAddIn1.Rest
{
    class RestProfileSync
    {

        public ProfileSyncObject SyncEvent(String token, String lastSyncTime) 
        {
            var maxLimit = 200;
            String currentTime = lastSyncTime;
            if (lastSyncTime == null) {
                currentTime = String.Format("{0:yyyy-MM-ddTHH:mm:ss.000Z}", DateTime.Now.AddDays(-2));
            }

            String url = "http://52.3.104.221:8080/wittyparrot/api/sync?from=" + currentTime + "&maxLimit=" + maxLimit + "";
            var client = new RestClient();
            client.BaseUrl = new Uri(url);

            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + token);
            request.Parameters.Clear();
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            request.RequestFormat = DataFormat.Json;

            // execute the request
            IRestResponse response = client.Execute(request);


            if (response.ErrorException != null || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }

            Common.lastLocalDBSyncTime = DateTime.UtcNow.ToString();

            ProfileSyncDao profileSyncDao = new ProfileSyncDao();
            profileSyncDao.saveProfileSyncTime("success");

            ProfileSyncObject syncObj = new ProfileSyncObject();
            String content = response.Content;
            syncObj = JsonConvert.DeserializeObject<ProfileSyncObject>(content);


            return syncObj;
        }


    }
}
