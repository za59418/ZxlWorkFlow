using Microsoft.Office.Interop.Visio;
using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace Zxl.Printer.Office
{
	public class VisioPrinter : BaseGHPrinter
	{
		private ApplicationClass application = null;

		private Document document = null;

		protected override bool doLoadSourceFile(string sourceFile)
		{
			this.application = new ApplicationClass();
            this.application.Visible = false;
			this.document = this.application.Documents.Open(sourceFile);
			return true;
		}

		protected override bool doLoadData(System.Collections.Hashtable data)
		{
			return true;
		}

		protected override bool doBuildFile(string saveAsFile)
		{
			this.SaveAs(saveAsFile);
			return true;
		}

		protected override bool doConvertToPdf(string saveAsFile)
		{
            VisFixedFormatTypes visFixedFormatTypes = VisFixedFormatTypes.visFixedFormatPDF;
			this.document.ExportAsFixedFormat(visFixedFormatTypes, saveAsFile, 0, 0, 1, -1, false, true, true, true, false, System.Reflection.Missing.Value);
			return true;
		}

		protected override void doDispose()
		{
			if (this.application != null)
			{
				this.application.Quit();
				this.application = null;
			}
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}

		private void SaveAs(string saveAsFile)
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(saveAsFile);
			if (fileInfo.Extension.ToLower().Equals(".pdf"))
			{
				base.ConvertToPdf(saveAsFile);
			}
			else
			{
				this.document.SaveAs(saveAsFile);
			}
		}
	}
}
