using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Utils
    {
        public static string Md5Hash(this string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            var result = md5.Hash;
            var strBuilder = new StringBuilder();
            for (var i = 0; i < result.Length; i++)
            {
                strBuilder.Append(i.ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}
