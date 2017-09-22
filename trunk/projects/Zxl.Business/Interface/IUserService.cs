using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Model;

namespace Zxl.Business.Interface
{
    public interface IUserService
    {
        List<SYS_USER> Users();
        int DelUser(int UserId);
        SYS_USER SaveUser(SYS_USER user);
        SYS_USER GetUser(string userId);
        SYS_USER GetUser(string username,string password);
        SYS_USER modifyPassword(string userId, string password);
        SYS_USER modifyUserInfo(string userId, string name, string value);
    }
}
