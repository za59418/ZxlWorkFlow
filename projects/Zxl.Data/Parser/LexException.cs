using System;

namespace DCIIDS.Data.Parser
{
	public class LexException : Exception
	{
		public LexException(int nRow, int nCol, string strMessage) : base(string.Concat(new object[]
		{
			"Lex Error: Line at ",
			nRow + 1,
			" and Column at ",
			nCol + 1,
			" ：",
			strMessage
		}))
		{
		}
	}
}
