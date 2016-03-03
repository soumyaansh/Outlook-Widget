using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _OutlookAddIn1.Utilities
{
    class UserRegistry
    {

        public void createRegistry() {

            RegistryKey key;
            key = Registry.CurrentUser.CreateSubKey("SAM ADDIN");
            key.SetValue("Name", "Soumyaansh");
            key.Close();

        }


        public void createFolder()
        {

            Microsoft.Win32.RegistryKey subKey =
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office");

            if (checkIfKeyExists(subKey))
            {
                subKey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\Outlook");

                // check if the Outlook folder is already there
                // if not then create it
                if (!checkIfKeyExists(subKey))
                {
                    subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Office\\Outlook");
                }
                

                subKey =
               Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\Addins");
                // check if the Addins folder is already there
                // if not then create it
                if (!checkIfKeyExists(subKey))
                {
                    subKey =  Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Office\\Outlook\\Addins");
                }
                
                subKey =
                      Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\OutlookAddIn2");

                // check if the project folder is already there
                // if not then create it
                if (!checkIfKeyExists(subKey))
                {
                    subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\OutlookAddIn2");
                }
                

                subKey.SetValue("Description", "OutlookAddIn1");
                subKey.SetValue("FriendlyName", "OutlookAddIn1");
                subKey.SetValue("Name", "Soumyaansh");
                subKey.Close();

            }
        }

            private static bool checkIfKeyExists(Microsoft.Win32.RegistryKey subKey)
        {
            bool status = true;
            if (subKey == null)
            {
                status = false;
            }
            return status;
        }

    }
}
