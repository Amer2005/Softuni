using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmployees = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string company = inputArgs[0];
                string employee = inputArgs[1];

                if (companyEmployees.ContainsKey(company))
                {
                    if(companyEmployees[company].Contains(employee))
                    {
                        continue;
                    }

                    companyEmployees[company].Add(employee);
                }
                else
                {
                    companyEmployees.Add(company, new List<string> { employee });
                }
            }

            foreach (var companyEmployeesPair in companyEmployees)
            {
                Console.WriteLine(companyEmployeesPair.Key);

                foreach (var name in companyEmployeesPair.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
