using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Helpers
{
    /// <summary>
    /// Class that helps in encryption process
    /// </summary>
    public class EncryptionHelper
    {
        public static string EncryptText(string plainText)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            StringBuilder str = new StringBuilder();
            UnicodeEncoding unicode = new UnicodeEncoding();

            byte[] hash = md5.ComputeHash(unicode.GetBytes(plainText));

            for (int i = 0; i < 100; i++)
                hash = md5.ComputeHash(hash);

            for (int i = 0; i < hash.Length; i++)
                str.Append(hash[i].ToString("X2"));

            return str.ToString();
        }
    }
}