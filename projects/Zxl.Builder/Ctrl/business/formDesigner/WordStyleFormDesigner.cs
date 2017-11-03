using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner
{
    /// <summary>
    /// Word风格表单设计器
    /// </summary>
    public class WordStyleFormDesigner : IFormDesigner
    {
        #region IFormDesigner Members

        public bool CreateFormEditor(IntPtr hParentWnd)
        {
            return NativeWordStyleFormDesigner.CreateFormEditor(hParentWnd);
        }

        public void MoveFormEditor(int cx, int cy)
        {
            NativeWordStyleFormDesigner.MoveFormEditor(cx, cy);
        }

        public void DoToolBarCmd(uint nID)
        {
            NativeWordStyleFormDesigner.DoToolBarCmd(nID);
        }

        public void FormItemChangeFun(IntPtr funFormItemChange)
        {
            NativeWordStyleFormDesigner.FormItemChangeFun(funFormItemChange);
        }

        public void FormItemDelete(IntPtr funFormItemDelete)
        {
            NativeWordStyleFormDesigner.FormItemDelete(funFormItemDelete);
        }

        public void FormEditorKeyDown(int wParam, int lParam)
        {
            NativeWordStyleFormDesigner.FormEditorKeyDown(wParam, lParam);
        }

        public void GetFormViewSize(ref int width, ref int height)
        {
            NativeWordStyleFormDesigner.GetFormViewSize(ref width, ref height);
        }

        public void SetFormViewSize(int widht, int heigth)
        {
            NativeWordStyleFormDesigner.SetFormViewSize(widht, heigth);
        }

        public IntPtr GetActiveItemhwnd()
        {
            return NativeWordStyleFormDesigner.GetActiveItemhwnd();
        }

        public void MoveActiveFormItem(Rect rcRect)
        {
            NativeWordStyleFormDesigner.MoveActiveFormItem(rcRect);
        }

        public bool CreateFormItem(int formItemType, Rect rcRect, int formItemID, short extension)
        {
            return NativeWordStyleFormDesigner.CreateFormItem(formItemType, rcRect, formItemID, extension);
        }

        public void ResetFormItem()
        {
            NativeWordStyleFormDesigner.ResetFormItem();
        }

        public bool SetWindowText(IntPtr hwnd, string windowtext)
        {
            return NativeWordStyleFormDesigner.SetWindowText(hwnd, windowtext);
        }

        public int GetWindowText(IntPtr hwnd, StringBuilder buf, int nMaxCount)
        {
            return NativeWordStyleFormDesigner.GetWindowText(hwnd, buf, nMaxCount);
        }

        public void SetStaticText(int formitemid, string caption)
        {
            NativeWordStyleFormDesigner.SetStaticText(formitemid, caption);
        }

        public int GetStaticText(int formitemid, StringBuilder buf, int nMaxCount)
        {
            return NativeWordStyleFormDesigner.GetStaticText(formitemid, buf, nMaxCount);
        }

        public void SetFormItemExtension(int nItemID, short extension)
        {
            NativeWordStyleFormDesigner.SetFormItemExtension(nItemID, extension);
        }

        public ushort GetFormItemExtension(int nItemID)
        {
            return NativeWordStyleFormDesigner.GetFormItemExtension(nItemID);
        }

        public bool GetNextFormItem(out FormItemInfo formItemInfo)
        {
            return NativeWordStyleFormDesigner.GetNextFormItem(out formItemInfo);
        }

        public bool SetFormItemColor(int formItemID, int colorFont)
        {
            return NativeWordStyleFormDesigner.SetFormItemColor(formItemID, colorFont);
        }

        public bool GetFormItemColor(int formItemID, out int colorFont)
        {
            return NativeWordStyleFormDesigner.GetFormItemColor(formItemID, out colorFont);
        }

        public bool SetFormItemFont(int formItemID, FontWnd fontWnd)
        {
            return NativeWordStyleFormDesigner.SetFormItemFont(formItemID, fontWnd);
        }

        public bool GetFormItemFont(int formItemID, out FontWnd fontWnd)
        {
            return NativeWordStyleFormDesigner.GetFormItemFont(formItemID, out fontWnd);
        }

        public bool InsertTabPage(int formitemid, string caption, int page)
        {
            return NativeWordStyleFormDesigner.InsertTabPage(formitemid, caption, page);
        }

        public bool CreateChlidFormItem(int formItemType, Rect rcRect, int formItemID, int ParentID, int page, short extension)
        {
            return NativeWordStyleFormDesigner.CreateChlidFormItem(formItemType, rcRect, formItemID, ParentID, page, extension);
        }

        public void ResetChildFormItem(int formItemID, int page)
        {
            NativeWordStyleFormDesigner.ResetChildFormItem(formItemID, page);
        }

        public bool GetNextChildFormItem(out FormItemInfo formItemInfo)
        {
            return NativeWordStyleFormDesigner.GetNextChildFormItem(out formItemInfo);
        }

        public int DeleteTabPage(int formitemid, int page)
        {
            return NativeWordStyleFormDesigner.DeleteTabPage(formitemid, page);
        }

        public int GetCurTabPage(int formitemid)
        {
            return NativeWordStyleFormDesigner.GetCurTabPage(formitemid);
        }

        public int SetCurTabPage(int formitemid, int page)
        {
            return NativeWordStyleFormDesigner.SetCurTabPage(formitemid, page);
        }

        public int GetTabPageCount(int formitemid)
        {
            return NativeWordStyleFormDesigner.GetTabPageCount(formitemid);
        }

        public void SetTabPageText(int formitemid, int page, string caption)
        {
            NativeWordStyleFormDesigner.SetTabPageText(formitemid, page, caption);
        }

        public void GetTabPageText(int formitemid, int page, StringBuilder buf, int nMaxCount)
        {
            NativeWordStyleFormDesigner.GetTabPageText(formitemid, page, buf, nMaxCount);
        }

        public void DeleteAllFormItem()
        {
            NativeWordStyleFormDesigner.DeleteAllFormItem();
        }

        public bool GetActiveFormItem(out FormItemInfo formItemInfo)
        {
            return NativeWordStyleFormDesigner.GetActiveFormItem(out formItemInfo);
        }

        public int InsertGridColumn(int formitemid, int columnIndex, GridColumn columnInfo)
        {
            return NativeWordStyleFormDesigner.InsertGridColumn(formitemid, columnIndex, columnInfo);
        }

        public int GetGridColumns(int formitemid)
        {
            return NativeWordStyleFormDesigner.GetGridColumns(formitemid);
        }

        public bool DeleteGridColumn(int formitemid, int indexColumn)
        {
            return NativeWordStyleFormDesigner.DeleteGridColumn(formitemid, indexColumn);
        }

        public bool GetGridColumnInfo(int formitemid, int indexColumn, out GridColumn columnInfo)
        {
            return NativeWordStyleFormDesigner.GetGridColumnInfo(formitemid, indexColumn, out columnInfo);
        }

        public bool ModifyGridColumn(int formitemid, int indexColumn, GridColumn columnInfo)
        {
            return NativeWordStyleFormDesigner.ModifyGridColumn(formitemid, indexColumn, columnInfo);
        }

        public void SetFormItemStyle(int formitemid, int style, bool isAdd)
        {
            NativeWordStyleFormDesigner.SetFormItemStyle(formitemid, style, isAdd);
        }

        public int GetFormItemStyle(int formitemid)
        {
            return NativeWordStyleFormDesigner.GetFormItemStyle(formitemid);
        }

        public int GetRaidoButtonRows(int formitemid)
        {
            return NativeWordStyleFormDesigner.GetRaidoButtonRows(formitemid);
        }

        public void SetRaidoButtonRows(int formitemid, int rows)
        {
            NativeWordStyleFormDesigner.SetRaidoButtonRows(formitemid, rows);
        }

        public int GetRaidoButtonCols(int formitemid)
        {
            return NativeWordStyleFormDesigner.GetRaidoButtonCols(formitemid);
        }

        public void SetRaidoButtonCols(int formitemid, int cols)
        {
            NativeWordStyleFormDesigner.SetRaidoButtonCols(formitemid, cols);
        }

        public bool SetRadioButtonCaption(int formitemid, string caption)
        {
            return NativeWordStyleFormDesigner.SetRadioButtonCaption(formitemid, caption);
        }

        public int GetRadioButtonCaption(int formitemid, StringBuilder buf)
        {
            return NativeWordStyleFormDesigner.GetRadioButtonCaption(formitemid, buf);
        }

        public void SetMaxItemID()
        {
            NativeWordStyleFormDesigner.SetMaxItemID();
        }

        public int GetWindowLong(IntPtr hWnd, int nIndex)
        {
            return NativeWordStyleFormDesigner.GetWindowLong(hWnd, nIndex);
        }

        public int SetWindowLong(IntPtr hWnd, int nIndex, int nVal)
        {
            return NativeWordStyleFormDesigner.SetWindowLong(hWnd, nIndex, nVal);
        }

        public bool BorderStyle(FormItemInfo formitemInfo)
        {
            return NativeWordStyleFormDesigner.BorderStyle(formitemInfo);
        }

        public int SaveSheetToBuffer(IntPtr lpBuffer)
        {
            return NativeWordStyleFormDesigner.SaveSheetToBuffer(lpBuffer);
        }

        public void LoadSheetFromBuffer(IntPtr lpBuffer)
        {
            NativeWordStyleFormDesigner.LoadSheetFromBuffer(lpBuffer);
        }

        public int SaveSheetToXML(StringBuilder buf)
        {
            return NativeWordStyleFormDesigner.SaveSheetToXML(buf);
        }

        public void ReleaseSheet()
        {
            NativeWordStyleFormDesigner.ReleaseSheet();
        }

        public bool GetPageBackgroundImage(int pageIndex, IntPtr lpBuffer, ref int fileSizeContent)
        {
            return NativeWordStyleFormDesigner.GetPageBackgroundImage(pageIndex, lpBuffer, ref fileSizeContent);
        }

        public int GetPageCountA()
        {
            return NativeWordStyleFormDesigner.GetPageCountA();
        }
        #endregion
    }
}
