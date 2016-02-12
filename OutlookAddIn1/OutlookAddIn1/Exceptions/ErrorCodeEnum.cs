using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1.Exceptions
{
    public enum ErrorCodeEnum : uint
    {
        [Description("Bad Request")]
        OK,
        [Description("Invalid Username and Password combination. ")]
        BadRequest
    }

    
}
