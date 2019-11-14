using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CL5_MPC_Account.Utils
{
    class CryptoUtils
    {
        RNGCryptoServiceProvider _cryptoProvider;

        public CryptoUtils()
        {
            _cryptoProvider = new RNGCryptoServiceProvider();
        }

        public string GenerateRandomSalt(int size)
        {
            var bytes = new Byte[size];
            _cryptoProvider.GetBytes(bytes);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public string GenerateSaltedHash(string plainText, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainText + salt);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public string GetHashAlgorithName()
        {
            return "SHA256";
        }

    }
}
