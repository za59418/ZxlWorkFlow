using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DCIIDS.Data
{
	public class DefaultDbTypeCast
	{
		public virtual object GetNullValue(Type type, object obj)
		{
			object result;
			switch (this.GetDbType(type))
			{
			case DbType.Date:
			case DbType.DateTime:
			case DbType.Time:
				result = ((obj == null) ? DateTime.MinValue : obj);
				return result;
			case DbType.Decimal:
				result = -79228162514264337593543950335m;
				return result;
			case DbType.Double:
			case DbType.Single:
				result = -1.7976931348623157E+308;
				return result;
			case DbType.Int16:
			case DbType.Int32:
			case DbType.Int64:
			case DbType.UInt16:
			case DbType.UInt32:
			case DbType.UInt64:
				result = -2147483648;
				return result;
			}
			result = obj;
			return result;
		}

		public virtual bool IsDbNullValue(object obj)
		{
			bool result;
			if (null == obj)
			{
				result = true;
			}
			else
			{
				switch (this.GetDbType(obj.GetType()))
				{
				case DbType.Date:
				case DbType.DateTime:
				case DbType.Time:
					result = (DateTime.MinValue.Ticks == ((DateTime)obj).Ticks || ((DateTime)obj).Ticks < 1L);
					return result;
				case DbType.Decimal:
					result = (-79228162514264337593543950335m == (decimal)obj);
					return result;
				case DbType.Double:
					result = (-1.7976931348623157E+308 == (double)obj);
					return result;
				case DbType.Int16:
					result = (-32768 == (short)obj);
					return result;
				case DbType.Int32:
					result = (-2147483648 == (int)obj);
					return result;
				case DbType.Int64:
					result = (-9223372036854775808L == (long)obj);
					return result;
				case DbType.Single:
					result = (-3.40282347E+38f == (float)obj);
					return result;
				case DbType.UInt16:
					result = (0 == (ushort)obj);
					return result;
				case DbType.UInt32:
					result = (0u == (uint)obj);
					return result;
				case DbType.UInt64:
					result = (0uL == (ulong)obj);
					return result;
				}
				result = (null == obj);
			}
			return result;
		}

		public virtual object Cast(Type type, object obj)
		{
			object result;
			if (type.IsArray)
			{
				result = obj;
			}
			else if (type.IsEnum)
			{
				result = InnerConvert.ToInt32(obj);
			}
			else if (type.Equals(typeof(short)) || type.Equals(typeof(byte)) || type.Equals(typeof(byte)) || type.Equals(typeof(short)))
			{
				result = InnerConvert.ToInt16(obj);
			}
			else if (type.Equals(typeof(long)) || type.Equals(typeof(long)))
			{
				result = InnerConvert.ToInt64(obj);
			}
			else if (type.Equals(typeof(int)) || type.Equals(typeof(int)))
			{
				result = InnerConvert.ToInt32(obj);
			}
			else if (type.Equals(typeof(double)) || type.Equals(typeof(float)) || type.Equals(typeof(double)))
			{
				result = InnerConvert.ToDouble(obj);
			}
			else if (type.Equals(typeof(decimal)))
			{
				result = InnerConvert.ToDecimal(obj);
			}
			else
			{
				if (type.Equals(typeof(bool)))
				{
					obj = InnerConvert.ToBoolean(obj);
				}
				else if (type.Equals(typeof(DateTime)))
				{
					obj = InnerConvert.ToDateTime(obj);
				}
				else if (obj != null && !type.Equals(typeof(byte[])) && obj.GetType().Equals(typeof(byte[])))
				{
					IFormatter formatter = new BinaryFormatter();
					MemoryStream memoryStream = new MemoryStream(obj as byte[]);
					obj = formatter.Deserialize(memoryStream);
					memoryStream.Close();
				}
				result = obj;
			}
			return result;
		}

		public virtual DbType GetDbType(Type type)
		{
			DbType result;
			if (type.IsArray)
			{
				result = DbType.Binary;
			}
			else if (type.IsEnum)
			{
				result = DbType.Int32;
			}
			else if (type.Equals(typeof(short)) || type.Equals(typeof(byte)) || type.Equals(typeof(byte)) || type.Equals(typeof(short)))
			{
				result = DbType.Int16;
			}
			else if (type.Equals(typeof(long)) || type.Equals(typeof(long)))
			{
				result = DbType.Int64;
			}
			else if (type.Equals(typeof(int)) || type.Equals(typeof(int)))
			{
				result = DbType.Int32;
			}
			else if (type.Equals(typeof(string)) || type.Equals(typeof(char)) || type.Equals(typeof(char)) || type.Equals(typeof(string)))
			{
				result = DbType.String;
			}
			else if (type.Equals(typeof(double)) || type.Equals(typeof(float)) || type.Equals(typeof(double)))
			{
				result = DbType.Double;
			}
			else if (type.Equals(typeof(decimal)))
			{
				result = DbType.Decimal;
			}
			else if (type.Equals(typeof(bool)))
			{
				result = DbType.Boolean;
			}
			else if (type.Equals(typeof(DateTime)))
			{
				result = DbType.DateTime;
			}
			else
			{
				result = DbType.Binary;
			}
			return result;
		}
	}
}
