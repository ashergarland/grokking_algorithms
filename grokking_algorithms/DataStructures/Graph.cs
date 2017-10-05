using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Graph
    {
        private Dictionary<string, LinkedList<string>> hashTable;

        public Graph()
        {
            this.hashTable = new Dictionary<string, LinkedList<string>>();
        }

        public void Add(string key, string value)
        {
            if(key == null)
            {
                return;
            }

            if(this.hashTable.ContainsKey(key))
            {
                this.hashTable[key].AddLast(value);
            }
            else
            {
                this.hashTable[key] = new LinkedList<string>();
                this.hashTable[key].AddLast(value);
            }
        }

        public LinkedList<string> this[string key]
        {
            get
            {
                if(key == null || !this.hashTable.ContainsKey(key))
                {
                    return null;
                }

                return this.hashTable[key];
            }
        }

        public bool BreadthFirstSearch(string initial, out string result, Func<string, bool> comparison)
        {
            var search_queue = new Queue<string>();
            var searched = new HashSet<string>();

            if(!this.hashTable.ContainsKey(initial))
            {
                result = null;
                return false;
            }

            search_queue.Enqueue(this.hashTable[initial]);
            while(!search_queue.isEmpty())
            {
                var item = search_queue.Dequeue();

                if(searched.Contains(item))
                {
                    continue;
                }

                if(comparison(item))
                {
                    result = item;
                    return true;
                }
                else if(this.hashTable.ContainsKey(item))
                {
                    searched.Add(item);
                    search_queue.Enqueue(this.hashTable[item]);
                }
            }

            result = null;
            return false;
        }

        static void Test()
        {
            var graph = new Graph();
            graph.Add("you", "alice");
            graph.Add("you", "bob");
            graph.Add("you", "claire");

            graph.Add("bob", "anuj");
            graph.Add("bob", "peggy");

            graph.Add("alice", "peggy");

            graph.Add("claire", "thom");
            graph.Add("claire", "jonny");

            string result;
            if (graph.BreadthFirstSearch("you", out result, Comparison))
            {
                Console.WriteLine("Success! : " + result);
            }
            else
            {
                Console.WriteLine("failed");
            }

            Console.Read();
        }

        private static bool Comparison(string input)
        {
            if (input == "anuj")
            {
                return true;
            }

            return false;
        }
    }
}
