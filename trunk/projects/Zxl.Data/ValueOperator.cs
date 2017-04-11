using System;
using System.Data;
using System.Data.Common;
using System.IO;
namespace DCIIDS.Data
{
	public class ValueOperator
	{
        public static int CreatePk(string tableName)
        {
            int result = 1;
            using (Sqlca sqlca = DatabaseManager.Sqlca)
            {
                DataTable tb = sqlca.ExecuteDataTable("select SEQ_" + tableName + ".Nextval VAL from dual");
                if (null != tb && tb.Rows.Count > 0)
                {
                    result = Convert.ToInt32(tb.Rows[0]["VAL"].ToString());
                }
            }
            return result;
        }
    }
}
