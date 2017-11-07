using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;
using System.Runtime.InteropServices;

using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;
using Zxl.WorkflowDesigner;

using FormDesigner;
using FormDesigner.Attribute;


namespace Zxl.Builder
{
    public partial class DockFormDesigner : DockContent
    {
        public IBusinessService BusinessService = new BusinessService();

        public DockFormDesigner()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public delegate void FormItemChange(Dap2xProvoider.FormItemInfo itemIinfo);
        private FormItemChange delegateFormItemChange;

        private void DockFormDesigner_Load(object sender, EventArgs e)
        {
            //画表单
            Dap2xProvoider.CreateFormEditor(this.Handle);
            Dap2xProvoider.MoveFormEditor(this.Width, this.Height);
            //属性
            delegateFormItemChange = new FormItemChange(DapxControlChange);
            Dap2xProvoider.FormItemChangeFun(Marshal.GetFunctionPointerForDelegate(delegateFormItemChange));

            DockProperty.PropertyGridControl.SelectedObject = new ControlItemAttribute(); // 默认空控件属性
        }

        private bool _itemChanged = false;
        public bool ItemChanged
        {
            get { return _itemChanged; }
            set { _itemChanged = value; }
        }

        public DockProperty DockProperty { get; set; }
        public DockCurrBusinessData DockCurrBusinessData { get; set; }

        public void DapxControlChange(Dap2xProvoider.FormItemInfo itemInfo)
        {
            try
            {
                _itemChanged = true;

                //显示属性
                if (null != DockProperty)
                {
                    DockProperty.SelectedControl = itemInfo;//
                    DockProperty.FormItemProperty();//
                }

                if (DockCurrBusinessData.selectedProperty != null && DockCurrBusinessData.selectedMetadata != null)
                {
                    SingleDataBindAttribute dataBindAttribute = new SingleDataBindAttribute(itemInfo.formItemID.ToString());
                    dataBindAttribute.Value = "/" + DockCurrBusinessData.selectedMetadata.NAME + "/" + DockCurrBusinessData.selectedProperty.NAME;

                    //if (!formDataCollection.ContainsKey(itemInfo.formItemID.ToString()))
                    //{
                    //    formDataCollection.Add(itemInfo.formItemID.ToString(), dataBindAttribute);
                    //}

                    DockCurrBusinessData.selectedProperty = null;
                    DockCurrBusinessData.selectedMetadata = null;
                }
                this.Focus();

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "系统提示", MessageBoxButtons.OK);
            }
        }

        private void DockFormDesigner_Resize(object sender, EventArgs e)
        {
            Dap2xProvoider.MoveFormEditor(this.Width, this.Height);
        }

        private SYS_BUSINESSFORM _currForm;
        public SYS_BUSINESSFORM CurrForm
        {
            get
            {
                return _currForm;
            }
            set
            {
                _currForm = value;
            }
        }
    }
}
