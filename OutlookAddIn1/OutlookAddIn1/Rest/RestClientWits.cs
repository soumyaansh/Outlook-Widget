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
using _OutlookAddIn1.Model;
using Newtonsoft.Json.Linq;

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

        public AttachmentDetail getWitsInfo(String witId)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken();

            String url = "http://52.3.104.221:8080/wittyparrot/api/wits/" + witId + "";
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

            WitsInfo witsInfo = new WitsInfo();
            dynamic jo = JObject.Parse(content);
            AttachmentDetail ad =  jo.AttachmentDetail;
            if (ad != null) {
                MessageBox.Show("ad fileId:" + ad.fileId + " ad name" + ad.fileName);
                return ad;
            }

             
            //witsInfo = JsonConvert.DeserializeObject<WitsInfo>(content);
            //if (witsInfo.attachmentDetails != null) {
            // MessageBox.Show("wits name:"+witsInfo.name + " wits Id"+ witsInfo.id);}


            return null;
        }

    }
}
