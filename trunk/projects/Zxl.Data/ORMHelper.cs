using System;
using System.Collections.Generic;
using System.Data;

namespace Zxl.Data
{
	public abstract class ORMHelper : DefaultORMHandler
	{
		public Sqlca Sqlca
		{
			get
			{
				return new Sqlca(this.CreateConnection());
			}
		}

		public abstract IDbConnection CreateConnection();

		public int Insert(object obj)
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Insert(dbConnection, obj);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public int Delete(object obj)
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Delete(dbConnection, obj, null);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public int Delete<T>(string strWhere) where T : class
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Delete<T>(dbConnection, strWhere);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public int Delete(object obj, string[] fieldNames)
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Delete(dbConnection, obj, fieldNames);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public int Save(object obj)
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				int num = base.Update(dbConnection, obj, null, null);
				if (num < 1)
				{
					num = base.Insert(dbConnection, obj);
				}
				result = num;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public int Update(object obj)
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Update(dbConnection, obj, null, null);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public int Update(object obj, string[] fieldWhere)
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Update(dbConnection, obj, null, fieldWhere);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public int Update(object obj, string[] fieldUpdate, string[] fieldWhere)
		{
			IDbConnection dbConnection = null;
			int result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Update(dbConnection, obj, fieldUpdate, fieldWhere);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public T Init<T>(string strSql) where T : class
		{
			IDbConnection dbConnection = null;
			T result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Init<T>(dbConnection, strSql, new object[0]);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public T Init<T>() where T : class
		{
			IDbConnection dbConnection = null;
			T result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Init<T>(dbConnection, null, new object[0]);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public List<T> Query<T>(string strSql, params object[] parameters) where T : class
		{
			IDbConnection dbConnection = null;
			List<T> result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Query<T>(dbConnection, strSql, parameters);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public List<T> Query<T>() where T : class
		{
			IDbConnection dbConnection = null;
			List<T> result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.Query<T>(dbConnection, null, new object[0]);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}

		public RETTYPE ExecuteScale<T, RETTYPE>(string strExpression, string strSql, params object[] parameters) where T : class
		{
			IDbConnection dbConnection = null;
			RETTYPE result;
			try
			{
				dbConnection = this.CreateConnection();
				result = base.ExecuteScale<T, RETTYPE>(dbConnection, strExpression, strSql, parameters);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (null != dbConnection)
				{
					dbConnection.Close();
				}
			}
			return result;
		}
	}
}
