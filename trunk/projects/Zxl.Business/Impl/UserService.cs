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
        #region User
        public List<ORUP_USER> Users()
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<ORUP_USER>();
            }
        }
        public int DelUser(int UserId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<ORUP_USER>("where ID=" + UserId);
            }
        }

        public ORUP_USER SaveUser(ORUP_USER user)
        {
            if (0 == user.ID)
            {
                user.ID = ValueOperator.CreatePk("ORUP_USER");
            }
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(user);
                return user;
            }
        }

        public ORUP_USER GetUser(int userId)
        {
            ORUP_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<ORUP_USER>("where ID=" + userId);
            }
            return user;
        }
        public ORUP_USER GetUser(string username, string password)
        {
            ORUP_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<ORUP_USER>("where USERNAME='" + username + "' and password='" + password + "'");
            }
            return user;
        }
        public ORUP_USER modifyPassword(string userId, string password)
        {
            ORUP_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<ORUP_USER>("where ID='" + userId + "'");
                user.PASSWORD = password;
                orm.Save(user);
            }
            return user;
        }
        public ORUP_USER modifyUserInfo(string userId, string name, string value)
        {
            ORUP_USER user = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<ORUP_USER>("where ID='" + userId + "'");
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
        #endregion User

        #region Role
        public List<ORUP_ROLE> Roles()
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<ORUP_ROLE>();
            }
        }
        public ORUP_ROLE GetRole(int RoleID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Init<ORUP_ROLE>("where ID=" + RoleID);
            }
        }
        public List<ORUP_USERROLE> GetUserRolesByRoleID(int RoleID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<ORUP_USERROLE>("where RoleID=" + RoleID);
            }
        }
        public List<ORUP_USERROLE> GetUserRolesByUserID(int UserID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<ORUP_USERROLE>("where UserID=" + UserID);
            }
        }
        public int DelRole(int RoleId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<ORUP_ROLE>("where ID=" + RoleId);
            }
        }
        public int DelUserRole(int UserRoleId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<ORUP_USERROLE>("where ID=" + UserRoleId);
            }

        }
        public ORUP_ROLE SaveRole(ORUP_ROLE role)
        {
            if (0 == role.ID)
            {
                role.ID = ValueOperator.CreatePk("ORUP_ROLE");
            }
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(role);
                return role;
            }
        }
        public ORUP_USERROLE SaveUserRole(int UserId, int RoleId)
        {
            ORUP_USERROLE ur = new ORUP_USERROLE();
            ur.ID = ValueOperator.CreatePk("ORUP_USERROLE");
            ur.UserID = UserId;
            ur.RoleID = RoleId;

            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(ur);
                return ur;
            }
        }

        #endregion Role

        #region Organization
        public List<ORUP_ORGANIZATION> Orgs()
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<ORUP_ORGANIZATION>();
            }
        }
        public ORUP_ORGANIZATION GetOrganization(int OrgID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Init<ORUP_ORGANIZATION>("where ID=" + OrgID);
            }
        }
        public List<ORUP_USERORGANIZATION> GetUserOrgsByOrgID(int OrgID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<ORUP_USERORGANIZATION>("where OrganizationID=" + OrgID);
            }
        }
        public List<ORUP_USERORGANIZATION> GetUserOrgsByUserID(int UserID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<ORUP_USERORGANIZATION>("where UserID=" + UserID);
            }
        }
        public ORUP_ORGANIZATION SaveOrg(ORUP_ORGANIZATION org)
        {
            if (0 == org.ID)
            {
                org.ID = ValueOperator.CreatePk("ORUP_ROLE");
            }
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(org);
                return org;
            }
        }
        public int DelOrg(int OrgId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<ORUP_ORGANIZATION>("where ID=" + OrgId);
            }
        }
        public int DelUserOrg(int UserOrgId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<ORUP_ORGANIZATION>("where ID=" + UserOrgId);
            }
        }
        public ORUP_USERORGANIZATION SaveUserOrg(int UserId, int OrgId)
        {
            ORUP_USERORGANIZATION uo = new ORUP_USERORGANIZATION();
            uo.ID = ValueOperator.CreatePk("ORUP_USERORGANIZATION");
            uo.USERID = UserId;
            uo.ORGANIZATIONID = OrgId;

            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(uo);
                return uo;
            }
        }
        #endregion

    }
}
