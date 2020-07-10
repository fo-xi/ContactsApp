using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    //TODO: название класса не совпадает с названием файла (+)
    /// <summary>
    /// A class containing auxiliary functions.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks whether the number of characters 
        /// is in the specified range.
        /// </summary>
        /// <param name="value">Value set by the user.</param>
        /// <param name="initialLength">The beginning of the border.</param>
        /// <param name="finalLength">The end of the border.</param>
        public static void AssertStringInRange(string value,
            int initialLength, int finalLength)
        {
            if ((value.Length < initialLength) || (value.Length > finalLength))
            {
                throw new ArgumentException(value + " " +
                    "must be in the range from" + " " +
                    initialLength + " " + "to" + " " + finalLength);
            }
        }
        /// <summary>
        /// Converts the first letter of the first 
        /// or last name to uppercase.
        /// </summary>
        /// <param name="value">Value set by the user.</param>
        public static string MakeUpperCase(string value) //TODO: не надо всё передавать по ref. Для простых типов данных никто не заморачивается и передает всё по значению (+)
        {
            return (value.Substring(0, 1).ToUpper() +
                    value.Substring(1, value.Length - 1).ToLower());
        }
        /// <summary>
        /// Checks whether the number is in this range.
        /// </summary>
        /// <param name="value">Value set by the user.</param>
        /// <param name="initialLength">The beginning of the border.</param>
        /// <param name="finalLength">The end of the border.</param>
        public static void AssertIntInRange(int value,
            int initialLength, int finalLength)
        {
            if ((value > initialLength) && (value > finalLength))
            {
                throw new ArgumentException(value + " " +
                    "must be in the range from" + " " +
                     initialLength + " " + "to" + " " + finalLength);
            }
        }
        public static void AssertEmptyString(string value)
        {
            if ((value.Length == 0))
            {
                throw new ArgumentException("Empty string");
            }
        }
        public static void AssertPhoneNumber(string value)
        {
            if ((value[0] != '7'))
            {
                throw new ArgumentException(value + " " +
                    "The number must contain exactly 11" +
                    "digits and start with 7");
            }
        }
        public static void AssertDateBirth(DateTime value)
        {
            if ((value.Year < 1900) || (value > DateTime.Now))
            {
                throw new ArgumentException(value.Year + " "
                    + "must be in the range from" + 1900 + "to" + DateTime.Now);
            }
        }
    }
}
