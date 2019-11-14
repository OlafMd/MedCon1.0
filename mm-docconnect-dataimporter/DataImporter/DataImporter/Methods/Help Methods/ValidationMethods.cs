using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataImporter.Methods
{
    public class ValidationMethods
    {
          public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

       public static bool IsMailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
          
        }

      public static bool isValidBic(string bic)
        {
            Regex regBic = new Regex("^([a-zA-Z]){4}([a-zA-Z]){2}([0-9a-zA-Z]){2}([0-9a-zA-Z]{3})?$");
            Match matchica = regBic.Match(bic);
            if (matchica.Success)
            {
                return true;
            }
            else { return false; }
        
        }

      public  static bool isValidPass(string password)
        {
            Regex regPass = new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])[-\\w!$%@^&*[()_#\\]+|~=`{}\\:\";'<>?,.\\/]{8,128}$");
            Match matchica = regPass.Match(password);
            if (matchica.Success)
            {
                return true;
            }
            else { return false; }

        }
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
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

        public static bool LANRValidation(string Lanr)
        {
            try
            {

                List<int> ListCheck = new List<int>();
                string LanrValid = Lanr;
                string sh1 = LanrValid[0].ToString();
                int ch1 = int.Parse(sh1);
                var char1 = ch1 * 4;
                ListCheck.Add(char1);
                string sh2 = LanrValid[1].ToString();
                int ch2 = int.Parse(sh2);
                var char2 = ch2 * 9;
                ListCheck.Add(char2);
                string sh3 = LanrValid[2].ToString();
                int ch3 = int.Parse(sh3);
                var char3 = ch3 * 4;
                ListCheck.Add(char3);
                string sh4 = LanrValid[3].ToString();
                int ch4 = int.Parse(sh4);
                var char4 = ch4 * 9;
                ListCheck.Add(char4);
                string sh5 = LanrValid[4].ToString();
                int ch5 = int.Parse(sh5);
                var char5 = ch5 * 4;
                ListCheck.Add(char5);
                string sh6 = LanrValid[5].ToString();
                int ch6 = int.Parse(sh6);
                var char6 = ch6 * 9;
                ListCheck.Add(char6);

                string sh7 = LanrValid[6].ToString();
                int ch7 = int.Parse(sh7);
                var CheckSum = ch7 * 1;

                var sum = 0;

                foreach (int item in ListCheck)
                {
                    var result = 0;
                    //if (item >= 10)
                    //{
                    //    var convertToString = item.ToString();
                    //    string stFr = convertToString[0].ToString();
                    //    var firstDigit = int.Parse(stFr);
                    //    string stDi = convertToString[1].ToString();
                    //    var secondDigit = int.Parse(stDi);
                    //    result = firstDigit * 1 + secondDigit * 1;
                    //}
                    //else
                    //{
                        result = item;
                  //  }
                    sum = sum + result;
                }
                CultureInfo infc = CultureInfo.InvariantCulture;
                string CheckSumCounted = "";
                double sum1 = Convert.ToDouble(sum);
                double sumHelper = Math.Round(sum1 / 10, 2);
                string sumStrHelp = sumHelper.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
                try
                {
                    string[] splited = sumStrHelp.Split('.');
                  string help   = splited[1];
                  CheckSumCounted = (10 - Convert.ToInt32(help)).ToString();
                  if (CheckSumCounted == "10") { CheckSumCounted = "0"; };
                }
                catch {
                    CheckSumCounted = "0";
                }
         
                if (Convert.ToInt32(CheckSumCounted) == CheckSum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch {
                return false;
            }
        }
        public static Tuple<bool, string> ValidateInsuranceStatusCode(string code) {
            string codeValid = "";
            bool codeValidBool = true;
            string[] matchFirst = new string[18]{"1", "4", "6", "7", "8", "9", "d", "f", "a", "c", "s", "p", "e", "n", "m", "x", "k", "l"};

            if (code.Length == 2)
            {
                string[] charArray = Regex.Split(code, string.Empty);
                if (!matchFirst.Contains(charArray[1].ToLower()))
                {
                    codeValidBool = false;
                    return Tuple.Create(codeValidBool, code);
                }
                  Regex regPass = new Regex("[135]");
                  Match matchica = regPass.Match(charArray[1]);
                  if (!matchica.Success)
                  {
                      codeValidBool = false;
                      return Tuple.Create(codeValidBool, code);
                      
                  }
                  codeValid = charArray[1] + "000" + charArray[2];
                return Tuple.Create( codeValidBool, codeValid);
            }
            else if (code.Length != 5)
            {
                codeValidBool = false;
                return Tuple.Create(codeValidBool, code);
            }
            else {
                string[] charArray = Regex.Split(code, string.Empty);
                if (!matchFirst.Contains(charArray[5].ToLower()))
                {
                    codeValidBool = false;
                    return Tuple.Create(codeValidBool, code);
                }
                 Regex regPass = new Regex("[135][0-8][0-9][0-9]");
                  Match matchica = regPass.Match(charArray[1] + charArray[2] + charArray[3] + charArray[4]);
                  if (!matchica.Success)
                  {
                      codeValidBool = false;
                      return Tuple.Create(codeValidBool, code);
                  }
            }
            return Tuple.Create(codeValidBool, code);
        }

    }
}
