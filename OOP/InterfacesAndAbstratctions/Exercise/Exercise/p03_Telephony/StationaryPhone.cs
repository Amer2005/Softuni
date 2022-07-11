using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        private const int NumberLenght = 7;

        public string Call(string number)
        {
            if (!ValidateNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }

        public bool ValidateNumber(string number)
        {
            if (number.Length != NumberLenght)
            {
                return false;
            }

            if (number.Any(x => !char.IsDigit(x)))
            {
                return false;
            }

            return true;
        }
    }
}
