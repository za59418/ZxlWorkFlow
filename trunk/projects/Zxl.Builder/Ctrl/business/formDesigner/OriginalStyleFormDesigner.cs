using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner
{
    /// <summary>
    /// 原始风格表单设计器
    /// </summary>
    public class OriginalStyleFormDesigner : IFormDesigner
    {
        #region IFormDesigner Members

        public bool CreateFormEditor(IntPtr hParentWnd)
        {
            return NativeOriginalStyleFormDesigner.CreateFormEditor(hParentWnd);
        }

        public void MoveFormEditor(int cx, int cy)
        {
            NativeOriginalStyleFormDesigner.MoveFormEditor(cx, cy);
        }

        public void DoToolBarCmd(uint nID)
        {
            NativeOriginalStyleFormDesigner.DoToolBarCmd(nID);
        }

        public void FormItemChangeFun(IntPtr funFormItemChange)
        {
            NativeOriginalStyleFormDesigner.FormItemChangeFun(funFormItemChange);
        }

        public void FormItemDelete(IntPtr funFormItemDelete)
        {
            NativeOriginalStyleFormDesigner.FormItemDelete(funFormItemDelete);
        }

        public void FormEditorKeyDown(int wParam, int lParam)
        {
            NativeOriginalStyleFormDesigner.FormEditorKeyDown(wParam, lParam);
        }

        public void GetFormViewSize(ref int width, ref int height)
        {
            NativeOriginalStyleFormDesigner.GetFormViewSize(ref width, ref height);
        }

        public void SetFormViewSize(int widht, int heigth)
        {
            NativeOriginalStyleFormDesigner.SetFormViewSize(widht, heigth);
        }

        public IntPtr GetActiveItemhwnd()
        {
            return NativeOriginalStyleFormDesigner.GetActiveItemhwnd();
        }

        public void MoveActiveFormItem(Rect rcRect)
        {
            NativeOriginalStyleFormDesigner.MoveActiveFormItem(rcRect);
        }

        public bool CreateFormItem(int formItemType, Rect rcRect, int formItemID, short extension)
        {
            return NativeOriginalStyleFormDesigner.CreateFormItem(formItemType, rcRect, formItemID, extension);
        }

        public void ResetFormItem()
        {
            NativeOriginalStyleFormDesigner.ResetFormItem();
        }

        public bool SetWindowText(IntPtr hwnd, string windowtext)
        {
            return NativeOriginalStyleFormDesigner.SetWindowText(hwnd, windowtext);
        }

        public int GetWindowText(IntPtr hwnd, StringBuilder buf, int nMaxCount)
        {
            return NativeOriginalStyleFormDesigner.GetWindowText(hwnd, buf, nMaxCount);
        }

        public void SetStaticText(int formitemid, string caption)
        {
            NativeOriginalStyleFormDesigner.SetStaticText(formitemid, caption);
        }

        public int GetStaticText(int formitemid, StringBuilder buf, int nMaxCount)
        {
            return NativeOriginalStyleFormDesigner.GetStaticText(formitemid, buf, nMaxCount);
        }

        public void SetFormItemExtension(int nItemID, short extension)
        {
            NativeOriginalStyleFormDesigner.SetFormItemExtension(nItemID, extension);
        }

        public ushort GetFormItemExtension(int nItemID)
        {
            return NativeOriginalStyleFormDesigner.GetFormItemExtension(nItemID);
        }

        public bool GetNextFormItem(out FormItemInfo formItemInfo)
        {
            return NativeOriginalStyleFormDesigner.GetNextFormItem(out formItemInfo);
        }

        public bool SetFormItemColor(int formItemID, int colorFont)
        {
            return NativeOriginalStyleFormDesigner.SetFormItemColor(formItemID, colorFont);
        }

        public bool GetFormItemColor(int formItemID, out int colorFont)
        {
            return NativeOriginalStyleFormDesigner.GetFormItemColor(formItemID, out colorFont);
        }

        public bool SetFormItemFont(int formItemID, FontWnd fontWnd)
        {
            return NativeOriginalStyleFormDesigner.SetFormItemFont(formItemID, fontWnd);
        }

        public bool GetFormItemFont(int formItemID, out FontWnd fontWnd)
        {
            return NativeOriginalStyleFormDesigner.GetFormItemFont(formItemID, out fontWnd);
        }

        public bool InsertTabPage(int formitemid, string caption, int page)
        {
            return NativeOriginalStyleFormDesigner.InsertTabPage(formitemid, caption, page);
        }

        public bool CreateChlidFormItem(int formItemType, Rect rcRect, int formItemID, int ParentID, int page, short extension)
        {
            return NativeOriginalStyleFormDesigner.CreateChlidFormItem(formItemType, rcRect, formItemID, ParentID, page, extension);
        }

        public void ResetChildFormItem(int formItemID, int page)
        {
            NativeOriginalStyleFormDesigner.ResetChildFormItem(formItemID, page);
        }

        public bool GetNextChildFormItem(out FormItemInfo formItemInfo)
        {
            return NativeOriginalStyleFormDesigner.GetNextChildFormItem(out formItemInfo);
        }

        public int DeleteTabPage(int formitemid, int page)
        {
            return NativeOriginalStyleFormDesigner.DeleteTabPage(formitemid, page);
        }

        public int GetCurTabPage(int formitemid)
        {
            return NativeOriginalStyleFormDesigner.GetCurTabPage(formitemid);
        }

        public int SetCurTabPage(int formitemid, int page)
        {
            return NativeOriginalStyleFormDesigner.SetCurTabPage(formitemid, page);
        }

        public int GetTabPageCount(int formitemid)
        {
            return NativeOriginalStyleFormDesigner.GetTabPageCount(formitemid);
        }

        public void SetTabPageText(int formitemid, int page, string caption)
        {
            NativeOriginalStyleFormDesigner.SetTabPageText(formitemid, page, caption);
        }

        public void GetTabPageText(int formitemid, int page, StringBuilder buf, int nMaxCount)
        {
            NativeOriginalStyleFormDesigner.GetTabPageText(formitemid, page, buf, nMaxCount);
        }

        public void DeleteAllFormItem()
        {
            NativeOriginalStyleFormDesigner.DeleteAllFormItem();
        }

        public bool GetActiveFormItem(out FormItemInfo formItemInfo)
        {
            return NativeOriginalStyleFormDesigner.GetActiveFormItem(out formItemInfo);
        }

        public int InsertGridColumn(int formitemid, int columnIndex, GridColumn columnInfo)
        {
            return NativeOriginalStyleFormDesigner.InsertGridColumn(formitemid, columnIndex, columnInfo);
        }

        public int GetGridColumns(int formitemid)
        {
            return NativeOriginalStyleFormDesigner.GetGridColumns(formitemid);
        }

        public bool DeleteGridColumn(int formitemid, int indexColumn)
        {
            return NativeOriginalStyleFormDesigner.DeleteGridColumn(formitemid, indexColumn);
        }

        public bool GetGridColumnInfo(int formitemid, int indexColumn, out GridColumn columnInfo)
        {
            return NativeOriginalStyleFormDesigner.GetGridColumnInfo(formitemid, indexColumn, out columnInfo);
        }

        public bool ModifyGridColumn(int formitemid, int indexColumn, GridColumn columnInfo)
        {
            return NativeOriginalStyleFormDesigner.ModifyGridColumn(formitemid, indexColumn, columnInfo);
        }

        public void SetFormItemStyle(int formitemid, int style, bool isAdd)
        {
            NativeOriginalStyleFormDesigner.SetFormItemStyle(formitemid, style, isAdd);
        }

        public int GetFormItemStyle(int formitemid)
        {
            return NativeOriginalStyleFormDesigner.GetFormItemStyle(formitemid);
        }

        public int GetRaidoButtonRows(int formitemid)
        {
            return NativeOriginalStyleFormDesigner.GetRaidoButtonRows(formitemid);
        }

        public void SetRaidoButtonRows(int formitemid, int rows)
        {
            NativeOriginalStyleFormDesigner.SetRaidoButtonRows(formitemid, rows);
        }

        public int GetRaidoButtonCols(int formitemid)
        {
            return NativeOriginalStyleFormDesigner.GetRaidoButtonCols(formitemid);
        }

        public void SetRaidoButtonCols(int formitemid, int cols)
        {
            NativeOriginalStyleFormDesigner.SetRaidoButtonCols(formitemid, cols);
        }

        public bool SetRadioButtonCaption(int formitemid, string caption)
        {
            return NativeOriginalStyleFormDesigner.SetRadioButtonCaption(formitemid, caption);
        }

        public int GetRadioButtonCaption(int formitemid, StringBuilder buf)
        {
            return NativeOriginalStyleFormDesigner.GetRadioButtonCaption(formitemid, buf);
        }

        public void SetMaxItemID()
        {
            NativeOriginalStyleFormDesigner.SetMaxItemID();
        }

        public int GetWindowLong(IntPtr hWnd, int nIndex)
        {
            return NativeOriginalStyleFormDesigner.GetWindowLong(hWnd, nIndex);
        }

        public int SetWindowLong(IntPtr hWnd, int nIndex, int nVal)
        {
            return NativeOriginalStyleFormDesigner.SetWindowLong(hWnd, nIndex, nVal);
        }

        public bool BorderStyle(FormItemInfo formitemInfo)
        {
            return NativeOriginalStyleFormDesigner.BorderStyle(formitemInfo);
        }

        public int SaveSheetToBuffer(IntPtr lpBuffer)
        {
            return NativeOriginalStyleFormDesigner.SaveSheetToBuffer(lpBuffer);
        }

        public void LoadSheetFromBuffer(IntPtr lpBuffer)
        {
            NativeOriginalStyleFormDesigner.LoadSheetFromBuffer(lpBuffer);
        }

        public int SaveSheetToXML(StringBuilder buf)
        {
            return NativeOriginalStyleFormDesigner.SaveSheetToXML(buf);
        }

        public void ReleaseSheet()
        {
            NativeOriginalStyleFormDesigner.ReleaseSheet();
        }

        public bool GetPageBackgroundImage(int pageIndex, IntPtr lpBuffer, ref int fileSizeContent)
        {
            return NativeOriginalStyleFormDesigner.GetPageBackgroundImage(pageIndex, lpBuffer, ref fileSizeContent);
        }

        public int GetPageCountA()
        {
            return NativeOriginalStyleFormDesigner.GetPageCountA();
        }

        #endregion
    }
}
