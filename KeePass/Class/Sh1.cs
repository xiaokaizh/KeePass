using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeePass.Class
{

    /********************************************************************************
    ** Author： Xiaokai Zh
    ** Created：2016-02-27
    ** Desc：SHA-1密码算法 加密
    *********************************************************************************/

    public static class Sh1
    {
        public static bool  SHA1(string needEncryptString,out string  encryptString)
        {
            try
            {
                byte[] result = Encoding.UTF8.GetBytes(needEncryptString);
                System.Security.Cryptography.SHA1 sh1 = System.Security.Cryptography.SHA1.Create();
                sh1.ComputeHash(result);
                encryptString = Convert.ToBase64String(sh1.Hash);
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
