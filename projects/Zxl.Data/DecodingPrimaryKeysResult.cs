using System;
using System.Collections.Generic;

namespace Zxl.Data
{
	public class DecodingPrimaryKeysResult
	{
		public string Sql
		{
			get;
			set;
		}

		public List<object> Parameters
		{
			get;
			set;
		}
	}
}
