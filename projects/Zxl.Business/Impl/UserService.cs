using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Interface;
using Zxl.Business.Model;
using Zxl.Data;

namespace Zxl.Business.Impl
{
    public class UserService : IUserService
    {
        public SYS_USER GetUser(string userId)
        {
            SYS_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<SYS_USER>("where ID='" + userId + "'");
            }
            return user;
        }
        public SYS_USER GetUser(string username, string password)
        {
            SYS_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<SYS_USER>("where USERNAME='" + username + "' and password='" + password + "'");
            }
            return user;
        }
    }
}
