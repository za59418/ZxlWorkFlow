using System;
using System.Collections.Generic;
using System.Text;

namespace DCIIDS.Data.Parser
{
	public class LexTokenCollection : List<LexToken>
	{
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (LexToken current in this)
			{
				stringBuilder.Append(current.getInitString());
			}
			return stringBuilder.ToString();
		}
	}
}
