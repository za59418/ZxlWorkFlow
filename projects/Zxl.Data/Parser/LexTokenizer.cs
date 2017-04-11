using System;

namespace Zxl.Data.Parser
{
	public abstract class LexTokenizer
	{
		public const char END = '\0';

		private string m_strInitStatement = null;

		private char[] m_charStatementArray = null;

		private int m_nLengthOfStatement = 0;

		private int m_nCurrentPosition = 0;

		private int m_nCurrentRowIndex = 0;

		private int m_nRowsCount = 0;

		private int m_nCurrentColumnIndex = 0;

		public LexTokenizer()
		{
		}

		public LexTokenizer(string strStatement)
		{
			this.m_strInitStatement = strStatement;
			this.reload();
		}

		public void reload()
		{
			this.m_strInitStatement = ((this.m_strInitStatement == null) ? null : (this.m_strInitStatement + " "));
			this.m_charStatementArray = ((this.m_strInitStatement == null) ? null : this.m_strInitStatement.ToCharArray());
			this.m_nLengthOfStatement = ((this.m_strInitStatement == null) ? 0 : this.m_charStatementArray.Length);
			this.m_nCurrentPosition = 0;
			this.m_nCurrentRowIndex = 0;
			this.m_nRowsCount = 0;
		}

		protected char peekPrev(int nPrevCount)
		{
			int num = this.m_nCurrentPosition - nPrevCount;
			return (this.m_nCurrentPosition < 0 || num < 0 || num >= this.m_nLengthOfStatement) ? '\0' : this.m_charStatementArray[num];
		}

		protected char peekNext(int nNextCount)
		{
			int num = this.m_nCurrentPosition + nNextCount;
			return (this.m_nCurrentPosition < 0 || num < 0 || num >= this.m_nLengthOfStatement) ? '\0' : this.m_charStatementArray[num];
		}

		protected string getNextString(int nNextCount)
		{
			return this.m_strInitStatement.Substring(Math.Max(0, this.m_nCurrentPosition), Math.Max(nNextCount, 0));
		}

		protected string getPrevString(int nPrevCount)
		{
			return this.m_strInitStatement.Substring(Math.Max(0, this.m_nCurrentPosition - nPrevCount), Math.Max(nPrevCount, 0));
		}

		protected char peekNext()
		{
			return this.peekNext(1);
		}

		protected char peekPrev()
		{
			return this.peekPrev(1);
		}

		protected char current()
		{
			return (this.m_nCurrentPosition < 0 || this.m_nCurrentPosition >= this.m_nLengthOfStatement) ? '\0' : this.m_charStatementArray[this.m_nCurrentPosition];
		}

		protected void backTo(int nPos)
		{
			this.m_nCurrentPosition = nPos;
			this.m_nCurrentPosition = Math.Max(this.m_nCurrentPosition, 0);
		}

		protected char next()
		{
			char result;
			if (this.m_nCurrentPosition < 0)
			{
				result = '\0';
			}
			else
			{
				this.m_nCurrentPosition++;
				this.m_nCurrentColumnIndex++;
				int nCurrentPosition = this.m_nCurrentPosition;
				char c = (nCurrentPosition < 0 || nCurrentPosition >= this.m_nLengthOfStatement) ? '\0' : this.m_charStatementArray[nCurrentPosition];
				if (c == '\n')
				{
					this.m_nCurrentColumnIndex = 0;
					this.m_nCurrentRowIndex++;
					this.m_nRowsCount++;
				}
				result = c;
			}
			return result;
		}

		protected LexToken createToken()
		{
			return LexToken.create(this.m_nCurrentPosition, this.m_nCurrentRowIndex, this.m_nCurrentColumnIndex);
		}

		public int getCurrentColumnIndex()
		{
			return this.m_nCurrentColumnIndex;
		}

		public int getCurrentPosition()
		{
			return this.m_nCurrentPosition;
		}

		public int getCurrentRowIndex()
		{
			return this.m_nCurrentRowIndex;
		}

		public int getLengthOfStatement()
		{
			return this.m_nLengthOfStatement;
		}

		public int getRowsCount()
		{
			return this.m_nRowsCount;
		}

		public void setInitStatement(string str)
		{
			this.m_strInitStatement = str;
			this.reload();
		}

		public string getInitStatement()
		{
			return this.m_strInitStatement;
		}

		public abstract LexToken nextToken();
	}
}
