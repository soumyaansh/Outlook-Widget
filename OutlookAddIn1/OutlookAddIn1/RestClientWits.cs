using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using System.Windows.Forms;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using _OutlookAddIn1.Auth;

namespace _OutlookAddIn1
{
    class RestClientWits
    {

        public List<Wits> getFolderWits(String parentFolderId)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken();

            String url = "http://52.3.104.221:8080/wittyparrot/api/wits/folder/" + parentFolderId + "/children";
            var client = new RestClient();
            client.BaseUrl = new Uri(url);

            var request = new RestRequest();
            request.Method = Method.GET;
            request.Parameters.Clear();
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            request.RequestFormat = DataFormat.Json;

            // execute the request
            IRestResponse response = client.Execute(request);
            String content = response.Content;

            List<Wits> childWits = new List<Wits>();
            childWits = JsonConvert.DeserializeObject<List<Wits>>(content);

            return childWits;
        }

    }
}
