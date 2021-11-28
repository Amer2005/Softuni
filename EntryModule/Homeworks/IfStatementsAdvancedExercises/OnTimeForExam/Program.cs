using System;

namespace OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHours = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());
            int arriveHours = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            startMinutes += startHours * 60;

            arriveMinutes += arriveHours * 60;

            if(arriveMinutes <= startMinutes)
            {
                if (arriveMinutes < startMinutes - 30)
                {
                    Console.WriteLine("Early");
                }
                else
                {
                    Console.WriteLine("On time");
                }

                if (startMinutes - arriveMinutes < 60)
                {
                    Console.WriteLine($"{startMinutes - arriveMinutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{(startMinutes - arriveMinutes) / 60}:{((startMinutes - arriveMinutes) % 60).ToString("D2")} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("Late");

                if (arriveMinutes - startMinutes < 60)
                {
                    Console.WriteLine($"{arriveMinutes - startMinutes} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{(arriveMinutes - startMinutes) / 60}:{((arriveMinutes - startMinutes) % 60).ToString("D2")} hours after the start");
                }
            }
        }
    }
}
