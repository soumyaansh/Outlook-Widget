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
using _OutlookAddIn1.Model;

namespace _OutlookAddIn1.Rest
{
    class RestClientSearch
    {

        public SearchOutputJson advanceSearch(SearchInputJson inputJson)
        {

            AccessTokenDao accesstokenDao = new AccessTokenDao();
            String token = accesstokenDao.getAccessToken(Common.userName);

            var client = new RestClient("http://52.3.104.221:8080/wittyparrot/api/search");
            var jsonInputString = prepareInputJson(inputJson);

            var request = new RestRequest();
            request.Method = Method.POST;
            //request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", jsonInputString, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            // execute the request
            IRestResponse response = client.Execute(request);
            if (response.ErrorException != null || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                MessageBox.Show(statusMessage == "" ? response.StatusDescription : statusMessage);
                var myException = new ApplicationException(response.StatusDescription, response.ErrorException);
                throw myException;
            }

            var content = response.Content;
            SearchOutputJson outputJson = new SearchOutputJson();
            outputJson = JsonConvert.DeserializeObject<SearchOutputJson>(content);
            return outputJson;

        }


        private String prepareInputJson(SearchInputJson inputJson)
        {      
            return JsonConvert.SerializeObject(inputJson);
        }
    }
}
