using System;
using System.Collections.Generic;
using System.IO;
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

        public static List<string> searchAcronyms(string acronymText) {

           
            // pattern for getting the acronym text out of a string
            var pattern1 = @"\[(.*?)\]";         
            MatchCollection matchCollection1 = Regex.Matches(acronymText, pattern1);

            var pattern2 = @"\<(.*?)\>";
            MatchCollection matchCollection2 = Regex.Matches(acronymText, pattern2);

            List<string> matches1 = matchCollection1.Cast<Match>().Select(m => m.Value).Distinct().ToList();       
            List<string> matches2 = matchCollection1.Cast<Match>().Select(m => m.Value).Distinct().ToList();
            matches2 = matches1.ToList();

            return matches2.Distinct().ToList();
        }

           
    }
}
