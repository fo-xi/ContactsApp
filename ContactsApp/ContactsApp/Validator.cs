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
        public static void AssertStringInRange(ref string value,
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
        public static void AssertIntInRange(ref int value,
            int initialLength, int finalLength)
        {
            if ((value > initialLength) && (value > finalLength))
            {
                throw new ArgumentException(value + " " +
                    "must be in the range from" + " " +
                     initialLength + " " + "to" + " " + finalLength);
            }
        }
    }
}
