using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Test.Extentions
{
    public static class StringExtention
    {
        public static bool MaxLength(this string str,int length )
        {
            if( str.Length > length)
            {
                return false;
            }
            return true;
        }

        public static bool MinLength(this string str, int length)
        {
            if (str.Length < length)
            {
                return false;
            }
            return true;
        }

        public static bool MinMaxLength(this string str, int min, int max)
        {
            if (str.Length<min || str.Length > max)
            {
                return false;
            }
            return true;
        }

        public static bool AcceptInt(this string str)
        {
            if (!Regex.IsMatch(str, @"^[0-9]+$"))
            {
                return false;
            }
            return true;
        }

        public static bool AcceptString(this string str)
        {
            if (!Regex.IsMatch(str, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            return true;
        }

        public static bool AcceptStringAndSpecialChar(this string str)
        {
            if (!Regex.IsMatch(str, @"^[a-zA-Z0-9_*#@.]+$"))
            {
                return false;
            }
            return true;
        }

    }
}
