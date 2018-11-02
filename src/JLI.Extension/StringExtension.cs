
using System;
using System.Linq;

namespace JLI.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// Convert a string to Int, float, double.
        /// </summary>
        /// <typeparam name="T">type of date.</typeparam>
        /// <param name="source">string to convert.</param>
        /// <returns>a number.</returns>
        public static T ToNumber<T>(this string source) where T : struct
        {
            if (typeof(T) != typeof(Int16) 
                && typeof(T) != typeof(Int32) 
                && typeof(T) != typeof(Int64) 
                && typeof(T) != typeof(UInt16)
                && typeof(T) != typeof(UInt32)
                && typeof(T) != typeof(UInt64)
                && typeof(T) != typeof(Single)
                && typeof(T) != typeof(float)
                && typeof(T) != typeof(decimal)
                && typeof(T) != typeof(double))
            {
                throw new ArgumentException(
                  string.Format("Type '{0}' is not valid.", typeof(T).ToString()));
            }

            return (T)Convert.ChangeType(source, typeof(T));
        }

        /// <summary>
        /// Check if the string is a number.
        /// </summary>
        /// <param name="source">string to check.</param>
        /// <returns>true if string is number otherwise false.</returns>
        public static bool IsNumber(this string source)
        {
            if(string.IsNullOrEmpty(source))
            {
                return false;
            }

            var cleanString = source.Where(at=> at != '.' && at != '-');
            return   (cleanString.All(char.IsDigit) || cleanString.All(char.IsNumber));
        }
    }
}
