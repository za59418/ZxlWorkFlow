using System;
using System.Collections.Generic;

namespace Zxl.Data.Parser
{
	public class StringCollection : List<string>
	{
		public StringCollection(params string[] a)
		{
			if (null != a)
			{
				for (int i = 0; i < a.Length; i++)
				{
					string item = a[i];
					base.Add(item);
				}
			}
		}

		public static StringCollection fromArray(string[] ary)
		{
			StringCollection result;
			if (ary == null || ary.Length < 1)
			{
				result = null;
			}
			else
			{
				StringCollection stringCollection = new StringCollection(new string[0]);
				stringCollection.AddRange(ary);
				result = stringCollection;
			}
			return result;
		}
	}
}
