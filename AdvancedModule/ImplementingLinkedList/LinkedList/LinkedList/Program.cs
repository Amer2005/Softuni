using System;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddFirst(3);
            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(5);
            doublyLinkedList.AddLast(6);

            doublyLinkedList.ForEach(n => Console.WriteLine(n));

            Console.WriteLine(String.Join(" ", doublyLinkedList.ToArray()));
        }
    }
}
