using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using Zxl.Printer;

namespace Zxl.Printer.Office
{
	public class ExcelPrinter : BaseGHPrinter, IChangeDebuug
	{
		private Application appExcel;

		private Worksheet sheet;

		private Workbook wb;

		private object missing = System.Reflection.Missing.Value;

		private bool isNullModel = false;

		private System.Data.DataTable dt = null;

		private System.Collections.Generic.Dictionary<string, string> expTitles;

		protected override bool doLoadSourceFile(string sourceFile)
		{
			this.isNullModel = false;
			if (string.IsNullOrEmpty(sourceFile))
			{
				this.LoadExcelApplication();
				this.isNullModel = true;
			}
			else
			{
				this.LoadExcelApplication(sourceFile);
			}
			return true;
		}

		protected override bool doLoadData(System.Collections.Hashtable data)
		{
			if (data.ContainsKey("TITLES"))
			{
				this.expTitles = (data["TITLES"] as System.Collections.Generic.Dictionary<string, string>);
			}
			if (data.ContainsKey("TABLE"))
			{
				this.dt = (data["TABLE"] as System.Data.DataTable);
			}
			return true;
		}

		protected override bool doBuildFile(string saveAsFile)
		{
			if (this.isNullModel)
			{
				this.DataTablePrinterWithOutModel(this.dt, this.expTitles);
			}
			else
			{
				this.DataTablePrinter(this.dt);
			}
			this.SaveAs(saveAsFile);
			return true;
		}

		protected override bool doConvertToPdf(string saveAsFile)
		{
			XlFixedFormatType type = XlFixedFormatType.xlTypePDF;
			this.wb.ExportAsFixedFormat(type, saveAsFile, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			return true;
		}

		protected override void doDispose()
		{
			try
			{
				if (this.appExcel != null)
				{
					this.appExcel.Application.Quit();
					this.appExcel.Quit();
					int generation = System.GC.GetGeneration(this.wb);
					System.GC.Collect(generation);
					generation = System.GC.GetGeneration(this.appExcel);
					System.GC.Collect(generation);
				}
			}
			catch
			{
			}
			finally
			{
				this.appExcel = null;
				this.wb = null;
				this.sheet = null;
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
		}

		private bool LoadExcelApplication(string fileNamePath)
		{
			this.appExcel = new ApplicationClass();
			this.appExcel.Visible = false;
			this.appExcel.Application.DisplayAlerts = false;
			this.wb = this.appExcel.Workbooks.Open(System.IO.Path.GetFullPath(fileNamePath), System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			this.sheet = (Worksheet)this.wb.Worksheets[1];
			return true;
		}

		private void LoadExcelApplication()
		{
			this.appExcel = new ApplicationClass();
			this.wb = this.appExcel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
			this.sheet = (Worksheet)this.wb.Worksheets[1];
			this.appExcel.Visible = false;
			this.appExcel.Application.DisplayAlerts = false;
		}

		private bool DataTablePrinter(System.Data.DataTable list)
		{
			bool result;
			if (list == null)
			{
				result = false;
			}
			else
			{
				Range range = null;
				Range range2 = this.GetRange(out range);
				int num = range2.Row;
				int fieldsCount = this.GetFieldsCount(num);
				for (int i = 0; i < list.Rows.Count; i++)
				{
					range.EntireRow.Insert(System.Type.Missing, System.Type.Missing);
				}
				range.EntireRow.Delete(System.Reflection.Missing.Value);
				int num2 = num;
				for (int i = 0; i < list.Rows.Count; i++)
				{
					DataRow dataRow = list.Rows[i];
					for (int j = 1; j <= fieldsCount; j++)
					{
						string text = (string)((Range)this.sheet.Cells[num2, j]).Text;
						string text2 = "";
						string[] array = text.Split("|".ToCharArray());
						if (array.Length == 2)
						{
							text = array[0];
							text2 = array[1];
						}
						if (list.Columns.Contains(text))
						{
							if (list.Rows[i][text] != null)
							{
								string text3;
								if (!string.IsNullOrEmpty(text2))
								{
									text3 = DigitToChnText.ChnTextOperator.GetFormatValue(list.Rows[i][text].ToString(), text2);
								}
								else
								{
									text3 = list.Rows[i][text].ToString();
								}
								this.sheet.Cells[num + 1, j] = text3;
							}
						}
					}
					num++;
				}
				range2.EntireRow.Delete(System.Type.Missing);
				result = true;
			}
			return result;
		}

		private bool DataTablePrinterWithOutModel(System.Data.DataTable dt, System.Collections.Generic.Dictionary<string, string> titles)
		{
			bool result;
			if (dt == null)
			{
				result = false;
			}
			else
			{
				System.Data.DataTable dataTable = dt.Copy();
				if (titles != null && titles.Count > 0)
				{
					System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
					for (int i = 0; i < dataTable.Columns.Count; i++)
					{
						if (titles.ContainsKey(dataTable.Columns[i].ColumnName.ToUpper()))
						{
							dataTable.Columns[i].ColumnName = titles[dataTable.Columns[i].ColumnName].ToString();
						}
						else
						{
							list.Add(dataTable.Columns[i].ColumnName);
						}
					}
					foreach (string current in list)
					{
						dataTable.Columns.Remove(current);
					}
				}
				Range range = null;
				Range range2 = this.GetRange(out range);
				for (int i = 1; i <= dataTable.Columns.Count; i++)
				{
					this.sheet.Cells[2, i] = dataTable.Columns[i - 1].Caption;
				}
				int num = 3;
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					DataRow dataRow = dataTable.Rows[j];
					for (int i = 0; i < dataTable.Columns.Count; i++)
					{
						this.sheet.Cells[num, i + 1] = dataRow[i].ToString();
					}
					num++;
				}
				result = true;
			}
			return result;
		}

		private int GetFieldsCount(int CurrentRowIndex)
		{
			int num = 0;
			while (!string.IsNullOrEmpty((string)((Range)this.sheet.Cells[CurrentRowIndex, num + 1]).Text))
			{
				num++;
			}
			return num;
		}

		private Range GetRange(out Range TempRange)
		{
			TempRange = null;
			Range result;
			for (int i = 1; i < 10; i++)
			{
				Range rows = this.sheet.get_Range("A" + i.ToString(), "A" + i.ToString()).Rows;
				if (rows.Font.Color.ToString() == "255")
				{
					TempRange = this.sheet.get_Range("A" + (i + 1), "A" + (i + 1)).Rows;
					rows.EntireRow.Font.Color = 0;
					result = rows;
					return result;
				}
			}
			result = null;
			return result;
		}

		private void SaveAs(string saveAsPath)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(saveAsPath);
			if (fileInfo.Extension.ToLower().Equals(".pdf"))
			{
				base.ConvertToPdf(saveAsPath);
			}
			else if (fileInfo.Extension.ToLower().Contains(".xlsx"))
			{
				this.sheet.SaveAs(saveAsPath, this.missing, this.missing, this.missing, this.missing, this.missing, this.missing, this.missing, this.missing, this.missing);
			}
			else
			{
				this.sheet.SaveAs(saveAsPath, 56, this.missing, this.missing, this.missing, this.missing, this.missing, this.missing, this.missing, this.missing);
			}
		}

		public void ChangeDebuug(string file)
		{
			try
			{
				if (base.LoadSourceFile(file))
				{
					this.SaveAs(file);
				}
			}
			catch (System.Exception var_0_1D)
			{
			}
			finally
			{
				base.Dispose();
			}
		}
	}
}
