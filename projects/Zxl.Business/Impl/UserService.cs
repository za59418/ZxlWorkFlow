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
        public List<SYS_USER> Users()
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<SYS_USER>();
            }
        }
        public int DelUser(int UserId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<SYS_USER>("where ID=" + UserId);
            }
        }

        public SYS_USER SaveUser(SYS_USER user)
        {
            if (0 == user.ID)
            {
                user.ID = ValueOperator.CreatePk("SYS_USER");
            }
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(user);
                return user;
            }
        }

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
        public SYS_USER modifyPassword(string userId, string password)
        {
            SYS_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<SYS_USER>("where ID='" + userId + "'");
                user.PASSWORD = password;
                orm.Save(user);
            }
            return user;
        }
        public SYS_USER modifyUserInfo(string userId, string name, string value)
        {
            SYS_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<SYS_USER>("where ID='" + userId + "'");
                if (name == "MOBILE")
                    user.MOBILE = value;
                if (name == "PHONE")
                    user.PHONE = value;
                if (name == "EMAIL")
                    user.EMAIL = value;
                orm.Save(user);
            }
            return user;
        }

    }
}
