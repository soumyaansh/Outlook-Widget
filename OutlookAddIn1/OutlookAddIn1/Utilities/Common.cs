using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OutlookAddIn1.Utilities
{
    public class Common
    {

        public static String path = "";
        public static String localProfilePath = "";
        public static String localDatabasePath = "";
        public static String userName = "";
        public static String lastLocalDBSyncTime = "";


        public static void searchAcronims(string acronymText)
        {
            MatchCollection collection = Regex.Matches(acronymText, @"[\S]+");
            MessageBox.Show(collection.ToString());
        }

       

    }
}
