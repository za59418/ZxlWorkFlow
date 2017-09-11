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
    public class BusinessService:IBusinessService
    {
        public List<SYS_PROJECT> Projectsing(string UserId)
        {
            List<SYS_PROJECT> list = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_PROJECT>("where ID in (select ref_project_id from sys_projectworkitem where ref_user_id = " + UserId + " and state=0)");
            }
            foreach (SYS_PROJECT prj in list)
            {
                prj._parentId = prj.PID;
            }
            return list;
        }

        public List<SYS_METADATA> MetaDatas()
        {
            List<SYS_METADATA> list = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_METADATA>();
            }
            foreach (SYS_METADATA data in list)
            {
                data._parentId = -1;
            }
            return list;
        }

    }
}
