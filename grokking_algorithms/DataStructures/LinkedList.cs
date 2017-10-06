using System;
using System.Collections;
using grokking_algorithms.DataStructures.Node;

namespace DataStructures_bad
{
    public class LinkedList<T>: System.Collections.IEnumerable
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int size;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }
        
        public int Count
        {
            get
            {
                return this.size;
            }
        }
        
        /// <summary>
        /// Retrieve the data in the list at the specified position or default
        /// </summary>
        /// <param name="position">position to retrieve</param>
        /// <returns>the retrieved data or default</returns>
        public T this[int position]
        {
            get
            {
                if (position > this.size - 1)
                {
                    return default(T);
                }

                var node = this.Walk(position);
                return node == null ? default(T) : node.Data;
            }
        }

        /// <summary>
        /// Add data to the list
        /// </summary>
        /// <param name="data">data to be added</param>
        public void Add(T data)
        {
            var node = new LinkedListNode<T>(data);
            if(this.isEmpty())
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                this.tail = node;
            }

            this.size++;
        }

        /// <summary>
        /// Remove data in the specified position
        /// </summary>
        /// <param name="position">position to remove</param>
        /// <returns>success boolean</returns>
        public bool Remove(int position)
        {
            if(position == 0)
            {
                this.head = this.head.Next;
                this.size--;
                return true;
            }

            var previous = this.Walk(position - 1);
            if(previous == null)
            {
                return false;
            }

            var selected = previous.Next;
            if(selected == null)
            {
                return false;
            }

            previous.Next = selected.Next;
            this.size--;
            if(selected == this.tail)
            {
                this.tail = previous;
            }

            return true;
        }

        private LinkedListNode<T> Walk(int steps)
        {
            var selected = this.head;

            var count = 0;
            while (count < steps && selected != null)
            {
                selected = selected.Next;
                count++;
            }

            return selected;
        }

        private bool isEmpty()
        {
            return this.head == null;
        }

        public override string ToString()
        {
            var stringBuilder = string.Empty;

            if(this.isEmpty())
            {
                return "[]";
            }

            var selected = this.head;
            for (int i = 0; i < this.size - 1; i++)
            {
                stringBuilder += string.Format("{0}, ", selected.Data.ToString());
                selected = selected.Next;
            }

            stringBuilder += selected.Data.ToString();
            return "[" + stringBuilder + "]";
        }

        public static void Test()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Console.WriteLine(list);

            Console.WriteLine(list[0]);
            Console.WriteLine(list[3]);
            Console.WriteLine(list[4]);
            Console.WriteLine(list[10]);
            
            list.Remove(4);
            list.Remove(0);
            list.Remove(2);
            Console.WriteLine(list);
            Console.WriteLine(list[0]);

            Console.Read();
        }

        public LinkedListEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this.head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class LinkedListEnumerator<T> : System.Collections.Generic.IEnumerator<T>
    {
        private LinkedListNode<T> current;
        private LinkedListNode<T> head;

        public LinkedListEnumerator(LinkedListNode<T> head)
        {
            this.head = head;
            this.current = new LinkedListNode<T>(default(T))
            {
                Next = this.head
            };
        }

        public T Current
        {
            get
            {
                // undefined behavior:
                // current is positioned after the tail
                // current is positioned before the head
                if (this.current == null)
                {
                    return default(T);
                }

                if (this.current.Next == this.head)
                {
                    return default(T);
                }

                return this.current.Data;
            }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if(this.current == null || this.current.Next == null)
            {
                return false;
            }

            this.current = this.current.Next;
            return true;
        }

        public void Reset()
        {
            this.current = new LinkedListNode<T>(default(T))
            {
                Next = this.head
            };
        }
    }
}
