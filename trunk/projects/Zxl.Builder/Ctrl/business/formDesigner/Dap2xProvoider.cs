using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FormDesigner
{
    /// <summary>
    /// 目  的：DAP2X面板接口
    /// 创建日期：2008-02-22
    /// </summary>
    public class Dap2xProvoider
    {

        private static IFormDesigner _designer = null;
        private static object _flag = new object();
        public static IFormDesigner CurrentFormDesigner
        {
            get
            {
                if (_designer == null)
                {
                    lock (_flag)
                    {
                        if (_designer == null)
                        {
                            _designer = (new FormDesignerProvider()).GetFormDesigner();
                        }
                    }
                }
                return _designer;
            }
        }

        /// <summary>
        /// 创建表单编辑器
        /// </summary>
        /// <param name="hParentWnd">父窗口句柄</param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "CreateFormEditor")]
        public static extern bool CreateFormEditor(IntPtr hParentWnd);

        /// <summary>
        /// 改变表单编辑器的大小
        /// </summary>
        /// <param name="cx">宽度</param>
        /// <param name="cy">高度</param>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "MoveFormEditor")]
        public static extern void MoveFormEditor(int cx, int cy);

        /// <summary>
        /// 工具按钮功能调用函数
        /// </summary>
        /// <param name="nID">功能ID</param>        
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "DoToolBarCmd")]
        public static extern void DoToolBarCmd(uint nID);

        /// <summary>
        /// 选中项改变事件，如果没有选中对象则返回FormItemInfo的内容都为0
        /// </summary>
        /// <param name="funFormItemChange"></param>
        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern void FormItemChangeFun(IntPtr funFormItemChange);

        /// <summary>
        /// 选中项目删除
        /// </summary>
        /// <param name="funFormItemDelete"></param>
        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern void FormItemDelete(IntPtr funFormItemDelete);

        /// <summary>
        /// 控件定位
        /// </summary>
        /// <param name="funFormItemDelete"></param>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "LocateGivenItem")]
        public static extern void LocateGivenItem(Int32 ctrlId);



        /// <summary>
        /// 表单按键事件，不调用无法触发表单的keydown事件
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern void FormEditorKeyDown(int wParam, int lParam);
        
        /// <summary>
        /// 画板的大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern void GetFormViewSize(ref Int32 width, ref Int32 height);

        /// <summary>
        /// 设置面板大小
        /// </summary>
        /// <param name="widht"></param>
        /// <param name="heigth"></param>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetFormViewSize")]
        public static extern void SetFormViewSize(Int32 widht, Int32 heigth);

        /// <summary>
        /// 取得当前选中项的句柄
        /// </summary>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern IntPtr GetActiveItemhwnd();

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }
        /// <summary>
        /// 改变选中项的大小
        /// </summary>
        /// <param name="rcRect"></param>
        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern void MoveActiveFormItem(Rect rcRect);

        /// <summary>
        /// 创建FormItem
        /// </summary>
        /// <param name="formItemType"></param>
        /// <param name="rcRect"></param>
        /// <returns></returns>        
        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern bool CreateFormItem(Int32 formItemType, Rect rcRect, Int32 formItemID,Int16 extension);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "ResetFormItem")]
        public static extern void ResetFormItem();

        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr hwnd, string windowtext);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hwnd,StringBuilder buf, int nMaxCount);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetStaticText")]
        public static extern void SetStaticText(Int32 formitemid, String caption);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetStaticText")]
        public static extern int GetStaticText(Int32 formitemid, StringBuilder buf, int nMaxCount);

        /// <summary>
        /// 设置控件扩展属性
        /// </summary>
        /// <param name="nItemID"></param>
        /// <param name="extension"></param>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetFormItemExtension")]
        public static extern void SetFormItemExtension(Int32 nItemID, Int16 extension);

        /// <summary>
        /// 获取控件扩展属性
        /// </summary>
        /// <param name="nItemID"></param>
        /// <param name="extension"></param>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetFormItemExtension")]
        public static extern UInt16 GetFormItemExtension(Int32 nItemID);

        /// <summary>
        /// 控件信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FormItemInfo
        {
            public Int32 left;
            public Int32 top;
            public Int32 width;
            public Int32 height;
            public Int32 formItemID;
            public Int16 formItemType;
            public Int16 extension;
            public UInt32 Hwnd;
        }

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetNextFormItem")]
        public static extern bool GetNextFormItem(out FormItemInfo formItemInfo);

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="colorFont"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetFormItemColor")]
        public static extern bool SetFormItemColor(Int32 formItemID, Int32 colorFont);

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="colorFont"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetFormItemColor")]
        public static extern bool GetFormItemColor(Int32 formItemID, out Int32 colorFont);


        [StructLayout(LayoutKind.Sequential)]
        public struct FontWnd
        {
            public Int32 ftSize;
            public Int32 ftStyle;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public string itemName;
        }

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="fontwnd"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetFormItemFont")]
        public static extern bool SetFormItemFont(Int32 formItemID, FontWnd fontwnd);

        /// <summary>
        /// 获取字体
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="fontwnd"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetFormItemFont")]
        public static extern bool GetFormItemFont(Int32 formItemID, out FontWnd fontwnd);

        #region TabControl控件操作

        /// <summary>
        /// tabControl控件插入新页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="caption"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [DllImport(@"FormEditor.dll", EntryPoint = "InsertTabPage")]
        public static extern bool InsertTabPage(Int32 formitemid, String caption, int page);

        /// <summary>
        /// tabControl插入子控件
        /// </summary>
        /// <param name="formItemType"></param>
        /// <param name="rcRect"></param>
        /// <param name="formItemID"></param>
        /// <param name="ParentID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [DllImport(@"FormEditor.dll", EntryPoint = "CreateChlidFormItem")]
        public static extern bool CreateChlidFormItem(Int32 formItemType, Rect rcRect,
            Int32 formItemID, Int32 ParentID, Int32 page, Int16 extension);

        /// <summary>
        /// 给定ID重新设置子控件
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="page"></param>
        [DllImport(@"FormEditor.dll", EntryPoint = "ResetChildFormItem")]
        public static extern void ResetChildFormItem(Int32 formItemID, Int32 page);

        /// <summary>
        /// tabControl遍历子控件
        /// </summary>
        /// <param name="formItemInfo"></param>
        /// <returns></returns>
        [DllImport(@"FormEditor.dll", EntryPoint = "GetNextChildFormItem")]
        public static extern bool GetNextChildFormItem(out FormItemInfo formItemInfo);

        /// <summary>
        /// 删除Page页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [DllImport(@"FormEditor.dll", EntryPoint = "DeleteTabPage")]
        public static extern int DeleteTabPage(Int32 formitemid, Int32 page);

        /// <summary>
        /// 获取当前page页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        [DllImport(@"FormEditor.dll", EntryPoint = "GetCurTabPage")]
        public static extern int GetCurTabPage(Int32 formitemid);

        /// <summary>
        /// 设置当前page页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [DllImport(@"FormEditor.dll", EntryPoint = "SetCurTabPage")]
        public static extern int SetCurTabPage(Int32 formitemid, Int32 page);

        /// <summary>
        /// 获取page数
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        [DllImport(@"FormEditor.dll", EntryPoint = "GetTabPageCount")]
        public static extern int GetTabPageCount(Int32 formitemid);

        /// <summary>
        /// 设置page页文本
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <param name="caption"></param>
        [DllImport(@"FormEditor.dll", EntryPoint = "SetTabPageText")]
        public static extern void SetTabPageText(Int32 formitemid, Int32 page, string caption);

        /// <summary>
        /// 获取page页文本
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <param name="buf"></param>
        /// <param name="nMaxCount"></param>
        [DllImport(@"FormEditor.dll", EntryPoint = "GetTabPageText")]
        public static extern void GetTabPageText(Int32 formitemid, int page, StringBuilder buf, int nMaxCount);

        #endregion TabControl控件操作

        /// <summary>
        /// 删除所有控件
        /// </summary>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "DeleteAllFormItem")]
        public static extern void DeleteAllFormItem();

        /// <summary>
        ///获取当前控件
        /// </summary>
        /// <param name="formItemInfo"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetActiveFormItem")]
        public static extern Boolean GetActiveFormItem(out FormItemInfo formItemInfo);

        /// <summary>
        /// 获取选中的控件数量
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetSelectedFormItemsCount")]
        public static extern int GetSelectedFormItemsCount();

        /// <summary>
        /// 获取多个控件信息
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetSelectedFormItems")]
        public static extern int GetSelectedFormItems();


        /// <summary>
        /// 获取多个控件ID
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetSelectedFormItemsID")]
        public static extern void GetSelectedFormItemsID(StringBuilder ctrlIdStr);


        #region Grid控件操作

        [StructLayout(LayoutKind.Sequential)]
        public struct GridColumn
        {
            public Int32 columnStyle;
            public Int32 columnalign;
            public Int32 columnWidth;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string columncaption;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string columndefaultValue;
			public Int32 sum;
        }

        /// <summary>
        /// 增加Grid的一个列
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="columnIndex"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="align"></param> 0:Left,1:Center,2:right
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "InsertGridColumn")]
        public static extern int InsertGridColumn(Int32 formitemid, int columnIndex, GridColumn columnInfo);
        /// <summary>
        /// 取得grid的列数
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetGridColumns")]
        public static extern int GetGridColumns(Int32 formitemid);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "DeleteGridColumn")]
        public static extern bool DeleteGridColumn(Int32 formitemid, int indexColumn);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetGridColumnInfo")]
        public static extern bool GetGridColumnInfo(Int32 formitemid, int indexColumn, out GridColumn columnInfo);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "ModifyGridColumn")]
        public static extern bool ModifyGridColumn(Int32 formitemid, int indexColumn, GridColumn columnInfo);
        #endregion Grid控件操作

        /// <summary>
        /// 编辑框 设置多选
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="style"></param>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetFormItemStyle")]
        public static extern void SetFormItemStyle(Int32 formitemid, Int32 style, Boolean isAdd);

        /// <summary>
        /// 编辑框 获取是否多选值
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetFormItemStyle")]
        public static extern Int32 GetFormItemStyle(Int32 formitemid);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetRaidoButtonRows")]
        public static extern Int32 GetRaidoButtonRows(Int32 formitemid);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetRaidoButtonRows")]
        public static extern void SetRaidoButtonRows(Int32 formitemid, Int32 rows);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetRaidoButtonCols")]
        public static extern Int32 GetRaidoButtonCols(Int32 formitemid);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetRaidoButtonCols")]
        public static extern void SetRaidoButtonCols(Int32 formitemid, Int32 cols);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetRadioButtonCaption")]
        public static extern Boolean SetRadioButtonCaption(Int32 formitemid, String caption);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "GetRadioButtonCaption")]
        public static extern int GetRadioButtonCaption(Int32 formitemid, StringBuilder buf);

        [DllImport(@"ZxlFormDesigner.dll", EntryPoint = "SetMaxItemID")]
        public static extern void SetMaxItemID();

        [DllImport(@"User32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd,int nIndex);

        [DllImport(@"User32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd,int nIndex, int nVal);

        public static bool BorderStyle(FormItemInfo formitemInfo)
        {
            bool boarderStyle = false;
            if ((GetWindowLong(new IntPtr(formitemInfo.Hwnd), -16) & 0x00800000) != 0)
            {
                boarderStyle = true;
            }
            return boarderStyle;
        }

        //public static bool MultilineStyle(FormItemInfo formitemInfo)
        //{
        //    bool boarderStyle = false;
        //    if ((GetWindowLong(new IntPtr(formitemInfo.Hwnd), -20) & 0x00000004) != 0)
        //    {
        //        boarderStyle = true;
        //    }
        //    return boarderStyle;
        //}

        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern Int32 SaveSheetToBuffer(IntPtr lpBuffer);

        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern void LoadSheetFromBuffer(IntPtr lpBuffer);

        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern Int32 SaveSheetToXML(StringBuilder buf);
        

        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern void ReleaseSheet();

        [DllImport(@"ZxlFormDesigner.dll")]
        public static extern Int32 ManualMessageProc(Int32 message, IntPtr wParam, IntPtr lParam);

        public static bool GetPageBackgroundImage(int pageIndex, IntPtr lpBuffer, ref int fileSizeContent)
        {
            return CurrentFormDesigner.GetPageBackgroundImage(pageIndex, lpBuffer, ref fileSizeContent);
        }

        public static int GetPageCount()
        {
            return CurrentFormDesigner.GetPageCountA();
        }
    }
}
