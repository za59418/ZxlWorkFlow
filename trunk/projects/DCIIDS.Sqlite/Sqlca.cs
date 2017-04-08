using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DCIIDS.Data
{
	public class Sqlca : IDisposable
	{
		private static DefaultORMHandler m_orm = new DefaultORMHandler();

		private IDbConnection m_connection = null;

		private IDbCommand m_command = null;

		private IDataReader m_reader = null;

		private string m_strSql = null;

		private SQLStatementTypes m_currentSQLType = SQLStatementTypes.Others;

		private IDbTransaction m_transaction = null;

		private bool m_isSelfConnect = false;

		public virtual IDbConnection Connection
		{
			get
			{
				return this.m_connection;
			}
			set
			{
				this.m_connection = value;
			}
		}

		public SQLStatementTypes SQLType
		{
			get
			{
				return this.m_currentSQLType;
			}
		}

		public IDataReader DataReader
		{
			get
			{
				return this.m_reader;
			}
		}

		public string Sql
		{
			get
			{
				return this.m_strSql;
			}
			set
			{
				this.m_strSql = value;
				string str = (this.m_strSql == null) ? "" : this.m_strSql.ToLower().Trim();
				this.GetSqlType(str);
				this.Close();
				this.m_command = this.m_connection.CreateCommand();
				this.m_command.CommandType = CommandType.Text;
				this.m_command.CommandText = this.m_strSql;
				if (null != this.m_transaction)
				{
					this.m_command.Transaction = this.m_transaction;
				}
			}
		}

		public CommandType CommandType
		{
			get
			{
				return this.m_command.CommandType;
			}
			set
			{
				this.m_command.CommandType = value;
			}
		}

		public string[] ColumnNames
		{
			get
			{
				DataTable schemaTable = this.m_reader.GetSchemaTable();
				string[] array = new string[schemaTable.Rows.Count];
				for (int i = 0; i < array.Length; i++)
				{
					DataRow dataRow = schemaTable.Rows[i];
					array[i] = dataRow[SchemaTableColumn.ColumnName].ToString();
				}
				return array;
			}
		}

		public object this[int key]
		{
			get
			{
				return this.m_reader[key];
			}
		}

		public object this[string key]
		{
			get
			{
				return this.m_reader[key];
			}
		}

		public DataTable SchemaTable
		{
			get
			{
				return this.m_reader.GetSchemaTable();
			}
		}

		public Sqlca(IDbConnection conn)
		{
			this.m_connection = conn;
			this.m_isSelfConnect = false;
		}

		public Sqlca(IDbConnection conn, IDbTransaction trans)
		{
			this.m_connection = conn;
			this.m_isSelfConnect = false;
			this.m_transaction = trans;
		}

		public Sqlca(Sqlca sqcal)
		{
			if (null != sqcal)
			{
				this.m_connection = sqcal.m_connection;
				this.m_isSelfConnect = false;
			}
		}

		public Sqlca(string strDriver, string strConnectionString)
		{
			this.m_connection = Sqlca.CreateConnection(strDriver, strConnectionString);
			this.m_isSelfConnect = true;
		}

		public T InitObject<T>() where T : class
		{
			return Sqlca.m_orm.Init<T>(this);
		}

		public object InitObject(Type t)
		{
			return Sqlca.m_orm.Init(t, this.DataReader);
		}

		public int ExecuteSclaleInt(string strSql)
		{
			int result;
			if (strSql == null || strSql.Trim().Length < 1)
			{
				result = -1;
			}
			else
			{
				if (!strSql.Trim().ToLower().StartsWith("select "))
				{
					strSql = "select count(*) from " + strSql;
				}
				object obj = this.ExecuteScalar(strSql);
				result = ((obj == null) ? 0 : Convert.ToInt32(obj));
			}
			return result;
		}

		public static IDbConnection CreateConnection(string strDriver, string strConnectionString)
		{
			IDbConnection result;
			if (strDriver == null || strConnectionString == null)
			{
				result = null;
			}
			else
			{
				DbProviderFactory factory = DbProviderFactories.GetFactory(strDriver);
				if (null != factory)
				{
					DbConnection dbConnection = factory.CreateConnection();
					dbConnection.ConnectionString = strConnectionString;
					dbConnection.Open();
					result = dbConnection;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		private void GetSqlType(string str)
		{
			if (str.StartsWith("select "))
			{
				this.m_currentSQLType = SQLStatementTypes.Select;
			}
			else if (str.StartsWith("create "))
			{
				this.m_currentSQLType = SQLStatementTypes.Others;
			}
			else if (str.StartsWith("update "))
			{
				this.m_currentSQLType = SQLStatementTypes.Update;
			}
			else if (str.StartsWith("insert "))
			{
				this.m_currentSQLType = SQLStatementTypes.Insert;
			}
			else if (str.StartsWith("delete "))
			{
				this.m_currentSQLType = SQLStatementTypes.Delete;
			}
			else
			{
				this.m_currentSQLType = SQLStatementTypes.Others;
			}
		}

		public void SetParameter(string strKey, DbType type, ParameterDirection direction, int nSize, object value)
		{
			IDbDataParameter dbDataParameter = this.m_command.CreateParameter();
			dbDataParameter.DbType = type;
			dbDataParameter.Value = value;
			dbDataParameter.Direction = direction;
			if (nSize >= 0)
			{
				dbDataParameter.Size = nSize;
			}
			dbDataParameter.ParameterName = strKey.Trim();
			this.m_command.Parameters.Add(dbDataParameter);
		}

		public void SetParameter(string strKey, DbType type, ParameterDirection direction, object value)
		{
			this.SetParameter(strKey, type, direction, -1, value);
		}

		public void SetParameter(string strKey, DbType type, object value)
		{
			this.SetParameter(strKey, type, ParameterDirection.Input, -1, value);
		}

		public void SetBlob(string strKey, byte[] blob)
		{
			this.SetParameter(strKey, DbType.Binary, ParameterDirection.Input, (blob == null) ? 0 : blob.Length, blob);
		}

		public void SetInt32(string strKey, int n)
		{
			this.SetParameter(strKey, DbType.Int32, ParameterDirection.Input, n);
		}

		public void SetInt64(string strKey, long n)
		{
			this.SetParameter(strKey, DbType.Int64, ParameterDirection.Input, n);
		}

		public void SetLong(string strKey, long n)
		{
			this.SetParameter(strKey, DbType.Int64, ParameterDirection.Input, n);
		}

		public void SetDouble(string strKey, double n)
		{
			this.SetParameter(strKey, DbType.Double, ParameterDirection.Input, n);
		}

		public void SetInt(string strKey, int n)
		{
			this.SetParameter(strKey, DbType.Int32, ParameterDirection.Input, n);
		}

		public void SetString(string strKey, string strValue)
		{
			this.SetParameter(strKey, DbType.String, ParameterDirection.Input, 0, strValue);
		}

		public void SetAnsiString(string strKey, string strValue)
		{
			this.SetParameter(strKey, DbType.AnsiString, ParameterDirection.Input, 0, strValue);
		}

		public void SetDateTime(string strKey, DateTime dateTime)
		{
			this.SetParameter(strKey, DbType.DateTime, ParameterDirection.Input, 0, dateTime);
		}

		public void Close()
		{
			try
			{
				this.m_command = null;
				if (null != this.m_reader)
				{
					this.m_reader.Close();
				}
				this.m_reader = null;
			}
			catch (Exception)
			{
				this.m_reader = null;
				this.m_command = null;
			}
		}

		public void CloseAll()
		{
			this.Close();
			try
			{
				if (null != this.m_connection)
				{
					this.m_connection.Close();
				}
			}
			catch (Exception)
			{
			}
		}

		public int Execute(string strSql)
		{
			this.Sql = strSql;
			return this.Execute();
		}

		public int Execute(string strSql, params object[] parameteres)
		{
			this.Sql = strSql;
			int num = 0;
			while (parameteres != null && num + 1 < parameteres.Length)
			{
				if (null != parameteres[num])
				{
					IDbDataParameter dbDataParameter = this.m_command.CreateParameter();
					dbDataParameter.ParameterName = parameteres[num].ToString();
					this.m_command.Parameters.Add(dbDataParameter);
					dbDataParameter.Value = parameteres[num + 1];
				}
				num += 2;
			}
			return this.Execute();
		}

		public int SafeExecute(string strSql)
		{
			int result;
			try
			{
				this.Sql = strSql;
				result = this.Execute();
				return result;
			}
			catch (Exception)
			{
			}
			result = -1;
			return result;
		}

		public virtual int Execute()
		{
			int result;
			if (this.SQLType == SQLStatementTypes.Select)
			{
				this.m_reader = this.m_command.ExecuteReader();
				if (this.m_reader is DbDataReader)
				{
					result = ((this.m_reader as DbDataReader).HasRows ? 1 : 0);
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = this.m_command.ExecuteNonQuery();
			}
			return result;
		}

		public object ExecuteScalar()
		{
			return this.m_command.ExecuteScalar();
		}

		public object ExecuteScalar(string str)
		{
			this.Sql = str;
			return this.m_command.ExecuteScalar();
		}

		public int ExecuteReader(string strScript)
		{
			this.Sql = strScript;
			this.m_reader = this.m_command.ExecuteReader();
			int result;
			if (this.m_reader is DbDataReader)
			{
				result = ((this.m_reader as DbDataReader).HasRows ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int ExecuteReader()
		{
			this.m_reader = this.m_command.ExecuteReader();
			int result;
			if (this.m_reader is DbDataReader)
			{
				result = ((this.m_reader as DbDataReader).HasRows ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public Type GetFieldType(int n)
		{
			return this.m_reader.GetFieldType(n);
		}

		public string GetDataTypeName(int n)
		{
			return this.m_reader.GetDataTypeName(n);
		}

		public int GetOrdinal(string strColName)
		{
			return this.m_reader.GetOrdinal(strColName);
		}

		public object[] GetValues()
		{
			object[] array = new object[this.m_reader.FieldCount];
			this.m_reader.GetValues(array);
			return array;
		}

		public virtual bool Next()
		{
			return this.m_reader != null && this.m_reader.Read();
		}

		public bool Read()
		{
			return this.m_reader != null && this.m_reader.Read();
		}

		public bool IsDBNull(int key)
		{
			return this.m_reader.IsDBNull(key);
		}

		public bool IsDBNull(string key)
		{
			object obj = this.m_reader[key];
			return Convert.DBNull.Equals(obj);
		}

		public string GetString(int key)
		{
			object obj = this[key];
			string result;
			if (Convert.DBNull.Equals(obj))
			{
				result = null;
			}
			else
			{
				result = Convert.ToString(obj);
			}
			return result;
		}

		public double GetDouble(int key)
		{
			object obj = this[key];
			double result;
			if (Convert.DBNull.Equals(obj))
			{
				result = 0.0;
			}
			else
			{
				result = Convert.ToDouble(obj);
			}
			return result;
		}

		public int GetInt(int key)
		{
			object obj = this[key];
			int result;
			if (Convert.DBNull.Equals(obj))
			{
				result = 0;
			}
			else
			{
				result = Convert.ToInt32(obj);
			}
			return result;
		}

		public long GetLong(int key)
		{
			object obj = this[key];
			long result;
			if (Convert.DBNull.Equals(obj))
			{
				result = 0L;
			}
			else
			{
				result = Convert.ToInt64(obj);
			}
			return result;
		}

		public DateTime GetDateTime(int key)
		{
			object obj = this[key];
			DateTime result;
			if (Convert.DBNull.Equals(obj))
			{
				result = DateTime.Now;
			}
			else
			{
				result = Convert.ToDateTime(obj);
			}
			return result;
		}

		public char GetChar(int key)
		{
			object obj = this[key];
			char result;
			if (Convert.DBNull.Equals(obj))
			{
				result = ' ';
			}
			else
			{
				result = Convert.ToChar(obj);
			}
			return result;
		}

		public bool GetBool(int key)
		{
			object obj = this[key];
			return !Convert.DBNull.Equals(obj) && Convert.ToBoolean(obj);
		}

		public string GetString(string key)
		{
			object obj = this[key];
			string result;
			if (Convert.DBNull.Equals(obj))
			{
				result = null;
			}
			else
			{
				result = Convert.ToString(obj);
			}
			return result;
		}

		public double GetDouble(string key)
		{
			object obj = this[key];
			double result;
			if (Convert.DBNull.Equals(obj))
			{
				result = 0.0;
			}
			else
			{
				result = Convert.ToDouble(obj);
			}
			return result;
		}

		public int GetInt(string key)
		{
			object obj = this[key];
			int result;
			if (Convert.DBNull.Equals(obj))
			{
				result = 0;
			}
			else
			{
				result = Convert.ToInt32(obj);
			}
			return result;
		}

		public long GetLong(string key)
		{
			object obj = this[key];
			long result;
			if (Convert.DBNull.Equals(obj))
			{
				result = 0L;
			}
			else
			{
				result = Convert.ToInt64(obj);
			}
			return result;
		}

		public byte[] GetBytes(string key)
		{
			object obj = this[key];
			byte[] result;
			if (Convert.DBNull.Equals(obj))
			{
				result = null;
			}
			else if (obj is byte[])
			{
				result = (obj as byte[]);
			}
			else
			{
				IFormatter formatter = new BinaryFormatter();
				MemoryStream memoryStream = new MemoryStream();
				formatter.Serialize(memoryStream, obj);
				result = memoryStream.ToArray();
			}
			return result;
		}

		public byte[] GetBytes(int key)
		{
			object obj = this[key];
			byte[] result;
			if (Convert.DBNull.Equals(obj))
			{
				result = null;
			}
			else if (obj is byte[])
			{
				result = (obj as byte[]);
			}
			else
			{
				IFormatter formatter = new BinaryFormatter();
				MemoryStream memoryStream = new MemoryStream();
				formatter.Serialize(memoryStream, obj);
				result = memoryStream.ToArray();
			}
			return result;
		}

		public DateTime GetDateTime(string key)
		{
			object obj = this[key];
			DateTime result;
			if (Convert.DBNull.Equals(obj))
			{
				result = DateTime.Now;
			}
			else
			{
				result = Convert.ToDateTime(obj);
			}
			return result;
		}

		public char GetChar(string key)
		{
			object obj = this[key];
			char result;
			if (Convert.DBNull.Equals(obj))
			{
				result = ' ';
			}
			else
			{
				result = Convert.ToChar(obj);
			}
			return result;
		}

		public bool GetBool(string key)
		{
			object obj = this[key];
			return !Convert.DBNull.Equals(obj) && Convert.ToBoolean(obj);
		}

		public byte[] GetBlob(int nColIndex)
		{
			byte[] array = new byte[this.m_reader.GetBytes(nColIndex, 0L, null, 0, 2147483647)];
			this.m_reader.GetBytes(nColIndex, 0L, array, 0, array.Length);
			return array;
		}

		public byte[] GetBlob(string strColName)
		{
			return this.GetBlob(this.m_reader.GetOrdinal(strColName));
		}

		public DataTable ExecuteDataTable(string strSql, string strTableName)
		{
			this.Execute(strSql);
			return this.GetDataTable(strTableName);
		}

		public DataTable ExecuteDataTable(string strSql)
		{
			this.Execute(strSql);
			return this.GetDataTable();
		}

		public DataTable GetDataTable()
		{
			return this.GetDataTable(null);
		}

		public DataTable GetDataTable(string strTableName)
		{
			DataTable result;
			if (this.m_reader == null)
			{
				result = null;
			}
			else
			{
				DataTable dataTable = new DataTable();
				if (null != strTableName)
				{
					dataTable.TableName = strTableName;
				}
				dataTable.Load(this.m_reader);
				result = dataTable;
			}
			return result;
		}

		public static string GetProductName(IDbConnection conn)
		{
			string result;
			if (conn == null || !(conn is DbConnection))
			{
				result = null;
			}
			else
			{
				DataTable schema = (conn as DbConnection).GetSchema("DataSourceInformation");
				if (schema == null || schema.Rows.Count < 1)
				{
					result = null;
				}
				else
				{
					result = schema.Rows[0][DbMetaDataColumnNames.DataSourceProductName].ToString();
				}
			}
			return result;
		}

		public static string GetProductVersion(IDbConnection conn)
		{
			string result;
			if (conn == null || !(conn is DbConnection))
			{
				result = null;
			}
			else
			{
				DataTable schema = (conn as DbConnection).GetSchema("DataSourceInformation");
				if (schema == null || schema.Rows.Count < 1)
				{
					result = null;
				}
				else
				{
					result = schema.Rows[0][DbMetaDataColumnNames.DataSourceProductVersionNormalized].ToString();
				}
			}
			return result;
		}

		public string GetProductName()
		{
			return Sqlca.GetProductName(this.m_connection);
		}

		public string GetProductVersion()
		{
			return Sqlca.GetProductVersion(this.m_connection);
		}

		public DataColumn GetDataColumn(int nCol)
		{
			DataTable schemaTable = this.m_reader.GetSchemaTable();
			DataColumn result;
			if (nCol >= schemaTable.Rows.Count)
			{
				result = null;
			}
			else
			{
				DataRow dataRow = schemaTable.Rows[nCol];
				result = new DataColumn
				{
					ColumnName = dataRow[SchemaTableColumn.ColumnName].ToString(),
					DataType = Type.GetType(dataRow[SchemaTableColumn.DataType].ToString())
				};
			}
			return result;
		}

		public void BeginTransaction()
		{
			try
			{
				this.m_transaction = this.m_connection.BeginTransaction();
			}
			catch (Exception)
			{
				this.m_transaction = null;
			}
		}

		public void Commit()
		{
			if (null != this.m_transaction)
			{
				this.m_transaction.Commit();
			}
		}

		public void Rollback()
		{
			if (null != this.m_transaction)
			{
				this.m_transaction.Rollback();
			}
		}

		void IDisposable.Dispose()
		{
			try
			{
				if (this.m_isSelfConnect)
				{
					this.CloseAll();
				}
				else
				{
					this.Close();
				}
			}
			catch
			{
			}
		}
	}
}
