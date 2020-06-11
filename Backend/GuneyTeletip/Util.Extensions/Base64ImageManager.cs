using System;
using System.Security.Cryptography;
using System.Text;

namespace IzcilikSistemi.Kutuphane
{
    public static class Base64ImageManager
    {
        public static string Convert2DataUrl(byte[] arr)
        {
            return $"data:image/jpeg;base64,{Convert.ToBase64String(arr)}";
        }
    }
}
