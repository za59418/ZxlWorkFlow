using System;
using System.Text;

namespace Zxl.Data.Parser
{
	public class BaseTokenizer : LexTokenizer
	{
		private LexTokenizerConfig m_LexTokenizerConfig = new LexTokenizerConfig();

		public BaseTokenizer()
		{
		}

		public BaseTokenizer(LexTokenizerConfig tk)
		{
			if (null != tk)
			{
				this.m_LexTokenizerConfig = tk;
			}
		}

		public BaseTokenizer(LexTokenizerConfig tk, string str) : base(str)
		{
			if (null != tk)
			{
				this.m_LexTokenizerConfig = tk;
			}
		}

		public BaseTokenizer(BaseTokenizer other, string str)
		{
			if (other != null)
			{
				this.m_LexTokenizerConfig = other.m_LexTokenizerConfig;
			}
			base.setInitStatement(str);
		}

		public BaseTokenizer(string str) : base(str)
		{
		}

		public LexTokenizerConfig getConfig()
		{
			return this.m_LexTokenizerConfig;
		}

		protected LexToken getPrefixBlankToken()
		{
			LexToken lexToken = base.createToken();
			StringBuilder stringBuilder = new StringBuilder();
			char c = base.current();
			while (c != '\0' && char.IsWhiteSpace(c))
			{
				stringBuilder.Append(c);
				c = base.next();
			}
			LexToken result;
			if (stringBuilder != null && stringBuilder.Length > 0)
			{
				lexToken.setToken(stringBuilder.ToString());
				lexToken.setType(LexTokenTypes.BLANK);
				lexToken.setEndRowIndex(base.getCurrentRowIndex());
				lexToken.setPrevBlanks(null);
				result = lexToken;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public override LexToken nextToken()
		{
			LexToken prefixBlankToken = this.getPrefixBlankToken();
			LexToken result;
			if (base.current() == '\0')
			{
				result = prefixBlankToken;
			}
			else
			{
				LexToken lexToken = this.parseToken();
				if (lexToken != null)
				{
					lexToken.setEndRowIndex(base.getCurrentRowIndex());
					lexToken.setPrevBlanks(prefixBlankToken);
				}
				result = lexToken;
			}
			return result;
		}

		private LexToken parseToken()
		{
			char c = base.current();
			LexToken result;
			if (c == '\0')
			{
				result = null;
			}
			else
			{
				LexToken lexToken = base.createToken();
				int num = 0;
				while (this.m_LexTokenizerConfig.getLineComment() != null && num < this.m_LexTokenizerConfig.getLineComment().Length)
				{
					string text = this.m_LexTokenizerConfig.getLineComment()[num];
					if (text != null)
					{
						if (base.getNextString(text.Length).Equals(text))
						{
							result = this.parseLineComment(lexToken, text);
							return result;
						}
					}
					num++;
				}
				num = 0;
				while (this.m_LexTokenizerConfig.getSpecialGroups() != null && num < this.m_LexTokenizerConfig.getSpecialGroups().Length)
				{
					string text = this.m_LexTokenizerConfig.getSpecialGroups()[num];
					if (text != null)
					{
						if (base.getNextString(text.Length).Equals(text))
						{
							lexToken.setType(LexTokenTypes.SPECIAL);
							lexToken.setToken(this.m_LexTokenizerConfig.getSpecialGroups()[num]);
							for (int i = 0; i < this.m_LexTokenizerConfig.getSpecialGroups()[num].Length; i++)
							{
								base.next();
							}
							result = lexToken;
							return result;
						}
					}
					num++;
				}
				if (this.m_LexTokenizerConfig.isNamePrefix(c))
				{
					result = this.parseName(lexToken);
				}
				else
				{
					num = 0;
					while (this.m_LexTokenizerConfig.getBlockComments() != null && num < this.m_LexTokenizerConfig.getBlockComments().Length)
					{
						if (num + 1 < this.m_LexTokenizerConfig.getBlockComments().Length && this.m_LexTokenizerConfig.getBlockComments()[num] != null && null != this.m_LexTokenizerConfig.getBlockComments()[num + 1])
						{
							string text = this.m_LexTokenizerConfig.getBlockComments()[num];
							if (base.getNextString(text.Length).Equals(text))
							{
								result = this.parseBlockComment(lexToken, text, this.m_LexTokenizerConfig.getBlockComments()[num + 1]);
								return result;
							}
						}
						num += 2;
					}
					num = 0;
					while (this.m_LexTokenizerConfig.getSpecialNamePair() != null && num < this.m_LexTokenizerConfig.getSpecialNamePair().Length)
					{
						if (num + 1 < this.m_LexTokenizerConfig.getSpecialNamePair().Length && this.m_LexTokenizerConfig.getSpecialNamePair()[num] != null && null != this.m_LexTokenizerConfig.getSpecialNamePair()[num + 1])
						{
							string text = this.m_LexTokenizerConfig.getSpecialNamePair()[num];
							if (base.getNextString(text.Length).Equals(text))
							{
								result = this.parseSpecialName(lexToken, text, this.m_LexTokenizerConfig.getSpecialNamePair()[num + 1]);
								return result;
							}
						}
						num += 2;
					}
					char c2 = base.peekNext();
					if (char.IsLetter(c))
					{
						result = this.parseName(lexToken);
					}
					else if (char.IsDigit(c) || (c == '.' && char.IsDigit(c2)))
					{
						result = this.parseNumber(lexToken);
					}
					else if (c == '"' || c == '\'')
					{
						result = this.parseString(false, lexToken);
					}
					else if (c == this.m_LexTokenizerConfig.getMultiLineStringPrefix() && (base.peekNext() == '"' || base.peekNext() == '\''))
					{
						result = this.parseString(true, lexToken);
					}
					else
					{
						result = this.parseSpecial(lexToken);
					}
				}
			}
			return result;
		}

		private LexToken parseSpecialName(LexToken token, string strBeginMask, string strEndMask)
		{
			token.setType(LexTokenTypes.LONG_NAME);
			StringBuilder stringBuilder = new StringBuilder();
			int length = strEndMask.Length;
			int num = strBeginMask.Length + strEndMask.Length;
			bool flag = false;
			while (base.current() != '\0')
			{
				if (stringBuilder.Length >= num && base.getPrevString(length).Equals(strEndMask))
				{
					flag = true;
					break;
				}
				stringBuilder.Append(base.current());
				base.next();
			}
			if (!flag)
			{
				this.throwException(token, "无法找到对应的结束的名称标记" + strBeginMask + "..." + strEndMask);
			}
			token.setToken(stringBuilder.ToString());
			return token;
		}

		private LexToken parseSpecial(LexToken token)
		{
			LexToken result;
			if ((base.current() == '+' || base.current() == '-') && char.IsDigit(base.peekNext()))
			{
				result = this.parseNumber(token);
			}
			else
			{
				token.setType(LexTokenTypes.SPECIAL);
				token.setToken(string.Concat(base.current()));
				base.next();
				result = token;
			}
			return result;
		}

		private LexToken parseString(bool isMulti, LexToken token)
		{
			char c = base.current();
			if (isMulti)
			{
				c = base.next();
			}
			char c2 = (c == '"') ? '"' : '\'';
			token.setType((c == '"') ? LexTokenTypes.STRING_QUOTED : LexTokenTypes.STRING);
			string text = "";
			base.next();
			char c3 = '\0';
			char c4 = '\0';
			while (base.current() != '\0')
			{
				if (base.current() == c2)
				{
					if (c3 != '\\')
					{
						break;
					}
				}
				char c5 = base.current();
				if (c5 == '\n')
				{
					if (!isMulti && this.m_LexTokenizerConfig.getMultiLineStringSuffix() != '\0')
					{
						if (c4 == '\0' || c4 != this.m_LexTokenizerConfig.getMultiLineStringSuffix())
						{
							this.throwException("", "不能在字符串中包含回车！");
						}
						int num = text.LastIndexOf(this.m_LexTokenizerConfig.getMultiLineStringSuffix());
						if (num >= 0)
						{
							text = text.Substring(0, num);
						}
					}
					else if (!isMulti)
					{
						this.throwException("", "不能在字符串中包含回车！");
					}
					c4 = '\0';
				}
				text += c5;
				c3 = c5;
				if (!char.IsWhiteSpace(c5))
				{
					c4 = c5;
				}
				base.next();
			}
			if (base.current() != c2)
			{
				this.throwException(token, "不能匹配字符串的开始标志和结束标志！");
			}
			if (isMulti)
			{
                token.setPrefix(this.m_LexTokenizerConfig.getMultiLineStringPrefix() + c + "");
			}
			else
			{
				token.setPrefix(string.Concat(c));
			}
			token.setSuffix(string.Concat(c2));
			token.setToken(text);
			base.next();
			return token;
		}

		private LexToken parseBlockComment(LexToken token, string strBeginComment, string strEndComment)
		{
			token.setType(LexTokenTypes.COMMENT_BLOCK);
			StringBuilder stringBuilder = new StringBuilder();
			int length = strEndComment.Length;
			int num = strBeginComment.Length + strEndComment.Length;
			bool flag = false;
			while (base.current() != '\0')
			{
				if (stringBuilder.Length >= num && base.getPrevString(length).Equals(strEndComment))
				{
					flag = true;
					break;
				}
				stringBuilder.Append(base.current());
				base.next();
			}
			if (!flag)
			{
				this.throwException(token, "无法找到对应的结束的注释标记" + strBeginComment + "..." + strEndComment);
			}
			token.setPrefix(strBeginComment);
			token.setToken(stringBuilder.ToString().Substring(strBeginComment.Length, stringBuilder.Length - strEndComment.Length));
			token.setSuffix(strEndComment);
			return token;
		}

		private LexToken parseLineComment(LexToken token, string strMask)
		{
			char c = base.current();
			StringBuilder stringBuilder = new StringBuilder();
			while (c != '\n' && c != '\0')
			{
				stringBuilder.Append(c);
				c = base.next();
			}
			token.setToken(stringBuilder.ToString().Substring(strMask.Length));
			token.setPrefix(strMask);
			token.setType(LexTokenTypes.COMMENT_LINE);
			return token;
		}

		private bool isSpecial(char c)
		{
			return !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c);
		}

		protected LexToken parseName(LexToken token)
		{
			token.setType(LexTokenTypes.NAME);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.current());
			bool flag = this.isSpecial(base.current());
			char c = base.next();
			while (c != '\0')
			{
				if (!char.IsLetter(c) && !char.IsDigit(c) && c != '_' && !this.m_LexTokenizerConfig.isNameChar(c))
				{
					break;
				}
				stringBuilder.Append(c);
				c = base.next();
				flag = (flag && this.isSpecial(c));
			}
			if (this.m_LexTokenizerConfig.isAllowLongSpecifiedName() && this.m_LexTokenizerConfig.getLongNameDelimiter() == c)
			{
				int currentPosition = base.getCurrentPosition();
				base.next();
				LexToken lexToken = this.nextToken();
				if (!lexToken.isName())
				{
					base.backTo(currentPosition);
				}
				else
				{
					token.setType(LexTokenTypes.LONG_NAME);
					stringBuilder.Append(c);
					stringBuilder.Append(lexToken.getToken());
				}
			}
			token.setToken(stringBuilder.ToString());
			return token;
		}

		protected void throwException(string strCurrentToken, string strMessage)
		{
			throw new LexException(base.getCurrentRowIndex(), base.getCurrentColumnIndex(), strMessage + ((strCurrentToken == null || strCurrentToken.Trim().Length < 1) ? "" : ("：" + strCurrentToken)));
		}

		protected void throwException(LexToken tk, string strMessage)
		{
			throw new LexException(tk.getBeginRowIndex(), tk.getBeginRowIndex(), strMessage);
		}

		protected LexToken parseNumber(LexToken token)
		{
			token.setType(LexTokenTypes.NUMBER);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.current());
			int num = 0;
			int num2 = 0;
			char c = base.next();
			bool flag = false;
			while (c != '\0')
			{
				if (char.IsDigit(c))
				{
					stringBuilder.Append(c);
				}
				else if (c == '.')
				{
					num++;
					if (num > 1)
					{
						this.throwException(stringBuilder.ToString(), "多余的小数点");
					}
					if (!char.IsDigit(base.peekNext()))
					{
						this.throwException(stringBuilder.ToString(), "小数点后面应该是数字");
					}
					token.setType(LexTokenTypes.DOUBLE);
					stringBuilder.Append(c);
				}
				else if (c == 'e' || c == 'E')
				{
					num2++;
					if (num2 > 1)
					{
						this.throwException(stringBuilder.ToString(), "多余的科学计数法E");
					}
					flag = true;
					if (!char.IsDigit(base.peekNext()) && base.peekNext() != '+' && base.peekNext() != '-')
					{
						this.throwException(stringBuilder.ToString(), "科学计数法E后面必须紧跟数字、正负号");
					}
					token.setType(LexTokenTypes.DOUBLE);
					stringBuilder.Append(c);
				}
				else
				{
					if (c != '+' && c != '-')
					{
						break;
					}
					if (!flag)
					{
						break;
					}
					stringBuilder.Append(c);
				}
				c = base.next();
			}
			if (this.m_LexTokenizerConfig.isUsingPrecentSign() && c == '%')
			{
				stringBuilder.Append(c);
				base.next();
				token.setType(LexTokenTypes.DOUBLE);
			}
			token.setToken(stringBuilder.ToString());
			return token;
		}

		public LexTokenCollection getTokens(bool bHaveComment, bool bHasBlanks)
		{
			LexTokenCollection lexTokenCollection = new LexTokenCollection();
			LexToken lexToken;
			while ((lexToken = this.nextToken()) != null && lexToken.getType() != LexTokenTypes.NULL)
			{
				if (!lexToken.isComment() || bHaveComment)
				{
					if (lexToken.getType() != LexTokenTypes.BLANK || bHasBlanks)
					{
						lexTokenCollection.Add(lexToken);
					}
				}
			}
			return lexTokenCollection;
		}
	}
}
