using System;
using System.Text;

namespace CSV2Core.Support
{
    public static class SQLSupport
    {
        /// <summary>
        /// Generates the IN Statement by adding Prefix + Index to the in Querry
        /// Starts from 0
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public static string GenerateInStatement(Guid[] guids,string prefix="D")
        {
            if (guids.Length == 0)
                return "( )";

            StringBuilder builder = new StringBuilder("( ");
            int index = 0;
            foreach (Guid guid in guids)
            {
                builder.Append("@"+prefix+(index++)+",");
            }
            builder.Remove(builder.Length-1, 1);
            builder.Append(" )");

            return builder.ToString();
        }

        public static string GenerateInStatement(object[] values, string prefix = "D")
        {
            if (values.Length == 0)
                return "( )";

            StringBuilder builder = new StringBuilder("( ");
            int index = 0;
            foreach (string value in values)
            {
                builder.Append("@" + prefix + (index++) + ",");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(" )");

            return builder.ToString();
        }

    }
}
