using System;
using System.Collections.Generic;
using System.Data;

namespace Zxl.Data
{
	public class ORMHandler : DefaultORMHandler, IDisposable
	{
		private IDbConnection m_connection = null;

		private IDbTransaction m_transaction = null;

		public IDbConnection Connection
		{
			get
			{
				return this.m_connection;
			}
		}

		public Sqlca Sqlca
		{
			get
			{
				return new Sqlca(this.m_connection);
			}
		}

		public PaginatedSqlca PaginatedSqlca
		{
			get
			{
				return new PaginatedSqlca(this.m_connection);
			}
		}

		public ORMHandler(IDbConnection conn)
		{
			this.m_connection = conn;
		}

		public void BeginTransaction()
		{
			if (null != this.m_connection)
			{
				this.m_transaction = this.m_connection.BeginTransaction();
			}
		}

		public void Commit()
		{
			if (null != this.m_transaction)
			{
				this.m_transaction.Commit();
				this.m_transaction = null;
			}
		}

		public void Rollback()
		{
			if (null != this.m_transaction)
			{
				this.m_transaction.Rollback();
				this.m_transaction = null;
			}
		}

		public virtual int Insert(object obj)
		{
			return base.Insert(this.m_connection, obj);
		}

		public virtual int Delete(object obj)
		{
			return base.Delete(this.m_connection, obj, null);
		}

		public int Delete<T>(string strWhere) where T : class
		{
			return base.Delete<T>(this.m_connection, strWhere);
		}

		public int Delete<T>() where T : class
		{
			return base.Delete<T>(this.m_connection, null);
		}

		public int Delete(object obj, string[] fieldNames)
		{
			return base.Delete(this.m_connection, obj, fieldNames);
		}

		public virtual int Save(object obj)
		{
			int num = base.Update(this.m_connection, obj, null, null);
			if (num < 1)
			{
				num = base.Insert(this.m_connection, obj);
			}
			return num;
		}

		public virtual int Update(object obj)
		{
			return base.Update(this.m_connection, obj, null, null);
		}

		public int Update(object obj, string[] fieldWhere)
		{
			return base.Update(this.m_connection, obj, null, fieldWhere);
		}

		public int Update(object obj, string[] fieldUpdate, string[] fieldWhere)
		{
			return base.Update(this.m_connection, obj, fieldUpdate, fieldWhere);
		}

		public T Init<T>(string strSql) where T : class
		{
			return base.Init<T>(this.m_connection, strSql, new object[0]);
		}

		public T Init<T>(string strSql, params object[] parameters) where T : class
		{
			return base.Init<T>(this.m_connection, strSql, parameters);
		}

		public T Init<T>() where T : class
		{
			return base.Init<T>(this.m_connection, null, new object[0]);
		}

		public List<T> Query<T>(string strSql, params object[] parameters) where T : class
		{
			return base.Query<T>(this.m_connection, strSql, parameters);
		}

		public List<T> Query<T>() where T : class
		{
			return base.Query<T>(this.m_connection, null, new object[0]);
		}

		public void FetchQuery<T>(Delegate_Fetch_Handler handler, string strSql, params object[] parameters) where T : class
		{
			base.FetchQuery<T>(handler, this.m_connection, strSql, parameters);
		}

		public void FetchQuery<T>(Delegate_Fetch_Handler handler) where T : class
		{
			base.FetchQuery<T>(handler, this.m_connection, null, new object[0]);
		}

		public void FetchQuery(Type t, Delegate_Fetch_Handler handler, string strSql, params object[] parameters)
		{
			base.FetchQuery(t, handler, this.m_connection, strSql, parameters);
		}

		public void FetchQuery(Type t, Delegate_Fetch_Handler handler)
		{
			base.FetchQuery(t, handler, this.m_connection, null, new object[0]);
		}

		public RETTYPE ExecuteScale<T, RETTYPE>(string strExpression, string strSql, params object[] parameters) where T : class
		{
			return base.ExecuteScale<T, RETTYPE>(this.m_connection, strExpression, strSql, parameters);
		}

		protected override IDbCommand PrepareCommand(IDbConnection conn, string strSql, object[] parameters)
		{
			IDbCommand dbCommand = base.PrepareCommand(conn, strSql, parameters);
			dbCommand.Transaction = this.m_transaction;
			return dbCommand;
		}

		public void Dispose()
		{
			this.Close();
		}

		public void Close()
		{
			try
			{
				if (null != this.m_transaction)
				{
					this.m_transaction.Commit();
					this.m_transaction = null;
				}
			}
			catch
			{
			}
			try
			{
				if (null != this.m_connection)
				{
					this.m_connection.Close();
					this.m_connection = null;
				}
			}
			catch
			{
			}
		}
	}
}
