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

        /// <summary>
        /// ��ָ�����ַ����б�CnStr�м�������ƴ�������ַ���
        /// </summary>
        /// <param name="CnStr">�����ַ���</param>
        /// <returns>���Ӧ�ĺ���ƴ������ĸ��</returns>
        public static string GetSpellCode(string CnStr)
        {
            string strTemp = "";
            int iLen = CnStr.Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
                break;
            }
            return strTemp;
        }

        /// <summary>
        /// �õ�һ�����ֵ�ƴ����һ����ĸ�������һ��Ӣ����ĸ��ֱ�ӷ��ش�д��ĸ
        /// </summary>
        /// <param name="CnChar">��������</param>
        /// <returns>������д��ĸ</returns>
        private static string GetCharSpellCode(string CnChar)
        {
            long iCnChar;
            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);
            //�������ĸ����ֱ�ӷ�������ĸ
            if (ZW.Length == 1)
            {
                return CutString(CnChar.ToUpper(), 1);
            }
            else
            {
                // get the array of byte from the single char
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }

            // iCnChar match the constant
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
                return "A";
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
                return "B";
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
                return "C";
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
                return "D";
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
                return "E";
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
                return "F";
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
                return "G";
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
                return "H";
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
                return "J";
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
                return "K";
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
                return "L";
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
                return "M";
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
                return "N";
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
                return "O";
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
                return "P";
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
                return "Q";
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
                return "R";
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
                return "S";
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
                return "T";
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
                return "W";
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
                return "X";
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
                return "Y";
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
                return "Z";
            else
                return ("?");
        }

        #region ��ȡ�ַ����� static string CutString(string str, int len)
        /// <summary>
        /// ��ȡ�ַ�����
        /// </summary>
        /// <param name="str">����ȡ���ַ���</param>
        /// <param name="len">����ȡ�ĳ���</param>
        /// <returns>���ַ���</returns>
        public static string CutString(string str, int len)
        {
            if (str == null || str.Length == 0 || len <= 0)
            {
                return string.Empty;
            }

            int l = str.Length;

            #region ���㳤��
            int clen = 0;
            while (clen < len && clen < l)
            {
                //ÿ����һ�����ģ���Ŀ�곤�ȼ�һ��
                if ((int)str[clen] > 128) { len--; }
                clen++;
            }
            #endregion

            if (clen < l)
            {
                return str.Substring(0, clen) + "...";
            }
            else
            {
                return str;
            }
        }

        #endregion
    }
}
