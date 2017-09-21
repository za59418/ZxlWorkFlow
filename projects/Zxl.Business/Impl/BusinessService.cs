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
    public class BusinessService : IBusinessService
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

        public SYS_METADATA MetaData(int MetaDataID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Init<SYS_METADATA>("where ID=" + MetaDataID);
            }
        }

        public List<SYS_METADATADETAIL> MetaDataDetails(int MetaDataID)
        {
            List<SYS_METADATADETAIL> list = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_METADATADETAIL>("where REF_METADATA_ID=" + MetaDataID);
            }
            return list;
        }

        public SYS_METADATADETAIL SaveMetaDataDetail(SYS_METADATADETAIL obj)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(obj);
            }
            return obj;
        }

        public int DelMetaDataDetail(int ID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<SYS_METADATADETAIL>("where ID=" + ID);
            }
        }

        public List<SYS_BUSINESSDATA> BusinessDatas()
        {
            List<SYS_BUSINESSDATA> list = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_BUSINESSDATA>();
            }
            foreach (SYS_BUSINESSDATA data in list)
            {
                data._parentId = -1;
            }
            return list;
        }

        public List<SYS_BUSINESSDATADETAIL> BusinessDataDetails(int BusinessDataID, int ParentID)
        {
            List<SYS_BUSINESSDATADETAIL> list = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                string whereClause = "where ParentID=" + ParentID;
                if (ParentID == 0)
                {
                    whereClause += " and REF_BUSINESSDATA_ID=" + BusinessDataID;
                }
                list = orm.Query<SYS_BUSINESSDATADETAIL>(whereClause);
            }
            return list;
        }



        public SYS_BUSINESSDATADETAIL BusinessDataDetail(int BusinessDataID, int MetaDataID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Init<SYS_BUSINESSDATADETAIL>("where REF_BUSINESSDATA_ID=" + BusinessDataID + " and REF_METADATA_ID=" + MetaDataID);
            }
        }

        public int DelBusinessData(int ID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                // 先删详情
                List<SYS_BUSINESSDATADETAIL> details = orm.Query<SYS_BUSINESSDATADETAIL>("where ref_businessdata_id=" + ID);
                foreach (SYS_BUSINESSDATADETAIL detail in details)
                {
                    orm.Delete<SYS_BUSINESSDATADETAIL>("where ID=" + detail.ID);
                }
                //再删业务数据
                return orm.Delete<SYS_BUSINESSDATA>("where ID=" + ID);
            }
        }

        public SYS_BUSINESSDATA AddBusinessData(string Name, string Description)
        {
            SYS_BUSINESSDATA result = new SYS_BUSINESSDATA();
            result.ID = ValueOperator.CreatePk("SYS_BUSINESSDATA");
            result.NAME = Name;
            result.DESCRIPTION = Description;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(result);
            }
            return result;
        }

        public SYS_BUSINESSDATA EditBusinessData(int Id, string Name, string Description)
        {
            SYS_BUSINESSDATA result = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                result = orm.Init<SYS_BUSINESSDATA>("where ID=" + Id);
                result.NAME = Name;
                result.DESCRIPTION = Description;
                orm.Update(result);
            }
            return result;
        }

        public SYS_BUSINESSDATADETAIL AddBusinessDataDetail(int REF_BUSINESSDATA_ID, int REF_METADATA_ID, int PARENTID)
        {
            SYS_BUSINESSDATADETAIL result = new SYS_BUSINESSDATADETAIL();
            result.ID = ValueOperator.CreatePk("SYS_BUSINESSDATADETAIL");
            result.REF_BUSINESSDATA_ID = REF_BUSINESSDATA_ID;
            result.REF_METADATA_ID = REF_METADATA_ID;
            result.PARENTID = PARENTID;

            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(result);
            }
            return result;
        }

        public int DelBusinessDataDetail(int ID)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<SYS_BUSINESSDATADETAIL>("where ID=" + ID);
            }
        }

    }
}
