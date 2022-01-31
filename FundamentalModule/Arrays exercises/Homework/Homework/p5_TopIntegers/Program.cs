using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p5_TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int maxNumber = 0;

            maxNumber = array[array.Length - 1];

            StringBuilder output = new StringBuilder();

            output.Insert(0, maxNumber.ToString());

            for (int i = array.Length - 2; i >= 0; i--)
            {
                if(array[i] > maxNumber)
                {
                    maxNumber = array[i];
                    output.Insert(0, maxNumber.ToString() + " ");
                }
            }

            Console.WriteLine(output);

        }
    }
}
