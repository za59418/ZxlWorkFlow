using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections;
using System.IO;

namespace Zxl.Printer.Office
{
	public class PowerPointPrinter : BaseGHPrinter
	{
		private ApplicationClass application = null;

		private Presentation persentation = null;

		protected override bool doLoadSourceFile(string sourceFile)
		{
			this.application = new ApplicationClass();
			this.persentation = this.application.Presentations.Open(sourceFile, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
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
			PpSaveAsFileType fileFormat = PpSaveAsFileType.ppSaveAsPDF;
            this.persentation.SaveAs(saveAsFile, fileFormat, MsoTriState.msoFalse);
			return true;
		}

		protected override void doDispose()
		{
			if (this.persentation != null)
			{
				this.persentation.Close();
				this.persentation = null;
			}
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
				this.persentation.SaveAs(saveAsFile, PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTriStateMixed);
			}
		}
	}
}
