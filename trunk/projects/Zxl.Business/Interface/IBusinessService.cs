using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Model;

namespace Zxl.Business.Interface
{
    public interface IBusinessService
    {
        List<SYS_PROJECT> Projectsing(string UserId);
        List<SYS_METADATA> MetaDatas();
        SYS_METADATA MetaData(int MetaDataID);
        SYS_METADATA AddMetaData(string Name, string Description);
        SYS_METADATA EditMetaData(int Id, string Name, string Description);
        int DelMetaData(int ID);
        List<SYS_METADATADETAIL> MetaDataDetails(int MetaDataID);
        SYS_METADATADETAIL SaveMetaDataDetail(SYS_METADATADETAIL obj);
        int DelMetaDataDetail(int ID);

        List<SYS_BUSINESSDATA> BusinessDatas();
        List<SYS_BUSINESSDATADETAIL> BusinessDataDetails(int BusinessDataID, int ParentID);
        SYS_BUSINESSDATADETAIL BusinessDataDetail(int BusinessDataID, int MetaDataID);
        int DelBusinessData(int ID);
        SYS_BUSINESSDATA AddBusinessData(string Name, string Description);
        SYS_BUSINESSDATA EditBusinessData(int Id, string Name, string Description);
        SYS_BUSINESSDATADETAIL AddBusinessDataDetail(int REF_BUSINESSDATA_ID, int REF_METADATA_ID, int PARENTID);
        int DelBusinessDataDetail(int ID);
    }
}
