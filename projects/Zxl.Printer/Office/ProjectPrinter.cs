using Microsoft.Office.Interop.MSProject;
using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace Zxl.Printer.Office
{
	public class ProjectPrinter : BaseGHPrinter
	{
		private ApplicationClass application = null;

		protected override bool doLoadSourceFile(string sourceFile)
		{
			this.application = new ApplicationClass();
            this.application.Visible = false;
			this.application.FileOpenEx(sourceFile, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 0, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			return true;
		}

		protected override bool doLoadData(System.Collections.Hashtable data)
		{
			return true;
		}

		protected override bool doBuildFile(string saveAsFile)
		{
			return true;
		}

		protected override bool doConvertToPdf(string saveAsFile)
		{
			this.application.DocumentExport(saveAsFile, 0, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			return true;
		}

		protected override void doDispose()
		{
			if (this.application != null)
			{
				this.application.DocClose();
                this.application.Quit(PjSaveType.pjDoNotSave);
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
				this.application.FileSaveAs(saveAsFile, 0, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			}
		}
	}
}
