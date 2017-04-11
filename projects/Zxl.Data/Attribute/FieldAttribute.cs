using System;
using System.Reflection;

namespace Zxl.Data
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class FieldAttribute : Attribute
	{
		private bool m_isNulable = true;

		public bool EnumName
		{
			get;
			set;
		}

		public int Length
		{
			get;
			set;
		}

		public int Scale
		{
			get
			{
				return this.Length;
			}
			set
			{
				this.Length = value;
			}
		}

		public int Precision
		{
			get;
			set;
		}

		public string DatabaseDataTypeString
		{
			get;
			set;
		}

		public string ClassField
		{
			get
			{
				return (this.FieldInfo == null) ? ((this.PropertyInfo == null) ? null : this.PropertyInfo.Name) : this.FieldInfo.Name;
			}
		}

		public Type ClassFieldType
		{
			get
			{
				return (this.FieldInfo == null) ? ((this.PropertyInfo == null) ? null : this.PropertyInfo.PropertyType) : this.FieldInfo.FieldType;
			}
		}

		public string TableFiled
		{
			get;
			set;
		}

		public bool PrimaryKey
		{
			get;
			set;
		}

		public bool PK
		{
			get
			{
				return this.PrimaryKey;
			}
			set
			{
				this.PrimaryKey = value;
			}
		}

		public object NullValue
		{
			get;
			set;
		}

		public bool Nullable
		{
			get
			{
				return !this.PrimaryKey && this.m_isNulable;
			}
			set
			{
				this.m_isNulable = value;
			}
		}

		public bool NotNull
		{
			get
			{
				return !this.Nullable;
			}
			set
			{
				this.Nullable = !value;
			}
		}

		public int Len
		{
			get
			{
				return this.Length;
			}
			set
			{
				this.Length = value;
			}
		}

		public FieldInfo FieldInfo
		{
			get;
			internal set;
		}

		public PropertyInfo PropertyInfo
		{
			get;
			set;
		}

		public FieldAttribute()
		{
		}

		public FieldAttribute(int nColumnLength)
		{
			this.Length = nColumnLength;
		}

		public FieldAttribute(string strColumnName)
		{
			this.TableFiled = strColumnName;
		}

		public FieldAttribute(string strColumnName, int nColumnLength)
		{
			this.TableFiled = strColumnName;
			this.Length = nColumnLength;
		}

		public void SetValue(object objInstance, object value)
		{
			if (this.PropertyInfo != null && this.PropertyInfo.CanWrite)
			{
				this.PropertyInfo.SetValue(objInstance, value, null);
			}
			else if (null != this.FieldInfo)
			{
				this.FieldInfo.SetValue(objInstance, value);
			}
		}

		public object GetValue(object objInstance)
		{
			object value;
			if (this.PropertyInfo != null && this.PropertyInfo.CanRead)
			{
				value = this.PropertyInfo.GetValue(objInstance, null);
			}
			else
			{
				if (null == this.FieldInfo)
				{
					throw new ORMException("不能读取值");
				}
				value = this.FieldInfo.GetValue(objInstance);
			}
			return value;
		}
	}
}
