using System;

namespace Zxl.Data.Parser
{
	public class LexToken
	{
		private int position = -1;

		private int beginRowIndex = 0;

		private int beginColumn = 0;

		private string token = "";

		private string prefix = null;

		private string suffix = null;

		private LexTokenTypes type = LexTokenTypes.NULL;

		private int endRowIndex = 0;

		private LexToken m_prevBlanks = null;

		private LexToken()
		{
			this.type = LexTokenTypes.NULL;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static LexToken create(string str)
		{
			LexToken result;
			if (null == str)
			{
				result = null;
			}
			else
			{
				result = new LexToken
				{
					type = LexTokenTypes.STRING_QUOTED,
					token = str
				};
			}
			return result;
		}

		public static LexToken create(int nPosition, int nBeginRowIndex, int nBeingColumn)
		{
			return new LexToken
			{
				position = nPosition,
				beginRowIndex = nBeginRowIndex,
				beginColumn = nBeingColumn
			};
		}

		public void clear()
		{
			this.position = -1;
			this.token = "";
			this.type = LexTokenTypes.NULL;
			this.beginColumn = 0;
			this.beginRowIndex = 0;
			this.endRowIndex = 0;
		}

		public bool isStartWithSpecial()
		{
			bool result;
			if (this.token == null || this.token.Length < 1)
			{
				result = false;
			}
			else
			{
				char c = this.token.ToCharArray()[0];
				result = (!char.IsDigit(c) && !char.IsWhiteSpace(c) && !char.IsLetter(c));
			}
			return result;
		}

		public bool isSpecial()
		{
			return this.type == LexTokenTypes.SPECIAL;
		}

		public bool isComment()
		{
			return this.type == LexTokenTypes.COMMENT_BLOCK || this.type == LexTokenTypes.COMMENT_LINE;
		}

		public bool isName()
		{
			return this.type == LexTokenTypes.NAME || this.type == LexTokenTypes.LONG_NAME;
		}

		public bool isNumeric()
		{
			return this.type == LexTokenTypes.NUMBER || this.type == LexTokenTypes.DOUBLE;
		}

		public bool isString()
		{
			return this.type == LexTokenTypes.STRING || this.type == LexTokenTypes.STRING_QUOTED;
		}

		public int getBeginColumn()
		{
			return this.beginColumn;
		}

		public int getBeginRowIndex()
		{
			return this.beginRowIndex;
		}

		public int getEndRowIndex()
		{
			return this.endRowIndex;
		}

		public LexToken getPrevBlanks()
		{
			return this.m_prevBlanks;
		}

		public int getPosition()
		{
			return this.position;
		}

		public string getToken()
		{
			return this.token;
		}

		public LexTokenTypes getType()
		{
			return this.type;
		}

		public string getSuffix()
		{
			return this.suffix;
		}

		public string getPrefix()
		{
			return this.prefix;
		}

		public void setType(LexTokenTypes type)
		{
			this.type = type;
		}

		public void setToken(string token)
		{
			this.token = token;
		}

		public void setPosition(int position)
		{
			this.position = position;
		}

		public void setPrevBlanks(LexToken m_prevBlanks)
		{
			this.m_prevBlanks = m_prevBlanks;
		}

		public void setEndRowIndex(int endRowIndex)
		{
			this.endRowIndex = endRowIndex;
		}

		public void setBeginRowIndex(int beginRowIndex)
		{
			this.beginRowIndex = beginRowIndex;
		}

		public void setBeginColumn(int beginColumn)
		{
			this.beginColumn = beginColumn;
		}

		public void setSuffix(string suffix)
		{
			this.suffix = suffix;
		}

		public void setPrefix(string prefix)
		{
			this.prefix = prefix;
		}

		public override string ToString()
		{
			return ((this.prefix == null) ? "" : this.prefix.ToString()) + this.getToken() + ((this.suffix == null) ? "" : this.suffix.ToString());
		}

		public bool Equals(string str)
		{
			return (this.getToken() == null) ? (str == null) : this.getToken().Equals(str);
		}

		public override bool Equals(object obj)
		{
			bool result;
			if (null == obj)
			{
				result = false;
			}
			else if (obj is LexToken)
			{
				LexToken lexToken = (LexToken)obj;
				result = (lexToken.getToken().Equals(this.getToken()) && lexToken.getType() == this.getType());
			}
			else
			{
				string value = obj.ToString();
				result = this.getToken().Equals(value);
			}
			return result;
		}

		public string getInitString()
		{
			return this.replaceToken(null);
		}

		public string replaceToken(string strReplace)
		{
			string str = (strReplace == null) ? this.getToken() : strReplace;
			return ((this.getPrevBlanks() == null) ? "" : this.getPrevBlanks().getToken()) + ((this.getPrefix() == null) ? "" : this.getPrefix()) + str + ((this.getSuffix() == null) ? "" : this.getSuffix());
		}

		public void moveToPrevToken(LexToken t)
		{
			if (null != t)
			{
				this.token = string.Concat(new string[]
				{
					t.getToken(),
					(this.getSuffix() == null) ? "" : this.getSuffix(),
					(this.getPrevBlanks() == null) ? "" : this.getPrevBlanks().getToken(),
					(this.getPrefix() == null) ? "" : this.getPrefix(),
					this.getToken()
				});
				this.prefix = t.prefix;
				this.m_prevBlanks = t.m_prevBlanks;
				this.beginColumn = t.beginColumn;
				this.beginRowIndex = t.beginRowIndex;
			}
		}
	}
}
