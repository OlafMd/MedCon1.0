///////////////////////////////////////////////////////////////////////////////
// SAMPLE: Symmetric key encryption and decryption using Rijndael algorithm.
// 
// To run this sample, create a new Visual C# project using the Console
// Application template and replace the contents of the Class1.cs file with
// the code below.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// 
// Copyright (C) 2002 Obviex(TM). All rights reserved.
// 
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// This class uses a symmetric key algorithm (Rijndael/AES) to encrypt and 
/// decrypt data. As long as encryption and decryption routines use the same
/// parameters to generate the keys, the keys are guaranteed to be the same.
/// The class uses static functions with duplicate code to make it easier to
/// demonstrate encryption and decryption logic. In a real-life application, 
/// this may not be the most efficient way of handling encryption, so - as
/// soon as you feel comfortable with it - you may want to redesign this class.
/// </summary>
/// 

namespace CSV2Core.Support.Security
{

    public class RijndaelSimple
    {
        private static string pkey = "P07aJK8soogA815C";

        private static byte[] HexStringToByteArray(string hex)
        {
            byte[] ret = new byte[hex.Length / 2];
            for (int j = 0; j < hex.Length; j += 2)
            {
                ret[j / 2] = byte.Parse(hex.Substring(j, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return ret;
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string Encrypt(string text)
        {
            //decode cipher text from base64
            byte[] cipher = Encoding.UTF8.GetBytes(text);
            //get key bytes

            //init AES 128
            RijndaelManaged aes128 = new RijndaelManaged();
            aes128.Mode = CipherMode.ECB;
            aes128.Padding = PaddingMode.Zeros;
            aes128.KeySize = 128;
            aes128.Key = Encoding.UTF8.GetBytes(pkey);

            ICryptoTransform encryptor = aes128.CreateEncryptor(Encoding.UTF8.GetBytes(pkey), aes128.IV);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

            cs.Write(cipher, 0, cipher.Length);
            cs.FlushFinalBlock();

            byte[] cipherTextBytes = ms.ToArray();

            ms.Close();
            cs.Close();

            return BitConverter.ToString(cipherTextBytes).Replace("-", "");
        }

        public static String Decrypt(String text)
        {
            //decode cipher text from base64
            byte[] cipher = HexStringToByteArray(text);
            //get key bytes

            //byte[] btkey = HexStringToByteArray(pkey);//twEncoding.ASCII.GetBytes(key);

            //init AES 128
            RijndaelManaged aes128 = new RijndaelManaged();
            aes128.Mode = CipherMode.ECB;
            aes128.Padding = PaddingMode.Zeros;
            aes128.KeySize = 128;
            aes128.Key = Encoding.UTF8.GetBytes(pkey);

            //decrypt
            ICryptoTransform decryptor = aes128.CreateDecryptor(Encoding.UTF8.GetBytes(pkey), aes128.IV);
            MemoryStream ms = new MemoryStream(cipher);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

            byte[] plain = new byte[cipher.Length];
            int decryptcount = cs.Read(plain, 0, plain.Length);



            ms.Close();
            cs.Close();
            //return plaintext in String
            string decrypted = Encoding.UTF8.GetString(plain, 0, decryptcount);
            decrypted = decrypted.TrimEnd('\0');
            decrypted = System.Web.HttpUtility.UrlDecode(decrypted, Encoding.UTF8);
            return decrypted;
        }
    }

}
//
// END OF FILE
///////////////////////////////////////////////////////////////////////////////