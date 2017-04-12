using System;
using System.Data;
using System.Data.Common;
using System.IO;
namespace Zxl.Data
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

        public static string CreateNo(string tableName, string val)
        {
            while (val.Length < 4)
                val = "0" + val;
            string month = DateTime.Now.Month+"";
            if (month.Length < 2)
                month = "0" + month;
            string year = DateTime.Now.Year + "";
            return "CD-" + year + "-" + month + "-" + val; ;
        }
    }
}
