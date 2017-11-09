using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraVerticalGrid;

using FormDesigner;
using FormDesigner.Attribute;
using FormDesigner.Common;

namespace Zxl.Builder
{
    public partial class DockProperty : DockContent
    {
        public static ControlsDictionary controlsDictionary = new ControlsDictionary();

        public DockProperty()
        {
            InitializeComponent();
        }


        private Dap2xProvoider.FormItemInfo _selectedControl;
        /// <summary>
        /// current focued control in the form designer
        /// </summary>
        public Dap2xProvoider.FormItemInfo SelectedControl
        {
            get { return _selectedControl; }
            set { _selectedControl = value; }
        }

        public PropertyGridControl PropertyGridControl 
        {
            get
            {
                return this.propertyGridControl1;
            }
        }


        public void FormItemProperty()
        {
            try
            {
                ControlItemAttribute attr = new ControlItemAttribute();
                if (_selectedControl.formItemType != 0)
                {
                    attr.FormItemInfo = _selectedControl;
                    StringBuilder windowtext = new StringBuilder(2560);
                    Dap2xProvoider.GetStaticText(_selectedControl.formItemID, windowtext, windowtext.Capacity);

                    attr.Left = _selectedControl.left;
                    attr.Top = _selectedControl.top;
                    attr.Width = _selectedControl.width;
                    attr.Height = _selectedControl.height;
                    attr.FormItemId = _selectedControl.formItemID;
                    attr.FormItemType = _selectedControl.formItemType;
                    attr.TempText = windowtext.ToString();
                    //attr.ControlType = DAP2ControlMapping.GetInstance().GetExtensionTypeName(_selectedControl.formItemType.ToString(), _selectedControl.extension.ToString());
                    if (_selectedControl.formItemType != 0) //==4
                    {
                        //get the contorl's font
                        Dap2xProvoider.FontWnd fontWnd = new Dap2xProvoider.FontWnd();
                        Dap2xProvoider.GetFormItemFont(_selectedControl.formItemID, out fontWnd);
                        if (!string.IsNullOrEmpty(fontWnd.itemName))
                        {

                            Font font = GeneralAttribute.SetFontStyle(new FontFamily(fontWnd.itemName), fontWnd.ftSize
                                , fontWnd.ftStyle);
                            attr.SetAttributeFont(font);

                        }
                        //点击控件显示其 绑定信息
                        if (_selectedControl.formItemType == 1 && Dap2xProvoider.GetSelectedFormItemsCount() == 1)
                        {
                            attr.Text = attr.DataItem;
                        }

                        //get the contorl's color
                        Int32 oldColor;
                        Dap2xProvoider.GetFormItemColor(_selectedControl.formItemID, out oldColor);
                        attr.SetAttributeColor(ColorTranslator.FromOle(oldColor));
                        attr.Border = Dap2xProvoider.BorderStyle(_selectedControl);
                    }
                    //_focusedControl = FormParameter.FormId + "_" + _selectedControl.formItemID.ToString();
                    controlsDictionary.AddValue(_selectedControl.formItemID, _selectedControl.formItemID.ToString());
                }
                else
                {
                    //attr.IsPrint = PageProperty.IsPrint.ToString();
                    //SelectedItemId = _selectedControl.formItemID.ToString();
                    //_selectedItemType = _selectedControl.formItemType.ToString();
                }

                propertyGridControl1.SelectedObject = attr;
                propertyGridControl1.RetrieveFields();
                //FormParameter.ControlsCollection = controlsDictionary;
                //SetPropertyGridShowItem();

            }
            catch (Exception E)
            {
                XtraMessageBox.Show(E.Message, "系统提示", MessageBoxButtons.OK);
            }
        }

    }
}
