using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL6_MRMS_Backoffice.Utils
{
    public static class StringUtils
    {     
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string CodeGen(int size)
        {
            Random _rng = new Random((int)DateTime.Now.Ticks);
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
