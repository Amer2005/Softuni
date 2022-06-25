using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public List<Renovator> Renovators { get; set; }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count 
        {
            get
            {
                return Renovators.Count;
            }
        }

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Type == null || renovator.Name == null)
            {
                return "Invalid renovator's information.";
            }
            if (NeededRenovators <= Renovators.Count)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            Renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (!Renovators.Any(x => x.Name == name))
            {
                return false;
            }

            Renovators.RemoveAll(x => x.Name == name);

            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            if (!Renovators.Any(x => x.Type == type))
            {
                return 0;
            }

            return Renovators.RemoveAll(x => x.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            if (!Renovators.Any(x => x.Name == name))
            {
                return null;
            }

            int index = Renovators.FindIndex(x => x.Name == name);

            Renovators[index].Hired = true;

            return Renovators[index];
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.Where(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            List<Renovator> notHiredRenovators = Renovators.Where(x => x.Hired == false).ToList();

            StringBuilder result = new StringBuilder();

            result.Append($"Renovators available for Project {Project}:");

            foreach (var renovator in notHiredRenovators)
            {
                result.Append(Environment.NewLine);
                result.Append($"{renovator}");
            }

            return result.ToString();
        }
    }
}
