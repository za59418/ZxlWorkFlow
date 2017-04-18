using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using Zxl.Printer.Office;

namespace Zxl.Printer
{
	public class HtmlPrinter : BaseGHPrinter
	{
		private const string WordSplitPageString = "<span lang=EN-US style='font-size:10.5pt;font-family:\"Calibri\",\"sans-serif\"'><br clear=all style='page-break-before:always'></span>";

		private string fileString = null;

        //分页务打印
        private string multiFileString = null;

		private string tempReportTableString = null;

		private string ConstTdString = null;

		private bool isDefaultModel = false;

		public string ImgUrl = "";

		public string ImgType = ".png";

		private bool isLandscape = false;

		public HtmlPrinter()
		{
			this.ImgUrl = ConfigurationSettings.AppSettings["IMGURL"];
			this.ImgType = ConfigurationSettings.AppSettings["IMGTYPE"];
		}

		protected override bool doLoadSourceFile(string sourceFile)
		{
			this.GetFileString(sourceFile);
			this.tempReportTableString = this.GetReportMainTableString(this.fileString);
			return true;
		}

		protected override bool doLoadData(System.Collections.Hashtable data)
		{
			if (data.ContainsKey("ISLANDSCAPE"))
			{
				this.isLandscape = System.Convert.ToBoolean(data["ISLANDSCAPE"]);
			}
			return true;
		}

		protected override bool doBuildFile(string saveAsFile)
		{
			this.fileString = this.ReplaceValuesString(this.fileString, base.Data);
            this.multiFileString = this.ReplaceMultiValuesString(this.fileString, base.Data); ;
			foreach (System.Collections.DictionaryEntry dictionaryEntry in base.Data)
			{
				if (dictionaryEntry.Value is DataTable)
				{
					this.fileString = this.ReplaceSourceString(this.fileString, dictionaryEntry.Value as DataTable, null, "1", "1");
				}
			}
			if (this.isLandscape)
			{
				this.fileString = this.SetLandscapeString(this.fileString);
			}
			this.SaveAs(saveAsFile);
			return true;
		}

		protected override bool doConvertToPdf(string saveAsFile)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(saveAsFile);
			string sourceFile = saveAsFile.Replace(fileInfo.Extension, ".doc");
            WordPrinter wrodPrinter = new WordPrinter();
			bool result;
			try
			{
				if (wrodPrinter.LoadSourceFile(sourceFile))
				{
					wrodPrinter.ConvertToPdf(saveAsFile);
					result = true;
					return result;
				}
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			finally
			{
				wrodPrinter.Dispose();
			}
			result = false;
			return result;
		}

		protected override void doDispose()
		{
		}

		private void GetFileString(string sourceFile)
		{
			this.isDefaultModel = false;
			this.fileString = System.IO.File.ReadAllText(sourceFile, System.Text.Encoding.Default);
			this.fileString = this.ReplaceTemp(this.fileString);
			if (sourceFile.Equals("Model."))
			{
				this.isDefaultModel = true;
			}
		}

		private string ReplaceTemp(string inputString)
		{
			inputString = inputString.Replace("＿", "_");
			string pattern = "＄｛([^＄｛｝]+)｝";
			string pattern2 = "＄［([^＄［］]+)］";
			MatchCollection matchCollection = Regex.Matches(inputString, pattern);
			if (matchCollection != null && matchCollection.Count > 0)
			{
				foreach (Match match in matchCollection)
				{
					inputString = inputString.Replace(match.Value, this.ReplaceAZ09(match.Value, true));
				}
			}
			matchCollection = Regex.Matches(inputString, pattern2);
			if (matchCollection != null && matchCollection.Count > 0)
			{
				foreach (Match match in matchCollection)
				{
					inputString = inputString.Replace(match.Value, this.ReplaceAZ09(match.Value, false));
				}
			}
			return inputString;
		}

		private string ReplaceAZ09(string inputString, bool type)
		{
			if (type)
			{
				inputString = inputString.Replace("＄｛", "${");
				inputString = inputString.Replace("｝", "}");
			}
			else
			{
				inputString = inputString.Replace("＄［", "$[");
				inputString = inputString.Replace("］", "]");
			}
			inputString = DigitToChnText.ChnTextOperator.ToDBC(inputString);
			return inputString;
		}

		public string ReplaceValuesString(string inputString, System.Collections.Hashtable values)
		{
			string regString = "\\$\\{([^\\$\\{\\}]+)\\}";
			return this.ReplaceValuesString(inputString, values, regString);
		}

        public string ReplaceMultiValuesString(string inputString, System.Collections.Hashtable values)
        {
            return null;
        }

		public string ReplaceValuesString(string inputString, System.Collections.Hashtable tempValues, string regString)
		{
			string str = "";
			MatchCollection matchCollection = Regex.Matches(inputString, regString);
			if (matchCollection != null && matchCollection.Count > 0)
			{
				try
				{
					System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
					foreach (Match match in matchCollection)
					{
						str = match.Value;
						string matchValue = this.GetMatchValue(match.Value, tempValues, regString, inputString, this.GetMatchIndex(match.Value, inputString));
						if (matchValue != null && matchValue.Equals("&HIDE&"))
						{
							int num = inputString.IndexOf(match.Value);
							if (num >= 0)
							{
								string oldValue = inputString.Substring(num, inputString.IndexOf(match.Value, num + 1) + match.Value.Length - num);
								inputString = inputString.Replace(oldValue, "");
							}
						}
						else
						{
							inputString = inputString.Replace(match.Value, matchValue);
							if (!string.IsNullOrEmpty(matchValue))
							{
								list.Add(matchValue);
							}
						}
					}
					string pattern = "\\$SUM\\[ROW\\]";
					Match match2 = Regex.Match(inputString, pattern);
					if (match2 != null && match2.Length > 0)
					{
						inputString = inputString.Replace(match2.Value, this.GetSumValue(list));
					}
				}
				catch (System.Exception ex)
				{
					throw new System.Exception("[" + str + "]数据加载出错：" + ex.Message);
				}
			}
			return inputString;
		}

		private string GetMatchValue(string fieldName, System.Collections.Hashtable values, string regString, string inputString, int index)
		{
			string result;
			if (index < 0)
			{
				result = null;
			}
			else
			{
				bool flag = true;
				string text = "";
				string text2 = null;
				bool flag2 = fieldName.Contains("_HTML");
				if (flag2)
				{
					fieldName = fieldName.Replace("_HMTL", "");
				}
				fieldName = Regex.Replace(fieldName, regString, "$1");
				if (fieldName.Contains("|"))
				{
					string[] array = fieldName.Split("|".ToCharArray());
					if (array != null && array.Length == 2)
					{
						fieldName = array[0];
						text2 = array[1];
					}
				}
				if (fieldName.Contains("."))
				{
					string[] array = fieldName.Split(".".ToCharArray());
					if (array != null && array.Length == 2)
					{
						fieldName = array[1];
					}
				}
				fieldName = fieldName.ToUpper();
				if (values.ContainsKey(fieldName) && values[fieldName] != null)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						text = this.GetFormatValue(values[fieldName].ToString(), text2);
						flag = false;
					}
					else
					{
						text = values[fieldName].ToString();
					}
				}
				if (flag)
				{
					text = Regex.Replace(text, "\\r\\n|\\n", "\r");
					text = text.Replace(" ", "&nbsp;");
					text = text.Replace("<", "&lt;");
					text = text.Replace(">", "&gt;");
				}
				if (text.Contains("\r"))
				{
					string text3 = inputString.Substring(0, index);
					string text4 = inputString.Substring(index);
					string text5 = null;
					string text6 = null;
					bool flag3 = false;
					if (text3.LastIndexOf("<span") > text3.LastIndexOf("<p"))
					{
						text5 = inputString.Substring(text3.LastIndexOf("<span"));
						text5 = text5.Substring(0, text5.IndexOf("</span>") + "</span>".Length);
						flag3 = true;
						if (text3.LastIndexOf("<p") >= 0)
						{
							text6 = inputString.Substring(text3.LastIndexOf("<p"));
							text6 = text6.Substring(0, text6.IndexOf(">") + ">".Length);
						}
						else
						{
							text6 = "<br>";
						}
					}
					else if (text3.LastIndexOf("<p") >= 0)
					{
						text5 = inputString.Substring(text3.LastIndexOf("<p"));
						text5 = text5.Substring(0, text5.IndexOf("</p>") + "</p>".Length);
					}
					string[] array2 = text.Split("\r".ToCharArray());
					text = "";
					if (string.IsNullOrEmpty(text5))
					{
						if (regString.Equals("\\$\\[([^\\$]+)\\]"))
						{
							text5 = string.Format("{0}<br>", "$[" + fieldName + "]");
						}
						else
						{
							text5 = string.Format("{0}<br>", "${" + fieldName + "}");
						}
					}
					bool flag4 = true;
					string[] array3 = array2;
					for (int i = 0; i < array3.Length; i++)
					{
						string value = array3[i];
						System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
						hashtable.Add(fieldName, value);
						if (string.IsNullOrEmpty(value))
						{
							hashtable[fieldName] = "&nbsp;";
						}
						if (!flag4 && flag3)
						{
							text = text + text6 + this.ReplaceValuesString(text5, hashtable, regString);
							if (!text6.Equals("<br>"))
							{
								text += "</p>";
							}
						}
						else
						{
							text += this.ReplaceValuesString(text5, hashtable, regString);
						}
						flag4 = false;
					}
				}
				result = text;
			}
			return result;
		}

		private string GetFormatValue(string value, string formatStr)
		{
			string text = formatStr.ToUpper();
			string result;
			if (text.Contains("CHECKBOX"))
			{
				int num = formatStr.IndexOf("[") + 1;
				string[] array = formatStr.Substring(num, formatStr.IndexOf("]") - num).Split(",".ToCharArray());
				if (array != null && array.Length == 2 && value.Equals(array[0]))
				{
					result = "<span lang=EN-US style='font-family:Wingdings'>&thorn;</span>";
				}
				else
				{
					result = "<span lang=EN-US style='font-family:Wingdings'>o</span>";
				}
			}
			else if (text.Contains("HIDE"))
			{
				int num = formatStr.IndexOf("[") + 1;
				string[] array = formatStr.Substring(num, formatStr.IndexOf("]") - num).Split(",".ToCharArray());
				if (array != null && array.Length == 2)
				{
					if (array[0].Equals("NULL"))
					{
						if (!string.IsNullOrEmpty(value))
						{
							result = "";
							return result;
						}
						result = "&HIDE&";
						return result;
					}
					else if (value.Equals(array[0]))
					{
						result = "&HIDE&";
						return result;
					}
				}
				result = "";
			}
			else
			{
				if (text.Equals("IMG"))
				{
					if (!string.IsNullOrEmpty(value))
					{
						result = "<img src='" + value + "' </img>";
						return result;
					}
				}
				else
				{
					if (!text.Equals("IMG2"))
					{
						result = DigitToChnText.ChnTextOperator.GetFormatValue(value, formatStr);
						return result;
					}
					if (!string.IsNullOrEmpty(value))
					{
						result = string.Concat(new string[]
						{
							"<img src='",
							this.ImgUrl,
							value,
							this.ImgType,
							"' </img>"
						});
						return result;
					}
				}
				result = value;
			}
			return result;
		}

		private string SetColumnSumValue(string inputString, object source)
		{
			string result;
			if (source == null)
			{
				result = inputString;
			}
			else
			{
				DataTable dataTable = source as DataTable;
				string pattern = "\\$SUM\\[([^\\$\\[\\]]+)\\]";
				MatchCollection matchCollection = Regex.Matches(inputString, pattern);
				if (matchCollection != null && matchCollection.Count > 0)
				{
					foreach (Match match in matchCollection)
					{
						string text = Regex.Replace(match.Value, pattern, "$1");
						if (!string.IsNullOrEmpty(text) && dataTable.Columns.Contains(text))
						{
							System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
							foreach (DataRow dataRow in dataTable.Rows)
							{
								if (dataRow[text] != null && !string.IsNullOrEmpty(dataRow[text].ToString()))
								{
									list.Add(dataRow[text].ToString());
								}
							}
							inputString = inputString.Replace(match.Value, this.GetSumValue(list));
						}
					}
				}
				result = inputString;
			}
			return result;
		}

		private string SetTableCountValue(string inputString, object source)
		{
			int num = 0;
			if (source != null)
			{
				DataTable dataTable = source as DataTable;
				if (dataTable.Rows.Count > 0)
				{
					num = dataTable.Rows.Count;
				}
				string pattern = "\\$COUNT\\[" + dataTable.TableName + "\\]";
				MatchCollection matchCollection = Regex.Matches(inputString, pattern);
				if (matchCollection != null && matchCollection.Count > 0)
				{
					foreach (Match match in matchCollection)
					{
						inputString = inputString.Replace(match.Value, num.ToString());
					}
				}
			}
			return inputString;
		}

		private string GetSumValue(System.Collections.Generic.List<string> values)
		{
			decimal d = 0m;
			string result;
			try
			{
				foreach (string current in values)
				{
					decimal d2 = System.Convert.ToDecimal(current);
					d += d2;
				}
			}
			catch
			{
				result = "值类型无法计算!";
				return result;
			}
			if (d > 0m)
			{
				result = d.ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		private string SetDefaultRow(object source)
		{
			string text = "";
			if (source != null)
			{
				DataTable dataTable = source as DataTable;
				text += "<tr class=xl23>";
				string format = " style='width:{0}px' ";
				foreach (DataColumn dataColumn in dataTable.Columns)
				{
					text += "<td class=xl23";
					if (!string.IsNullOrEmpty(dataColumn.Caption))
					{
						text += string.Format(format, System.Convert.ToInt32(dataColumn.Caption) + 5);
					}
					text += ">";
					text += dataColumn.ColumnName;
					text += "</td>";
				}
				text += "</tr>";
				foreach (DataRow dataRow in dataTable.Rows)
				{
					text += "<tr class=xl23>";
					foreach (DataColumn dataColumn in dataTable.Columns)
					{
						text += "<td class=xl23>";
						string str = "";
						if (dataRow[dataColumn] != null)
						{
							if (dataColumn.DataType == typeof(System.DateTime))
							{
								if (string.IsNullOrEmpty(dataRow[dataColumn].ToString()))
								{
									str = " ";
								}
								else
								{
									str = System.Convert.ToDateTime(dataRow[dataColumn]).ToShortDateString();
								}
							}
							else
							{
								str = dataRow[dataColumn].ToString();
							}
						}
						text += str;
						text += "</td>";
					}
					text += "</tr>";
				}
			}
			return text;
		}

		private bool CheckChildTableString(Match match, string tableKey)
		{
			string pattern = "\\$\\[([^\\$]+)\\]";
			string text = Regex.Replace(match.Value, pattern, "$1");
			return !text.Contains(".") || text.Split(".".ToCharArray())[0].Equals(tableKey);
		}

		private int GetMatchIndex(string value, string inputString)
		{
			return inputString.IndexOf(value);
		}

		private string GetReportMainTableString(string inputString)
		{
			string text = null;
			string pattern = "<(table)[^<]*>((?!<table).)+</\\1>";
			string input = Regex.Replace(inputString, "\\r\\n|\\n", "{ENTER}");
			MatchCollection matchCollection = Regex.Matches(input, pattern);
			if (matchCollection != null && matchCollection.Count > 0)
			{
				foreach (Match match in matchCollection)
				{
					if (match.Value.Contains("ROWCOUNT"))
					{
						text = match.Value;
					}
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace("{ENTER}", "\r\n");
			}
			return text;
		}

		public string ReplaceSourceString(string inputString, DataTable source, string orderbyKey, string pageIndex, string pageCount)
		{
			inputString = Regex.Replace(inputString, "{PageIndex}", pageIndex);
			string pattern = "<(tr)[^<]*>((?!<tr).)+</\\1>";
			inputString = Regex.Replace(inputString, "\\r\\n|\\n", "{ENTER}");
			MatchCollection matchCollection = Regex.Matches(inputString, pattern);
			decimal num = 0m;
			decimal num2 = 0m;
			decimal d = 0m;
			if (source != null)
			{
				d = source.Rows.Count;
			}
			if (matchCollection != null && matchCollection.Count > 0)
			{
				foreach (Match match in matchCollection)
				{
					string text = "\\$\\[([^\\$]+)\\]";
					MatchCollection matchCollection2 = Regex.Matches(match.Value, text);
					if (matchCollection2 != null && matchCollection2.Count > 0)
					{
						if (!this.CheckChildTableString(matchCollection2[0], source.TableName))
						{
							continue;
						}
						this.isDefaultModel = false;
						decimal rowCount = this.GetRowCount(match.Value);
						if (num == 0m)
						{
							num = this.GetDefCount(match.Value);
						}
						string oldValue = match.Value;
						if (rowCount > 0m)
						{
							System.Collections.Generic.List<DataTable> splitTableDataList = this.GetSplitTableDataList(System.Convert.ToInt32(rowCount), source);
							oldValue = this.GetRowCountReplaceValue(inputString, match.Value, matchCollection, rowCount);
							if (splitTableDataList.Count > 1)
							{
								pageCount = splitTableDataList.Count.ToString();
								source = splitTableDataList[0];
								splitTableDataList.Remove(splitTableDataList[0]);
								inputString = this.InsertTableDataString(inputString, this.tempReportTableString, splitTableDataList);
							}
						}
						string sourceString = this.GetSourceString(match.Value, source, text, num);
						inputString = inputString.Replace(oldValue, sourceString);
					}
					if (num > 0m && num2 < d)
					{
						if (num2 > 0m)
						{
							string newValue = this.SetConstTdString(match.Value, source.Rows[System.Convert.ToInt32(num2)], text);
							inputString = inputString.Replace(match.Value, newValue);
						}
						num2 = ++num2;
					}
				}
				inputString = this.SetColumnSumValue(inputString, source);
				inputString = this.SetTableCountValue(inputString, source);
				if (this.isDefaultModel && matchCollection.Count > 0)
				{
					string newValue2 = this.SetDefaultRow(source);
					inputString = inputString.Replace(matchCollection[0].Value, newValue2);
				}
				inputString = inputString.Replace("border-top:none;", "");
				inputString = inputString.Replace("border-bottom:none;", "");
			}
			inputString = inputString.Replace("[START]", "");
			inputString = inputString.Replace("[END]", "");
			inputString = inputString.Replace("{ENTER}", "\r\n");
			inputString = Regex.Replace(inputString, "{PageCount}", pageCount);
			return inputString;
		}

		private string SetTableBoder(string trString)
		{
			int num = trString.IndexOf("border:");
			if (num >= 0)
			{
				string text = trString.Substring(num + "border:".Length);
				text = text.Substring(0, text.IndexOf(";"));
				if (text != "none")
				{
					trString = trString.Replace("none", text);
				}
			}
			return trString;
		}

		private string SetLandscapeString(string inputString)
		{
			int num = inputString.IndexOf("{size");
			if (num > 0)
			{
				inputString = inputString.Insert(num + 1, "mso-page-orientation:landscape;");
			}
			return inputString;
		}

		private decimal GetRowCount(string rowString)
		{
			Match match = Regex.Match(rowString, "ROWCOUNT_\\d+");
			decimal result;
			if (match != null && !string.IsNullOrEmpty(match.Value))
			{
				result = System.Convert.ToDecimal(match.Value.Replace("ROWCOUNT_", ""));
			}
			else
			{
				result = 0m;
			}
			return result;
		}

		private decimal GetDefCount(string rowString)
		{
			Match match = Regex.Match(rowString, "CONST_\\d+");
			decimal result;
			if (match != null && !string.IsNullOrEmpty(match.Value))
			{
				result = System.Convert.ToDecimal(match.Value.Replace("CONST_", ""));
			}
			else
			{
				result = 0m;
			}
			return result;
		}

		private string SetConstTdString(string rowString, DataRow row, string regString)
		{
			string pattern = "<(td)[^<]*>((?!<td).)+</\\1>";
			MatchCollection matchCollection = Regex.Matches(rowString, pattern);
			string result;
			if (matchCollection != null && matchCollection.Count > 0)
			{
				int num = -1;
				int num2 = -1;
				for (int i = 0; i < matchCollection.Count; i++)
				{
					if (matchCollection[i].Value.Contains("[START]"))
					{
						num = matchCollection[i].Index;
					}
					else if (matchCollection[i].Value.Contains("[END]"))
					{
						num2 = matchCollection[i].Index + matchCollection[i].Value.Length;
					}
					if (num > 0 && num2 > 0)
					{
						string oldValue = rowString.Substring(num, num2 - num);
						rowString = rowString.Replace(oldValue, this.ConstTdString);
						DataTable dataTable = row.Table.Clone();
						dataTable.Rows.Add(row.ItemArray);
						result = this.GetSourceString(rowString, dataTable, regString, 0m);
						return result;
					}
				}
			}
			result = rowString;
			return result;
		}

		private string GetRowCountReplaceValue(string inputString, string startRowString, MatchCollection matchs, decimal rowCount)
		{
			string result = null;
			string text = null;
			for (int i = 0; i < matchs.Count; i++)
			{
				if (matchs[i].Value.Equals(startRowString))
				{
					text = matchs[i + System.Convert.ToInt32(rowCount) - 1].Value;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				int num = inputString.IndexOf(startRowString);
				int num2 = inputString.LastIndexOf(text) + text.Length;
				result = inputString.Substring(num, num2 - num);
			}
			return result;
		}

		public System.Collections.Generic.List<DataTable> GetSplitTableDataList(int rowCount, DataTable dt)
		{
			int num = System.Convert.ToInt32(System.Math.Ceiling((double)dt.Rows.Count / System.Convert.ToDouble(rowCount)));
			System.Collections.Generic.List<DataTable> list = new System.Collections.Generic.List<DataTable>();
			for (int i = 0; i < num; i++)
			{
				DataTable dataTable = dt.Clone();
				if (!dataTable.Columns.Contains("ROWNUMBER"))
				{
					dataTable.Columns.Add("ROWNUMBER");
				}
				if (!dataTable.Columns.Contains("NUM"))
				{
					dataTable.Columns.Add("NUM");
				}
				for (int j = 0; j < rowCount; j++)
				{
					if (dt.Rows.Count > i * rowCount + j)
					{
						DataRow dataRow = dataTable.Rows.Add(dt.Rows[i * rowCount + j].ItemArray);
						dataRow["ROWNUMBER"] = i * rowCount + j + 1;
						dataRow["NUM"] = i * rowCount + j + 1;
					}
					else
					{
						dataTable.Rows.Add(dt.NewRow().ItemArray);
					}
				}
				list.Add(dataTable);
			}
			return list;
		}

		private string InsertTableDataString(string inputString, string tableString, System.Collections.Generic.List<DataTable> dts)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			decimal d = 2m;
			decimal num = dts.Count + 1;
			foreach (DataTable current in dts)
			{
				stringBuilder.Append("<span lang=EN-US style='font-size:10.5pt;font-family:\"Calibri\",\"sans-serif\"'><br clear=all style='page-break-before:always'></span>");
				stringBuilder.Append(this.ReplaceSourceString(tableString, current, null, d.ToString(), num.ToString()));
				d = ++d;
			}
			inputString = inputString.Insert(inputString.LastIndexOf("</table>") + "</table>".Length, stringBuilder.ToString());
			return inputString;
		}

		private string GetSourceString(string rowString, object source, string regString, decimal constCount)
		{
			rowString = this.SetAutoRowHeight(rowString);
			rowString = this.SetTableBoder(rowString);
			string result;
			if (source != null)
			{
				decimal num = -1m;
				Match match = Regex.Match(rowString, "ROWCOUNT_\\d+");
				if (match != null && !string.IsNullOrEmpty(match.Value))
				{
					num = System.Convert.ToDecimal(match.Value.Replace("ROWCOUNT_", ""));
					rowString = rowString.Replace("|" + match.Value, "");
				}
				match = Regex.Match(rowString, "CONST_\\d+");
				if (match != null && !string.IsNullOrEmpty(match.Value))
				{
					rowString = rowString.Replace("|" + match.Value, "");
				}
				DataTable dataTable = source as DataTable;
				if (dataTable == null)
				{
					dataTable = new DataTable();
					dataTable.Columns.Add("NULLROW");
				}
				if (num > 0m)
				{
					if (dataTable.Rows.Count < num)
					{
						int count = dataTable.Rows.Count;
						bool flag = false;
						int num2 = 0;
						while (num2 < num - count)
						{
							DataRow dataRow = dataTable.NewRow();
							if (!flag)
							{
								dataRow[0] = "以下空白";
								flag = true;
							}
							dataTable.Rows.Add(dataRow);
							num2++;
						}
					}
				}
				if (dataTable.Rows.Count > 0)
				{
					System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
					if (constCount == 0m)
					{
						foreach (DataRow row in dataTable.Rows)
						{
							stringBuilder.Append(this.ReplaceValuesString(rowString, BaseInit.GetHashtable(row), regString));
						}
					}
					else
					{
						this.ConstTdString = this.GetConstTdString(rowString);
						rowString = rowString.Replace("|END", "");
						stringBuilder.Append(this.ReplaceValuesString(rowString, BaseInit.GetHashtable(dataTable.Rows[0]), regString));
					}
					result = stringBuilder.ToString();
					return result;
				}
			}
			result = "";
			return result;
		}

		private string GetConstTdString(string inputString)
		{
			string pattern = "<(td)[^<]*>((?!<td).)+</\\1>";
			MatchCollection matchCollection = Regex.Matches(inputString, pattern);
			int num = -1;
			int num2 = -1;
			string result;
			if (matchCollection != null && matchCollection.Count > 0)
			{
				for (int i = 0; i < matchCollection.Count; i++)
				{
					if (matchCollection[i].Value.Contains("END]"))
					{
						num2 = matchCollection[i].Index + matchCollection[i].Value.Length;
					}
					else if (matchCollection[i].Value.Contains("$[") && num < 0)
					{
						num = matchCollection[i].Index;
					}
					if (num > 0 && num2 > 0)
					{
						string text = inputString.Substring(num, num2 - num);
						result = text.Replace("|END", "");
						return result;
					}
				}
			}
			result = null;
			return result;
		}

		private string SetAutoRowHeight(string inputString)
		{
			string result;
			if (!inputString.Contains("ROWCOUNT_") && !inputString.Contains("CONST_"))
			{
				if (inputString.Contains("|DEFHEIGHT"))
				{
					result = inputString.Replace("|DEFHEIGHT", "");
					return result;
				}
				inputString = Regex.Replace(inputString, "height[=:][\\d]+[\\.]*[\\d]*[pt]*", "");
			}
			result = inputString;
			return result;
		}

        private void CreateExcelFile(string FileName)
        {
            //create  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "Work";

            //headline  
            worksheet.Cells[1, 1] = "FileName";
            worksheet.Cells[1, 2] = "FindString";
            worksheet.Cells[1, 3] = "ReplaceString";

            worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }  

		private void SaveAs(string saveAsFile)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(saveAsFile);
			if (fileInfo.Extension.ToLower().Equals(".pdf"))
			{
				string path = saveAsFile.Replace(fileInfo.Extension, ".doc");
				System.IO.File.WriteAllText(path, this.fileString, System.Text.Encoding.Default);
				base.ConvertToPdf(saveAsFile);
			}
			else
			{
				System.IO.File.WriteAllText(saveAsFile, this.fileString, System.Text.Encoding.Default);

                /*
                if(File.Exists(saveAsFile))
                {
                    File.Delete(saveAsFile);
                }
                if (saveAsFile.EndsWith(".xls") || saveAsFile.EndsWith(".xlsx"))
                {
                    CreateExcelFile(saveAsFile);
                }
                */
			}
			if (fileInfo.Extension.ToLower().Contains(".doc") || fileInfo.Extension.ToLower().Contains(".xls"))
			{
				IChangeDebuug changeDebuug = GHPrinter.Instance.GetObj(fileInfo.Extension) as IChangeDebuug;
				changeDebuug.ChangeDebuug(saveAsFile);
			}
		}
	}
}
