using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowserable
    {
        private const int NumberLenght = 10;

        public string Browse(string website)
        {
            if (!ValidateWebsite(website))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {website}!";
        }

        public string Call(string number)
        {
            if (!ValidateNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
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

        public bool ValidateWebsite(string website)
        {
            if (website.Any(x => char.IsDigit(x)))
            {
                return false;
            }

            return true;
        }
    }
}
