using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Util.Security
{
    public class Sifreleme
    {
        public static string byteuzunlugu;
        public static string SifreleAES(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) plainText = "";
            string sharedSecret = "Medlife_SistemOnline_Semsettin";
            string genelsifre = "semilhan112233445566778899semilhansemilhan112233445566778899semilhan";

            byte[] _salt = Encoding.ASCII.GetBytes(genelsifre);
            string outStr = null;
            RijndaelManaged aesAlg = null;
            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    byteuzunlugu = msEncrypt.ToArray().Length.ToString();
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                if (aesAlg != null)
                    aesAlg.Clear();
            }
            return outStr;
        }


        public static string SifreyiCozAES(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) cipherText = "cipherTextaa";
            string sharedSecret = "Medlife_SistemOnline_Semsettin";
            string genelsifre = "semilhan112233445566778899semilhansemilhan112233445566778899semilhan";



            byte[] _salt = Encoding.ASCII.GetBytes(genelsifre);
            RijndaelManaged aesAlg = null;


            string plaintext = null;

            try
            {

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);


                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    try
                    {
                        aesAlg = new RijndaelManaged();
                        aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                        aesAlg.IV = ReadByteArray(msDecrypt);
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                                plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                    catch (Exception)
                    { plaintext = ""; }

                }
            }
            finally
            {

                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            try
            {
                byte[] rawLength = new byte[sizeof(int)];
                if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
                {
                    throw new SystemException("Stream did not contain properly formatted byte array");
                }

                byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
                if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
                {
                    throw new SystemException("Did not read byte array properly");
                }

                return buffer;

            }
            catch (Exception)
            { return null; }
        }


        public static bool IIsNumeric(string deger)
        {
            bool isNumberResult = true;
            if (deger.Length > 0)
            {
                for (int i = 0; i < deger.Length; i++)
                {
                    if (!Char.IsNumber(deger, i))
                    {
                        isNumberResult = false;
                        break;
                    }
                }
            }
            else
            { isNumberResult = false; }
            return isNumberResult;
        }


        public static string SifreleMD5(string Metin)
        {
            MD5CryptoServiceProvider MD5Code = new MD5CryptoServiceProvider();
            byte[] byteDizisi = Encoding.UTF8.GetBytes(Metin + "Medlife_Semsettin");
            byteDizisi = MD5Code.ComputeHash(byteDizisi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in byteDizisi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
