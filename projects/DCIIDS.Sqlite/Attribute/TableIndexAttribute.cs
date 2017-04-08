using System;

namespace DCIIDS.Data
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class TableIndexAttribute : Attribute
	{
		public string Name
		{
			get;
			set;
		}

		public string Field
		{
			get;
			set;
		}

		public TableIndexAttribute()
		{
		}

		public TableIndexAttribute(string strIndexName)
		{
			this.Name = strIndexName;
		}

		public TableIndexAttribute(string strIndexName, string sFieldList)
		{
			this.Name = strIndexName;
			this.Field = sFieldList;
		}
	}
}
