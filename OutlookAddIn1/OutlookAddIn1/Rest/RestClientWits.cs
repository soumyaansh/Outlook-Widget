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

namespace _OutlookAddIn1
{
    class RestClientWits
    {
      
        public List<Wits> getFolderWits(String parentFolderId)
        {
            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken(Common.userName);

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

        public WitsInfo getWitInfo(String witId)
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

            WitsInfo info = JsonConvert.DeserializeObject<WitsInfo>(content);
            if (info != null){return info;} return null;
        }



        public String getWitContent(string witId)
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
            if (witInfo != null) {

                String witContent = witInfo.content;
                if (witContent != null)
                {
                    return witContent;
                }

                String witType = witInfo.witType;
                // check the type of the wit if its combo then we need to call the associated
                // wits and get the content to merge it and then return the content from this method

                if (witType == WitType.COMBO.Value)
                {
                    return getCombowitContent(witInfo); // return the combined wit content
                }
            }
                   
            return null;
    
    }

        private String getCombowitContent(WitsInfo witInfo)
        {
            String content = "";

            if (witInfo.comboWit != null) {
                
                 foreach (ComboWit comboWit in witInfo.comboWit) {
                    content +=  getWitContent(comboWit.associatedWitId);
                }
            }

            return content;
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
            if (details != null && details.Count >0) {
                return details;
                }

                return null;
            }
    }
}
