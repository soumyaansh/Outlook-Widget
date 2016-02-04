using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Interop;

namespace _OutlookAddIn1
{
    class PermissionDao
    {
        ISQLitePlatform sqlitePlatform ;
        String connectionUserDBPath = "Data Source=" + "C:\\Users\\WittyParrot\\AppData\\Local\\WittyParrotWidget" + "\\userDB.sqlite;Version=3;";


        public void createTable()
        {
            var db = new SQLiteConnection(sqlitePlatform, "foofoo");
            db.CreateTable<Permission>();
           

        }
    }
}
