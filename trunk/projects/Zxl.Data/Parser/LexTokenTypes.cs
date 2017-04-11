using System;

namespace Zxl.Data.Parser
{
	public enum LexTokenTypes
	{
		NAME,
		LONG_NAME,
		SPECIAL,
		DOUBLE,
		NUMBER,
		STRING,
		STRING_QUOTED,
		COMMENT_LINE,
		COMMENT_BLOCK,
		NULL,
		BLANK
	}
}
