using System;
using System.Collections.Generic;

namespace DCIIDS.Data.Parser
{
	public class LexTokenizerConfig
	{
		protected List<char> m_aryNamePrefixes = null;

		protected List<char> m_aryNameChars = null;

		protected bool m_isAllowLongSpecifiedName = false;

		protected char m_cLongNameDelimiter = '\0';

		protected List<string> m_BlockComments = null;

		protected List<string> m_LineComment = null;

		protected List<string> m_specialGroups = null;

		protected List<string> m_specialNamePair = null;

		protected char m_cMultiLineStringPrefix = '\0';

		protected char m_cMultiLineStringSuffix = '\0';

		protected bool m_isUsingPercentSign = false;

		public LexTokenizerConfig()
		{
			this.m_aryNamePrefixes = this.fromString("_");
			this.m_aryNameChars = this.fromString("_");
		}

		protected List<char> fromString(string s)
		{
			List<char> result;
			if (s == null || s.Length < 1)
			{
				result = null;
			}
			else
			{
				List<char> list = new List<char>();
				char[] array = s.ToCharArray();
				for (int i = 0; i < array.Length; i++)
				{
					char item = array[i];
					list.Add(item);
				}
				result = list;
			}
			return result;
		}

		public string[] getLineComment()
		{
			string[] result;
			if (null == this.m_LineComment)
			{
				result = null;
			}
			else
			{
				string[] array = new string[this.m_LineComment.Count];
				for (int i = 0; i < this.m_LineComment.Count; i++)
				{
					array[i] = this.m_LineComment[i];
				}
				result = array;
			}
			return result;
		}

		public void setLineComment(string[] ary)
		{
			this.m_LineComment = ((ary == null) ? null : StringCollection.fromArray(ary));
		}

		public string[] getSpecialNamePair()
		{
			string[] result;
			if (null == this.m_specialNamePair)
			{
				result = null;
			}
			else
			{
				string[] array = new string[this.m_specialNamePair.Count];
				for (int i = 0; i < this.m_specialNamePair.Count; i++)
				{
					array[i] = this.m_specialNamePair[i];
				}
				result = array;
			}
			return result;
		}

		public void setSpecialNamePair(string[] ary)
		{
			this.m_specialNamePair = ((ary == null) ? null : StringCollection.fromArray(ary));
		}

		public string[] getSpecialGroups()
		{
			string[] result;
			if (null == this.m_specialGroups)
			{
				result = null;
			}
			else
			{
				string[] array = new string[this.m_specialGroups.Count];
				for (int i = 0; i < this.m_specialGroups.Count; i++)
				{
					array[i] = this.m_specialGroups[i];
				}
				result = array;
			}
			return result;
		}

		public void setSpecialGroups(string[] ary)
		{
			this.m_specialGroups = ((ary == null) ? null : StringCollection.fromArray(ary));
		}

		public string[] getBlockComments()
		{
			string[] result;
			if (null == this.m_BlockComments)
			{
				result = null;
			}
			else
			{
				string[] array = new string[this.m_BlockComments.Count];
				for (int i = 0; i < this.m_BlockComments.Count; i++)
				{
					array[i] = this.m_BlockComments[i];
				}
				result = array;
			}
			return result;
		}

		public void setBlockComments(string[] ary)
		{
			this.m_BlockComments = ((ary == null) ? null : StringCollection.fromArray(ary));
		}

		public char getLongNameDelimiter()
		{
			return this.m_cLongNameDelimiter;
		}

		public void setLongNameDelimiter(char c)
		{
			this.m_cLongNameDelimiter = c;
			this.m_isAllowLongSpecifiedName = (c != '\0');
		}

		public char getMultiLineStringPrefix()
		{
			return this.m_cMultiLineStringPrefix;
		}

		public void setMultiLineStringPrefix(char c)
		{
			this.m_cMultiLineStringPrefix = c;
		}

		public char getMultiLineStringSuffix()
		{
			return this.m_cMultiLineStringSuffix;
		}

		public void setMultiLineStringSuffix(char c)
		{
			this.m_cMultiLineStringSuffix = c;
		}

		public bool isUsingPrecentSign()
		{
			return this.m_isUsingPercentSign;
		}

		public void setUsingPrecentSign(bool b)
		{
			this.m_isUsingPercentSign = b;
		}

		public bool isAllowLongSpecifiedName()
		{
			return this.m_isAllowLongSpecifiedName;
		}

		public void setAllowLongSpecifiedName(bool b)
		{
			this.m_isAllowLongSpecifiedName = b;
		}

		public void setNamePrefixes(char[] ary)
		{
			if (ary != null && ary.Length > 0)
			{
				this.m_aryNamePrefixes = new List<char>();
				this.m_aryNamePrefixes.AddRange(ary);
			}
		}

		public void setNamePrefixes(string str)
		{
			this.m_aryNamePrefixes = this.fromString(str);
			if (null == this.m_aryNameChars)
			{
				this.m_aryNameChars = this.fromString(str);
			}
			else
			{
				this.m_aryNameChars.AddRange(this.m_aryNamePrefixes);
			}
		}

		public bool isNamePrefix(char c)
		{
			return this.m_aryNamePrefixes != null && this.m_aryNamePrefixes.Contains(c);
		}

		public void setNameChars(char[] ary)
		{
			if (ary != null && ary.Length > 0)
			{
				this.m_aryNameChars = new List<char>();
				this.m_aryNameChars.AddRange(ary);
			}
		}

		public void setNameChars(string str)
		{
			this.m_aryNameChars = this.fromString(str);
		}

		public bool isNameChar(char c)
		{
			return this.m_aryNameChars != null && this.m_aryNameChars.Contains(c);
		}
	}
}
