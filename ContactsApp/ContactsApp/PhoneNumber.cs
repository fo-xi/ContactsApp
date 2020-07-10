using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Class containing information about the phone number.
    /// </summary>
    public class PhoneNumber //TODO: перед каждым классом нужен модификатор доступа public - иначе потом нельзя будет использовать в другом проекте (поправить здесь и в других классах) (+)
    {
        /// <summary>
        /// Contains information about the phone number.
        /// </summary>
        private string _number; //TODO: пустые строки между членами класса (поправить здесь и в других классах) (+)
        /// <summary>
        /// Returns and sets the phone number.
        /// </summary>
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                Validator.AssertPhoneNumber(value);
                Validator.AssertStringInRange(value, 0, 11);
                _number = value;
            }
        }
        /// <summary>
        /// Creates a phone number.
        /// </summary>
        /// <param name="number">Contact phone number.</param>
        public PhoneNumber(string number)
        {
            this.Number = number;
        }
    }
}
