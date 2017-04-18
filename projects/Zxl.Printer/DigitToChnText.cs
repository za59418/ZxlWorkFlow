using System;
using System.Text;

namespace Zxl.Printer
{
	public class DigitToChnText
	{
		private static DigitToChnText chnTextOperator;

		private readonly char[] chnTimeText;

		private readonly char[] chnGenText;

		private readonly char[] chnGenDigit;

		private readonly char[] chnRMBText;

		private readonly char[] chnRMBDigit;

		private readonly char[] chnRMBUnit;

		public static DigitToChnText ChnTextOperator
		{
			get
			{
				if (DigitToChnText.chnTextOperator == null)
				{
					DigitToChnText.chnTextOperator = new DigitToChnText();
				}
				return DigitToChnText.chnTextOperator;
			}
		}

		public DigitToChnText()
		{
			this.chnTimeText = new char[]
			{
				'〇',
				'一',
				'二',
				'三',
				'四',
				'五',
				'六',
				'七',
				'八',
				'九'
			};
			this.chnGenText = new char[]
			{
				'零',
				'一',
				'二',
				'三',
				'四',
				'五',
				'六',
				'七',
				'八',
				'九'
			};
			this.chnGenDigit = new char[]
			{
				'十',
				'百',
				'千',
				'万',
				'亿'
			};
			this.chnRMBText = new char[]
			{
				'零',
				'壹',
				'贰',
				'叁',
				'肆',
				'伍',
				'陆',
				'柒',
				'捌',
				'玖'
			};
			this.chnRMBDigit = new char[]
			{
				'拾',
				'佰',
				'仟',
				'万',
				'亿'
			};
			this.chnRMBUnit = new char[]
			{
				'角',
				'分'
			};
		}

		public string ConvertDateTimeToChnTimeOnlyDate(System.DateTime resTime)
		{
			string text = this.ConvertYearIntegral(resTime.Year.ToString());
			string text2 = this.ConvertIntegral(resTime.Month.ToString(), false);
			if (text2.Length < 2)
			{
				text2 += "  ";
			}
			string text3 = this.ConvertIntegral(resTime.Day.ToString(), false);
			return string.Concat(new string[]
			{
				text,
				"  ",
				text2,
				"  ",
				text3,
				"  "
			});
		}

		public string ConvertDigitTimeToChnTime(System.DateTime resTime)
		{
			string text = resTime.ToLongDateString();
			int num = text.IndexOf('年');
			int num2 = text.IndexOf('月');
			int num3 = text.IndexOf('日');
			string strYearIntegral = text.Substring(0, num);
			string strIntegral = text.Substring(num + 1, num2 - num - 1);
			string strIntegral2 = text.Substring(num2 + 1, num3 - num2 - 1);
			string text2 = this.ConvertYearIntegral(strYearIntegral);
			string text3 = this.ConvertIntegral(strIntegral, false);
			string text4 = this.ConvertIntegral(strIntegral2, false);
			return string.Concat(new string[]
			{
				text2,
				"年",
				text3,
				"月",
				text4,
				"日"
			});
		}

		public string ConvertDigitNumToChnNum(string strDigit)
		{
			string result;
			if (!this.CheckDigit(ref strDigit, false))
			{
				result = "";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				this.ExtractSign(ref stringBuilder, ref strDigit, false);
				this.ConvertNumber(ref stringBuilder, ref strDigit, false);
				result = stringBuilder.ToString();
			}
			return result;
		}

		public string ConvertDigitNumToChnNum2(string strDigit)
		{
			if (!string.IsNullOrEmpty(strDigit) && strDigit.Length > 0)
			{
				for (int i = 0; i < 10; i++)
				{
					strDigit = strDigit.Replace(i.ToString(), this.chnRMBText[i].ToString());
				}
			}
			return strDigit;
		}

		public string ConvertDigitMoneyToChnMoney(string strDigit)
		{
			string result;
			if (!this.CheckDigit(ref strDigit, false))
			{
				result = "";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				this.ExtractSign(ref stringBuilder, ref strDigit, true);
				this.ConvertNumber(ref stringBuilder, ref strDigit, true);
				result = stringBuilder.ToString();
			}
			return result;
		}

		protected void ConvertNumber(ref System.Text.StringBuilder strResult, ref string strDigit, bool bToRMB)
		{
			int num;
			if (-1 == (num = strDigit.IndexOf('.')))
			{
				strResult.Append(this.ConvertIntegral(strDigit, bToRMB));
				if (bToRMB)
				{
					strResult.Append("圆整");
				}
			}
			else
			{
				if (0 == num)
				{
					if (!bToRMB)
					{
						strResult.Append('零');
					}
				}
				else
				{
					strResult.Append(this.ConvertIntegral(strDigit.Substring(0, num), bToRMB));
				}
				if (strDigit.Length - 1 != num)
				{
					if (bToRMB)
					{
						if (0 != num)
						{
							if (1 == strResult.Length && "零" == strResult.ToString())
							{
								strResult.Remove(0, 1);
							}
							else
							{
								strResult.Append('圆');
							}
						}
					}
					else
					{
						strResult.Append('点');
					}
					string text = this.ConvertFractional(strDigit.Substring(num + 1), bToRMB);
					if (0 != text.Length)
					{
						if (bToRMB && strResult.Length == 0 && "零" == text.Substring(0, 1))
						{
							strResult.Append(text.Substring(1));
						}
						else
						{
							strResult.Append(text);
						}
					}
					if (bToRMB)
					{
						if (0 == strResult.Length)
						{
							strResult.Append("零圆整");
						}
						else if ("圆" == strResult.ToString().Substring(strResult.Length - 1, 1))
						{
							strResult.Append('整');
						}
					}
				}
				else if (bToRMB)
				{
					strResult.Append("圆整");
				}
			}
		}

		private bool CheckDigit(ref string strDigit, bool bToRMB)
		{
			decimal d;
			bool result;
			try
			{
				d = decimal.Parse(strDigit);
			}
			catch (System.Exception var_1_0D)
			{
				result = false;
				return result;
			}
			if (bToRMB)
			{
				if (d >= new decimal(10000000000000000L))
				{
					result = false;
					return result;
				}
				if (d < 0m)
				{
					result = false;
					return result;
				}
			}
			else if (d <= new decimal(-10000000000000000L) || d >= new decimal(10000000000000000L))
			{
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		protected void ExtractSign(ref System.Text.StringBuilder strResult, ref string strDigit, bool bToRMB)
		{
			if ("+" == strDigit.Substring(0, 1))
			{
				strDigit = strDigit.Substring(1);
			}
			else if ("-" == strDigit.Substring(0, 1))
			{
				if (!bToRMB)
				{
					strResult.Append('负');
				}
				strDigit = strDigit.Substring(1);
			}
			else if ("+" == strDigit.Substring(strDigit.Length - 1, 1))
			{
				strDigit = strDigit.Substring(0, strDigit.Length - 1);
			}
			else if ("-" == strDigit.Substring(strDigit.Length - 1, 1))
			{
				if (!bToRMB)
				{
					strResult.Append('负');
				}
				strDigit = strDigit.Substring(0, strDigit.Length - 1);
			}
		}

		public string ConvertIntegral(string strIntegral, bool bToRMB)
		{
			char[] array = long.Parse(strIntegral).ToString().ToCharArray();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int num = array.Length - 1;
			char[] array2 = bToRMB ? this.chnRMBText : this.chnGenText;
			char[] array3 = bToRMB ? this.chnRMBDigit : this.chnGenDigit;
			int i;
			for (i = 0; i < array.Length - 1; i++)
			{
				stringBuilder.Append(array2[(int)(array[i] - '0')]);
				if (0 == num % 4)
				{
					if (4 == num || 12 == num)
					{
						stringBuilder.Append(array3[3]);
					}
					else if (8 == num)
					{
						stringBuilder.Append(array3[4]);
					}
				}
				else
				{
					stringBuilder.Append(array3[num % 4 - 1]);
				}
				num--;
			}
			if ('0' != array[array.Length - 1] || 1 == array.Length)
			{
				stringBuilder.Append(array2[(int)(array[i] - '0')]);
			}
			i = 0;
			string text;
			while (i < stringBuilder.Length)
			{
				int num2 = i;
				bool flag = false;
				while (num2 < stringBuilder.Length - 1 && "零" == stringBuilder.ToString().Substring(num2, 1))
				{
					text = stringBuilder.ToString().Substring(num2 + 1, 1);
					if (array3[3].ToString() == text || array3[4].ToString() == text)
					{
						flag = true;
						break;
					}
					num2 += 2;
				}
				if (num2 != i)
				{
					stringBuilder = stringBuilder.Remove(i, num2 - i);
					if (i <= stringBuilder.Length - 1 && !flag)
					{
						stringBuilder = stringBuilder.Insert(i, '零');
						i++;
					}
				}
				if (flag)
				{
					stringBuilder = stringBuilder.Remove(i, 1);
					i++;
				}
				else
				{
					i += 2;
				}
			}
			text = array3[4].ToString() + array3[3].ToString();
			int num3 = stringBuilder.ToString().IndexOf(text);
			if (-1 != num3)
			{
				if (stringBuilder.Length - 2 != num3 && num3 + 2 < stringBuilder.Length && "零" != stringBuilder.ToString().Substring(num3 + 2, 1))
				{
					stringBuilder = stringBuilder.Replace(text, array3[4].ToString(), num3, 2);
					stringBuilder = stringBuilder.Insert(num3 + 1, "零");
				}
				else
				{
					stringBuilder = stringBuilder.Replace(text, array3[4].ToString(), num3, 2);
				}
			}
			if (!bToRMB)
			{
				if (stringBuilder.Length > 1 && "一十" == stringBuilder.ToString().Substring(0, 2))
				{
					stringBuilder = stringBuilder.Remove(0, 1);
				}
			}
			return stringBuilder.ToString();
		}

		protected string ConvertFractional(string strFractional, bool bToRMB)
		{
			char[] array = strFractional.ToCharArray();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			if (bToRMB)
			{
				for (int i = 0; i < System.Math.Min(2, array.Length); i++)
				{
					stringBuilder.Append(this.chnRMBText[(int)(array[i] - '0')]);
					stringBuilder.Append(this.chnRMBUnit[i]);
				}
				if ("零分" == stringBuilder.ToString().Substring(stringBuilder.Length - 2, 2))
				{
					stringBuilder.Remove(stringBuilder.Length - 2, 2);
				}
				if ("零角" == stringBuilder.ToString().Substring(0, 2))
				{
					if (2 == stringBuilder.Length)
					{
						stringBuilder.Remove(0, 2);
					}
					else
					{
						stringBuilder.Remove(1, 1);
					}
				}
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(this.chnGenText[(int)(array[i] - '0')]);
				}
			}
			return stringBuilder.ToString();
		}

		public string ConvertYearIntegral(string strYearIntegral)
		{
			char[] array = long.Parse(strYearIntegral).ToString().ToCharArray();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int num = array.Length;
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(this.chnTimeText[(int)(array[i] - '0')]);
			}
			return stringBuilder.ToString();
		}

		public string ToDBC(string input)
		{
			char[] array = input.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == '\u3000')
				{
					array[i] = ' ';
				}
				else if (array[i] > '＀' && array[i] < '｟')
				{
					array[i] -= 'ﻠ';
				}
			}
			return new string(array);
		}

		public string GetFormatValue(string value, string formatStr)
		{
			string text = formatStr.ToUpper();
			string result;
			if (text.Equals("DATECN"))
			{
				System.DateTime resTime;
				if (System.DateTime.TryParse(value, out resTime))
				{
					if (resTime.Year == 1)
					{
						result = "";
						return result;
					}
					result = DigitToChnText.ChnTextOperator.ConvertDigitTimeToChnTime(resTime);
					return result;
				}
			}
			else
			{
				if (text.Equals("NUMBERCN"))
				{
					result = DigitToChnText.ChnTextOperator.ConvertDigitNumToChnNum(value);
					return result;
				}
				if (text.Equals("NUMBERCN2"))
				{
					result = DigitToChnText.ChnTextOperator.ConvertDigitNumToChnNum2(value);
					return result;
				}
				if (text.Equals("NUMBERCN3"))
				{
					if (string.IsNullOrEmpty(value.Trim()))
					{
						result = "";
						return result;
					}
					value = value.Replace(",", "");
					string text2 = DigitToChnText.ChnTextOperator.ConvertDigitMoneyToChnMoney((value.Split(new char[]
					{
						'.'
					}).Length > 1) ? value.Split(new char[]
					{
						'.'
					})[0] : value);
					if (string.IsNullOrEmpty(text2))
					{
						result = "";
						return result;
					}
					if (value.Split(new char[]
					{
						'.'
					}).Length > 1)
					{
						text2 = text2.Replace("圆整", "点");
						string text3 = DigitToChnText.ChnTextOperator.ConvertDigitNumToChnNum2(value.Split(new char[]
						{
							'.'
						})[1]);
						if (!string.IsNullOrEmpty(text3))
						{
							text2 += text3;
						}
					}
					else
					{
						text2 = text2.Replace("圆整", "");
					}
					result = text2;
					return result;
				}
				else
				{
					if (text.Equals("MONEYCN"))
					{
						result = DigitToChnText.ChnTextOperator.ConvertDigitMoneyToChnMoney(value);
						return result;
					}
					System.DateTime resTime;
					if (text.Equals("DATETYPE1"))
					{
						string format = "yyyy-M-d";
						if (System.DateTime.TryParse(value, out resTime))
						{
							if (resTime.Year == 1)
							{
								result = "";
								return result;
							}
							result = resTime.ToString(format);
							return result;
						}
					}
					else if (text.Equals("DATETYPE2"))
					{
						string format = "yyyy年M月d日";
						if (System.DateTime.TryParse(value, out resTime))
						{
							if (resTime.Year == 1)
							{
								result = "";
								return result;
							}
							result = resTime.ToString(format);
							return result;
						}
					}
					else if (text.Equals("DATEYEAR"))
					{
						if (System.DateTime.TryParse(value, out resTime))
						{
							result = resTime.Year.ToString();
							return result;
						}
					}
					else if (text.Equals("DATEMONTH"))
					{
						if (System.DateTime.TryParse(value, out resTime))
						{
							result = resTime.Month.ToString();
							return result;
						}
					}
					else if (text.Equals("DATEDAY"))
					{
						if (System.DateTime.TryParse(value, out resTime))
						{
							result = resTime.Day.ToString();
							return result;
						}
					}
					else if (text.Equals("DATEYEAR_CN"))
					{
						if (System.DateTime.TryParse(value, out resTime))
						{
							result = DigitToChnText.ChnTextOperator.ConvertYearIntegral(resTime.Year.ToString());
							return result;
						}
					}
					else if (text.Equals("DATEMONTH_CN"))
					{
						if (System.DateTime.TryParse(value, out resTime))
						{
							result = DigitToChnText.ChnTextOperator.ConvertIntegral(resTime.Month.ToString(), false);
							return result;
						}
					}
					else if (text.Equals("DATEDAY_CN"))
					{
						if (System.DateTime.TryParse(value, out resTime))
						{
							result = DigitToChnText.ChnTextOperator.ConvertIntegral(resTime.Day.ToString(), false);
							return result;
						}
					}
					else if (text.Equals("FREETIME"))
					{
						double num = 0.0;
						if (double.TryParse(value, out num))
						{
							decimal num2 = System.Math.Truncate(System.Convert.ToDecimal((num - System.Math.Truncate(num)) * 7.5));
							if (num2 < 0m)
							{
								num2 *= -1m;
							}
							decimal num3 = System.Convert.ToDecimal(System.Math.Truncate(num));
							if (num2 == 0m)
							{
								result = string.Format("{0}天", num3);
								return result;
							}
							result = string.Format("{0}天{1}小时", num3, num2);
							return result;
						}
					}
					else if (text.Equals("FREETIME"))
					{
						double num = 0.0;
						if (double.TryParse(value, out num))
						{
							decimal num2 = System.Math.Truncate(System.Convert.ToDecimal((num - System.Math.Truncate(num)) * 7.5));
							if (num2 < 0m)
							{
								num2 *= -1m;
							}
							decimal num3 = System.Convert.ToDecimal(System.Math.Truncate(num));
							if (num2 == 0m)
							{
								result = string.Format("{0}天", num3);
								return result;
							}
							result = string.Format("{0}天{1}小时", num3, num2);
							return result;
						}
					}
					else if (System.DateTime.TryParse(value, out resTime))
					{
						result = resTime.ToString(formatStr);
						return result;
					}
				}
			}
			result = value;
			return result;
		}
	}
}
