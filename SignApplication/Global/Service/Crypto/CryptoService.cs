using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SignApplication.Global.Service.Crypto
{
    public class CryptoService : ICryptoService
    {
        public const string Key = "lasnbfyuwnmv;p87b4";

        public string Encrypt(string str)
        {
            return System.Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(str), Key));
        }

        public string Decrypt(string str)
        {
            string Result;
            try
            {
                var Cs = InternalDecrypt(System.Convert.FromBase64String(str), Key);
                var Sr = new StreamReader(Cs);

                Result = Sr.ReadToEnd();

                Cs.Close();
                Cs.Dispose();

                Sr.Close();
                Sr.Dispose();
            }
            catch (CryptographicException)
            {
                return null;
            }

            return Result;
        }

        private static byte[] Encrypt(byte[] key, string value)
        {
            SymmetricAlgorithm Sa = Rijndael.Create();
            ICryptoTransform Ct = Sa.CreateEncryptor((new PasswordDeriveBytes(value, null)).GetBytes(16), new byte[16]);

            var Ms = new MemoryStream();
            var Cs = new CryptoStream(Ms, Ct, CryptoStreamMode.Write);

            Cs.Write(key, 0, key.Length);
            Cs.FlushFinalBlock();

            byte[] Result = Ms.ToArray();

            Ms.Close();
            Ms.Dispose();

            Cs.Close();
            Cs.Dispose();

            Ct.Dispose();

            return Result;
        }

        private static CryptoStream InternalDecrypt(byte[] key, string value)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            ICryptoTransform ct = sa.CreateDecryptor((new PasswordDeriveBytes(value, null)).GetBytes(16), new byte[16]);

            var ms = new MemoryStream(key);
            return new CryptoStream(ms, ct, CryptoStreamMode.Read);
        }
    }
}