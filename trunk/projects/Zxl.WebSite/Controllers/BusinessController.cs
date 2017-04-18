using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using Zxl.Data;
using Zxl.WebSite.Model;
using Zxl.WebSite.ModelView;
using Zxl.Printer;

namespace Zxl.WebSite.Controllers
{
    public class BusinessController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Projects()
        {
            List<SYS_PROJECT> list = null;
            string UserId = Session["UserId"].ToString();
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_PROJECT>("where ID in (select ref_project_id from sys_projectworkitem where ref_user_id = " + UserId + " and state=0)");
            }
            foreach (SYS_PROJECT prj in list)
            {
                prj._parentId = prj.PID;
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(new { rows = list }));
            System.Web.HttpContext.Current.Response.End();
            return Json(new { rows = list });
        }

        public ActionResult Project(int ProjectId)
        {
            return View(ProjectId);
        }

        public ActionResult ProjectForm(int ProjectId)
        {
            return View(ProjectId);
        }

        public ActionResult Form(int ProjectFormId)
        {
            return View(ProjectFormId);
        }

        public ActionResult BuildForm(int ProjectFormId)
        {
            SYS_PROJECTFORM prjForm = null;
            SYS_BUSINESSFORM businessForm = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                prjForm = orm.Init<SYS_PROJECTFORM>("where ID=" + ProjectFormId);
                businessForm = orm.Init<SYS_BUSINESSFORM>("where ID=" + prjForm.REF_BUSINESSFORM_ID);
            }
            StringBuilder result = new StringBuilder();
            string content = System.Text.Encoding.Default.GetString(businessForm.CONTENT);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);

            XmlNode controlNode = doc.SelectNodes("Form/Control").Item(0);
            string formWidth = controlNode.Attributes["width"].Value;
            string formHeight = controlNode.Attributes["height"].Value;
            result.Append("<div id='form-" + ProjectFormId + "' style='position:relative; margin:0 auto;margin-top:20px;margin-bottom:20px; width:" + formWidth + "px; height:" + formHeight + "px;background:white;'>");
            foreach(XmlNode node in controlNode.ChildNodes)
            {
                string NodeType = node.Name;
                string id = node.Attributes["id"].Value;
                string name = node.Attributes["name"].Value;
                string x = node.Attributes["x"].Value;
                string y = node.Attributes["y"].Value;
                string width = node.Attributes["width"].Value;
                string height = node.Attributes["height"].Value;
                string readonlyT = node.Attributes["readonly"].Value;
                string isprint = node.Attributes["isprint"].Value;
                string text = null;
                if (null != node.Attributes["text"])
                    text = node.Attributes["text"].Value;

                string temp = "";
                switch (NodeType)
                {
                    case "Label":
                        temp = "<span id='" + id + "' style='position: absolute;left:" + x + "px;top:" + y + "px;width:" + width + "px;height:" + height + "px' >" + text + "</span>";
                        break;
                    case "TextBox":
                        temp = "<input type='text' id='" + id + "' style='position: absolute;left:" + x + "px;top:" + y + "px;width:" + width + "px;height:" + height + "px' />";
                        break;
                    case "ComboBox":
                        temp = "<select id='" + id + "' style='position: absolute;left:" + x + "px;top:" + y + "px;width:" + width + "px;height:" + height + "px' >" + "</select>";
                        break;
                    case "RadioButtonList":
                        temp = "<input type='radio' id='" + id + "' style='position: absolute;left:" + x + "px;top:" + y + "px;width:" + width + "px;height:" + height + "px' />";
                        break;
                    default:
                        break;
                }
                result.Append(temp);                
            }
            result.Append("</div>");         
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write( result.ToString() );
            System.Web.HttpContext.Current.Response.End();
            return Content(result.ToString());
        }

        public ActionResult GetForms(int ProjectId)
        {
            List<SYS_PROJECTFORM> list = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_PROJECTFORM>("where ref_project_id='" + ProjectId + "'");
            }
            SYS_PROJECTFORM root = null;
            if (null != list && list.Count > 0)
            {
                root = new SYS_PROJECTFORM();
                root.children = new List<AbstractModel>();
                root.id = 1;
                root.pid = 0;
                root.text = "表单列表";

                foreach (SYS_PROJECTFORM form in list)
                {
                    form.id = form.ID;
                    form.pid = 1;
                    form.text = form.FORMNAME;
                    root.children.Add(form);
                }
            }

            List<SYS_PROJECTFORM> result = new List<SYS_PROJECTFORM>();
            result.Add(root);

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(result));
            System.Web.HttpContext.Current.Response.End();
            return Json(result);
        }

        #region 材料
        public ActionResult ProjectMaterial(int ProjectId)
        {
            return View(ProjectId);
        }

        public ActionResult GetMaterials(int ProjectId)
        {

            List<SYS_BUSINESSMATERIAL> result = null;
            List<SYS_PROJECTMATERIAL> projectMaterials = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                SYS_PROJECT prj = orm.Init<SYS_PROJECT>("where id='" + ProjectId + "'");

                result = orm.Query<SYS_BUSINESSMATERIAL>("where ref_business_id='" + prj.REF_BUSINESS_ID + "'");

                projectMaterials = orm.Query<SYS_PROJECTMATERIAL>("where ref_project_id='" + ProjectId + "'");
            }

            foreach (SYS_BUSINESSMATERIAL tem in result)
            {
                tem.id = tem.ID;
                tem.pid = 0;
                tem.text = tem.MATERIALNAME;
                tem.iconCls = "icon-folder";

                tem.children = new List<AbstractModel>();
                foreach (SYS_PROJECTMATERIAL projectMaterial in projectMaterials)
                {
                    if (tem.id == projectMaterial.REF_BUSINESSMATERIAL_ID)
                    {
                        projectMaterial.id = projectMaterial.ID;// +10;
                        projectMaterial.pid = tem.id;
                        projectMaterial.text = projectMaterial.MATERIALNAME;

                        switch (projectMaterial.MATERIALNAME.Substring(projectMaterial.MATERIALNAME.LastIndexOf(".") + 1).ToLower())
                        {
                            case "doc":
                            case "docx":
                                projectMaterial.iconCls = "icon-page-white-word";
                                break;
                            case "xls":
                            case "xlsx":
                                projectMaterial.iconCls = "icon-page-white-excel";
                                break;
                            case "ppt":
                            case "pptx":
                                projectMaterial.iconCls = "icon-page-white-powerpoint";
                                break;
                            case "jpg":
                            case "jpeg":
                            case "bmp":
                            case "png":
                            case "gif":
                                projectMaterial.iconCls = "icon-page-white-picture";
                                break;
                            default:
                                break;
                        }

                        tem.children.Add(projectMaterial);
                    }
                }
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(result));
            System.Web.HttpContext.Current.Response.End();
            return Json(result);
        }

        [System.Web.Http.HttpPost]
        [ValidateInput(false)]
        public ActionResult UploadMaterial() // int ProjectId, int BusinessMaterialId, string MaterialName, string FileSize)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                int ProjectId = Convert.ToInt32(Request.Form["ProjectId"].ToString());
                int BusinessMaterialId = Convert.ToInt32(Request.Form["BusinessMaterialId"].ToString());
                string MaterialName = Request.Form["MaterialName"].ToString();
                string FileSize = Request.Form["FileSize"].ToString();

                string uploadRoot = null;
                string downloadRoot = null;
                using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                {
                    SYS_SYSTEMCONFIG uploadConfig = orm.Init<SYS_SYSTEMCONFIG>("where KEY='UploadFile'");
                    uploadRoot = uploadConfig.VALUE;
                    SYS_SYSTEMCONFIG downloadConfig = orm.Init<SYS_SYSTEMCONFIG>("where KEY='DownloadFile'");
                    downloadRoot = downloadConfig.VALUE;
                    orm.Close();
                }

                string uploadPath = null;
                string pdfPath = null;
                string viewPath = null;
                if (files.Count > 0)
                {
                    HttpPostedFile file = files[0];
                    string fileDir = uploadRoot + ProjectId + "/" + BusinessMaterialId + "/";
                    string pdfDir = uploadRoot + ProjectId + "_Pdf/" + BusinessMaterialId + "/";
                    if (!Directory.Exists(fileDir))
                        Directory.CreateDirectory(fileDir);
                    if (!Directory.Exists(pdfDir))
                        Directory.CreateDirectory(pdfDir);

                    uploadPath = System.IO.Path.Combine(fileDir, System.IO.Path.GetFileName(file.FileName));
                    file.SaveAs(uploadPath);

                    //转PDF
                    try
                    {
                        pdfPath = System.IO.Path.Combine(pdfDir, System.IO.Path.GetFileName(file.FileName));
                        FileInfo fileInfo = new FileInfo(pdfPath);
                        pdfPath = pdfDir + fileInfo.Name.Replace(fileInfo.Extension, "") + fileInfo.Extension.Replace(".", "_") + ".pdf";
                        GHPrinter.Instance.ConvertToPdf(uploadPath, pdfPath);
                        viewPath = downloadRoot + ProjectId + "_Pdf/" + BusinessMaterialId + "/" + fileInfo.Name.Replace(fileInfo.Extension, "") + fileInfo.Extension.Replace(".", "_") + ".pdf";
                    }
                    catch(Exception e)
                    {
                        viewPath = downloadRoot + ProjectId + "/" + BusinessMaterialId + "/" + System.IO.Path.GetFileName(file.FileName);
                        result.ReturnCode = ServiceResultCode.Error;
                        result.Message = e.Message;
                        return Json(result);
                    }
                    
                }

                using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                {
                    SYS_PROJECTMATERIAL material = new SYS_PROJECTMATERIAL();
                    material.ID = ValueOperator.CreatePk("SYS_PROJECTMATERIAL");
                    material.REF_PROJECT_ID = ProjectId;
                    material.REF_BUSINESSMATERIAL_ID = BusinessMaterialId;
                    material.CREATETIME = DateTime.Now;
                    material.MATERIALNAME = MaterialName;
                    material.FILEPATH = viewPath;
                    material.FILESIZE = FileSize;
                    material.CREATEUSER = Convert.ToInt32(Session["UserId"].ToString());
                    orm.Insert(material);
                    orm.Close();
                    result.ReturnCode = ServiceResultCode.Success;
                }
            }
            catch (Exception e)
            {
                result.ReturnCode = ServiceResultCode.Success;
                result.Message = e.Message;
            }
            return Json(result);
        }

        public ActionResult DeleteMaterial(string MaterialId)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                {
                    SYS_PROJECTMATERIAL material = orm.Init<SYS_PROJECTMATERIAL>("where ID=" + MaterialId);
                    if (null != material)
                    {
                        string path = material.FILEPATH;
                        if(System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }
                    material.Delete();
                    orm.Close();
                    result.ReturnCode = ServiceResultCode.Success;
                }
            }
            catch (Exception e)
            {
                result.ReturnCode = ServiceResultCode.Success;
                result.Message = e.Message;
            }
            return Json(result);
        }
        public ActionResult ViewMaterial(string MaterialId)
        {
            SYS_PROJECTMATERIAL material = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                material = orm.Init<SYS_PROJECTMATERIAL>("where ID=" + MaterialId);
                orm.Close();
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(material));
            System.Web.HttpContext.Current.Response.End();
            return Json(material);
        }
        #endregion 材料
        public ActionResult Dialog_SendUser(int ProjectId)
        {
            return View("Dialog/Dialog_SendUser", ProjectId);
        }

        public ActionResult Dialog_Business()
        {
            return View("Dialog/Dialog_Business");
        }

        public ActionResult DoNewProject(int BusinessId)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                {
                    orm.BeginTransaction();
                    SYS_PROJECT prj = new SYS_PROJECT();
                    prj.ID = ValueOperator.CreatePk("SYS_PROJECT");
                    prj.REF_BUSINESS_ID = BusinessId;
                    prj.PROJECTNO = ValueOperator.CreateNo("SYS_PROJECT", prj.ID + "");
                    prj.PROJECTNAME = prj.PROJECTNO; // 给个初使值
                    prj.CREATETIME = DateTime.Now;
                    prj.ISDELETE = 0;
                    orm.Insert(prj);

                    SYS_PROJECTPROCESS prjPro = new SYS_PROJECTPROCESS();
                    prjPro.ID = ValueOperator.CreatePk("SYS_PROJECTPROCESS");
                    prjPro.REF_BUSINESSPROCESS_ID = orm.Init<SYS_BUSINESSPROCESS>("where REF_BUSINESS_ID=" + BusinessId).ID;
                    prjPro.REF_PROJECT_ID = prj.ID;
                    prjPro.REF_USER_ID = Convert.ToInt32(Session["UserId"].ToString());
                    prjPro.CREATETIME = DateTime.Now;
                    orm.Insert(prjPro);

                    SYS_PROJECTACTIVITY prjAct = new SYS_PROJECTACTIVITY();
                    prjAct.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITY");
                    prjAct.REF_BUSINESSACTIVITY_ID = orm.Init<SYS_BUSINESSACTIVITY>("where REF_BUSINESS_ID=" + BusinessId + "order by id").ID;
                    prjAct.REF_PROJECT_ID = prj.ID;
                    prjAct.REF_PROJECTPROCESS_ID = prjPro.ID;
                    prjAct.STATE = 0;
                    orm.Insert(prjAct);

                    SYS_PROJECTWORKITEM prjWi = new SYS_PROJECTWORKITEM();
                    prjWi.ID = ValueOperator.CreatePk("SYS_PROJECTWORKITEM");
                    prjWi.REF_PROJECT_ID = prj.ID;
                    prjWi.REF_PROJECTACTIVITY_ID = prjAct.ID;
                    prjWi.REF_USER_ID = Convert.ToInt32(Session["UserId"].ToString());
                    prjWi.STARTTIME = DateTime.Now;
                    prjWi.STATE = 0;
                    orm.Insert(prjWi);

                    List<SYS_PROJECTFORM> forms = new List<SYS_PROJECTFORM>();
                    List<SYS_PROJECTMATERIAL> materials = new List<SYS_PROJECTMATERIAL>();
                    orm.Commit();
                    orm.Close();
                    result.ReturnCode = ServiceResultCode.Success;
                }
            }
            catch(Exception e)
            {
                result.ReturnCode = ServiceResultCode.Error;
                result.Message = e.Message;
            }
            return Json(result);
        }

        public ActionResult BusinessTree()
        {
            List<SYS_BUSINESS> businesses = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                businesses = orm.Query<SYS_BUSINESS>();
                orm.Close();
            }

            SYS_BUSINESS root = null;
            if (null != businesses && businesses.Count > 0)
            {
                root = new SYS_BUSINESS();
                root.children = new List<AbstractModel>();
                root.id = 1;
                root.pid = 0;
                root.text = "业务列表";

                foreach (SYS_BUSINESS business in businesses)
                {
                    business.id = business.ID;
                    business.pid = 1;
                    business.text = business.BUSINESSNAME;
                    root.children.Add(business);
                }
            }

            List<SYS_BUSINESS> result = new List<SYS_BUSINESS>();
            result.Add(root);

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(result));
            System.Web.HttpContext.Current.Response.End();
            return Json(result);
        }

        public ActionResult SendUserTree(int ProjectId)
        {
            SYS_PROJECTACTIVITY currProjActivity = null;
            SYS_BUSINESSACTIVITY nextBusinessActivity = null;
            List<SYS_BUSINESSROLE> businessRoles = null;
            List<SYS_BUSINESSROLEUSER> businessRoleUsers = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                currProjActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id=" + ProjectId + " and state=0");
                int nextBusinessActivityId = orm.Init<SYS_BUSINESSACTIVITYROUTE>("where REF_FROM_BUSINESSACTIVITY_ID=" + currProjActivity.REF_BUSINESSACTIVITY_ID).REF_TO_BUSINESSACTIVITY_ID;
                nextBusinessActivity = orm.Init<SYS_BUSINESSACTIVITY>("where id=" + nextBusinessActivityId);
                businessRoles = orm.Query<SYS_BUSINESSROLE>("where id=" + nextBusinessActivity.REF_BUSINESSROLE_ID);
                foreach (SYS_BUSINESSROLE role in businessRoles)
                {
                    role.text = role.ROLENAME;
                    role.id = role.ID;
                    role.pid = 0;
                    role.iconCls = "icon-users";
                    role.children = new List<AbstractModel>();
                    businessRoleUsers = orm.Query<SYS_BUSINESSROLEUSER>("where ref_businessrole_id=" + role.ID);

                    foreach (SYS_BUSINESSROLEUSER u in businessRoleUsers)
                    {
                        SYS_USER user = orm.Init<SYS_USER>("where id=" + u.REF_USER_ID);
                        user.text = user.USERNAME;
                        user.id = user.ID;
                        user.pid = nextBusinessActivity.id;
                        user.iconCls = "icon-user-suit-black";
                        role.children.Add(user);
                    }
                }
                orm.Close();
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(businessRoles));
            System.Web.HttpContext.Current.Response.End();
            return Json(businessRoles);
        }
        public ActionResult DoSend(int ProjectId, string RecvUserId)
        {
            ServiceResult result = new ServiceResult();
            SYS_PROJECTACTIVITY currActivity = null;
            SYS_PROJECTWORKITEM currWorkitem = null;

            try
            {
                string[] userIds = RecvUserId.Split(',');
                if (null == RecvUserId || "" == RecvUserId || userIds.Length == 0)
                {
                    result.ReturnCode = ServiceResultCode.Error;
                    result.Message = "没有接收人员！";
                }
                else
                {
                    using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                    {
                        currActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id=" + ProjectId + " and state=0");
                        currWorkitem = orm.Init<SYS_PROJECTWORKITEM>("where ref_project_id=" + ProjectId + " and state=0");

                        //插入新记录
                        int nextBusinessActivityId = orm.Init<SYS_BUSINESSACTIVITYROUTE>("where REF_FROM_BUSINESSACTIVITY_ID=" + currActivity.REF_BUSINESSACTIVITY_ID).REF_TO_BUSINESSACTIVITY_ID;
                        SYS_PROJECTACTIVITY nextActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id=" + ProjectId + " and REF_BUSINESSACTIVITY_ID=" + nextBusinessActivityId);

                        if (null == nextActivity) // 不重复创建，只改状态
                        {
                            nextActivity = new SYS_PROJECTACTIVITY();
                            nextActivity.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITY");
                            nextActivity.REF_PROJECTPROCESS_ID = currActivity.REF_PROJECTPROCESS_ID;
                            nextActivity.REF_BUSINESSACTIVITY_ID = nextBusinessActivityId;
                            nextActivity.REF_PROJECT_ID = currActivity.REF_PROJECT_ID;
                            nextActivity.STATE = 0;
                            orm.Insert(nextActivity);
                        }
                        foreach (string userId in userIds)
                        {
                            //保存新的工作项
                            SYS_PROJECTWORKITEM nextWorkitem = new SYS_PROJECTWORKITEM();
                            nextWorkitem.ID = ValueOperator.CreatePk("SYS_PROJECTWORKITEM");
                            nextWorkitem.REF_PROJECTACTIVITY_ID = nextActivity.ID;
                            nextWorkitem.REF_USER_ID = Convert.ToInt32(userId);
                            nextWorkitem.REF_PROJECT_ID = currActivity.REF_PROJECT_ID;
                            nextWorkitem.STARTTIME = DateTime.Now;
                            nextWorkitem.STATE = 0;
                            orm.Insert(nextWorkitem);

                            //保存路由
                            SYS_PROJECTACTIVITYROUTE route = new SYS_PROJECTACTIVITYROUTE();
                            route.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITYROUTE");
                            route.REF_FROM_PROACT_ID = currActivity.ID;
                            route.REF_TO_PROACT_ID = nextActivity.ID;
                            route.ROUTETYPE = 0; // 发送
                            orm.Insert(route);
                        }

                        //更新旧记录
                        currActivity.STATE = 1;
                        orm.Save(currActivity);
                        //更新新记录
                        nextActivity.STATE = 0;
                        orm.Save(nextActivity);
                        //更新旧工作项
                        currWorkitem.STATE = 1;
                        currWorkitem.ENDTIME = DateTime.Now;
                        orm.Save(currWorkitem);

                        orm.Close();
                        result.ReturnCode = ServiceResultCode.Success;
                    }
                }
            }
            catch (Exception e)
            {
                result.ReturnCode = ServiceResultCode.Error;
                result.Message = e.Message;
            }
            return Json(result);
        }
        public ActionResult DoBack(int ProjectId)
        {
            ServiceResult result = new ServiceResult();
            SYS_PROJECTACTIVITY currActivity = null;
            SYS_PROJECTACTIVITY lastActivity = null;
            SYS_PROJECTWORKITEM currWorkitem = null;

            try
            {
                using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                {
                    currActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id='" + ProjectId + "' and state=0");
                    currWorkitem = orm.Init<SYS_PROJECTWORKITEM>("where ref_project_id=" + ProjectId + " and state=0");
                    int lastBusinessActivityId = orm.Init<SYS_BUSINESSACTIVITYROUTE>("where REF_TO_BUSINESSACTIVITY_ID=" + currActivity.REF_BUSINESSACTIVITY_ID).REF_FROM_BUSINESSACTIVITY_ID;
                    lastActivity = orm.Init<SYS_PROJECTACTIVITY>("where REF_BUSINESSACTIVITY_ID=" + lastBusinessActivityId);

                    //回退也要保存新的工作项
                    SYS_PROJECTWORKITEM nextWorkitem = new SYS_PROJECTWORKITEM();
                    nextWorkitem.ID = ValueOperator.CreatePk("SYS_PROJECTWORKITEM");
                    nextWorkitem.REF_PROJECTACTIVITY_ID = lastActivity.ID;
                    nextWorkitem.REF_USER_ID = orm.Init<SYS_PROJECTWORKITEM>("where REF_PROJECTACTIVITY_ID=" + lastActivity.ID + " order by id desc").REF_USER_ID;//找最后一条USERID
                    nextWorkitem.REF_PROJECT_ID = currActivity.REF_PROJECT_ID;
                    nextWorkitem.STARTTIME = DateTime.Now;
                    nextWorkitem.STATE = 0;
                    orm.Insert(nextWorkitem);

                    //保存路由
                    SYS_PROJECTACTIVITYROUTE route = new SYS_PROJECTACTIVITYROUTE();
                    route.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITYROUTE");
                    route.REF_FROM_PROACT_ID = currActivity.ID;
                    route.REF_TO_PROACT_ID = lastActivity.ID;
                    route.ROUTETYPE = Convert.ToInt32(PROJECTACTIVITYROUTE.BACK); // 回退
                    orm.Insert(route);

                    //更新新环节记录
                    lastActivity.STATE = 0;
                    orm.Save(lastActivity);
                    //更新旧环节记录
                    currActivity.STATE = 1;
                    orm.Save(currActivity);
                    //更新旧工作项
                    currWorkitem.STATE = 1;
                    currWorkitem.ENDTIME = DateTime.Now;
                    orm.Save(currWorkitem);

                    orm.Close();
                    result.ReturnCode = ServiceResultCode.Success;
                }
            }
            catch (Exception e)
            {
                result.ReturnCode = ServiceResultCode.Error;
                result.Message = e.Message;
            }
            return Json(result);
        }
    }
}