using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_MultiplyBigIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> bigNumber = Console.ReadLine().ToCharArray().Select(x => x - '0').ToList();
            int digit = int.Parse(Console.ReadLine());

            Multiply(bigNumber, digit);

            Console.WriteLine(String.Join(String.Empty, bigNumber));
        }

        static void Multiply(List<int> bigNumber, int digit)
        {
            if (digit == 0)
            {
                bigNumber.RemoveRange(1, bigNumber.Count - 1);

                bigNumber[0] = 0;

                return;
            }

            int carry = 0;

            for (int i = bigNumber.Count - 1; i >= 0; i--)
            {
                int digitNow = digit * bigNumber[i] + carry;

                carry = digitNow / 10;
                digitNow = digitNow % 10;

                bigNumber[i] = digitNow;
            }

            if (carry != 0)
            {
                bigNumber.Insert(0, carry);
            }
        }
    }
}
