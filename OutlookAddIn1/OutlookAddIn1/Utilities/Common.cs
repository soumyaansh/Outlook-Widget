using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.Utilities
{
    public class Common
    {

        static void Main(string[] args)
        {

            String str = " hello how are you [Name] ?";
            searchAcronims(str);

        }

        public static void searchAcronims(string acronymText)
        {
            MatchCollection collection = Regex.Matches(acronymText, @"[\S]+");
            MessageBox.Show(collection.ToString());
        }

    }
}
