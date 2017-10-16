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

        List<SYS_BUSINESSGROUP> BusinessGroups();

        List<SYS_BUSINESS> Businesses(int GroupID);
        SYS_BUSINESS Business(int BusinessID);
        SYS_BUSINESS SaveBusiness(SYS_BUSINESS businesses);
        int DelBusiness(int ID);


        List<SYS_BUSINESSROLE> BusinessRoles(int BusinessID);
        SYS_BUSINESSROLE GetBusinessRole(int RoleID);
        SYS_BUSINESSROLE SaveBusinessRole(SYS_BUSINESSROLE role);
        int DelBusinessRole(int RoleId);
        
        
        List<SYS_BUSINESSMATERIAL> BusinessMaterials(int BusinessID);
        SYS_BUSINESSMATERIAL GetBusinessMaterial(int MaterialID);
        SYS_BUSINESSMATERIAL SaveBusinessMaterial(SYS_BUSINESSMATERIAL material);
        int DelBusinessMaterial(int MaterialID);


        List<SYS_BUSINESSFORM> BusinessForms(int BusinessID);
        SYS_BUSINESSFORM GetBusinessForm(int FormID);
        SYS_BUSINESSFORM SaveBusinessForm(SYS_BUSINESSFORM form);
        int DelBusinessForm(int FormID);


        List<SYS_BUSINESSPROCESS> BusinessProcesses(int BusinessID);
        SYS_BUSINESSPROCESS GetBusinessProcess(int ProcessID);
        SYS_BUSINESSPROCESS SaveBusinessProcess(SYS_BUSINESSPROCESS process);
        int DelBusinessProcess(int ProcessID);
        
        
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
