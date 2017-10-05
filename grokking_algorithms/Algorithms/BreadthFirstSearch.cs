using System;
using System.Collections.Generic;

namespace Algorithms
{
    static class BreadthFirstSearch
    {
        /// <summary>
        /// Returns true if there is exists path from the initial to the target in the graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="initial"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool PathExists(Dictionary<string, LinkedList<string>> graph, string initial, string target)
        {
            var search_queue = new Queue<string>(); // Queue that will contain the nodes we are searching
            var searched = new HashSet<string>(); // List that will contain the nodes that we have searched

            // initial the search_queue
            search_queue.Enqueue(initial);

            // While the search queue is not empty
            while(search_queue.Count != 0)
            {
                // Pop the next node off the search queue
                var selected = search_queue.Dequeue();

                // Check to see if it is the target
                if(selected == target)
                {
                    return true;
                }

                // Add all of its connections unless we have already checked it before or it's not in our graph at all
                if (!searched.Contains(selected) && graph.ContainsKey(selected))
                {
                    foreach (var connection in graph[selected])
                    {
                        search_queue.Enqueue(connection);
                    }
                }

                // Add the node we just checked to our list of searched nodes.
                searched.Add(selected);
            }

            return false;
        }

        /// <summary>
        /// Returns the shortest path from the initial to the target if a path exists in the unweighted graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="initial"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int ShortestPath(Dictionary<string, LinkedList<string>> graph, string initial, string target)
        {
            var searched = new HashSet<string>(); // List that will contain the nodes that we have searched
            var distance = 0;
            
            searched.Add(initial);
            if (initial == target)
            {
                return distance;
            }

            var sum = 0;
            if(graph.ContainsKey(initial))
            {
                foreach (var connection in graph[initial])
                {
                    if (!searched.Contains(connection))
                    {
                        sum += _ShortestPath(graph, connection, target, distance + 1, searched);
                    }
                }
            }

            if(sum == 0)
            {
                return -1;
            }
            else
            {
                return sum;
            }
        }

        private static int _ShortestPath(Dictionary<string, LinkedList<string>> graph, string initial, string target, int distance, HashSet<string> searched)
        {
            searched.Add(initial);
            if (initial == target)
            {
                return distance;
            }

            var sum = 0;
            if (graph.ContainsKey(initial))
            {
                foreach (var connection in graph[initial])
                {
                    if (!searched.Contains(connection))
                    {
                        sum += _ShortestPath(graph, connection, target, distance + 1, searched);
                    }
                }
            }

            return sum;
        }

        public static void Test1()
        {
            var graph = new Dictionary<string, LinkedList<string>>();

            var you = new LinkedList<string>();
            you.AddLast("alice");
            you.AddLast("bob");
            you.AddLast("claire");

            var bob = new LinkedList<string>();
            bob.AddLast("anuj");
            bob.AddLast("peggy");

            var alice = new LinkedList<string>();
            alice.AddLast("peggy");

            var claire = new LinkedList<string>();
            claire.AddLast("thom");

            graph.Add("you", you);
            graph.Add("bob", bob);
            graph.Add("alice", alice);
            graph.Add("claire", claire);

            Console.Write(BreadthFirstSearch.PathExists(graph, "you", "anuj"));
            Console.Read();
        }

        public static void Test2()
        {
            var graph = new Dictionary<string, LinkedList<string>>();

            var you = new LinkedList<string>();
            you.AddLast("alice");
            you.AddLast("bob");

            var bob = new LinkedList<string>();
            bob.AddLast("anuj");
            bob.AddLast("peggy");

            var alice = new LinkedList<string>();
            alice.AddLast("peggy");

            var claire = new LinkedList<string>();
            claire.AddLast("thom");

            graph.Add("you", you);
            graph.Add("bob", bob);
            graph.Add("alice", alice);
            graph.Add("claire", claire);

            Console.Write(BreadthFirstSearch.ShortestPath(graph, "you", "thom"));
            Console.Read();
        }
    }
}
