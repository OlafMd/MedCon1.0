using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMVCTemplates
{
    public class Pzn8Generator
    {
        public String GenerateValidPzn8()
        {
            int[] pzn = GenerateNewPzn();
            int[] validatedPzn = new int[8];

            while (ValidatePZNAndConcatinateCheckDigit(pzn, out validatedPzn) != true)
            {
                pzn = GenerateNewPzn();
            }

            String pznString = string.Join("", validatedPzn);
            return pznString;
        }

        private int[] GenerateNewPzn()
        {
            int[] result = new int[8];

            result[0] = 8;

            Random rnd = new Random();
            int[] posibleFirst2digits = new int[] { 0, 1, 2, 3 };

            result[1] = posibleFirst2digits[rnd.Next(0, 4)];

            for (int i = 2; i < 7; i++)
            {
                result[i] = rnd.Next(0, 9);
            }

            return result;
        }

        public bool ValidatePZNAndConcatinateCheckDigit(int[] pzn, out int[] validatedPZN)
        {

            validatedPZN = new int[] { -1 };

            // calculating checkdigit
            int checkDigit = 0;

            for (int i = 0; i < 7; i++)
            {
                checkDigit += (pzn[i] * (i + 1));
            }

            checkDigit %= 11;

            if (checkDigit >= 10)
                return false;

            validatedPZN = pzn;
            validatedPZN[7] = checkDigit;

            return true;
        }

        public bool ValidatePzn(string pzn)
        {
            if (pzn.Length == 7)
            {
                pzn.Insert(0, "0");
            }

            int[] ia = pzn.Select(c => (int)(c - '0')).ToArray();   // string to int array

            return ValidatePzn(ia);
        }

        public bool ValidatePzn(int[] pzn)
        {
            if (pzn.Length == 7)    // ad leading zero if array does not have 8 characters
            {
                List<int> pznList = pzn.ToList();
                pznList.Insert(0, 0);
                pzn = pznList.ToArray();
            }

            // calculating checkdigit
            int checkDigit = 0;

            try
            {

                for (int i = 0; i < 7; i++)
                {
                    checkDigit += (pzn[i] * (i + 1));
                }

                checkDigit %= 11;

                if (checkDigit >= 10)
                    return false;

                return true;

            }
            catch
            {
                return false;
            }
        }

        public void testStuff()
        {
            string[] checkPZNs = new string[] { "1111115", "1234562", "1234125", "4569783", "4561020", "1022593", "1022452", "5210222", "5210825", "5219708",
                "0514822", "0245658", "7452662", "7452627"};

            Pzn8Generator gen = new Pzn8Generator();
            foreach (string pzn in checkPZNs)
            {
                bool test = gen.ValidatePzn(pzn);
            }
        }

    }
}