using System;

namespace DCIIDS.Data
{
	internal class InnerConvert
	{
		public static DateTime ToDateTime(object obj)
		{
			return InnerConvert.ToDateTime(obj, DateTime.Now);
		}

		public static DateTime ToDateTime(object obj, DateTime defaultValue)
		{
			DateTime result;
			try
			{
				if (null == obj)
				{
					result = defaultValue;
				}
				else
				{
					result = Convert.ToDateTime(obj);
				}
			}
			catch (Exception)
			{
				result = defaultValue;
			}
			return result;
		}

		public static string ToString(object obj)
		{
			return InnerConvert.ToString(obj, "");
		}

		public static string ToString(object obj, string strDefault)
		{
			string result;
			try
			{
				if (null == obj)
				{
					result = strDefault;
				}
				else
				{
					result = Convert.ToString(obj);
				}
			}
			catch (Exception)
			{
				result = strDefault;
			}
			return result;
		}

		public static double ToDouble(object obj)
		{
			return InnerConvert.ToDouble(obj, 0.0);
		}

		public static double ToDouble(object obj, double lfDefault)
		{
			double result;
			try
			{
				if (null == obj)
				{
					result = lfDefault;
				}
				else
				{
					result = Convert.ToDouble(obj);
				}
			}
			catch (Exception)
			{
				result = lfDefault;
			}
			return result;
		}

		public static int ToInt32(object obj)
		{
			return InnerConvert.ToInt32(obj, 0);
		}

		public static long ToInt64(object obj)
		{
			return InnerConvert.ToInt64(obj, 0L);
		}

		public static short ToInt16(object obj)
		{
			return InnerConvert.ToInt16(obj, 0);
		}

		public static int ToInt32(object obj, int defaultValue)
		{
			int result;
			try
			{
				if (null == obj)
				{
					result = defaultValue;
				}
				else
				{
					result = Convert.ToInt32(obj);
				}
			}
			catch (Exception)
			{
				result = defaultValue;
			}
			return result;
		}

		public static long ToInt64(object obj, long defaultValue)
		{
			long result;
			try
			{
				if (null == obj)
				{
					result = defaultValue;
				}
				else
				{
					result = Convert.ToInt64(obj);
				}
			}
			catch (Exception)
			{
				result = defaultValue;
			}
			return result;
		}

		public static short ToInt16(object obj, short defaultValue)
		{
			short result;
			try
			{
				if (null == obj)
				{
					result = defaultValue;
				}
				else
				{
					result = Convert.ToInt16(obj);
				}
			}
			catch (Exception)
			{
				result = defaultValue;
			}
			return result;
		}

		public static bool ToBoolean(object obj)
		{
			bool result;
			if (null == obj)
			{
				result = false;
			}
			else
			{
				Type type = obj.GetType();
				if (type.Equals(typeof(short)) || type.Equals(typeof(byte)) || type.Equals(typeof(byte)) || type.Equals(typeof(short)))
				{
					result = (Convert.ToInt16(obj) > 0);
				}
				else if (type.Equals(typeof(long)) || type.Equals(typeof(long)))
				{
					result = (Convert.ToInt64(obj) > 0L);
				}
				else if (type.Equals(typeof(int)) || type.Equals(typeof(int)))
				{
					result = (Convert.ToInt32(obj) > 0);
				}
				else if (type.Equals(typeof(double)) || type.Equals(typeof(float)) || type.Equals(typeof(double)))
				{
					result = (Convert.ToDouble(obj) > 0.0);
				}
				else if (type.Equals(typeof(decimal)))
				{
					result = (Convert.ToDecimal(obj) > 0m);
				}
				else if (type.Equals(typeof(bool)))
				{
					result = Convert.ToBoolean(obj);
				}
				else
				{
					result = (null != obj);
				}
			}
			return result;
		}

		public static decimal ToDecimal(object obj)
		{
			return Convert.ToDecimal(obj);
		}
	}
}
