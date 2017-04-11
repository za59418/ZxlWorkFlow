using System;
using System.Collections.Generic;

namespace Zxl.Data
{
	public class TableMapFactory
	{
		private Dictionary<Type, TableMap> m_mapType2Table = new Dictionary<Type, TableMap>();

		private static TableMapFactory m_instance = null;

		public static TableMapFactory Instance
		{
			get
			{
				if (null == TableMapFactory.m_instance)
				{
					lock (typeof(TableMapFactory))
					{
						if (null == TableMapFactory.m_instance)
						{
							TableMapFactory.m_instance = new TableMapFactory();
						}
					}
				}
				return TableMapFactory.m_instance;
			}
		}

		public TableMap this[object type]
		{
			get
			{
				return (type == null) ? null : this[type.GetType()];
			}
		}

		public TableMap this[string strTableName]
		{
			get
			{
				TableMap result;
				if (strTableName == null || strTableName.Trim().Length < 1 || null == this.m_mapType2Table)
				{
					result = null;
				}
				else
				{
					foreach (KeyValuePair<Type, TableMap> current in this.m_mapType2Table)
					{
						if (current.Value.TableName != null && current.Value.TableName.Equals(strTableName, StringComparison.CurrentCultureIgnoreCase))
						{
							result = current.Value;
							return result;
						}
					}
					result = null;
				}
				return result;
			}
		}

		public TableMap this[Type type]
		{
			get
			{
				TableMap result;
				if (null == type)
				{
					result = null;
				}
				else
				{
					TableMap tableMap = this.m_mapType2Table.ContainsKey(type) ? this.m_mapType2Table[type] : null;
					if (null == tableMap)
					{
						lock (typeof(TableMapFactory))
						{
							tableMap = new TableMap(type);
							this.m_mapType2Table.Add(type, tableMap);
						}
					}
					result = tableMap;
				}
				return result;
			}
		}

		private TableMapFactory()
		{
		}

		public Dictionary<Type, TableMap>.ValueCollection GetAllTableMaps()
		{
			return this.m_mapType2Table.Values;
		}

		public string GetTableColumnName(Type t, string strFieldName)
		{
			TableMap tableMap = this[t];
			string result;
			if (null == tableMap)
			{
				result = strFieldName;
			}
			else
			{
				foreach (FieldAttribute current in tableMap.MappedFields)
				{
					if (current.ClassField.Equals(strFieldName, StringComparison.CurrentCultureIgnoreCase))
					{
						result = current.TableFiled;
						return result;
					}
				}
				result = strFieldName;
			}
			return result;
		}

		public string GetTableNameFromType(Type t)
		{
			TableMap tableMap = this[t];
			return (tableMap == null) ? t.Name : tableMap.TableName;
		}
	}
}
