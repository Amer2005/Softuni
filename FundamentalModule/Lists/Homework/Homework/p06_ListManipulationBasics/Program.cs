using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split(' '); 

                if (inputs[0] == "Add")
                {
                    int numberToAdd = int.Parse(inputs[1]);

                    numbers.Add(numberToAdd);

                    continue;
                }

                if (inputs[0] == "Remove")
                {
                    int numberToRemove = int.Parse(inputs[1]);

                    numbers.Remove(numberToRemove);

                    continue;
                }

                if (inputs[0] == "RemoveAt")
                {
                    int indexToRemove = int.Parse(inputs[1]);

                    numbers.RemoveAt(indexToRemove);

                    continue;
                }

                if (inputs[0] == "Insert")
                {
                    int indexToInsert = int.Parse(inputs[2]);
                    int numberToInsert = int.Parse(inputs[1]);

                    numbers.Insert(indexToInsert, numberToInsert);

                    continue;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
