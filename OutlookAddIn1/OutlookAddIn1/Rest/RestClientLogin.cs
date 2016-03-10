using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Windows.Forms;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using _OutlookAddIn1.Utilities;
using _OutlookAddIn1.Exceptions;

namespace _OutlookAddIn1
{
    class RestClientLogin
    {
        public RootObject login(String username, String password)
        {

            if (username == null || username.Trim().Length == 0 || password == null || password.Trim().Length == 0)
            {
                MessageBox.Show("invalid User credentials");
            }

           
            var client = new RestClient(Resource.endpoint + "wittyparrot/api/auth/login");
            var strJSONContent = "{\"userId\":\"" + username + "\" ,\"password\":\"" + password + "\"}";
            
            var request = new RestRequest();
            request.Method = Method.POST;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);
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
            RootObject rootObj = new RootObject();
            rootObj = JsonConvert.DeserializeObject<RootObject>(content);
            return rootObj;
        }

    }
}
