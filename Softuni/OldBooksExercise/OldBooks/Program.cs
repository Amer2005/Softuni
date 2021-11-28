using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchBook = Console.ReadLine();

            string book = Console.ReadLine();

            int checkedBooks = 0;

            while(book != searchBook)
            {
                if(book == "No More Books")
                {
                    Console.WriteLine($"The book you search is not here!");
                    Console.WriteLine($"You checked {checkedBooks} books.");

                    return;
                }

                checkedBooks++;

                book = Console.ReadLine();
            }
            Console.WriteLine($"You checked {checkedBooks} books and found it.");    
        }
    }
}
