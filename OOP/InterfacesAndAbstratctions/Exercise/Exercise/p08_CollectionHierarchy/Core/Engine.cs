using p08_CollectionHierarchy.Contracts;
using p08_CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace p08_CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        private IAddableCollection<string> addableCollection = new AddableCollection<string>();
        private IAddableAndRemovableCollection<string> addableAndRemovableCollection = new AddableAndRemovableCollcetion<string>();
        private IAddableRemovableAndUsableCollection<string> addableRemovableAndUsableCollection = new AddableRemovableAndUsableCollection<string>();

        public void Run()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removeCount = int.Parse(Console.ReadLine());

            Console.WriteLine(AddToCollection(addableCollection, input));
            Console.WriteLine(AddToCollection(addableAndRemovableCollection, input));
            Console.WriteLine(AddToCollection(addableRemovableAndUsableCollection, input));

            Console.WriteLine(RemoveFromCollection(addableAndRemovableCollection, removeCount));
            Console.WriteLine(RemoveFromCollection(addableRemovableAndUsableCollection, removeCount));
        }

        private string AddToCollection(IAddableCollection<string> collection, string[] collectionToAdd)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < collectionToAdd.Length; i++)
            {
                result.Append(collection.Add(collectionToAdd[i]) + " ");
            }

            return result.ToString();
        }

        private string RemoveFromCollection(IAddableAndRemovableCollection<string> collection, int countToRemove)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < countToRemove; i++)
            {
                result.Append(collection.Remove() + " ");
            }

            return result.ToString();
        }
    }
}
