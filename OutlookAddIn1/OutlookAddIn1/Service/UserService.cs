using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OutlookAddIn1
{
    class UserService
    {
        UserDao userDao = new UserDao();

        public void saveUser(RootObject rootObj)
        {     
            userDao.saveUser(rootObj);
        }


    }
}
