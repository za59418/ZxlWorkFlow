using System;
using System.Collections.Generic;
using System.Reflection;

namespace Zxl.Data
{
	public class TableMap
	{
		private string m_strTableName = null;

		private Type m_initType = null;

		private List<FieldAttribute> m_mapFields = new List<FieldAttribute>();

		public Type InitType
		{
			get
			{
				return this.m_initType;
			}
		}

		public List<FieldAttribute> MappedFields
		{
			get
			{
				return (this.m_mapFields.Count > 0) ? this.m_mapFields : null;
			}
		}

		public List<FieldAttribute> PrimaryKeys
		{
			get
			{
				List<FieldAttribute> list = new List<FieldAttribute>();
				foreach (FieldAttribute current in this.m_mapFields)
				{
					if (current.PrimaryKey)
					{
						list.Add(current);
					}
				}
				return list;
			}
		}

		public string TableName
		{
			get
			{
				return this.m_strTableName;
			}
		}

		public FieldAttribute this[string strFieldName]
		{
			get
			{
				FieldAttribute result;
				if (strFieldName == null || strFieldName.Length < 1)
				{
					result = null;
				}
				else
				{
					int num = 0;
					while (this.m_mapFields != null && num < this.m_mapFields.Count)
					{
						FieldAttribute fieldAttribute = this.m_mapFields[num];
						if (fieldAttribute.TableFiled != null && fieldAttribute.TableFiled.Equals(strFieldName, StringComparison.CurrentCultureIgnoreCase))
						{
							result = fieldAttribute;
							return result;
						}
						if (fieldAttribute.FieldInfo != null && fieldAttribute.FieldInfo.Name.Equals(strFieldName, StringComparison.CurrentCultureIgnoreCase))
						{
							result = fieldAttribute;
							return result;
						}
						if (fieldAttribute.PropertyInfo != null && fieldAttribute.PropertyInfo.Name.Equals(strFieldName, StringComparison.CurrentCultureIgnoreCase))
						{
							result = fieldAttribute;
							return result;
						}
						num++;
					}
					result = null;
				}
				return result;
			}
		}

		public TableMap(Type typeBean)
		{
			if (null == typeBean)
			{
				throw new ORMException("Can not build a " + typeof(TableMap).FullName + " from a Null pointer.");
			}
			try
			{
				this.m_initType = typeBean;
				this.initTableName(typeBean);
				FieldInfo[] fields = typeBean.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				for (int i = 0; i < fields.Length; i++)
				{
					FieldInfo fieldInfo = fields[i];
					FieldAttribute[] array = (FieldAttribute[])fieldInfo.GetCustomAttributes(typeof(FieldAttribute), false);
					if (null != array)
					{
						FieldAttribute[] array2 = array;
						for (int j = 0; j < array2.Length; j++)
						{
							FieldAttribute fieldAttribute = array2[j];
							this.RemoveByFieldInfo(fieldInfo);
							fieldAttribute.FieldInfo = fieldInfo;
							if (string.IsNullOrEmpty(fieldAttribute.TableFiled))
							{
								fieldAttribute.TableFiled = fieldInfo.Name;
							}
							this.m_mapFields.Add(fieldAttribute);
						}
					}
				}
				PropertyInfo[] properties = typeBean.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				for (int i = 0; i < properties.Length; i++)
				{
					PropertyInfo propertyInfo = properties[i];
					FieldAttribute[] array = (FieldAttribute[])propertyInfo.GetCustomAttributes(typeof(FieldAttribute), false);
					if (null != array)
					{
						if (propertyInfo.GetSetMethod(true) != null && null != propertyInfo.GetGetMethod(true))
						{
							FieldAttribute[] array2 = array;
							for (int j = 0; j < array2.Length; j++)
							{
								FieldAttribute fieldAttribute = array2[j];
								this.RemoveByPropertyInfo(propertyInfo);
								fieldAttribute.PropertyInfo = propertyInfo;
								if (string.IsNullOrEmpty(fieldAttribute.TableFiled))
								{
									fieldAttribute.TableFiled = propertyInfo.Name;
								}
								this.m_mapFields.Add(fieldAttribute);
							}
						}
					}
				}
				if (this.m_mapFields == null || this.m_mapFields.Count < 1)
				{
					throw new ORMConfigException(string.Concat(new string[]
					{
						"Can not build a instance of ",
						typeof(TableMap).FullName,
						" from class ",
						typeBean.FullName,
						", no filed and property has been annotated with ",
						typeof(FieldAttribute).FullName
					}));
				}
			}
			catch (ORMException ex)
			{
				throw ex;
			}
			catch (Exception innerException)
			{
				throw new ORMException("Can not build a instance of " + typeof(TableMap).FullName + " from class " + typeBean.FullName, innerException);
			}
		}

		private void initTableName(Type typeBean)
		{
			TableAttribute[] array = (TableAttribute[])typeBean.GetCustomAttributes(typeof(TableAttribute), false);
			if (array != null && array.Length > 1)
			{
				throw new ORMException("Mapping Error：The class " + typeBean.FullName + " has been mapped to more than one database-table.");
			}
			if (array != null && array.Length > 0)
			{
				this.m_strTableName = array[0].Name;
			}
			if (string.IsNullOrEmpty(this.m_strTableName))
			{
				if (array[0].Prefix != null && array[0].Prefix.Trim().Length > 0)
				{
					this.m_strTableName = array[0].Prefix.Trim() + typeBean.Name;
				}
				else
				{
					this.m_strTableName = typeBean.Name;
				}
			}
			if (string.IsNullOrEmpty(this.m_strTableName))
			{
				throw new ORMException("构造TableMap实例出现错误,From[" + typeBean.FullName + "]，无法确定表格的名称！");
			}
		}

		public TableIndexAttribute[] GetIndexes()
		{
			TableIndexAttribute[] result;
			if (null == this.m_initType)
			{
				result = null;
			}
			else
			{
				result = (TableIndexAttribute[])this.m_initType.GetCustomAttributes(typeof(TableIndexAttribute), false);
			}
			return result;
		}

		private void RemoveByFieldInfo(FieldInfo f)
		{
			int num = 0;
			while (this.m_mapFields != null && num < this.m_mapFields.Count)
			{
				if (this.m_mapFields[num].FieldInfo != null && this.m_mapFields[num].FieldInfo.Equals(f))
				{
					this.m_mapFields.RemoveAt(num);
					num = Math.Max(0, num - 1);
				}
				num++;
			}
		}

		private void RemoveByPropertyInfo(PropertyInfo f)
		{
			int num = 0;
			while (this.m_mapFields != null && num < this.m_mapFields.Count)
			{
				if (this.m_mapFields[num].PropertyInfo != null && this.m_mapFields[num].PropertyInfo.Equals(f))
				{
					this.m_mapFields.RemoveAt(num);
					num = Math.Max(0, num - 1);
				}
				num++;
			}
		}

		public bool IsMapped(string strColumnName)
		{
			return null != this[strColumnName];
		}
	}
}
