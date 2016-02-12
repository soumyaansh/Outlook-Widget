﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    class StringUtils
    {
        public static bool isNullOrEmpty(string s)
        {
            if (String.IsNullOrEmpty(s))
                return true;
            else
                return false;
        }

        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }

        public static MatchCollection searchAcronyms(string acronymText) {

           
            // pattern for getting the acronym text out of a string
            var pattern = @"\[(.*?)\]";
            var matches = Regex.Matches(acronymText, pattern);

            return matches;
        }

    }
}
