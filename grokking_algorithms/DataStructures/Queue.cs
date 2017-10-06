using System;
using grokking_algorithms.DataStructures.Node;
using Utilities;
using DataStructures_bad;

namespace DataStructures
{
    public class Queue<T>
    {
        private LinkedListNode<T> head;
        private int size;

        public Queue()
        {
            this.head = null;
            this.size = 0;
        }

        public bool isEmpty()
        {
            return this.size == 0;
        }

        public void Enqueue(T data)
        {
            var node = new LinkedListNode<T>(data);
            
            if(this.head == null)
            {
                this.head = node;
            }
            else
            {
                var selected = this.head;
                while(selected.Next != null)
                {
                    selected = selected.Next;
                }

                selected.Next = node;
            }

            this.size++;
        }

        public void Enqueue(LinkedList<T> data)
        {
            foreach(var item in data)
            {
                this.Enqueue(item);
            }
        }

        public T Dequeue()
        {
            if(this.isEmpty())
            {
                return default(T);
            }

            var selected = this.head;

            this.head = selected.Next;
            this.size--;

            return selected.Data;
        }

        public static void Test()
        {
            var queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            var arr = new int[]
            {
                queue.Dequeue(),
                queue.Dequeue(),
                queue.Dequeue(),
                queue.Dequeue(),
                queue.Dequeue()
            };

            Console.Write(arr.ToStringExtended());
            Console.Read();
        }
    }
}
