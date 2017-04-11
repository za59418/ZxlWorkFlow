using System;
using System.Collections.Generic;
using System.Text;

namespace DCIIDS.Data
{
	public delegate void Delegate_ShowMessage(string str);
	internal delegate void DelegateNavigateTo(string strUrl);
	public static class ExtendStringClass
	{
		public static string ToChineseWholeAngleCharacters(string input)
		{
			char[] c = input.ToCharArray();
			for (int i = 0; i < c.Length; i++)
			{
				if (c[i] == 32)
				{
					c[i] = (char)12288;
					continue;
				}
				if (c[i] < 127)
					c[i] = (char)(c[i] + 65248);
			}
			return new String(c); 
		}
		public static string EscaseChineseWholeAngleCharacters(string input)
		{
			char[] c = input.ToCharArray();
			for (int i = 0; i < c.Length; i++)
			{
				if (c[i] == 12288)
				{
					c[i] = (char)32;
					continue;
				}
				if (c[i] > 65280 && c[i] < 65375)
					c[i] = (char)(c[i] - 65248);
			}
			return new String(c); 

		}
	}
}
