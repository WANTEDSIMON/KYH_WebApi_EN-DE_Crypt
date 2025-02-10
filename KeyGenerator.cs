using System;
using System.Security.Cryptography;
using System.Text;


namespace Key
{
    public class KeyGenerator
    {
        private const int KeyLength = 32; // AES-256 Key length

        public static string GenerateRandomKey()
        {
            byte[] key = new byte[KeyLength];
            RandomNumberGenerator.Fill(key);
            return Convert.ToBase64String(key);
        }
    }
}