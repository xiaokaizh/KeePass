using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeePass.Class
{

    /********************************************************************************
    ** Author： Xiaokai Zh
    ** Created：2016-02-27
    ** Desc：DES 算法 加密/解密 静态类(密钥，且必须为8位)
    *********************************************************************************/

    public static class DES
    {
        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public static bool Encrypt(string pToEncrypt, string sKey,out string encryptString)
        {
            //如果出错，出错信息将储存于encryptString返回
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                if (!des.ValidKeySize(sKey.Length))
                {
                    encryptString = "Error:Key is not valid size";
                    return false;
                }
                   
                bool bl = des.ValidKeySize(sKey.Length);
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                    ms.Close();
                    return true;
                }
                catch (Exception e)
                {
                    encryptString = e.ToString();
                    return false;
                }
            }
        }


        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>已解密的字符串。</returns>
        public static bool Decrypt(string pToDecrypt, string sKey, out string decryptString)
        {
            byte[] inputByteArray;
            try
            {
                inputByteArray = Convert.FromBase64String(pToDecrypt);
            }
            catch (Exception e)
            {
                decryptString = e.ToString();
                return false;
            }

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                if (!des.ValidKeySize(sKey.Length))
                {
                    decryptString = "Error:Key is not valid size";
                    return false;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    decryptString = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                    return true;
                }
                catch (Exception e)
                {
                    decryptString = e.ToString();
                    return false;
                }
            }
        }  
    }
}
