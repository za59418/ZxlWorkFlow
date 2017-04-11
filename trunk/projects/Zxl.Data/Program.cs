using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Zxl.Data;
using System.Text;

namespace DCIIDS.Main
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string s1 = Utils.Encrypt("123456", "zxl");

            //string pwd = "ay+e42FBgYn2oY04hiUFaQ==";
            //string s2 = Utils.Decrypt(pwd, "zxl");

            string s2 = EncodeBase64("1");
            Console.WriteLine(s2);
            Console.ReadLine();
        }


        public static string EncodeBase64(Encoding encode, string source)
        {
            string result = null;
            byte[] bytes = encode.GetBytes(source);
            try
            {
                result = Convert.ToBase64String(bytes);
            }
            catch
            {
                result = source;
            }
            return result;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }
    }
}
