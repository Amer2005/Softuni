using System;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string str = Console.ReadLine();

                if(str == "Stop")
                {
                    break;
                }

                Console.WriteLine(str);
            }
        }
    }
}
