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
using _OutlookAddIn1.Dao;


namespace _OutlookAddIn1.Rest
{
    class RestClientAttachment
    {

        // download all the attachments of a wit to the local folders
        public void getAttachment(String witId, String fileAssociationId, String fileName, String userProfilepath)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken(Common.userName);

            String url = Resource.endpoint + "wittyparrot/api/attachments/associationId/" + fileAssociationId + "";
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
                MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
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


            AttachmentDao attachmentDao = new AttachmentDao();
            attachmentDao.saveDocs(doc);

            File.WriteAllBytes(fullPath + fileName, r);
        }


    public List<AttachmentDetail> getWitsInfo(String witId)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken(Common.userName);

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
                MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }


            WitsInfo witInfo = JsonConvert.DeserializeObject<WitsInfo>(content);
            List<AttachmentDetail> details = (List<AttachmentDetail>)witInfo.attachmentDetails;
            if (details != null && details.Count > 0)
            {
                return details;
            }

            return null;
        }
    }


   
}
