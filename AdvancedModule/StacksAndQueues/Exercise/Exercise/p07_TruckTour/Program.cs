using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_TruckTour
{
    internal class Program
    {
        public class PetrolStation
        {
            public PetrolStation(int petrolAmount, int distanceToNextStation)
            {
                PetrolAmount = petrolAmount;
                DistanceToNextStation = distanceToNextStation;
            }

            public int PetrolAmount { get; set; }

            public int DistanceToNextStation { get; set; }
        }

        static void Main(string[] args)
        {
            Queue<PetrolStation> stations = new Queue<PetrolStation>();

            int numberOfStations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStations; i++)
            {
                int[] inputArgs = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int petrolAmount = inputArgs[0];
                int distanceToNextStation = inputArgs[1];

                stations.Enqueue(new PetrolStation(petrolAmount, distanceToNextStation));
            }

            for (int i = 0; i < numberOfStations; i++)
            {
                if(IsCircleCompletable(i, stations))
                {
                    Console.WriteLine(i);

                    break;
                }
            }
        }

        static bool IsCircleCompletable(int startPoint, Queue<PetrolStation> stationsOld)
        {
            Queue<PetrolStation> stations = new Queue<PetrolStation>(stationsOld);

            for (int i = 0; i < startPoint; i++)
            {
                stations.Enqueue(stations.Dequeue());
            }

            int petrol = 0;

            while (stations.Count > 0)
            {
                PetrolStation stationNow = stations.Dequeue();

                petrol += stationNow.PetrolAmount;

                if (petrol >= stationNow.DistanceToNextStation)
                {
                    petrol -= stationNow.DistanceToNextStation;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
