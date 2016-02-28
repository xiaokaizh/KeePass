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
    ** Desc：MD5 算法加密
    *********************************************************************************/

    public static class Md5
    {
        public static bool Md5Encrypt(string needEncryptString,out string  encryptString)
        {
            try
            {
                //通用编码格式utf-8,不同的编码格式的MD5码不一样，这里推荐使用utf-8
                byte[] result = Encoding.UTF8.GetBytes(needEncryptString);
                MD5 md = new MD5CryptoServiceProvider();
                byte[] output = md.ComputeHash(result);
                encryptString = BitConverter.ToString(output).Replace("-", "");
                return true;
            }
            catch (Exception e)
            {
                encryptString = e.ToString();
                return false;
            }
        }

    }
}
