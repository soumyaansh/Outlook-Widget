using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Exceptions
{
    class RestCallException : Exception
    {
        public RestCallException(string errorInfo, string errorDetails)
        {
            ErrorInfo = errorInfo;
            ErrorDetails = errorDetails;
        }

        public string ErrorInfo { get; private set; }

        public string ErrorDetails { get; private set; }



    }
}
