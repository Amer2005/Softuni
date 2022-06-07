using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode(element);

                this.tail = this.head;
            }
            else
            {
                ListNode newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                head = newHead;
            }

            this.Count++;
        }

        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode(element);

                this.tail = this.head;
            }
            else
            {
                ListNode newTail = new ListNode(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                tail = newTail;
            }

            this.Count++;
        }

        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            int firstElement = this.head.Value;

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
        
        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            int lastElement = this.tail.Value;

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

        public void ForEach(Action<int> action)
        {
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            List<int> result = new List<int>();
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                result.Add(currentNode.Value);

                currentNode = currentNode.NextNode;
            }

            return result.ToArray();
        }
    }
}
