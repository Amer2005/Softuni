using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            string[] inputs = Console.ReadLine().Split(' ');

            int bombNumber = int.Parse(inputs[0]);
            int bombRange = int.Parse(inputs[1]);

            bool[] isNumberBlownUp = new bool[numbers.Count];

            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i] == bombNumber)
                {
                    for (int j = 0; j <= bombRange; j++)
                    {
                        if (i - j >= 0)
                        {
                            isNumberBlownUp[i - j] = true;
                        }

                        if (i + j < numbers.Count)
                        {
                            isNumberBlownUp[i + j] = true;
                        }
                    }

                    i = i + bombRange;
                }
            }

            int sum = 0;


            for (int i = 0; i < numbers.Count; i++)
            {
                if (!isNumberBlownUp[i])
                {
                    sum += numbers[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
