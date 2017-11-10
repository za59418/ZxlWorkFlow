using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FormDesigner
{
    #region 设计器枚举定义

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public Int32 left;
        public Int32 top;
        public Int32 right;
        public Int32 bottom;
    }

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

    [StructLayout(LayoutKind.Sequential)]
    public struct FontWnd
    {
        public Int32 ftSize;
        public Int32 ftStyle;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string itemName;
    }

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

    #endregion

    /// <summary>
    /// 表单设计器接口定义
    /// </summary>
    public interface IFormDesigner
    {
        /// <summary>
        /// 创建表单编辑器
        /// </summary>
        /// <param name="hParentWnd">父窗口句柄</param>
        /// <returns></returns>
        bool CreateFormEditor(IntPtr hParentWnd);

        /// <summary>
        /// 改变表单编辑器的大小
        /// </summary>
        /// <param name="cx">宽度</param>
        /// <param name="cy">高度</param>
        void MoveFormEditor(int cx, int cy);

        /// <summary>
        /// 工具按钮功能调用函数
        /// </summary>
        /// <param name="nID">功能ID</param>        
        void DoToolBarCmd(uint nID);

        /// <summary>
        /// 选中项改变事件，如果没有选中对象则返回FormItemInfo的内容都为0
        /// </summary>
        /// <param name="funFormItemChange"></param>
        void FormItemChangeFun(IntPtr funFormItemChange);

        /// <summary>
        /// 选中项目删除
        /// </summary>
        /// <param name="funFormItemDelete"></param>
        void FormItemDelete(IntPtr funFormItemDelete);

        /// <summary>
        /// 表单按键事件，不调用无法触发表单的keydown事件
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        void FormEditorKeyDown(int wParam, int lParam);

        /// <summary>
        /// 画板的大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void GetFormViewSize(ref Int32 width, ref Int32 height);

        /// <summary>
        /// 设置面板大小
        /// </summary>
        /// <param name="widht"></param>
        /// <param name="heigth"></param>
        void SetFormViewSize(Int32 widht, Int32 heigth);

        /// <summary>
        /// 取得当前选中项的句柄
        /// </summary>
        /// <returns></returns>
        IntPtr GetActiveItemhwnd();

        /// <summary>
        /// 改变选中项的大小
        /// </summary>
        /// <param name="rcRect"></param>
        void MoveActiveFormItem(Rect rcRect);

        /// <summary>
        /// 创建FormItem
        /// </summary>
        /// <param name="formItemType"></param>
        /// <param name="rcRect"></param>
        /// <returns></returns>        
        bool CreateFormItem(Int32 formItemType, Rect rcRect, Int32 formItemID, Int16 extension);

        void ResetFormItem();

        bool SetWindowText(IntPtr hwnd, string windowtext);

        int GetWindowText(IntPtr hwnd, StringBuilder buf, int nMaxCount);

        void SetStaticText(Int32 formitemid, String caption);

        int GetStaticText(Int32 formitemid, StringBuilder buf, int nMaxCount);

        /// <summary>
        /// 设置控件扩展属性
        /// </summary>
        /// <param name="nItemID"></param>
        /// <param name="extension"></param>
        void SetFormItemExtension(Int32 nItemID, Int16 extension);

        /// <summary>
        /// 获取控件扩展属性
        /// </summary>
        /// <param name="nItemID"></param>
        /// <param name="extension"></param>
        UInt16 GetFormItemExtension(Int32 nItemID);

        bool GetNextFormItem(out FormItemInfo formItemInfo);

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="colorFont"></param>
        /// <returns></returns>
        bool SetFormItemColor(Int32 formItemID, Int32 colorFont);

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="colorFont"></param>
        /// <returns></returns>
        bool GetFormItemColor(Int32 formItemID, out Int32 colorFont);

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="fontwnd"></param>
        /// <returns></returns>
        bool SetFormItemFont(Int32 formItemID, FontWnd fontwnd);

        /// <summary>
        /// 获取字体
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="fontwnd"></param>
        /// <returns></returns>
        bool GetFormItemFont(Int32 formItemID, out FontWnd fontwnd);

        #region TabControl控件操作

        /// <summary>
        /// tabControl控件插入新页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="caption"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        bool InsertTabPage(Int32 formitemid, String caption, int page);

        /// <summary>
        /// tabControl插入子控件
        /// </summary>
        /// <param name="formItemType"></param>
        /// <param name="rcRect"></param>
        /// <param name="formItemID"></param>
        /// <param name="ParentID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        bool CreateChlidFormItem(Int32 formItemType, Rect rcRect,
            Int32 formItemID, Int32 ParentID, Int32 page, Int16 extension);

        /// <summary>
        /// 给定ID重新设置子控件
        /// </summary>
        /// <param name="formItemID"></param>
        /// <param name="page"></param>
        void ResetChildFormItem(Int32 formItemID, Int32 page);

        /// <summary>
        /// tabControl遍历子控件
        /// </summary>
        /// <param name="formItemInfo"></param>
        /// <returns></returns>
        bool GetNextChildFormItem(out FormItemInfo formItemInfo);

        /// <summary>
        /// 删除Page页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        int DeleteTabPage(Int32 formitemid, Int32 page);

        /// <summary>
        /// 获取当前page页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        int GetCurTabPage(Int32 formitemid);

        /// <summary>
        /// 设置当前page页
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        int SetCurTabPage(Int32 formitemid, Int32 page);

        /// <summary>
        /// 获取page数
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        int GetTabPageCount(Int32 formitemid);

        /// <summary>
        /// 设置page页文本
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <param name="caption"></param>
        void SetTabPageText(Int32 formitemid, Int32 page, string caption);

        /// <summary>
        /// 获取page页文本
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="page"></param>
        /// <param name="buf"></param>
        /// <param name="nMaxCount"></param>
        void GetTabPageText(Int32 formitemid, int page, StringBuilder buf, int nMaxCount);

        #endregion TabControl控件操作

        /// <summary>
        /// 删除所有控件
        /// </summary>
        void DeleteAllFormItem();

        /// <summary>
        ///获取当前控件
        /// </summary>
        /// <param name="formItemInfo"></param>
        /// <returns></returns>
        Boolean GetActiveFormItem(out FormItemInfo formItemInfo);


        #region Grid控件操作

        /// <summary>
        /// 增加Grid的一个列
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="columnIndex"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="align"></param> 0:Left,1:Center,2:right
        /// <returns></returns>
        int InsertGridColumn(Int32 formitemid, int columnIndex, GridColumn columnInfo);
        /// <summary>
        /// 取得grid的列数
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        int GetGridColumns(Int32 formitemid);

        bool DeleteGridColumn(Int32 formitemid, int indexColumn);

        bool GetGridColumnInfo(Int32 formitemid, int indexColumn, out GridColumn columnInfo);

        bool ModifyGridColumn(Int32 formitemid, int indexColumn, GridColumn columnInfo);

        #endregion Grid控件操作

        /// <summary>
        /// 编辑框 设置多选
        /// </summary>
        /// <param name="formitemid"></param>
        /// <param name="style"></param>
        void SetFormItemStyle(Int32 formitemid, Int32 style, Boolean isAdd);

        /// <summary>
        /// 编辑框 获取是否多选值
        /// </summary>
        /// <param name="formitemid"></param>
        /// <returns></returns>
        Int32 GetFormItemStyle(Int32 formitemid);

        Int32 GetRaidoButtonRows(Int32 formitemid);

        void SetRaidoButtonRows(Int32 formitemid, Int32 rows);

        Int32 GetRaidoButtonCols(Int32 formitemid);

        void SetRaidoButtonCols(Int32 formitemid, Int32 cols);

        Boolean SetRadioButtonCaption(Int32 formitemid, String caption);

        int GetRadioButtonCaption(Int32 formitemid, StringBuilder buf);

        void SetMaxItemID();

        int GetWindowLong(IntPtr hWnd, int nIndex);

        int SetWindowLong(IntPtr hWnd, int nIndex, int nVal);

        bool BorderStyle(FormItemInfo formitemInfo);
        /*
        public static bool BorderStyle(FormItemInfo formitemInfo)
        {
            bool boarderStyle = false;
            if ((GetWindowLong(new IntPtr(formitemInfo.Hwnd), -16) & 0x00800000) != 0)
            {
                boarderStyle = true;
            }
            return boarderStyle;
        }
        */
        //public static bool MultilineStyle(FormItemInfo formitemInfo)
        //{
        //    bool boarderStyle = false;
        //    if ((GetWindowLong(new IntPtr(formitemInfo.Hwnd), -20) & 0x00000004) != 0)
        //    {
        //        boarderStyle = true;
        //    }
        //    return boarderStyle;
        //}

        Int32 SaveSheetToBuffer(IntPtr lpBuffer);

        void LoadSheetFromBuffer(IntPtr lpBuffer);

        Int32 SaveSheetToXML(StringBuilder buf);

        void ReleaseSheet();

        bool GetPageBackgroundImage(int pageIndex, IntPtr lpBuffer, ref int fileSizeContent);

        int GetPageCountA();

        //[DllImport(@"ZxlFormDesigner.dll")]
        //Int32 SaveSheetToBuffer(IntPtr lpBuffer);

        //[DllImport(@"ZxlFormDesigner.dll")]
        //void LoadSheetFromBuffer(IntPtr lpBuffer);

        //[DllImport(@"ZxlFormDesigner.dll")]
        //Int32 SaveSheetToXML(StringBuilder buf);


        //[DllImport(@"ZxlFormDesigner.dll")]
        //void ReleaseSheet();

        /////////////////////////////////////////////////////////////////////////////////
        /*
         *  function    :   将原来的ZxlFormDesigner.dll替换原来的ZxlFormDesigner.dll
         *                  注释掉上面4个扩展调用函数，新增下面4个空函数入口
         *  createDate  :   2010-6-9 13:36:28
         * 
         */
        /////////////////////////////////////////////////////////////////////////////////

        /*
        public static Int32 SaveSheetToBuffer(IntPtr lpBuffer)
        {
            return 0;
        }

        public static void LoadSheetFromBuffer(IntPtr lpBuffer)
        {

        }

        public static Int32 SaveSheetToXML(StringBuilder buf)
        {
            return 0;
        }

        public static void ReleaseSheet()
        {

        }
        */
    }
}
