using Microsoft.Office.Interop.Graph;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Zxl.Printer;

namespace Zxl.Printer.Office
{
	public class WordPrinter : BaseGHPrinter, IChangeDebuug
	{
		private ApplicationClass WordApp;

		private Document WordDoc;

		private object missing = System.Reflection.Missing.Value;

		private string CurBookMark = "";

		private System.Collections.Generic.List<string> defFormatStr = new System.Collections.Generic.List<string>(new string[]
		{
			"TABLE",
			"TABLES",
			"TAB",
			"CHARTPIE",
			"CHARTLINE",
			"CHARTCOLUMN"
		});

		protected override bool doLoadSourceFile(string sourceFile)
		{
			this.WordApp = new ApplicationClass();
			this.WordApp.Visible = false;
			Documents arg_B1_0 = this.WordApp.Documents;
			object obj = sourceFile;
			object value = System.Reflection.Missing.Value;
			object value2 = System.Reflection.Missing.Value;
			object value3 = System.Reflection.Missing.Value;
			object value4 = System.Reflection.Missing.Value;
			object value5 = System.Reflection.Missing.Value;
			object value6 = System.Reflection.Missing.Value;
			object value7 = System.Reflection.Missing.Value;
			object value8 = System.Reflection.Missing.Value;
			object value9 = System.Reflection.Missing.Value;
			object value10 = System.Reflection.Missing.Value;
			object value11 = System.Reflection.Missing.Value;
			object value12 = System.Reflection.Missing.Value;
			object value13 = System.Reflection.Missing.Value;
			object value14 = System.Reflection.Missing.Value;
			object value15 = System.Reflection.Missing.Value;
			this.WordDoc = arg_B1_0.Open(ref obj, ref value, ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, ref value8, ref value9, ref value10, ref value11, ref value12, ref value13, ref value14, ref value15);
			this.WordDoc.Activate();
			return true;
		}

		protected override bool doLoadData(System.Collections.Hashtable data)
		{
			return true;
		}

		protected override bool doBuildFile(string saveAsFile)
		{
			this.SetWordValues(base.Data);
			this.SaveAs(saveAsFile);
			return true;
		}

		protected override bool doConvertToPdf(string saveAsFile)
		{
			WdExportFormat wdExportFormat = WdExportFormat.wdExportFormatPDF;
			_Document arg_20_0 = this.WordDoc;
			WdExportFormat arg_20_2 = wdExportFormat;
			bool arg_20_3 = false;
			WdExportOptimizeFor arg_20_4 = WdExportOptimizeFor.wdExportOptimizeForPrint;
			WdExportRange arg_20_5 = WdExportRange.wdExportAllDocument;
			int arg_20_6 = 1;
			int arg_20_7 = 1;
			WdExportItem arg_20_8 = WdExportItem.wdExportDocumentContent;
			bool arg_20_9 = false;
			bool arg_20_10 = true;
			WdExportCreateBookmarks arg_20_11 = WdExportCreateBookmarks.wdExportCreateNoBookmarks;
			bool arg_20_12 = true;
			bool arg_20_13 = true;
			bool arg_20_14 = false;
			object value = System.Reflection.Missing.Value;
			arg_20_0.ExportAsFixedFormat(saveAsFile, arg_20_2, arg_20_3, arg_20_4, arg_20_5, arg_20_6, arg_20_7, arg_20_8, arg_20_9, arg_20_10, arg_20_11, arg_20_12, arg_20_13, arg_20_14, ref value);
			return true;
		}

		protected override void doDispose()
		{
			try
			{
				if (this.WordApp != null)
				{
					object obj = false;
					this.WordApp.Application.Quit(ref obj, ref this.missing, ref this.missing);
				}
			}
			catch
			{
			}
			finally
			{
				if (this.WordApp != null)
				{
					this.WordApp = null;
				}
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
		}

		private void SetWordValues(System.Collections.Hashtable hsvalues)
		{
			object obj = 12;
			if (this.WordApp.ActiveDocument.Bookmarks.Count > 0)
			{
				System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
				foreach (Bookmark bookmark in this.WordApp.ActiveDocument.Bookmarks)
				{
					string text = "";
					if (!list.Contains(bookmark.Name))
					{
						list.Add(bookmark.Name);
						this.CurBookMark = bookmark.Name;
						string[] array = bookmark.Name.Split(new char[]
						{
							System.Convert.ToChar("：")
						});
						string text2 = Regex.Replace(array[0], "_\\d+$", "").ToUpper();
						string[] array2 = text2.Split(new char[]
						{
							System.Convert.ToChar("_")
						});
						string text3 = null;
						if (array2.Length > 1 && this.defFormatStr.Contains(array2[0]))
						{
							text3 = array2[0];
							text2 = text2.Replace(array2[0] + "_", "");
						}
						bookmark.Select();
						int num = this.WordDoc.Application.Selection.End - this.WordDoc.Application.Selection.Start;
						if (!string.IsNullOrEmpty(text2))
						{
							if (!string.IsNullOrEmpty(text3) && text3.ToUpper().Contains("CHART"))
							{
								this.SetChart(text3, text2, hsvalues[text2], bookmark);
							}
							else if (!string.IsNullOrEmpty(text3) && text3.ToUpper().Equals("TAB"))
							{
								System.Data.DataTable dataTable = hsvalues[text2] as System.Data.DataTable;
								if (dataTable != null)
								{
									foreach (DataRow dataRow in dataTable.Rows)
									{
										foreach (DataColumn column in dataTable.Columns)
										{
											if (dataRow[column] != null && !string.IsNullOrEmpty(dataRow[column].ToString()))
											{
												this.WordApp.Selection.TypeText(dataRow[column].ToString());
											}
											else
											{
												this.WordApp.Selection.TypeText("");
											}
											if (dataTable.Rows.IndexOf(dataRow) == dataTable.Rows.Count - 1 && dataTable.Columns.IndexOf(column) == dataTable.Columns.Count - 1)
											{
												break;
											}
											this.WordApp.Selection.MoveRight(ref obj, ref this.missing, ref this.missing);
											while (this.WordApp.Selection.Text != "\r\a")
											{
												this.WordApp.Selection.MoveRight(ref obj, ref this.missing, ref this.missing);
											}
										}
									}
								}
							}
							else if (!string.IsNullOrEmpty(text3) && text3.ToUpper().Equals("TABLE"))
							{
								this.SetDataTableToWord(bookmark, hsvalues[text2]);
							}
							else if (!string.IsNullOrEmpty(text3) && text3.ToUpper().Equals("TABLES"))
							{
								this.WordApp.Application.Selection.Start = bookmark.Start;
								this.WordApp.Application.Selection.End = bookmark.End;
								this.WordApp.Application.Selection.Copy();
								System.Collections.Generic.List<System.Data.DataTable> list2 = hsvalues[text2] as System.Collections.Generic.List<System.Data.DataTable>;
								bool flag = true;
								Bookmark bookmark2 = null;
								foreach (System.Data.DataTable dataTable in list2)
								{
									if (flag)
									{
										this.SetDataTableToWord(bookmark, dataTable);
										flag = false;
										foreach (Bookmark bookmark3 in this.WordApp.ActiveDocument.Bookmarks)
										{
											if (bookmark3.Name.Equals(dataTable.TableName + "_TITLE"))
											{
												bookmark2 = bookmark3;
												break;
											}
										}
									}
									else
									{
										object obj2 = 14;
										object obj3 = WdUnits.wdLine;
										this.WordApp.Selection.MoveDown(ref obj3, ref obj2, ref this.missing);
										object obj4 = hsvalues.ContainsKey(dataTable.TableName + "_TITLE") ? hsvalues[dataTable.TableName + "_TITLE"] : "";
										int end = this.WordApp.Selection.End;
										this.WordApp.Selection.TypeText(obj4.ToString());
										this.WordApp.Selection.Start = end;
										if (bookmark2 != null)
										{
											this.WordApp.Selection.Font = bookmark2.Range.Font;
											this.WordApp.Selection.ParagraphFormat = bookmark2.Range.ParagraphFormat;
										}
										this.WordApp.Selection.Start = this.WordApp.Selection.End;
										this.WordApp.Application.Selection.Paste();
										Bookmark bookmark4 = this.WordApp.ActiveDocument.Tables[this.WordApp.ActiveDocument.Tables.Count].Range.Bookmarks.Add("TABLE_" + dataTable.TableName, ref this.missing);
										this.SetDataTableToWord(bookmark4, dataTable);
									}
								}
							}
							else
							{
								object value = null;
								text3 = bookmark.Range.Text;
								if (!string.IsNullOrEmpty(bookmark.Range.Text) && bookmark.Range.Text.Contains("."))
								{
									string[] array3 = bookmark.Range.Text.Split("|".ToCharArray());
									text = array3[0];
									if (array3.Length == 2)
									{
										text3 = array3[1];
									}
									array3 = text.Split(".".ToCharArray());
									if (array3.Length == 2)
									{
										value = this.GetTabValue(hsvalues, array3[0], array3[1]);
										text = this.GetBookmarkValue(bookmark, value);
										text2 = array3[1];
									}
								}
								else if (hsvalues.ContainsKey(text2))
								{
									value = hsvalues[text2];
									text = this.GetBookmarkValue(bookmark, value);
								}
								if (!string.IsNullOrEmpty(text3) && (text3.Equals("□") || text3.Equals("×")))
								{
									this.SetBookmarkCheckBoxValue(bookmark.Range, value, text3);
								}
								else
								{
									if (!string.IsNullOrEmpty(text3))
									{
										text3 = text3.Replace("\r", "").Trim();
										text = DigitToChnText.ChnTextOperator.GetFormatValue(text, text3);
									}
									if (string.IsNullOrEmpty(text))
									{
										try
										{
											bookmark.End = bookmark.Start;
										}
										catch
										{
										}
										this.WordDoc.Application.Selection.Text = "";
									}
									else if (bookmark.Range.Text != null && bookmark.Range.Text.Contains("\r\a"))
									{
										bookmark.Range.Text = text;
									}
									else
									{
										bookmark.Range.InsertBefore(text);
										try
										{
											this.WordDoc.Application.Selection.Start = this.WordDoc.Application.Selection.End - num;
											this.WordDoc.Application.Selection.Text = "";
											if (bookmark.Start == bookmark.End)
											{
												bookmark.End += text.Length;
											}
										}
										catch
										{
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private object GetTabValue(System.Collections.Hashtable hs, string tabName, string fieldName)
		{
			object result;
			if (hs.Contains(tabName))
			{
				if (!(hs[tabName] is System.Data.DataTable))
				{
					result = hs[tabName];
					return result;
				}
				System.Data.DataTable dataTable = hs[tabName] as System.Data.DataTable;
				if (dataTable.Columns.Contains(fieldName.ToUpper()) && dataTable.Rows.Count > 0)
				{
					result = dataTable.Rows[0][fieldName.ToUpper()];
					return result;
				}
			}
			result = null;
			return result;
		}

		private void SetChart(string formatStr, string Name, object value, Bookmark tempBookmark)
		{
			try
			{
				if (value != null)
				{
					XlChartType xlChartType = XlChartType.xlColumnClustered;
					if (formatStr != null)
					{
						if (!(formatStr == "CHARTLINE"))
						{
							if (formatStr == "CHARTPIE")
							{
								xlChartType = XlChartType.xl3DPieExploded;
							}
						}
						else
						{
							xlChartType = XlChartType.xlLine;
						}
					}
					System.Data.DataTable dataTable = value as System.Data.DataTable;
					object obj = "MSGraph.Chart.8";
					Microsoft.Office.Interop.Word.Range range = tempBookmark.Range;
					InlineShape inlineShape = range.InlineShapes.AddOLEObject(ref obj, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing);
					if (tempBookmark.Range.Cells.Count == 1)
					{
						inlineShape.Width = tempBookmark.Range.Cells[1].Width - 20f;
						inlineShape.Height = tempBookmark.Range.Cells[1].Height;
					}
					object @object = inlineShape.OLEFormat.Object;
					object obj2 = @object.GetType().InvokeMember("Application", System.Reflection.BindingFlags.GetProperty, null, @object, null);
					object[] args = new object[]
					{
						4
					};
					@object.GetType().InvokeMember("ChartType", System.Reflection.BindingFlags.SetProperty, null, @object, args);
					Microsoft.Office.Interop.Graph.Chart chart = (Microsoft.Office.Interop.Graph.Chart)inlineShape.OLEFormat.Object;
					chart.ChartType = xlChartType;
					chart.HasTitle = true;
					chart.ChartTitle.Text = dataTable.TableName;
					chart.PlotArea.Interior.Color = Color.White;
					if (!string.IsNullOrEmpty(dataTable.TableName))
					{
						chart.ChartTitle.Font.Size = 12;
					}
					DataSheet dataSheet = chart.Application.DataSheet;
					dataSheet.Columns.Clear();
					dataSheet.Rows.Clear();
					foreach (DataColumn dataColumn in dataTable.Columns)
					{
						dataSheet.Cells[1, dataTable.Columns.IndexOf(dataColumn) + 1] = dataColumn.ColumnName;
					}
					foreach (DataRow dataRow in dataTable.Rows)
					{
						foreach (DataColumn dataColumn in dataTable.Columns)
						{
							if (dataRow[dataColumn] == System.DBNull.Value)
							{
								dataRow[dataColumn] = "";
							}
							dataSheet.Cells[dataTable.Rows.IndexOf(dataRow) + 2, dataTable.Columns.IndexOf(dataColumn) + 1] = dataRow[dataColumn];
						}
					}
					if (xlChartType != XlChartType.xl3DPieExploded)
					{
						chart.Legend.Position = Microsoft.Office.Interop.Graph.XlLegendPosition.xlLegendPositionTop;
						for (int i = 1; i <= dataTable.Rows.Count; i++)
						{
							Microsoft.Office.Interop.Graph.Series series = (Microsoft.Office.Interop.Graph.Series)chart.SeriesCollection(i);
							series.HasDataLabels = true;
							Color chartColor = this.GetChartColor(i);
							if (chartColor != Color.Empty)
							{
								series.Interior.Color = chartColor;
							}
							else
							{
								series.Interior.ColorIndex = 15 + i;
							}
						}
					}
					else
					{
						chart.HasLegend = false;
						Microsoft.Office.Interop.Graph.Series series = (Microsoft.Office.Interop.Graph.Series)chart.SeriesCollection(1);
						series.HasDataLabels = true;
						series.HasLeaderLines = true;
					}
					chart.Application.Update();
					obj2.GetType().InvokeMember("Update", System.Reflection.BindingFlags.InvokeMethod, null, obj2, null);
					obj2.GetType().InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, obj2, null);
				}
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("图表[" + tempBookmark.Name + "]数据加载出错：" + ex.Message);
			}
		}

		private Color GetChartColor(int i)
		{
			Color result;
			switch (i)
			{
			case 1:
				result = ColorTranslator.FromHtml("#4572a7");
				break;
			case 2:
				result = ColorTranslator.FromHtml("#aa4643");
				break;
			case 3:
				result = ColorTranslator.FromHtml("#89a54e");
				break;
			case 4:
				result = ColorTranslator.FromHtml("#71588f");
				break;
			case 5:
				result = ColorTranslator.FromHtml("#4198af");
				break;
			case 6:
				result = ColorTranslator.FromHtml("#db843d");
				break;
			case 7:
				result = ColorTranslator.FromHtml("#93a9cf");
				break;
			case 8:
				result = ColorTranslator.FromHtml("#d19392");
				break;
			case 9:
				result = ColorTranslator.FromHtml("#b9cd96");
				break;
			case 10:
				result = ColorTranslator.FromHtml("#a99bbd");
				break;
			default:
				result = Color.Empty;
				break;
			}
			return result;
		}

		private void SetDataTableToWord(Bookmark bookmark, object table)
		{
			try
			{
				System.Data.DataTable dataTable = null;
				if (table != null)
				{
					dataTable = (table as System.Data.DataTable);
				}
				else
				{
					dataTable = new System.Data.DataTable();
				}
				Table table2 = bookmark.Range.Tables[1];
				int num = bookmark.Range.Cells[1].RowIndex;
				Cells cells = bookmark.Range.Cells;
				if (bookmark.Range.Rows.Count > 1)
				{
					try
					{
						cells = bookmark.Range.Rows.Last.Cells;
						num = bookmark.Range.Rows.Last.Index;
					}
					catch
					{
						throw new System.Exception("表格有纵向合并的单元格，书签定义时请只选中列头一行！");
					}
				}
				System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
				for (int i = 1; i <= cells.Count; i++)
				{
					if (cells[i].Range.Text != "\r\a")
					{
						string value = Regex.Replace(cells[i].Range.Text, "\r\a", "");
						dictionary.Add(i, value);
					}
					cells[i].Range.Text = "";
				}
				if (dataTable.Rows.Count > 1)
				{
					object obj = dataTable.Rows.Count - 1;
					this.WordApp.Selection.InsertRows(ref obj);
				}
				foreach (DataRow dataRow in dataTable.Rows)
				{
					foreach (System.Collections.Generic.KeyValuePair<int, string> current in dictionary)
					{
						string text = current.Value;
						string text2 = "";
						string text3 = "";
						string[] array = text.Split("|".ToCharArray());
						if (array.Length == 2)
						{
							text = array[0];
							text2 = array[1];
							if (dataRow.Table.Columns.Contains(text) && dataRow[text] != null)
							{
								text3 = DigitToChnText.ChnTextOperator.GetFormatValue(dataRow[text].ToString(), text2);
							}
						}
						else if (dataRow.Table.Columns.Contains(text) && dataRow[text] != null)
						{
							text3 = dataRow[text].ToString();
						}
						if (text2.Equals("□") || text2.Equals("×"))
						{
							this.SetBookmarkCheckBoxValue(table2.Cell(num, current.Key).Range, text3, text2);
						}
						else
						{
							table2.Cell(num, current.Key).Range.Text = text3;
						}
					}
					num++;
				}
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("子表[" + bookmark.Name + "]数据加载出错：" + ex.Message);
			}
		}

		private void SetBookmarkCheckBoxValue(Microsoft.Office.Interop.Word.Range range, object value, string type)
		{
			object obj = "Wingdings 2";
			object unicode = System.Text.Encoding.Unicode;
			object obj2 = true;
			if (type.Equals("□") && range.Text == "\r\a")
			{
				range.SetRange(range.Start, range.Start);
			}
			if (value != null && !string.IsNullOrEmpty(value.ToString()) && !value.ToString().Equals("0"))
			{
				if (type.Equals("□"))
				{
					range.InsertSymbol(-4014, ref obj, ref obj2, ref this.missing);
				}
				else
				{
					range.Text = "√";
				}
			}
			else if (type.Equals("□"))
			{
				range.InsertSymbol(-3933, ref obj, ref obj2, ref this.missing);
			}
			else
			{
				range.Text = "×";
			}
		}

		private string GetBookmarkValue(Bookmark tempBookmark, object value)
		{
			string result;
			if (!string.IsNullOrEmpty(tempBookmark.Range.Text) && tempBookmark.Range.Text.Equals("√", System.StringComparison.OrdinalIgnoreCase))
			{
				if (value != null && !string.IsNullOrEmpty(value.ToString()))
				{
					result = "√";
				}
				else
				{
					result = " ";
				}
			}
			else if (value == null)
			{
				result = "";
			}
			else if (value.ToString() == "")
			{
				result = "";
			}
			else
			{
				if (value.ToString().Equals("0.00", System.StringComparison.OrdinalIgnoreCase))
				{
					value = "0";
				}
				value = Regex.Replace(value.ToString(), "0:00:00", "");
				result = value.ToString();
			}
			return result;
		}

		private void SaveAs(string SaveAsPath)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(SaveAsPath);
			if (fileInfo.Extension.ToLower().Equals(".pdf"))
			{
				base.ConvertToPdf(SaveAsPath);
			}
			else
			{
				object obj = SaveAsPath;
				_Document arg_C9_0 = this.WordApp.ActiveDocument;
				object value = System.Reflection.Missing.Value;
				object value2 = System.Reflection.Missing.Value;
				object value3 = System.Reflection.Missing.Value;
				object value4 = System.Reflection.Missing.Value;
				object value5 = System.Reflection.Missing.Value;
				object value6 = System.Reflection.Missing.Value;
				object value7 = System.Reflection.Missing.Value;
				object value8 = System.Reflection.Missing.Value;
				object value9 = System.Reflection.Missing.Value;
				object value10 = System.Reflection.Missing.Value;
				object value11 = System.Reflection.Missing.Value;
				object value12 = System.Reflection.Missing.Value;
				object value13 = System.Reflection.Missing.Value;
				object value14 = System.Reflection.Missing.Value;
				object value15 = System.Reflection.Missing.Value;
				arg_C9_0.SaveAs(ref obj, ref value, ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, ref value8, ref value9, ref value10, ref value11, ref value12, ref value13, ref value14, ref value15);
			}
		}

		public void ChangeDebuug(string file)
		{
			try
			{
				if (base.LoadSourceFile(file))
				{
					this.WordApp.ActiveDocument.ActiveWindow.View.Type = WdViewType.wdPrintView;
					this.WordApp.ActiveDocument.ActiveWindow.ActivePane.View.Type = WdViewType.wdPrintView;
					object obj = file;
					object obj2 = WdSaveFormat.wdFormatDocumentDefault;
					_Document arg_E8_0 = this.WordApp.ActiveDocument;
					object value = System.Reflection.Missing.Value;
					object value2 = System.Reflection.Missing.Value;
					object value3 = System.Reflection.Missing.Value;
					object value4 = System.Reflection.Missing.Value;
					object value5 = System.Reflection.Missing.Value;
					object value6 = System.Reflection.Missing.Value;
					object value7 = System.Reflection.Missing.Value;
					object value8 = System.Reflection.Missing.Value;
					object value9 = System.Reflection.Missing.Value;
					object value10 = System.Reflection.Missing.Value;
					object value11 = System.Reflection.Missing.Value;
					object value12 = System.Reflection.Missing.Value;
					object value13 = System.Reflection.Missing.Value;
					object value14 = System.Reflection.Missing.Value;
					arg_E8_0.SaveAs(ref obj, ref obj2, ref value, ref value2, ref value3, ref value4, ref value5, ref value6, ref value7, ref value8, ref value9, ref value10, ref value11, ref value12, ref value13, ref value14);
				}
			}
			catch (System.Exception var_2_F2)
			{
			}
			finally
			{
				base.Dispose();
			}
		}
	}
}
