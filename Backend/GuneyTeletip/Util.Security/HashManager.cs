using System;
using System.Security.Cryptography;
using System.Text;

namespace IzcilikSistemi.Kutuphane
{
    public static class HashManager
    {
        public static string GetHashCode(string data)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(data);
            var str = Convert.ToBase64String(HashAlgorithm.Create("SHA1").ComputeHash(bytes));
           
            return str;
        }
    }
}
