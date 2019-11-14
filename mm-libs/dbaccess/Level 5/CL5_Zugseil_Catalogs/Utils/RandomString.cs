using System;

namespace CL5_Zugseil_Catalogs.Utils
{
    public class RandomString
    {
        private static readonly Random _rng = new Random((int)DateTime.Now.Ticks);
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

        public static string Generate(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
