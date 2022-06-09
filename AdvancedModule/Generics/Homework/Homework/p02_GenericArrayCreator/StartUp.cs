using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = ArrayCreator.Create<int>(5, 1);

            Console.WriteLine(String.Join(" ", array));
        }
    }
}
