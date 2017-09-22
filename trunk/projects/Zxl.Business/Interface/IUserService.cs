﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Model;

namespace Zxl.Business.Interface
{
    public interface IUserService
    {
        List<ORUP_USER> Users();
        int DelUser(int UserId);
        ORUP_USER SaveUser(ORUP_USER user);
        ORUP_USER GetUser(int userId);
        ORUP_USER GetUser(string username, string password);
        ORUP_USER modifyPassword(string userId, string password);
        ORUP_USER modifyUserInfo(string userId, string name, string value);

        List<ORUP_ROLE> Roles();
        List<ORUP_USERROLE> UserRoles(int RoleID);
        int DelRole(int RoleId);
        int DelUserRole(int UserRoleId);
        ORUP_ROLE SaveRole(ORUP_ROLE role);
        ORUP_USERROLE SaveUserRole(int UserId,int RoleId);

        List<ORUP_ORGANIZATION> Orgs();
        List<ORUP_USERORGANIZATION> UserOrgs(int OrgID);
        int DelOrg(int OrgId);
        int DelUserOrg(int UserOrgId);
        ORUP_ORGANIZATION SaveOrg(ORUP_ORGANIZATION org);
        ORUP_USERORGANIZATION SaveUserOrg(int UserId, int OrgId);

    }
}
