using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace BOp.RAA.Data
{
    public class CookieInfo
    {
        private static char KEY_SEPARATOR = '#';
        private static string KEY_TOKEN = "st";
        private static string KEY_LANGUAGE = "ln";

        public string DefaultLanguage { get; set; }
        public string SessionToken { get; set; }

        public CookieInfo() { }

        public CookieInfo(string cookieValue)
        {
            var values = GetValues(cookieValue);
            SessionToken = values[KEY_TOKEN];
            DefaultLanguage = values.ContainsKey(KEY_LANGUAGE) == true? values[KEY_LANGUAGE] : "EN";
        }

        public Dictionary<string, string> GetValues(string cookieValue)
        {
            cookieValue = cookieValue.TrimEnd('#').Trim('"');

            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] segments = cookieValue.Split(KEY_SEPARATOR);

            foreach (string pair in segments)
            {
                string[] values = pair.Split('=');
                if (values.Length == 2) { 
                    dict.Add(values[0], values[1]);
                }
            }

            return dict;
        }

        public string ToCookieValue()
        {
            return String.Format("{1}={2}{0}{3}={4}",
                KEY_SEPARATOR,
                KEY_TOKEN, SessionToken,
                KEY_LANGUAGE, DefaultLanguage);
        }

        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
