using System;
using System.Collections;
using System.IO;

namespace Zxl.Printer
{
	public class BaseGHPrinter : IGHPrinterDefine
	{
		private System.Collections.Hashtable _data = null;

		public event System.EventHandler BeforeBuildFile;

		public event System.EventHandler AfterBuildFile;

		public event System.EventHandler AfterDispose;

		public event System.EventHandler AfterLoadSourceFile;

		public event System.EventHandler AfterLoadData;

		public System.Collections.Hashtable Data
		{
			get
			{
				if (this._data == null)
				{
					this._data = new System.Collections.Hashtable();
				}
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		public bool LoadSourceFile(string sourceFile)
		{
			bool result = false;
			try
			{
				result = this.doLoadSourceFile(sourceFile);
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("加载模版出错:" + ex.Message);
			}
			if (this.AfterLoadSourceFile != null)
			{
				this.AfterLoadSourceFile(this, null);
			}
			return result;
		}

		public bool LoadData(System.Collections.Hashtable data)
		{
			this.Data = data;
			bool result = false;
			try
			{
				result = this.doLoadData(data);
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("加载数据出错:" + ex.Message);
			}
			if (this.AfterLoadData != null)
			{
				this.AfterLoadData(this, null);
			}
			return result;
		}

		public bool BuildFile(string saveAsFile)
		{
			if (System.IO.File.Exists(saveAsFile))
			{
				System.IO.File.Delete(saveAsFile);
			}
			if (this.BeforeBuildFile != null)
			{
				this.BeforeBuildFile(this, null);
			}
			bool result = false;
			try
			{
				result = this.doBuildFile(saveAsFile);
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("生成文件出错:" + ex.Message);
			}
			if (this.AfterBuildFile != null)
			{
				this.AfterBuildFile(this, null);
			}
			return result;
		}

		public bool ConvertToPdf(string saveAsFile)
		{
			if (System.IO.File.Exists(saveAsFile))
			{
				System.IO.File.Delete(saveAsFile);
			}
			bool result = false;
			try
			{
				result = this.doConvertToPdf(saveAsFile);
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("生成pdf出错:" + ex.Message);
			}
			return result;
		}

		public void Dispose()
		{
			try
			{
				this.doDispose();
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("释放资源出错:" + ex.Message);
			}
			if (this.AfterDispose != null)
			{
				this.AfterDispose(this, null);
			}
		}

		protected virtual bool doLoadSourceFile(string sourceFile)
		{
			return true;
		}

		protected virtual bool doLoadData(System.Collections.Hashtable data)
		{
			return true;
		}

		protected virtual bool doBuildFile(string saveAsFile)
		{
			return true;
		}

		protected virtual bool doConvertToPdf(string saveAsFile)
		{
			return true;
		}

		protected virtual void doDispose()
		{
		}
	}
}
