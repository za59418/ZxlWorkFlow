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
using FormDesigner.Common;


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

        public DockProperty DockProperty { get; set; }
        public FormProvoider.FormItemInfo SelectedControl { get; set; }
        public DockCurrBusinessData DockCurrBusinessData { get; set; }
        public GridColumnStyle ColumnStyle = new GridColumnStyle();


        public delegate void FormItemChange(FormProvoider.FormItemInfo itemIinfo);
        private FormItemChange delegateFormItemChange;


        public static List<string> controlIdItems = new List<string>();
        public static ControlDictionary controlDictionary = new ControlDictionary();

        private void DockFormDesigner_Load(object sender, EventArgs e)
        {            
            InitForm();
            InitSheet();
            if (null != CurrForm.CONTENT && CurrForm.CONTENT.Length > 0)
            {
                string s = System.Text.Encoding.Default.GetString(CurrForm.CONTENT);
                new FormXmlFacade().ResetXml(this, s);
            }

            DockProperty.PropertyGridControl.SelectedObject = new ControlItemAttribute(); // 默认空控件属性

        }

        private void InitForm()
        {
            //画表单
            FormProvoider.CreateFormEditor(this.Handle);
            FormProvoider.MoveFormEditor(this.Width, this.Height);
            //属性
            delegateFormItemChange = new FormItemChange(Control_Change);
            FormProvoider.FormItemChangeFun(Marshal.GetFunctionPointerForDelegate(delegateFormItemChange));
        }

        private void InitSheet()
        {
            if (null != CurrForm.SHEET)
            {
                int nLen = (int)CurrForm.SHEET.Length;

                // 通过内存加载
                IntPtr xxBuffer = Marshal.AllocHGlobal(nLen);
                Marshal.Copy(CurrForm.SHEET, 0, xxBuffer, nLen);
                FormProvoider.LoadSheetFromBuffer(xxBuffer);
                Marshal.FreeHGlobal(xxBuffer);
            }
        }


        private bool _itemChanged = false;
        public bool ItemChanged
        {
            get { return _itemChanged; }
            set { _itemChanged = value; }
        }


        public void Control_Change(FormProvoider.FormItemInfo itemInfo)
        {
            try
            {
                _itemChanged = true;

                //显示属性
                if (null != DockProperty)
                {
                    DockProperty.SelectedControl = itemInfo; //
                    this.SelectedControl = itemInfo; //
                    DockProperty.FormItemProperty(); //
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
            FormProvoider.MoveFormEditor(this.Width, this.Height);
        }
    }
}
