using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;

namespace Zxl.WorkflowDesigner
{
    public class ManualActivity : BaseActivity
    {
        public ManualActivity(int x, int y)
            : base(x, y)
        {
            Description = "环节";            
        }

        public decimal Time { get; set; }

        private List<SYS_BUSINESSROLE> _roles;
        public List<SYS_BUSINESSROLE> Roles
        {
            get
            {
                if (null == _roles)
                {
                    if (null != CurrProcess)
                    {
                        _roles = BusinessService.BusinessRoles(CurrProcess.REF_BUSINESS_ID);
                    }
                }
                else
                {
                    if (null != CurrProcess)
                    {
                        List<SYS_BUSINESSROLE> tempRoles = BusinessService.BusinessRoles(CurrProcess.REF_BUSINESS_ID);
                        foreach (SYS_BUSINESSROLE tempRole in tempRoles)
                        {
                            foreach (SYS_BUSINESSROLE role in _roles)
                            {
                                if (tempRole.ID == role.ID && role.Selected == 1)
                                {
                                    tempRole.Selected = 1;
                                    break;
                                }
                            }
                        }
                        _roles = tempRoles;
                    }
                }
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
        private List<SYS_BUSINESSFORM> _forms;
        public List<SYS_BUSINESSFORM> Forms
        {
            get
            {
                if (null == _forms)
                {
                    if (null != CurrProcess)
                    {
                        _forms = BusinessService.BusinessForms(CurrProcess.REF_BUSINESS_ID);
                    }
                }
                else
                {
                    if (null != CurrProcess)
                    {
                        List<SYS_BUSINESSFORM> tempForms = BusinessService.BusinessForms(CurrProcess.REF_BUSINESS_ID);
                        foreach (SYS_BUSINESSFORM tempForm in tempForms)
                        {
                            foreach (SYS_BUSINESSFORM form in _forms)
                            {
                                if (tempForm.ID == form.ID && form.Checked == 1)
                                {
                                    tempForm.Checked = 1;
                                    break;
                                }
                            }
                        }
                        _forms = tempForms;
                    }
                }
                return _forms;
            }
            set
            {
                _forms = value;
            }
        }

        override protected void DrawIcon(Graphics g)
        {
            if (IsSelected)
                g.DrawImage(Properties.Resources.manualSelect, _rect);
            else
                g.DrawImage(Properties.Resources.manual, _rect);
        }

        override public void OpenPropertyDialog()
        {
            ActivityInfoDlg dlg = new ActivityInfoDlg();
            dlg.Description = Description;
            dlg.Time = Time;
            dlg.Roles = Roles;
            dlg.Forms = Forms;
            
            //dlg.WfActivity = this;
            if(DialogResult.OK == dlg.ShowDialog())
            {
                Description = dlg.Description;
                Time = dlg.Time;
                Roles = dlg.Roles;
                Forms = dlg.Forms;
            }
            dlg.Dispose();
        }

        public override string GetActivityType()
        {
            return "2";
        }

        public override void CreateXml(XmlElement activitiesElement)
        {
            XmlElement activityElement = activitiesElement.OwnerDocument.CreateElement("activity");

            XmlAttribute attr = activityElement.OwnerDocument.CreateAttribute("id");
            attr.Value = _id;
            activityElement.Attributes.Append(attr);
            attr = activityElement.OwnerDocument.CreateAttribute("description");
            attr.Value = _description;
            activityElement.Attributes.Append(attr);
            attr = activityElement.OwnerDocument.CreateAttribute("x");
            attr.Value = _x.ToString();
            activityElement.Attributes.Append(attr);

            attr = activityElement.OwnerDocument.CreateAttribute("y");
            attr.Value = _y.ToString();
            activityElement.Attributes.Append(attr);
            //type
            attr = activityElement.OwnerDocument.CreateAttribute("type");
            attr.Value = GetActivityType();
            activityElement.Attributes.Append(attr);
            activitiesElement.AppendChild(activityElement);

            attr = activityElement.OwnerDocument.CreateAttribute("time");
            attr.Value = Time.ToString();
            activityElement.Attributes.Append(attr);

            XmlElement rolesElement = activityElement.OwnerDocument.CreateElement("roles");
            foreach(SYS_BUSINESSROLE role in Roles)
            {
                XmlElement roleElement = rolesElement.OwnerDocument.CreateElement("role");

                attr = roleElement.OwnerDocument.CreateAttribute("id");
                attr.Value = role.ID.ToString();
                roleElement.Attributes.Append(attr);
                attr = roleElement.OwnerDocument.CreateAttribute("name");
                attr.Value = role.ROLENAME;
                roleElement.Attributes.Append(attr);
                attr = roleElement.OwnerDocument.CreateAttribute("selected");
                attr.Value = role.Selected.ToString();
                roleElement.Attributes.Append(attr);

                rolesElement.AppendChild(roleElement);
            }
            activityElement.AppendChild(rolesElement);

            XmlElement formsElement = activityElement.OwnerDocument.CreateElement("forms");
            foreach (SYS_BUSINESSFORM form in Forms)
            {
                XmlElement formElement = formsElement.OwnerDocument.CreateElement("form");

                attr = formElement.OwnerDocument.CreateAttribute("id");
                attr.Value = form.ID.ToString();
                formElement.Attributes.Append(attr);
                attr = formElement.OwnerDocument.CreateAttribute("name");
                attr.Value = form.FORMNAME;
                formElement.Attributes.Append(attr);
                attr = formElement.OwnerDocument.CreateAttribute("checked");
                attr.Value = form.Checked.ToString();
                formElement.Attributes.Append(attr);

                formsElement.AppendChild(formElement);
            }
            activityElement.AppendChild(formsElement);
        }
    }
}
