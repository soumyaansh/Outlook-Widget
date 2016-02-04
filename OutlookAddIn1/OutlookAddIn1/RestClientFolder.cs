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
    class RestClientFolder
    {

        public List<Folder> getAllFolders(String token, String workspaceId, Int16 level, List<Folder> allFolderList)
        {

            // used class objects defined below
            RestClientWits restWits = new RestClientWits();
            List<Folder> firstLevelFolders = new List<Folder>();
            WitsDao witsDao = new WitsDao();

            String url = "http://52.3.104.221:8080/wittyparrot/api/folders/workspaceId/"+ workspaceId + "/level/"+ level + "";
            var client = new RestClient();
            client.BaseUrl = new Uri(url);

            //var strJSONContent = "{\"workspaceId\":\"" + workspaceId + "\" ,\"level\":\"" + level + "\"}";

            var request = new RestRequest();
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + token);
            request.Parameters.Clear();
            request.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            request.RequestFormat = DataFormat.Json;

            // execute the request
            IRestResponse response = client.Execute(request);
            String content = response.Content; 

            firstLevelFolders = JsonConvert.DeserializeObject<List<Folder>>(content);
            allFolderList.AddRange(firstLevelFolders);        


                foreach (var folder in firstLevelFolders){
                if (folder.children != null)
                { 
                    // in this scenario wits wont be there in the folder
                    getChildFolders(token, folder.id, allFolderList);
                }
                else {
                    // in this scenario wits can be present in the folders
                    // query for the wits in the folder
                    List<Wits> wits  = restWits.getFolderWits(folder.id);
                    witsDao.saveAllWits(wits);
                }
                }
                return allFolderList;
        }

        public List<Folder> getChildFolders(String parentFolderId)
        {

            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken();

            String url = "http://52.3.104.221:8080/wittyparrot/api/folders/" + parentFolderId + "/children";
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

            List<Folder> childFolders = new List<Folder>();
            childFolders = JsonConvert.DeserializeObject<List<Folder>>(content);

            return childFolders;
        }

        public void getChildFolders(String token, String folderId, List<Folder> allFolderList)
        {
            String url = "http://52.3.104.221:8080/wittyparrot/api/folders/" + folderId + "/children";
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

            List<Folder> childFolders = new List<Folder>();
            childFolders = JsonConvert.DeserializeObject<List<Folder>>(content);
            allFolderList.AddRange(childFolders);

            foreach (var folder in childFolders){
                if (folder.children != null)
                {
                    getChildFolders(token, folder.id, allFolderList);
                }
            }
          
        }

        }
    }
