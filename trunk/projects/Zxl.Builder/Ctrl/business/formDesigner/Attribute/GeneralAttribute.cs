using System;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;

namespace FormDesigner.Attribute
{
    /// <summary>
    /// 目  的：控件通用属性
    /// 创建人：weiwy
    /// 创建日期：2008-02-22
    /// </summary>
    public class GeneralAttribute : IControlAttribute
    {
        #region Variables
        private Int32 left;
        private Int32 top;
        private Int32 width;
        private Int32 height;
        private Int32 formItemID;
        private Int16 formItemType;
        private string text;
        private Font windowTextFont = new Font("宋体", 9, FontStyle.Regular);
        private Color windowTextColor = SystemColors.ControlText;
        private bool isMultiline = false;
        private Int16 extensionType;
        private bool border;
        #endregion

        #region Properties
        [CategoryAttribute("外观布局")]
        public Int32 Left
        {
            get { return left; }
            set
            {
                left = value;
                if (left != 0 && top != 0 && width != 0 && height != 0)
                {
                    FormProvoider.Rect rcRect = new FormProvoider.Rect();
                    rcRect.left = value;
                    rcRect.right =left+width;
                    rcRect.top = top;
                    rcRect.bottom = top + height;
                    FormProvoider.MoveActiveFormItem(rcRect);
                }
            }
        }

        [CategoryAttribute("外观布局")]
        public Int32 Top
        {
            get { return top; }
            set 
            { 
                top = value;
                if (left != 0 && top != 0 && width != 0 && height != 0)
                {
                    FormProvoider.Rect rcRect = new FormProvoider.Rect();
                    rcRect.left = left;
                    rcRect.right = left + width;
                    rcRect.top = value;
                    rcRect.bottom = value + height;
                    FormProvoider.MoveActiveFormItem(rcRect);
                }
            }
        }

        [CategoryAttribute("外观布局")]
        public Int32 Width
        {
            get { return width; }
            set {
                width = value;
                if (left != 0 && top != 0 && width != 0 && height != 0)
                {
                    FormProvoider.Rect rcRect = new FormProvoider.Rect();
                    rcRect.left = left;
                    rcRect.right = left + value;
                    rcRect.top = top;
                    rcRect.bottom = top + height;
                    FormProvoider.MoveActiveFormItem(rcRect);
                }
            }
        }

        [CategoryAttribute("外观布局")]
        public Int32 Height
        {
            get { return height; }
            set { 
                height = value;
                if (left != 0 && top != 0 && width != 0 && height != 0)
                {
                    FormProvoider.Rect rcRect = new FormProvoider.Rect();
                    rcRect.left = left;
                    rcRect.right = left + width;
                    rcRect.top = top;
                    rcRect.bottom = top + value;
                    FormProvoider.MoveActiveFormItem(rcRect);
                }
            }
        }

        [BrowsableAttribute(false)]
        public Int32 FormItemId
        {
            get { return formItemID; }
            set { formItemID = value; }
        }

        [CategoryAttribute("外观布局"),
       ReadOnlyAttribute(true), BrowsableAttribute(false)]
        public Int16 FormItemType
        {
            get { return formItemType; }
            set { formItemType = value; }
        }

        [CategoryAttribute("外观布局"),
        ReadOnlyAttribute(true)]
        public string ControlId
        {
            get { return formItemID.ToString(); }
        }

        [CategoryAttribute("外观布局"),EditorAttribute(typeof(UITextBoxEditor), typeof(System.Drawing.Design.UITypeEditor)),
          BrowsableAttribute(true)]
        public string Text
        {
            get { return text; }
            set {
                text = value;
                FormProvoider.FormItemInfo formItemInfo;
                FormProvoider.GetActiveFormItem(out formItemInfo);
                FormProvoider.SetStaticText(formItemInfo.formItemID, value);
                }
        }

        [CategoryAttribute("外观布局"), DescriptionAttribute("字体,适用于静态文本")]
        public Font WindowTextFont
        {
            get { return windowTextFont; }
            set
            {
                SetFont(value, formItemID);
            }
        }

        [CategoryAttribute("外观布局"), DescriptionAttribute("颜色,适用于静态文本")]
        public Color WindowTextColor
        {
            get { return windowTextColor; }
            set {
                SetColor(value, formItemID);
            }
        }

        [CategoryAttribute("类型"), DescriptionAttribute("控制编辑控件的文本是否能跨越多行"), BrowsableAttribute(false)]
        public bool Multiline
        {
            get { return isMultiline; }
            set { isMultiline = value; }
        }

        [CategoryAttribute("类型"), DescriptionAttribute("文本框边框"), BrowsableAttribute(false)]
        public bool Border
        {
            get { return border; }
            set { border = value; }
        }

        [BrowsableAttribute(false)]
        public Int16 ExtensionType
        {
            get { return extensionType; }
            set { extensionType = value; }
        }
        #endregion

        private void SetFont(Font font, int formItemID)
        {
            windowTextFont = font;
            FormProvoider.FontWnd fonts = new FormProvoider.FontWnd();
            fonts.ftSize = Convert.ToInt32(font.Size);
            fonts.ftStyle = GetFontStyle(font);
            fonts.itemName = font.Name;
            FormProvoider.SetFormItemFont(formItemID, fonts);
        }

        private void SetColor(Color color,int formItemID)
        {
            windowTextColor = color;
            int col = color.B << 16 | color.G << 8 | color.R;
            FormProvoider.SetFormItemColor(formItemID, col);
        }

        #region Methods
        public  static int GetFontStyle(Font font)
        {
            return (font.Bold == true ? 0x0001 : 0) + (font.Italic == true ? 0x0002 : 0) + (font.Underline == true ? 0x0004 : 0) + (font.Strikeout == true ? 0x0008 : 0);
        }

        public static Font SetFontStyle(FontFamily Name, float Size, int style)
        {
            FontStyle fontStyle = new FontStyle();
            if (style != 0)
            {
                if ((style & 0x0001) != 0x0000)
                { fontStyle = FontStyle.Bold; }

                if ((style & 0x0002) != 0x0000)
                { fontStyle = (fontStyle | FontStyle.Italic); }

                if ((style & 0x0004) != 0x0000)
                { fontStyle = (fontStyle | FontStyle.Underline); }

                if ((style & 0x0008) != 0x0000)
                { fontStyle = (fontStyle | FontStyle.Strikeout); }
            }
            else
            {
                fontStyle = FontStyle.Regular;
            }
            Font font = new Font(Name, Size, fontStyle);
            return font;
        }

        public void SetAttributeFont(Font font)
        {
            windowTextFont = font;
        }

        public void SetAttributeColor(Color color)
        {
            windowTextColor = color;
        }
        #endregion

    }
}
