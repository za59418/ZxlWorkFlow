using System;
using System.Collections.Generic;
using System.Text;

namespace Zxl.Data.Parser
{
	public class SqlTokenizer : BaseTokenizer
	{
		public SqlTokenizer() : base(new SQLConfiguration())
		{
		}

		public SqlTokenizer(string str) : base(new SQLConfiguration(), str)
		{
		}

		public override LexToken nextToken()
		{
			LexToken lexToken = base.nextToken();
			if (lexToken != null && lexToken.isSpecial() && lexToken.Equals("?"))
			{
				char c = base.current();
				if (c != '\0' && c != ';' && c != ',' && c != ')' && !char.IsWhiteSpace(c))
				{
					base.throwException(lexToken, "SQL Parse Error: \"?\" can not be followed by \"" + c + "\"");
				}
			}
			return lexToken;
		}

		public static List<string> SplitSQLStatement(string strSql, bool isContainsComments)
		{
			List<string> result;
			if (strSql == null || strSql.Trim().Length < 1)
			{
				result = null;
			}
			else
			{
				List<LexTokenCollection> list = SqlTokenizer.SplitSQLToken(strSql, isContainsComments);
				if (null == list)
				{
					result = null;
				}
				else
				{
					List<string> list2 = new List<string>();
					foreach (LexTokenCollection current in list)
					{
						string text = current.ToString().Trim();
						if (text.Length > 0)
						{
							list2.Add(text);
						}
					}
					result = list2;
				}
			}
			return result;
		}

		public static List<string> GetSQLParametersName(string strSql)
		{
			List<string> list = new List<string>();
			List<string> result;
			if (strSql == null || strSql.Trim().Length < 1)
			{
				result = list;
			}
			else
			{
				SqlTokenizer sqlTokenizer = new SqlTokenizer(strSql);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (LexToken current in sqlTokenizer.getTokens(false, false))
				{
					if (SqlTokenizer.IsSQLParameterToken(current))
					{
						if (current.isSpecial() || !dictionary.ContainsKey(current.getToken()))
						{
							dictionary.Add(current.getToken(), current.getToken());
							list.Add(current.getToken());
						}
					}
				}
				result = list;
			}
			return result;
		}

		public static bool IsSQLParameterToken(LexToken token)
		{
			return token != null && token.getToken() != null && token.getToken().Length > 0 && (token.isName() || token.isSpecial()) && "#@:?".IndexOf(token.getToken().ToCharArray()[0]) >= 0;
		}

		public static string CleanSQL(string strSql)
		{
			string result;
			if (strSql == null || strSql.Trim().Length < 1)
			{
				result = null;
			}
			else
			{
				SqlTokenizer sqlTokenizer = new SqlTokenizer(strSql);
				StringBuilder stringBuilder = new StringBuilder();
				foreach (LexToken current in sqlTokenizer.getTokens(false, true))
				{
					stringBuilder.Append(current.getInitString());
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static List<LexTokenCollection> SplitSQLToken(string strSql, bool isContainsComments)
		{
			List<LexTokenCollection> result;
			if (strSql == null || strSql.Trim().Length < 1)
			{
				result = null;
			}
			else
			{
				SqlTokenizer sqlTokenizer = new SqlTokenizer(strSql);
				List<LexTokenCollection> list = new List<LexTokenCollection>();
				LexTokenCollection lexTokenCollection = new LexTokenCollection();
				foreach (LexToken current in sqlTokenizer.getTokens(isContainsComments, false))
				{
					if ((current.isSpecial() && current.Equals(";")) || (current.isName() && current.getToken().Equals("GO", StringComparison.CurrentCultureIgnoreCase)))
					{
						if (lexTokenCollection.Count > 0)
						{
							list.Add(lexTokenCollection);
						}
						lexTokenCollection = new LexTokenCollection();
					}
					else
					{
						lexTokenCollection.Add(current);
					}
				}
				if (lexTokenCollection.Count > 0)
				{
					list.Add(lexTokenCollection);
				}
				result = ((list.Count > 0) ? list : null);
			}
			return result;
		}
	}
}
