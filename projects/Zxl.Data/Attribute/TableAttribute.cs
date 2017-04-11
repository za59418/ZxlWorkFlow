using System;

namespace Zxl.Data
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TableAttribute : Attribute
	{
		public string Name
		{
			get;
			set;
		}

		public string Prefix
		{
			get;
			set;
		}

		public TableAttribute()
		{
		}

		public TableAttribute(string strTableName)
		{
			this.Name = strTableName;
		}
	}
}
