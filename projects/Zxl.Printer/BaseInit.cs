using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Zxl.Printer
{
	public class BaseInit
	{
		public static void InitConstValues(System.Collections.Hashtable data)
		{
			if (data == null)
			{
				data = new System.Collections.Hashtable();
			}
			if (!data.ContainsKey("TODAY"))
			{
				data.Add("TODAY", System.DateTime.Now);
			}
			if (!data.ContainsKey("YEAR"))
			{
				data.Add("YEAR", System.DateTime.Now.Year);
			}
			if (!data.ContainsKey("MONTH"))
			{
				data.Add("MONTH", System.DateTime.Now.Month);
			}
			if (!data.ContainsKey("DAY"))
			{
				data.Add("DAY", System.DateTime.Now.Day);
			}
			foreach (System.Collections.DictionaryEntry dictionaryEntry in data)
			{
				if (dictionaryEntry.Value is DataTable)
				{
					BaseInit.InitDataTableNUM(dictionaryEntry.Value as DataTable);
				}
			}
		}

		private static void InitDataTableNUM(DataTable dt)
		{
			if (dt != null)
			{
				if (!dt.Columns.Contains("NUM"))
				{
					dt.Columns.Add("NUM", typeof(decimal));
				}
				if (!dt.Columns.Contains("ROWNUMBER"))
				{
					dt.Columns.Add("ROWNUMBER", typeof(decimal));
				}
				foreach (DataRow dataRow in dt.Rows)
				{
					dataRow["NUM"] = dataRow.Table.Rows.IndexOf(dataRow) + 1;
					dataRow["ROWNUMBER"] = dataRow["NUM"];
				}
			}
		}

		public static System.Collections.Hashtable GetHashtable(DataRow row)
		{
			System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			foreach (DataColumn dataColumn in row.Table.Columns)
			{
				hashtable.Add(dataColumn.ColumnName, row[dataColumn]);
			}
			if (!hashtable.ContainsKey("ROWNUMBER"))
			{
				hashtable.Add("ROWNUMBER", row.Table.Rows.IndexOf(row) + 1);
			}
			if (!hashtable.ContainsKey("NUM"))
			{
				hashtable.Add("NUM", row.Table.Rows.IndexOf(row) + 1);
			}
			return hashtable;
		}

		public static System.Collections.Hashtable GetHashtable(object[] objs)
		{
			System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			hashtable = (objs[0] as System.Collections.Hashtable);
			for (int i = 0; i < objs.Length; i++)
			{
				object obj = objs[i];
				if (obj != null)
				{
					if (obj is DataTable)
					{
						DataTable dataTable = obj as DataTable;
						if (dataTable != null && dataTable.Rows.Count > 0)
						{
							if (!dataTable.Columns.Contains("ROWNUMBER"))
							{
								dataTable.Columns.Add("ROWNUMBER");
							}
							if (!dataTable.Columns.Contains("NUM"))
							{
								dataTable.Columns.Add("NUM");
							}
							foreach (DataRow dataRow in dataTable.Rows)
							{
								dataRow["ROWNUMBER"] = dataRow.Table.Rows.IndexOf(dataRow) + 1;
								dataRow["NUM"] = dataRow.Table.Rows.IndexOf(dataRow) + 1;
							}
						}
						if (!hashtable.ContainsKey(dataTable.TableName))
						{
							hashtable.Add(dataTable.TableName.ToUpper(), dataTable);
							hashtable.Add(dataTable.TableName.ToUpper() + "_COUNT", (dataTable.Rows != null) ? dataTable.Rows.Count.ToString() : "0");
							hashtable.Add(dataTable.TableName.ToUpper() + "_NAME", dataTable.TableName);
						}
					}
				}
			}
			return hashtable;
		}

		public static System.Collections.Hashtable GetHashtable<T>(T obj)
		{
			System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			System.Type type = obj.GetType();
			System.Reflection.PropertyInfo[] properties = type.GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				System.Reflection.PropertyInfo propertyInfo = properties[i];
				hashtable.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null));
			}
			return hashtable;
		}
	}
}
