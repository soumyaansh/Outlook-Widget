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
using System.IO;
using _OutlookAddIn1.Utilities;

namespace _OutlookAddIn1
{
    class RestClientWits
    {

        String path = null;
        public RestClientWits(String path)
        {
            this.path = path;
        }

        public List<Wits> getFolderWits(String parentFolderId)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao(path);
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

            if (response.ErrorException != null)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }

            List<Wits> childWits = new List<Wits>();
            childWits = JsonConvert.DeserializeObject<List<Wits>>(content);

            // loop through the wits and create wits 
            if (childWits.Count > 0)
            {

                foreach (var wit in childWits)
                {
                    String witContent = getWitContent(wit.id);
                    if (witContent != null)
                    {
                        wit.content = witContent;
                    }
                }
            }

            return childWits;
        }

        private String getWitContent(string witId)
        {

            AccessTokenDao accesstokenDao = new AccessTokenDao(path);
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

            if (response.ErrorException != null)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                //MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }

            WitsInfo witsInfo = new WitsInfo();
            WitsInfo ad = JsonConvert.DeserializeObject<WitsInfo>(content);
            //dynamic jo = JObject.Parse(content);
            String witType = ad.witType;
            String witName = ad.name;
            String witContent = ad.content;


            if (witContent != null)
            {
                return witContent;
            }

            return null;
    
    }

    public void getAttachment(String witId, String fileAssociationId, String fileName, String userProfilepath)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao(path);
            String token = accesstokenDao.getAccessToken();

            String url = "http://52.3.104.221:8080/wittyparrot/api/attachments/associationId/" + fileAssociationId + "";
            var client = new RestClient();
            client.BaseUrl = new Uri(url);

            var request = new RestRequest();
            request.Method = Method.GET;
            request.Parameters.Clear();
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            request.RequestFormat = DataFormat.Json;

            // execute the request
            IRestResponse response = client.Execute(request);
            if (response.ErrorException != null)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                //MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }

            byte[] r = client.DownloadData(request);
            String fullPath = userProfilepath + "//files//attachments//";
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            // save the file details to docs table
            Docs doc = new Docs();
            doc.docId = fileName.GetHashCode().ToString();
            doc.localPath = fullPath;
            doc.fileName = fileName;
            doc.witId = witId;


            WitsDao witDao = new WitsDao(userProfilepath);
            witDao.saveDocs(doc);

            File.WriteAllBytes(fullPath + fileName, r);
        }

    

    public List<AttachmentDetail> getWitsInfo(String witId)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao(path);
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

            if (response.ErrorException != null)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                //MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }

            WitsInfo witsInfo = new WitsInfo();
            WitsInfo ad = JsonConvert.DeserializeObject<WitsInfo>(content);
            //dynamic jo = JObject.Parse(content);
            String witType  = ad.witType;
            String witName = ad.name;
            if (witName == "My first sync test") {

                MessageBox.Show("check attachment nmbers");
            }
            List<AttachmentDetail> details = (List<AttachmentDetail>)ad.attachmentDetails;
            if (details != null) {
                return details;
                }

                return null;
            }
    }
}
