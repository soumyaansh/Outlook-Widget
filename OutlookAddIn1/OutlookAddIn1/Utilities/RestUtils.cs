using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace _OutlookAddIn1.Utilities
{
    class RestUtils
    {

        public static String getErrorMessage(HttpStatusCode status) {

            var statusCode = "ERROR_" + status.ToString();
            var statusCodeMessage = Resource.ResourceManager.GetString(statusCode);
            if (!StringUtils.isNullOrEmpty(statusCodeMessage)) {

                return statusCodeMessage;
            }

            return "";
        }
    }
}
