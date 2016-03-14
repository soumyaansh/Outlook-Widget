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
using _OutlookAddIn1.Utilities;
using System.Threading;

namespace _OutlookAddIn1
{
    class RestClientFolder
    {

            public Folder getFolderDetails(String folderId)
        {

            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken(Common.userName);

            String url = Resource.endpoint + "wittyparrot/api/folders/" + folderId + "";
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

           
           Folder  folderDetails = JsonConvert.DeserializeObject<Folder>(content);
           return folderDetails;

        } 

        // This method fetches only the first level folders , and further calls the child folders of the
        // first level folders
        public void getAllFolders(String token, String workspaceId,int level)
        {

            // used class objects defined below
           
            List<Folder> firstLevelFolders = new List<Folder>();
          

            String url = Resource.endpoint + "wittyparrot/api/folders/workspaceId/" + workspaceId + "/level/" + level + "";
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
            if (response.ErrorException != null)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }

            // This method pulls the first level folder
            firstLevelFolders = JsonConvert.DeserializeObject<List<Folder>>(content);
            if (firstLevelFolders != null && firstLevelFolders.Count > 0)
            {
                // save the folders into db

                FolderDao folderDao = new FolderDao();
                folderDao.saveAllFolders(firstLevelFolders);

                foreach (var folder in firstLevelFolders)
                {

                    if (folder.hasChildren == false)
                    {
                        // in this scenario child folders wont be present 
                        // query for the wits in the folder
                        // Implimenting thread to improve the performance
                        
                        Thread thread = new Thread(() => getFolderWitsThread(folder));
                        thread.Start();

                    }
                    else if (folder.hasChildren == true)
                    {
                        // in this scenario child folders will be there                 
                        getChildFolders(token, folder.id,1);


                        // Implimenting thread to improve the performance
                        Thread thread = new Thread(() => getFolderWitsThread(folder));
                        thread.Start();
                    }
                }

            }         
        }


        // Fetch all the wits of the folder
        private void getFolderWitsThread(Folder folder)
        {
            RestClientWits restWits = new RestClientWits();
            WitsDao witsDao = new WitsDao();


            List<Wits> wits = restWits.getFolderWits(folder.id);
            if (wits != null && wits.Count > 0)
            {
                witsDao.saveAllWits(wits);
            }

        }

        
        // This method will fetch all the child folders of the parent folder
        public void getChildFolders(String token, String folderId,int level)
        {
            String url = Resource.endpoint + "wittyparrot/api/folders/" + folderId + "/hierarchy/level/" + level ;
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

            
            Folder parentfolder = JsonConvert.DeserializeObject<Folder>(content);
            List<Folder> childFolders = parentfolder.children;
            if (childFolders != null && childFolders.Count > 0)
            {
                foreach (var folder in childFolders)
                {
                    // save the folders into db

                    FolderDao folderDao = new FolderDao();
                    folderDao.saveFolder(folder);

                    WitsDao witsDao = new WitsDao();
                    RestClientWits restWits = new RestClientWits();


                    List<Wits> wits = restWits.getFolderWits(folder.id);
                    if (wits != null && wits.Count > 0)
                    {
                        witsDao.saveAllWits(wits);
                    }


                  
                    if (folder.hasChildren != null && folder.hasChildren == true)
                    {
                        // This is a self loop code where it check if a folder is having child folders
                        // loop itself get all the child folders and the wits of that folder
                        getChildFolders(token, folder.id, level);
                    }

                }
            }


        }

        // not implemented/used
        public List<Folder> getChildFolders(String parentFolderId)
        {

            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken(Common.userName);

            String url = Resource.endpoint + "wittyparrot/api/folders/" + parentFolderId + "/children";
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

            List<Folder> childFolders = new List<Folder>();
            childFolders = JsonConvert.DeserializeObject<List<Folder>>(content);
            if (childFolders != null && childFolders.Count > 0)
            {
                // all the code comes under this code
            }
                return childFolders;
        }

    }



    }
