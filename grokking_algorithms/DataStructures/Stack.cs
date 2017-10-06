using grokking_algorithms.DataStructures.Node;
using System;
using Utilities;

namespace DataStructures
{
    public class Stack<T>
    {
        private LinkedListNode<T> head;
        
        public Stack()
        {
            this.head = null;
        }

        public void Push(T data)
        {
            var node = new LinkedListNode<T>(data);

            if(this.head != null)
            {
                node.Next = this.head;
            }

            this.head = node;
        }

        public T Pop()
        {
            if(this.head == null)
            {
                return default(T);
            }

            var selected = this.head;
            this.head = this.head.Next;

            return selected.Data;
        }

        public static void Test()
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            var arr = new int[]
            {
                stack.Pop(),
                stack.Pop(),
                stack.Pop(),
                stack.Pop(),
                stack.Pop()
            };

            Console.Write(arr.ToStringExtended());
            Console.Read();
        }
    }
}
