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

            IRestResponse response = null;
            var client = new RestClient("http://52.3.104.221:8080/wittyparrot/api/auth/login");
            var strJSONContent = "{\"userId\":\"" + username + "\" ,\"password\":\"" + password + "\"}";
            
            var request = new RestRequest();
            request.Method = Method.POST;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            
                // execute the request
                response = client.Execute(request);
                if (response.StatusCode.ToString() != "OK") {

                    var statusMessage = RestUtils.getErrorMessage(response.StatusCode);
                    MessageBox.Show(statusMessage ==""? "error occured" : statusMessage);
                    throw new RestCallException(statusMessage == null ? "" : statusMessage, response.ErrorMessage == null ? "" : response.ErrorMessage);
                }
            
            var content = response.Content;

            RootObject rootObj = new RootObject();
            rootObj = JsonConvert.DeserializeObject<RootObject>(content);
            return rootObj;
        }

    }
}
