using System;
using System.Collections.Generic;
using System.Text;

namespace p09_CustomLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode<T>(element);

                this.tail = this.head;
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode<T>(element);

                this.tail = this.head;
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            T firstElement = this.head.Value;

            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            T lastElement = this.tail.Value;

            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            List<T> result = new List<T>();
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                result.Add(currentNode.Value);

                currentNode = currentNode.NextNode;
            }

            return result.ToArray();
        }
    }
}
