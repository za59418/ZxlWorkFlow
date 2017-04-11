using System;

namespace Zxl.Data.Parser
{
	public class SQLConfiguration : LexTokenizerConfig
	{
		public SQLConfiguration()
		{
			base.setNamePrefixes(":@#$");
			this.m_isAllowLongSpecifiedName = true;
			this.m_cLongNameDelimiter = '.';
			this.m_BlockComments = new StringCollection(new string[]
			{
				"/*",
				"*/"
			});
			this.m_LineComment = new StringCollection(new string[]
			{
				"--"
			});
			this.m_specialGroups = new StringCollection(new string[]
			{
				"<>",
				"!=",
				">=",
				"<=",
				"=="
			});
		}
	}
}
