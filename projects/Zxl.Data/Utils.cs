using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace Zxl.Data
{
    public class Utils
    {
        public static string md5Unicodebase64(String str)
        {
            Base64Encoder base64 = new Base64Encoder();
            var ss = (byte[])MYMD5.md5(str, true, Encoding.Unicode);
            return base64.GetEncoded((byte[])MYMD5.md5(str, true, Encoding.Unicode));
        }


        public static void WriteFile(string strFileName, byte[] bytes, int nsize)
        {
            if (null == strFileName || null == bytes || bytes.Length < 1)
            {
                return;
            }
            FileStream stream = null;
            if (System.IO.File.Exists(strFileName) == false)
            {
                stream = System.IO.File.OpenWrite(strFileName);
            }
            else
            {
                stream = new FileStream(strFileName, FileMode.Append, FileAccess.Write, FileShare.None);
            }
            stream.Write(bytes, 0, nsize);
            stream.Flush();
            stream.Close();
        }

        //public static byte[] File2Bytes(string strFileName)
        //{
        //    if (System.IO.File.Exists(strFileName) == false)
        //    {
        //        return null;
        //    }
        //    FileStream s = (new FileInfo(strFileName)).OpenRead();
        //    byte[] ret = new byte[s.Length];
        //    s.Read(ret, 0, (int)s.Length);
        //    s.Close();
        //    return ret;
        //}
        // Encrypt a byte array into a byte array using a key and an IV 
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a MemoryStream to accept the encrypted bytes 
                MemoryStream ms = new MemoryStream();

                // Create a symmetric algorithm. 
                // We are going to use Rijndael because it is strong and
                // available on all platforms. 
                // You can use other algorithms, to do so substitute the
                // next line with something like 
                //      TripleDES alg = TripleDES.Create(); 
                Rijndael alg = Rijndael.Create();

                // Now set the key and the IV. 
                // We need the IV (Initialization Vector) because
                // the algorithm is operating in its default 
                // mode called CBC (Cipher Block Chaining).
                // The IV is XORed with the first block (8 byte) 
                // of the data before it is encrypted, and then each
                // encrypted block is XORed with the 
                // following block of plaintext.
                // This is done to make encryption more secure. 

                // There is also a mode called ECB which does not need an IV,
                // but it is much less secure. 
                alg.Key = Key;
                alg.IV = IV;

                // Create a CryptoStream through which we are going to be
                // pumping our data. 
                // CryptoStreamMode.Write means that we are going to be
                // writing data to the stream and the output will be written
                // in the MemoryStream we have provided. 
                CryptoStream cs = new CryptoStream(ms,
                   alg.CreateEncryptor(), CryptoStreamMode.Write);

                // Write the data and make it do the encryption 
                cs.Write(clearData, 0, clearData.Length);

                // Close the crypto stream (or do FlushFinalBlock). 
                // This will tell it that we have done our encryption and
                // there is no more data coming in, 
                // and it is now a good time to apply the padding and
                // finalize the encryption process. 
                cs.Close();

                // Now get the encrypted data from the MemoryStream.
                // Some people make a mistake of using GetBuffer() here,
                // which is not the right way. 
                byte[] encryptedData = ms.ToArray();

                return encryptedData;
            }
            catch (Exception ex)
            {
                throw new Exception("加密错误：" + ex.Message, ex);
            }
        }

        // Encrypt a string into a string using a password 
        //    Uses Encrypt(byte[], byte[], byte[]) 

        public static string Encrypt(string clearText, string Password)
        {
            // First we need to turn the input string into a byte array. 
            byte[] clearBytes =
              System.Text.Encoding.Unicode.GetBytes(clearText);

            // Then, we need to turn the password into Key and IV 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the encryption using the
            // function that accepts byte arrays. 
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size. 
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes. 
            byte[] encryptedData = Encrypt(clearBytes,
                     pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting byte array into a string. 
            // A common mistake would be to use an Encoding class for that.
            //It does not work because not all byte values can be
            // represented by characters. 
            // We are going to be using Base64 encoding that is designed
            //exactly for what we are trying to do. 
            return Convert.ToBase64String(encryptedData);

        }

        // Encrypt bytes into bytes using a password 
        //    Uses Encrypt(byte[], byte[], byte[]) 

        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            // We need to turn the password into Key and IV. 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the encryption using the function
            // that accepts byte arrays. 
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is 8
            // bytes and so should be the IV size. 
            // You can also read KeySize/BlockSize properties off the
            // algorithm to find out the sizes. 
            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));

        }

        // Encrypt a file into another file using a password 
        public static void Encrypt(string fileIn,
                    string fileOut, string Password)
        {

            // First we are going to open the file streams 
            FileStream fsIn = new FileStream(fileIn,
                FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut,
                FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from the
            // Password and create an algorithm 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going
            // to be pumping data. 
            // Our fileOut is going to be receiving the encrypted bytes. 
            CryptoStream cs = new CryptoStream(fsOut,
                alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be processing
            // the input file in chunks. 
            // This is done to avoid reading the whole file (which can
            // be huge) into memory. 
            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                // read a chunk of data from the input file 
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // encrypt it 
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything 

            // this will also close the unrelying fsOut stream
            cs.Close();
            fsIn.Close();
        }

        // Decrypt a byte array into a byte array using a key and an IV 
        public static byte[] Decrypt(byte[] cipherData,
                                    byte[] Key, byte[] IV)
        {
            try
            {
                // Create a MemoryStream that is going to accept the
                // decrypted bytes 
                MemoryStream ms = new MemoryStream();

                // Create a symmetric algorithm. 
                // We are going to use Rijndael because it is strong and
                // available on all platforms. 
                // You can use other algorithms, to do so substitute the next
                // line with something like 
                //     TripleDES alg = TripleDES.Create(); 
                Rijndael alg = Rijndael.Create();

                // Now set the key and the IV. 
                // We need the IV (Initialization Vector) because the algorithm
                // is operating in its default 
                // mode called CBC (Cipher Block Chaining). The IV is XORed with
                // the first block (8 byte) 
                // of the data after it is decrypted, and then each decrypted
                // block is XORed with the previous 
                // cipher block. This is done to make encryption more secure. 
                // There is also a mode called ECB which does not need an IV,
                // but it is much less secure. 
                alg.Key = Key;
                alg.IV = IV;

                // Create a CryptoStream through which we are going to be
                // pumping our data. 
                // CryptoStreamMode.Write means that we are going to be
                // writing data to the stream 
                // and the output will be written in the MemoryStream
                // we have provided. 
                CryptoStream cs = new CryptoStream(ms,
                    alg.CreateDecryptor(), CryptoStreamMode.Write);

                // Write the data and make it do the decryption 
                cs.Write(cipherData, 0, cipherData.Length);

                // Close the crypto stream (or do FlushFinalBlock). 
                // This will tell it that we have done our decryption
                // and there is no more data coming in, 
                // and it is now a good time to remove the padding
                // and finalize the decryption process. 
                cs.Close();

                // Now get the decrypted data from the MemoryStream. 
                // Some people make a mistake of using GetBuffer() here,
                // which is not the right way. 
                byte[] decryptedData = ms.ToArray();

                return decryptedData;
            }
            catch (Exception ex)
            {
                throw new Exception("解密错误：" + ex.Message, ex);
            }
        }

        // Decrypt a string into a string using a password 
        //    Uses Decrypt(byte[], byte[], byte[]) 

        public static string Decrypt(string cipherText, string Password)
        {
            // First we need to turn the input string into a byte array. 
            // We presume that Base64 encoding was used 
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Then, we need to turn the password into Key and IV 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 
            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the decryption using
            // the function that accepts byte arrays. 
            // Using PasswordDeriveBytes object we are first
            // getting 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by
            // default 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size. 
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes. 
            byte[] decryptedData = Decrypt(cipherBytes,
                pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting byte array into a string. 
            // A common mistake would be to use an Encoding class for that.
            // It does not work 
            // because not all byte values can be represented by characters. 
            // We are going to be using Base64 encoding that is 
            // designed exactly for what we are trying to do. 
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        // Decrypt bytes into bytes using a password 
        //    Uses Decrypt(byte[], byte[], byte[]) 

        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            // We need to turn the password into Key and IV. 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            // Now get the key/IV and do the Decryption using the 
            //function that accepts byte arrays. 
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size. 

            // You can also read KeySize/BlockSize properties off the
            // algorithm to find out the sizes. 
            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Decrypt a file into another file using a password 
        public static void Decrypt(string fileIn,
                    string fileOut, string Password)
        {

            // First we are going to open the file streams 
            FileStream fsIn = new FileStream(fileIn,
                        FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut,
                        FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from
            // the Password and create an algorithm 
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going
            // to be pumping data. 
            // Our fileOut is going to be receiving the Decrypted bytes. 
            CryptoStream cs = new CryptoStream(fsOut,
                alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be 
            // processing the input file in chunks. 
            // This is done to avoid reading the whole file (which can be
            // huge) into memory. 
            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;

            do
            {
                // read a chunk of data from the input file 
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // Decrypt it 
                cs.Write(buffer, 0, bytesRead);

            } while (bytesRead != 0);

            // close everything 
            cs.Close(); // this will also close the unrelying fsOut stream 
            fsIn.Close();
        }
    }

    class MYMD5
    {
        // 格式化md5 hash 字节数组所用的格式（两位小写16进制数字）   
        private static readonly string m_strHexFormat = "x2";
        private MYMD5() { }
        /// <summary>   
        /// 使用当前缺省的字符编码对字符串进行加密   
        /// </summary>   
        /// <param name="str">需要进行md5演算的字符串</param>   
        /// <returns>用小写字母表示的32位16进制数字字符串</returns>   
        public static string md5(string str)
        {
            return (string)md5(str, false, Encoding.Default);
        }
        /// <summary>   
        /// 对字符串进行md5 hash计算   
        /// </summary>   
        /// <param name="str">需要进行md5演算的字符串</param>   
        /// <param name="raw_output">   
        /// false则返回经过格式化的加密字符串(等同于 string md5(string) )   
        /// true则返回原始的md5 hash 长度16 的 byte[] 数组   
        /// </param>   
        /// <returns>   
        /// byte[] 数组或者经过格式化的 string 字符串   
        /// </returns>   
        public static object md5(string str, bool raw_output)
        {
            return md5(str, raw_output, Encoding.Default);
        }
        /// <summary>   
        /// 对字符串进行md5 hash计算   
        /// </summary>   
        /// <param name="str">需要进行md5演算的字符串</param>   
        /// <param name="raw_output">   
        /// false则返回经过格式化的加密字符串(等同于 string md5(string) )   
        /// true则返回原始的md5 hash 长度16 的 byte[] 数组   
        /// </param>   
        /// <param name="charEncoder">   
        /// 用来指定对输入字符串进行编解码的 Encoding 类型，   
        /// 当输入字符串中包含多字节文字（比如中文）的时候   
        /// 必须保证进行匹配的 md5 hash 所使用的字符编码相同，   
        /// 否则计算出来的 md5 将不匹配。   
        /// </param>   
        /// <returns>   
        /// byte[] 数组或者经过格式化的 string 字符串   
        /// </returns>   
        public static object md5(string str, bool raw_output,
                                                    Encoding charEncoder)
        {
            if (!raw_output)
                return md5str(str, charEncoder);
            else
                return md5raw(str, charEncoder);
        }

        /// <summary>   
        /// 使用当前缺省的字符编码对字符串进行加密   
        /// </summary>   
        /// <param name="str">需要进行md5演算的字符串</param>   
        /// <returns>用小写字母表示的32位16进制数字字符串</returns>   
        protected static string md5str(string str)
        {
            return md5str(str, Encoding.Default);
        }
        /// <summary>   
        /// 对字符串进行md5加密   
        /// </summary>   
        /// <param name="str">需要进行md5演算的字符串</param>   
        /// <param name="charEncoder">   
        /// 指定对输入字符串进行编解码的 Encoding 类型   
        /// </param>   
        /// <returns>用小写字母表示的32位16进制数字字符串</returns>   
        protected static string md5str(string str, Encoding charEncoder)
        {
            byte[] bytesOfStr = md5raw(str, charEncoder);
            int bLen = bytesOfStr.Length;
            StringBuilder pwdBuilder = new StringBuilder(32);
            for (int i = 0; i < bLen; i++)
            {
                pwdBuilder.Append(bytesOfStr[i].ToString(m_strHexFormat));
            }
            return pwdBuilder.ToString();
        }
        /// <summary>   
        /// 使用当前缺省的字符编码对字符串进行加密   
        /// </summary>   
        /// <param name="str">需要进行md5演算的字符串</param>   
        /// <returns>长度16 的 byte[] 数组</returns>   
        protected static byte[] md5raw(string str)
        {
            return md5raw(str, Encoding.Default);
        }
        /// <summary>   
        /// 对字符串进行md5加密   
        /// </summary>   
        /// <param name="str">需要进行md5演算的字符串</param>   
        /// <param name="charEncoder">   
        /// 指定对输入字符串进行编解码的 Encoding 类型   
        /// </param>   
        /// <returns>长度16 的 byte[] 数组</returns>   
        protected static byte[] md5raw(string str, Encoding charEncoder)
        {
            System.Security.Cryptography.MD5 md5 =
                System.Security.Cryptography.MD5.Create();
            return md5.ComputeHash(charEncoder.GetBytes(str));
        }
    }
    /// <summary>  
    /// Base64编码类。  
    /// 将byte[]类型转换成Base64编码的string类型。  
    /// </summary>  
    public class Base64Encoder
    {
        byte[] source;
        int length, length2;
        int blockCount;
        int paddingCount;
        public static Base64Encoder Encoder = new Base64Encoder();

        public Base64Encoder()
        {
        }

        private void init(byte[] input)
        {
            source = input;
            length = input.Length;
            if ((length % 3) == 0)
            {
                paddingCount = 0;
                blockCount = length / 3;
            }
            else
            {
                paddingCount = 3 - (length % 3);
                blockCount = (length + paddingCount) / 3;
            }
            length2 = length + paddingCount;
        }

        public string GetEncoded(byte[] input)
        {
            //初始化  
            init(input);

            byte[] source2;
            source2 = new byte[length2];

            for (int x = 0; x < length2; x++)
            {
                if (x < length)
                {
                    source2[x] = source[x];
                }
                else
                {
                    source2[x] = 0;
                }
            }

            byte b1, b2, b3;
            byte temp, temp1, temp2, temp3, temp4;
            byte[] buffer = new byte[blockCount * 4];
            char[] result = new char[blockCount * 4];
            for (int x = 0; x < blockCount; x++)
            {
                b1 = source2[x * 3];
                b2 = source2[x * 3 + 1];
                b3 = source2[x * 3 + 2];

                temp1 = (byte)((b1 & 252) >> 2);

                temp = (byte)((b1 & 3) << 4);
                temp2 = (byte)((b2 & 240) >> 4);
                temp2 += temp;

                temp = (byte)((b2 & 15) << 2);
                temp3 = (byte)((b3 & 192) >> 6);
                temp3 += temp;

                temp4 = (byte)(b3 & 63);

                buffer[x * 4] = temp1;
                buffer[x * 4 + 1] = temp2;
                buffer[x * 4 + 2] = temp3;
                buffer[x * 4 + 3] = temp4;

            }

            for (int x = 0; x < blockCount * 4; x++)
            {
                result[x] = sixbit2char(buffer[x]);
            }


            switch (paddingCount)
            {
                case 0: break;
                case 1: result[blockCount * 4 - 1] = '='; break;
                case 2: result[blockCount * 4 - 1] = '=';
                    result[blockCount * 4 - 2] = '=';
                    break;
                default: break;
            }
            return new string(result);
        }
        private char sixbit2char(byte b)
        {
            char[] lookupTable = new char[64]{  
                  'A','B','C','D','E','F','G','H','I','J','K','L','M',  
                 'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',  
                 'a','b','c','d','e','f','g','h','i','j','k','l','m',  
                 'n','o','p','q','r','s','t','u','v','w','x','y','z',  
                 '0','1','2','3','4','5','6','7','8','9','+','/'};

            if ((b >= 0) && (b <= 63))
            {
                return lookupTable[(int)b];
            }
            else
            {

                return ' ';
            }
        }


    }

}
