using System;
using System.Collections;

namespace Zxl.Printer
{
	public interface IGHPrinterDefine
	{
		event System.EventHandler BeforeBuildFile;

		event System.EventHandler AfterBuildFile;

		event System.EventHandler AfterDispose;

		event System.EventHandler AfterLoadSourceFile;

		event System.EventHandler AfterLoadData;

		System.Collections.Hashtable Data
		{
			get;
			set;
		}

		bool LoadSourceFile(string sourceFile);

		bool LoadData(System.Collections.Hashtable data);

		bool BuildFile(string saveAsFile);

		bool ConvertToPdf(string saveAsFile);

		void Dispose();
	}
}
