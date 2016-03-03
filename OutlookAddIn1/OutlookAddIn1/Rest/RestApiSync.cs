using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _OutlookAddIn1.Utilities;
using RestSharp;

namespace _OutlookAddIn1.Rest
{
    class RestApiSync
    {
        String path = null;
        public RestApiSync(String path)
        {
            this.path = path;
        }

        public List<Folder> SyncEvent(String token)
        {
            var maxLimit = 200;
            var currentIme = "";
            
            RestClientWits restWits = new RestClientWits(path);
            List<Folder> firstLevelFolders = new List<Folder>();
            WitsDao witsDao = new WitsDao(path);

            String url = "http://52.3.104.221:8080/wittyparrot/api/sync?from="+ currentIme + "&maxLimit=" + maxLimit + "";
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

            if (response.ErrorException != null)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }


            return null;
        }


    }
}
