using Zxl.Printer.Office;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Zxl.Printer
{
	public class GHPrinter
	{
		private static GHPrinter _instance;

		private System.Collections.Generic.Dictionary<string, IGHPrinterDefine> _instanceList;

		public static GHPrinter Instance
		{
			get
			{
				if (GHPrinter._instance == null)
				{
					GHPrinter._instance = new GHPrinter();
				}
				return GHPrinter._instance;
			}
		}

		public System.Collections.Generic.Dictionary<string, IGHPrinterDefine> InstanceList
		{
			get
			{
				if (this._instanceList == null)
				{
					this._instanceList = new System.Collections.Generic.Dictionary<string, IGHPrinterDefine>();
				}
				return this._instanceList;
			}
		}

		public bool PrintToFile(string sourceFile, string saveAsFile, System.Collections.Hashtable data)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(sourceFile);
			IGHPrinterDefine obj = this.GetObj(fileInfo.Extension.ToLower());
			bool result;
			if (obj != null)
			{
				this.CheckDir(saveAsFile);
				try
				{
					BaseInit.InitConstValues(data);
					if (obj.LoadSourceFile(sourceFile) && obj.LoadData(data))
					{
						result = obj.BuildFile(saveAsFile);
						return result;
					}
				}
				catch (System.Exception ex)
				{
					throw ex;
				}
				finally
				{
					obj.Dispose();
				}
			}
			result = false;
			return result;
		}

		public bool ConvertToPdf(string sourceFile, string saveAsFile)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(sourceFile);
			IGHPrinterDefine obj = this.GetObj(fileInfo.Extension.ToLower());
			bool result;
			if (obj != null)
			{
				this.CheckDir(saveAsFile);
				try
				{
					if (obj.LoadSourceFile(sourceFile))
					{
						result = obj.ConvertToPdf(saveAsFile);
						return result;
					}
				}
				catch (System.Exception ex)
				{
					throw ex;
				}
				finally
				{
					obj.Dispose();
				}
			}
			result = false;
			return result;
		}

		public bool RegPrintClass(string printType, IGHPrinterDefine printObject)
		{
			bool result;
			if (!string.IsNullOrEmpty(printType) && printObject != null)
			{
				printType = printType.ToLower();
				string[] array = printType.Split(",".ToCharArray());
				if (array != null && array.Length > 0)
				{
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string key = array2[i];
						if (!this.InstanceList.ContainsKey(key))
						{
							this.InstanceList.Add(key, null);
						}
						this.InstanceList[key] = printObject;
					}
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public bool RegPrintClass(string printType, BaseGHPrinter printObject)
		{
			return this.RegPrintClass(printType, printObject);
		}

		public IGHPrinterDefine GetObj(string Extension)
		{
			Extension = Extension.ToLower();
			IGHPrinterDefine result;
			if (this.InstanceList.ContainsKey(Extension))
			{
				result = this.InstanceList[Extension];
			}
			else
			{
				string text = Extension;
				switch (text)
				{
				case ".doc":
				case ".docx":
				case ".dot":
				case ".dotx":
				case ".txt":
					result = new WordPrinter();
					return result;
				case ".xls":
				case ".xlt":
				case ".xlsx":
				case ".xltx":
					result = new ExcelPrinter();
					return result;
				case ".htm":
                case ".html":
                case ".mht":
                    result = new HtmlPrinter();
					return result;
				case ".ppt":
				case ".pptx":
					result = new PowerPointPrinter();
					return result;
				case ".vsd":
				case ".vsdx":
					result = new VisioPrinter();
					return result;
				case ".mpp":
					result = new ProjectPrinter();
					return result;
				//case ".frx":
				//	//result = new FastReportPrinter();
				//	return result;
                case ".bmp":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                    result = new ImgPrinter();
                    return result;
				}
				result = null;
			}
			return result;
		}

		private void CheckDir(string filePath)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
			if (!fileInfo.Directory.Exists)
			{
				fileInfo.Directory.Create();
			}
		}
	}
}
