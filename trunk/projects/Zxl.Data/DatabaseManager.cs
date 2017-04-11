using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;
using Zxl.Data.Parser;

namespace Zxl.Data
{
    public class DatabaseManager
    {
        private static DatabaseManager m_instance = null;
        private DatabaseManager()
        {
        }
        public static DatabaseManager Instance
        {
            get
            {
                if (null == m_instance)
                {
                    lock (typeof(DatabaseManager))
                    {
                        if (null == m_instance)
                        {
                            m_instance = new DatabaseManager();
                        }
                    }
                }
                return m_instance;
            }
        }
        public static ORMHandler ORMHandler
        {
            get
            {
                return new ORMHandler(GetConnection());
            }
        }
        public static Sqlca Sqlca
        {
            get
            {
                return new Sqlca(GetConnection());
            }
        }
        public static PaginatedSqlca PaginatedSqlca
        {
            get
            {
                return new PaginatedSqlca(GetConnection());
            }
        }

        private static IDbConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["OA"].ToString();
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            return conn;
        }

    }
}
