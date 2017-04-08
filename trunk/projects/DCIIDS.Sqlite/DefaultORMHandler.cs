using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace DCIIDS.Data
{
	public class DefaultORMHandler
	{
		private const char EncodingPrimaryKeys_Delimiter = '|';

		private const char EncodingPrimaryKeys_Assigner = '=';

		protected string m_strPrameterPrefix = "@PAM_";

		protected DefaultDbTypeCast m_type2DbType = new DefaultDbTypeCast();

		public bool Verbose
		{
			get;
			set;
		}

		private void VerboseInfo(IDbCommand command)
		{
			if (this.Verbose && null != command)
			{
				Console.WriteLine(typeof(DefaultORMHandler).FullName + ": " + command.CommandText);
			}
		}

		public DefaultORMHandler()
		{
		}

		public DefaultORMHandler(string strParameterPrefix)
		{
			this.m_strPrameterPrefix = strParameterPrefix;
		}

		public DefaultORMHandler(string strParameterPrefix, DefaultDbTypeCast caster)
		{
			this.m_strPrameterPrefix = strParameterPrefix;
			if (null != caster)
			{
				this.m_type2DbType = caster;
			}
		}

		private IDbDataParameter CreateParameter(IDbCommand cmd, FieldAttribute fa, string strParamName, object objInstance)
		{
			IDbDataParameter dbDataParameter = cmd.CreateParameter();
			dbDataParameter.ParameterName = strParamName;
			dbDataParameter.DbType = this.m_type2DbType.GetDbType(fa.ClassFieldType);
			object obj = fa.GetValue(objInstance);
			if (this.m_type2DbType.IsDbNullValue(obj))
			{
				dbDataParameter.Value = DBNull.Value;
			}
			else
			{
				if (dbDataParameter.DbType == DbType.Binary && !obj.GetType().Equals(typeof(byte[])))
				{
					IFormatter formatter = new BinaryFormatter();
					MemoryStream memoryStream = new MemoryStream();
					formatter.Serialize(memoryStream, obj);
					obj = memoryStream.ToArray();
				}
				dbDataParameter.Value = obj;
			}
			return dbDataParameter;
		}

		private IDbDataParameter CreateParameter(IDbCommand cmd, string strParamName, object paramValue)
		{
			IDbDataParameter dbDataParameter = cmd.CreateParameter();
			dbDataParameter.ParameterName = strParamName;
			dbDataParameter.DbType = ((paramValue == null) ? DbType.String : this.m_type2DbType.GetDbType(paramValue.GetType()));
			if (this.m_type2DbType.IsDbNullValue(paramValue))
			{
				dbDataParameter.Value = DBNull.Value;
			}
			else
			{
				dbDataParameter.Value = paramValue;
			}
			return dbDataParameter;
		}

		public string GetParameterName(string strColumnName)
		{
			return this.m_strPrameterPrefix + strColumnName;
		}

		public string MD5Object(object obj)
		{
			string result;
			if (null == obj)
			{
				result = null;
			}
			else
			{
				TableMap tableMap = TableMapFactory.Instance[obj];
				if (tableMap == null || null == tableMap.MappedFields)
				{
					throw new ORMException("构造" + obj.GetType().FullName + "的映射产生错误");
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (FieldAttribute current in tableMap.MappedFields)
				{
					object value = current.GetValue(obj);
					if (this.m_type2DbType.IsDbNullValue(value))
					{
						value = DBNull.Value;
					}
					stringBuilder.Append(value.ToString());
				}
				MD5 mD = new MD5CryptoServiceProvider();
				ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
				byte[] bytes = aSCIIEncoding.GetBytes(stringBuilder.ToString());
				result = DefaultORMHandler.GetHexString(mD.ComputeHash(bytes));
			}
			return result;
		}

		private static string GetHexString(byte[] bt)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < bt.Length; i++)
			{
				byte b = bt[i];
				int num = (int)b;
				int num2 = num & 15;
				int num3 = num >> 4 & 15;
				if (num3 > 9)
				{
					stringBuilder.Append(((char)(num3 - 10 + 65)).ToString());
				}
				else
				{
					stringBuilder.Append(num3.ToString());
				}
				if (num2 > 9)
				{
					stringBuilder.Append(((char)(num2 - 10 + 65)).ToString());
				}
				else
				{
					stringBuilder.Append(num2.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		public int Insert(IDbConnection conn, object obj)
		{
			int result;
			if (null == obj)
			{
				result = -1;
			}
			else
			{
				TableMap tableMap = TableMapFactory.Instance[obj];
				if (tableMap == null || null == tableMap.MappedFields)
				{
					throw new ORMException("构造" + obj.GetType().FullName + "的映射产生错误");
				}
				string text = "";
				string text2 = "";
				IDbCommand dbCommand = this.PrepareCommand(conn, null, null);
				foreach (FieldAttribute current in tableMap.MappedFields)
				{
					string parameterName = this.GetParameterName(current.TableFiled);
					if (text.Length > 0)
					{
						text += ",";
						text2 += ",";
					}
					text += current.TableFiled;
					text2 += parameterName;
					dbCommand.Parameters.Add(this.CreateParameter(dbCommand, current, parameterName, obj));
				}
				if (text.Length < 1 || text2.Length < 1)
				{
					throw new ORMException(obj.GetType().FullName + "的映射产生错误:无字段");
				}
				string format = "insert into {0}({1}) values({2})";
				dbCommand.CommandText = string.Format(format, tableMap.TableName, text, text2);
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				result = dbCommand.ExecuteNonQuery();
			}
			return result;
		}

		public List<object> Delete(Type type, IDbConnection conn, string strSql, List<object> parameters)
		{
			return this.Query(type, conn, strSql, (parameters == null) ? null : parameters.ToArray());
		}

		public List<object> Delete(Type type, IDbConnection conn, string strSql, params object[] parameters)
		{
			IDataReader dataReader = null;
			List<object> result;
			try
			{
				TableMap tableMap = TableMapFactory.Instance[type];
				if (null == tableMap)
				{
					throw new ORMException("构造" + type.FullName + "的映射产生错误");
				}
				if (strSql == null || strSql.Trim().Length < 1)
				{
					strSql = "delete from " + tableMap.TableName;
				}
				else if (strSql.Trim().ToLower().StartsWith("order"))
				{
					strSql = "delete from " + tableMap.TableName + " " + strSql;
				}
				else if (!strSql.Trim().ToLower().StartsWith("delete"))
				{
					if (!strSql.Trim().ToLower().StartsWith("where "))
					{
						strSql = "where " + strSql;
					}
					strSql = "delete from " + tableMap.TableName + " " + strSql;
				}
				IDbCommand dbCommand = this.PrepareCommand(conn, strSql, parameters);
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				dataReader = dbCommand.ExecuteReader();
				result = this.Query(type, dataReader);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (null != dataReader)
				{
					dataReader.Close();
				}
			}
			return result;
		}

		public int Delete<T>(IDbConnection conn, string strWhere) where T : class
		{
			int result;
			if (conn == null)
			{
				result = -1;
			}
			else
			{
				Type typeFromHandle = typeof(T);
				TableMap tableMap = TableMapFactory.Instance[typeFromHandle];
				if (tableMap == null || null == tableMap.MappedFields)
				{
					throw new ORMException("构造" + typeFromHandle.FullName + "的映射产生错误");
				}
				IDbCommand dbCommand = this.PrepareCommand(conn, null, null);
				if (strWhere != null && strWhere.Trim().Length > 0)
				{
					if (!strWhere.Trim().ToLower().StartsWith("where "))
					{
						strWhere = "where " + strWhere;
					}
				}
				else
				{
					strWhere = "";
				}
				string format = "delete from {0} {1}";
				dbCommand.CommandText = string.Format(format, tableMap.TableName, strWhere);
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				result = dbCommand.ExecuteNonQuery();
			}
			return result;
		}

		public int Delete(IDbConnection conn, object obj, string[] fieldNames)
		{
			int result;
			if (obj == null || conn == null)
			{
				result = -1;
			}
			else
			{
				TableMap tableMap = TableMapFactory.Instance[obj];
				if (tableMap == null || null == tableMap.MappedFields)
				{
					throw new ORMException("构造" + obj.GetType().FullName + "的映射产生错误");
				}
				if (fieldNames == null || fieldNames.Length < 1)
				{
					List<FieldAttribute> primaryKeys = tableMap.PrimaryKeys;
					if (null != primaryKeys)
					{
						fieldNames = new string[primaryKeys.Count];
						for (int i = 0; i < primaryKeys.Count; i++)
						{
							fieldNames[i] = primaryKeys[i].TableFiled;
						}
					}
				}
				string text = "";
				IDbCommand dbCommand = this.PrepareCommand(conn, null, null);
				string[] array = fieldNames;
				for (int j = 0; j < array.Length; j++)
				{
					string text2 = array[j];
					FieldAttribute fieldAttribute = tableMap[text2];
					if (null == fieldAttribute)
					{
						throw new ORMException(obj.GetType().FullName + "的映射产生错误:无法找到" + text2 + "的字段映射");
					}
					string parameterName = this.GetParameterName(fieldAttribute.TableFiled);
					if (text.Length > 0)
					{
						text += " and ";
					}
					text = text + fieldAttribute.TableFiled + "=" + parameterName;
					dbCommand.Parameters.Add(this.CreateParameter(dbCommand, fieldAttribute, parameterName, obj));
				}
				if (text.Length < 1)
				{
					throw new ORMException(obj.GetType().FullName + "的映射产生错误:无主键");
				}
				string format = "delete from {0} where {1}";
				dbCommand.CommandText = string.Format(format, tableMap.TableName, text);
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				result = dbCommand.ExecuteNonQuery();
			}
			return result;
		}

		public int Update(IDbConnection conn, object obj, string[] fieldUpdate, string[] fieldWhere)
		{
			if (obj == null || conn == null)
			{
				throw new ORMException((obj == null) ? "输入的对象为空！" : "数据库连接为空！");
			}
			TableMap tableMap = TableMapFactory.Instance[obj];
			if (tableMap == null || null == tableMap.MappedFields)
			{
				throw new ORMException("构造" + obj.GetType().FullName + "的映射产生错误");
			}
			if (fieldWhere == null || fieldWhere.Length < 1)
			{
				List<FieldAttribute> primaryKeys = tableMap.PrimaryKeys;
				if (null != primaryKeys)
				{
					fieldWhere = new string[primaryKeys.Count];
					for (int i = 0; i < primaryKeys.Count; i++)
					{
						fieldWhere[i] = primaryKeys[i].TableFiled;
					}
				}
			}
			string text = "";
			if (fieldWhere != null)
			{
				string[] array = fieldWhere;
				for (int j = 0; j < array.Length; j++)
				{
					string text2 = array[j];
					FieldAttribute fieldAttribute = tableMap[text2];
					if (null == fieldAttribute)
					{
						throw new ORMException(obj.GetType().FullName + "的映射产生错误:无法找到" + text2 + "的字段映射");
					}
					text = text + "[" + fieldAttribute.TableFiled.Trim().ToUpper() + "]";
				}
			}
			string text3 = "";
			string text4 = "";
			IDbCommand dbCommand = this.PrepareCommand(conn, null, null);
			List<FieldAttribute> list = tableMap.MappedFields;
			if (fieldUpdate != null && fieldUpdate.Length > 0)
			{
				list = new List<FieldAttribute>();
				for (int j = 0; j < fieldUpdate.Length; j++)
				{
					string strFieldName = fieldUpdate[j];
					FieldAttribute fieldAttribute2 = tableMap[strFieldName];
					if (null != fieldAttribute2)
					{
						list.Add(fieldAttribute2);
					}
				}
			}
			foreach (FieldAttribute fieldAttribute in list)
			{
				//FieldAttribute fieldAttribute;
				if (text.IndexOf("[" + fieldAttribute.TableFiled.ToUpper() + "]") < 0)
				{
					if (text4.Length > 0)
					{
						text4 += ",";
					}
					if (!this.m_type2DbType.IsDbNullValue(fieldAttribute.GetValue(obj)))
					{
						string parameterName = this.GetParameterName(fieldAttribute.TableFiled);
						text4 = text4 + fieldAttribute.TableFiled + "=" + parameterName;
						IDbDataParameter value = this.CreateParameter(dbCommand, fieldAttribute, parameterName, obj);
						dbCommand.Parameters.Add(value);
					}
					else
					{
						text4 = text4 + fieldAttribute.TableFiled + "=null";
					}
				}
			}
			foreach (FieldAttribute fieldAttribute in list)
			{
				//FieldAttribute fieldAttribute;
				if (text.IndexOf("[" + fieldAttribute.TableFiled.ToUpper() + "]") >= 0)
				{
					string parameterName = this.GetParameterName(fieldAttribute.TableFiled);
					IDbDataParameter value = this.CreateParameter(dbCommand, fieldAttribute, parameterName, obj);
					if (text3.Length > 0)
					{
						text3 += " and ";
					}
					text3 = text3 + fieldAttribute.TableFiled + "=" + parameterName;
					dbCommand.Parameters.Add(value);
				}
			}
			if (text4 == null || text4.Length < 1)
			{
				throw new ORMException(obj.GetType().FullName + "的映射产生错误:无法找到可更新的字段");
			}
			if (text3 == null || text3.Trim().Length < 1)
			{
				throw new ORMException(obj.GetType().FullName + "的映射产生错误:找不到更新数据库表格的可参考字段");
			}
			text3 = " where " + text3;
			string format = "update {0} set {1} {2}";
			dbCommand.CommandText = string.Format(format, tableMap.TableName, text4, text3);
			if (this.Verbose)
			{
				this.VerboseInfo(dbCommand);
			}
			return dbCommand.ExecuteNonQuery();
		}

		private object CreateInstance(Type type)
		{
			object result;
			if (null == type)
			{
				result = null;
			}
			else
			{
				ConstructorInfo constructor = type.GetConstructor(new Type[0]);
				if (null == constructor)
				{
					throw new ORMException(type.FullName + "没有默认的构造函数，无法构造实例");
				}
				object obj = constructor.Invoke(null);
				result = obj;
			}
			return result;
		}

		private T CreateInstance<T>() where T : class
		{
			Type typeFromHandle = typeof(T);
			return this.CreateInstance(typeFromHandle) as T;
		}

		public T Init<T>(IDbConnection conn, string strSql, params object[] parameters) where T : class
		{
			List<T> list = this.Query<T>(conn, strSql, parameters);
			return (list == null || list.Count < 1) ? default(T) : list[0];
		}

		public object Init(Type type, IDataReader reader)
		{
			object result;
			if (type == null || null == reader)
			{
				result = null;
			}
			else
			{
				TableMap tableMap = TableMapFactory.Instance[type];
				if (tableMap == null || null == tableMap.MappedFields)
				{
					throw new ORMException("构造" + type.FullName + "的映射产生错误");
				}
				object obj = this.CreateInstance(type);
				foreach (FieldAttribute current in tableMap.MappedFields)
				{
					object obj2 = reader[current.TableFiled];
					if (obj2 is DBNull)
					{
						obj2 = null;
					}
					current.SetValue(obj, this.m_type2DbType.Cast(current.ClassFieldType, obj2));
				}
				result = obj;
			}
			return result;
		}

		public T Init<T>(Sqlca sqlca) where T : class
		{
			return this.Init(typeof(T), sqlca.DataReader) as T;
		}

		public T Init<T>(IDataReader reader) where T : class
		{
			return this.Init(typeof(T), reader) as T;
		}

		public object InitByObject(IDbConnection conn, object obj)
		{
			object result;
			if (null == obj)
			{
				result = null;
			}
			else
			{
				TableMap tableMap = TableMapFactory.Instance[obj.GetType()];
				string text = "";
				List<object> list = new List<object>();
				foreach (FieldAttribute current in tableMap.PrimaryKeys)
				{
					if (text.Length > 0)
					{
						text += " And ";
					}
					string parameterName = this.GetParameterName(current.TableFiled);
					object value = current.GetValue(obj);
					text = text + current.TableFiled + "=" + parameterName;
					list.Add(parameterName);
					list.Add(value);
				}
				List<object> list2 = this.Query(obj.GetType(), conn, text, list);
				result = ((list2 == null || list2.Count < 1) ? null : list2[0]);
			}
			return result;
		}

		public List<T> Query<T>(IDataReader reader) where T : class
		{
			List<object> list = this.Query(typeof(T), reader);
			List<T> list2 = new List<T>();
			int num = 0;
			while (list != null && num < list.Count)
			{
				list2.Add(list[num] as T);
				num++;
			}
			return list2;
		}

		public List<object> Query(Type type, IDataReader reader)
		{
			List<object> list = new List<object>();
			while (reader != null && reader.Read())
			{
				list.Add(this.Init(type, reader));
			}
			return list;
		}

		public void FetchQuery<T>(Delegate_Fetch_Handler handler, IDataReader reader) where T : class
		{
			if (null != handler)
			{
				while (reader != null && reader.Read())
				{
					handler(this.Init<T>(reader));
				}
			}
		}

		public void FetchQuery(Type type, Delegate_Fetch_Handler handler, IDataReader reader)
		{
			if (null != handler)
			{
				while (reader != null && reader.Read())
				{
					handler(this.Init(type, reader));
				}
			}
		}

		public void FetchQuery(Type type, Delegate_Fetch_Handler handler, IDbConnection conn, string strSql, params object[] parameters)
		{
			IDataReader dataReader = null;
			try
			{
				TableMap tableMap = TableMapFactory.Instance[type];
				if (null == tableMap)
				{
					throw new ORMException("构造" + type.FullName + "的映射产生错误");
				}
				if (strSql == null || strSql.Trim().Length < 1)
				{
					strSql = "select * from " + tableMap.TableName;
				}
				else if (strSql.Trim().ToLower().StartsWith("order"))
				{
					strSql = "select * from " + tableMap.TableName + " " + strSql;
				}
				else if (!strSql.Trim().ToLower().StartsWith("select"))
				{
					if (!strSql.Trim().ToLower().StartsWith("where "))
					{
						strSql = "where " + strSql;
					}
					strSql = "select * from " + tableMap.TableName + " " + strSql;
				}
				IDbCommand dbCommand = this.PrepareCommand(conn, strSql, parameters);
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				dataReader = dbCommand.ExecuteReader();
				this.FetchQuery(type, handler, dataReader);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (null != dataReader)
				{
					dataReader.Close();
				}
			}
		}

		public void FetchQuery<T>(Delegate_Fetch_Handler handler, IDbConnection conn, string strSql, params object[] parameters) where T : class
		{
			IDataReader dataReader = null;
			try
			{
				Type typeFromHandle = typeof(T);
				TableMap tableMap = TableMapFactory.Instance[typeFromHandle];
				if (null == tableMap)
				{
					throw new ORMException("构造" + typeFromHandle.FullName + "的映射产生错误");
				}
				if (strSql == null || strSql.Trim().Length < 1)
				{
					strSql = "select * from " + tableMap.TableName;
				}
				else if (strSql.Trim().ToLower().StartsWith("order"))
				{
					strSql = "select * from " + tableMap.TableName + " " + strSql;
				}
				else if (!strSql.Trim().ToLower().StartsWith("select"))
				{
					if (!strSql.Trim().ToLower().StartsWith("where "))
					{
						strSql = "where " + strSql;
					}
					strSql = "select * from " + tableMap.TableName + " " + strSql;
				}
				IDbCommand dbCommand = this.PrepareCommand(conn, strSql, parameters);
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				dataReader = dbCommand.ExecuteReader();
				this.FetchQuery<T>(handler, dataReader);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (null != dataReader)
				{
					dataReader.Close();
				}
			}
		}

		public List<T> Query<T>(IDbConnection conn, string strSql, params object[] parameters) where T : class
		{
			List<object> list = this.Query(typeof(T), conn, strSql, parameters);
			List<T> list2 = new List<T>();
			int num = 0;
			while (list != null && num < list.Count)
			{
				list2.Add(list[num] as T);
				num++;
			}
			return list2;
		}

		public List<object> Query(Type type, IDbConnection conn, string strSql, List<object> parameters)
		{
			return this.Query(type, conn, strSql, (parameters == null) ? null : parameters.ToArray());
		}

		public List<object> Query(Type type, IDbConnection conn, string strSql, params object[] parameters)
		{
			IDataReader dataReader = null;
			List<object> result;
			try
			{
				TableMap tableMap = TableMapFactory.Instance[type];
				if (null == tableMap)
				{
					throw new ORMException("构造" + type.FullName + "的映射产生错误");
				}
				if (strSql == null || strSql.Trim().Length < 1)
				{
					strSql = "select * from " + tableMap.TableName;
				}
				else if (strSql.Trim().ToLower().StartsWith("order"))
				{
					strSql = "select * from " + tableMap.TableName + " " + strSql;
				}
				else if (!strSql.Trim().ToLower().StartsWith("select"))
				{
					if (!strSql.Trim().ToLower().StartsWith("where "))
					{
						strSql = "where " + strSql;
					}
					strSql = "select * from " + tableMap.TableName + " " + strSql;
				}
				IDbCommand dbCommand = this.PrepareCommand(conn, strSql, parameters);
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				dataReader = dbCommand.ExecuteReader();
				result = this.Query(type, dataReader);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (null != dataReader)
				{
					dataReader.Close();
				}
			}
			return result;
		}

		protected virtual IDbCommand PrepareCommand(IDbConnection conn, string strSql, object[] parameters)
		{
			IDbCommand dbCommand = conn.CreateCommand();
			dbCommand.CommandType = CommandType.Text;
			if (null != strSql)
			{
				dbCommand.CommandText = strSql;
			}
			int num = 0;
			while (parameters != null && num < parameters.Length)
			{
				if (num + 1 >= parameters.Length)
				{
					break;
				}
				string strParamName = (string)parameters[num];
				object paramValue = parameters[num + 1];
				dbCommand.Parameters.Add(this.CreateParameter(dbCommand, strParamName, paramValue));
				num += 2;
			}
			return dbCommand;
		}

		public RETTYPE ExecuteScale<T, RETTYPE>(IDbConnection conn, string strExpression, string strSql, params object[] parameters) where T : class
		{
			RETTYPE result;
			try
			{
				Type typeFromHandle = typeof(T);
				TableMap tableMap = TableMapFactory.Instance[typeFromHandle];
				if (null == tableMap)
				{
					throw new ORMException("构造" + typeFromHandle.FullName + "的映射产生错误");
				}
				if (strSql == null || strSql.Trim().Length < 1)
				{
					strSql = "select " + strExpression + " from " + tableMap.TableName;
				}
				else if (strSql.Trim().ToLower().StartsWith("order"))
				{
					strSql = string.Concat(new string[]
					{
						"select ",
						strExpression,
						" from ",
						tableMap.TableName,
						" ",
						strSql
					});
				}
				else if (!strSql.Trim().ToLower().StartsWith("select"))
				{
					if (!strSql.Trim().ToLower().StartsWith("where "))
					{
						strSql = "where " + strSql;
					}
					strSql = string.Concat(new string[]
					{
						"select ",
						strExpression,
						" from ",
						tableMap.TableName,
						" ",
						strSql
					});
				}
				IDbCommand dbCommand = this.PrepareCommand(conn, strSql, parameters);
				object obj = dbCommand.ExecuteScalar();
				if (obj.Equals(DBNull.Value))
				{
					obj = null;
				}
				if (this.Verbose)
				{
					this.VerboseInfo(dbCommand);
				}
				result = (RETTYPE)((object)this.m_type2DbType.GetNullValue(typeof(RETTYPE), obj));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public string EncodingPrimaryKeys(object obj)
		{
			string result;
			if (null == obj)
			{
				result = null;
			}
			else
			{
				TableMap tableMap = TableMapFactory.Instance[obj];
				if (tableMap == null || null == tableMap.MappedFields)
				{
					throw new ORMException("构造" + obj.GetType().FullName + "的映射产生错误");
				}
				string text = "";
				foreach (FieldAttribute current in tableMap.PrimaryKeys)
				{
					if (text.Length > 0)
					{
						text += '|';
					}
					object value = current.GetValue(obj);
					string text2 = this.m_type2DbType.IsDbNullValue(value) ? DBNull.Value.ToString() : value.ToString();
					object obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						current.TableFiled,
						'=',
						text2
					});
				}
				result = text;
			}
			return result;
		}

		public DecodingPrimaryKeysResult DecodingPrimaryKeys(string strEncoder)
		{
			DecodingPrimaryKeysResult result;
			if (strEncoder == null || strEncoder.Trim().Length < 1)
			{
				result = null;
			}
			else
			{
				List<object> list = new List<object>();
				string text = "";
				string[] array = strEncoder.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					string text2 = array[i];
					int num = text2.IndexOf('=');
					if (num > 0)
					{
						string text3 = text2.Substring(0, num).Trim();
						if (text3.Trim().Length >= 1)
						{
							if (text.Length > 0)
							{
								text += " and ";
							}
							string parameterName = this.GetParameterName(text3);
							text = text + text3 + "=" + parameterName;
							string text4 = text2.Substring(num + 1).Trim();
							list.Add(parameterName);
							if (text4.Equals(DBNull.Value.ToString()))
							{
								list.Add(null);
							}
							else
							{
								list.Add(text4);
							}
						}
					}
				}
				DecodingPrimaryKeysResult decodingPrimaryKeysResult = new DecodingPrimaryKeysResult();
				decodingPrimaryKeysResult.Sql = ((text == null || text.Trim().Length < 1) ? null : text);
				decodingPrimaryKeysResult.Parameters = ((list == null || list.Count < 1) ? null : list);
				result = ((decodingPrimaryKeysResult.Sql == null && decodingPrimaryKeysResult.Parameters == null) ? null : decodingPrimaryKeysResult);
			}
			return result;
		}
	}
}
