﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppServices
{
    public static class Util
    {
        public static IPInfo GetIPInfo(HttpRequest request)
        {
            string userIp = null;
            try
            {
                userIp = request["HTTP_X_FORWARDED_FOR"];
            }
            catch (Exception ex) { }

            userIp = userIp == null ? request["REMOTE_ADDR"] : userIp.Split(',')[0];

            return new IPInfo()
            {
                agent = request.Browser.Browser + " " + request.Browser.Version,
                address = userIp

            };
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
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }

    public class IPInfo
    {
        public string address { get; set; }
        public string agent { get; set; }
    }


}