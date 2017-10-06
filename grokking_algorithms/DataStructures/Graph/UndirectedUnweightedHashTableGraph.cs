using grokking_algorithms.DataStructures.Node;
using System;
using System.Collections;
using System.Collections.Generic;

namespace grokking_algorithms.DataStructures.Graph
{
    public class UndirectedUnweightedHashTableGraph<T>
    {
        private Dictionary<Node<T>, LinkedList<Node<T>>> hashTable;

        public UndirectedUnweightedHashTableGraph()
        {
            this.hashTable = new Dictionary<Node<T>, LinkedList<Node<T>>>();
        }

        /// <summary>
        /// Adds a new node to the graph.
        /// </summary>
        /// <param name="node">Node to be added.</param>
        /// <returns>False if the node already exists. True if successfully added.</returns>
        public bool AddNode(Node<T> node)
        {
            if(hashTable.ContainsKey(node))
            {
                return false;
            }

            hashTable.Add(node, new LinkedList<Node<T>>());
            return true;
        }

        /// <summary>
        /// Adds a new connecting edge between two nodes to the graph
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns>True if connection successfully added. False if both nodes aren't already added, 
        /// or if there is already an edge between the two nodes,
        /// or if the two nodes are the same node</returns>
        public bool AddEdge(Node<T> node1, Node<T> node2)
        {
            // check if nodes are both already added
            if(!hashTable.ContainsKey(node1) || !hashTable.ContainsKey(node1))
            {
                return false;
            }

            // check if edge between nodes already exists
            if(hashTable[node1].Contains(node2) || hashTable[node2].Contains(node1))
            {
                return false;
            }

            // check if the two nodes are the same
            if(node1 == node2)
            {
                return false;
            }

            // add edge
            hashTable[node1].AddLast(node2);
            hashTable[node2].AddLast(node1);
            return true;
        }

        /// <summary>
        /// Adds the node to the graph
        /// </summary>
        /// <param name="node1"></param>
        /// <returns></returns>
        public bool Add(Node<T> node1)
        {
            return this.AddNode(node1);
        }

        /// <summary>
        /// Adds the two nodes and creates a connecting edge on the graph
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public bool Add(Node<T> node1, Node<T> node2)
        {
            this.AddNode(node1);
            this.AddNode(node2);

            return this.AddEdge(node1, node2);
        }

        /// <summary>
        /// Adds all nodes and creates edges connecting them all together
        /// </summary>
        /// <param name="nodes"></param>
        public void Add(params Node<T>[] nodes)
        {
            foreach(var keyNode in nodes)
            {
                this.AddNode(keyNode);
                foreach(var connectingNode in nodes)
                {
                    this.AddNode(connectingNode);
                    this.AddEdge(keyNode, connectingNode);
                }
            }
        }

        /// <summary>
        /// Gets all edge connected nodes for the node provided
        /// </summary>
        /// <param name="node"></param>
        /// <returns>returns list of nodes, or an empty list if not in the graph</returns>
        public LinkedList<Node<T>> GetEdges(Node<T> node)
        {
            if(this.hashTable.ContainsKey(node))
            {
                return this.hashTable[node];
            }

            return new LinkedList<Node<T>>();
        }

        public GraphBreadthEnumerator<T> BreadthEnumerator(Node<T> initial)
        {
            return new GraphBreadthEnumerator<T>(this, initial);
        }

        public override string ToString()
        {
            var strBuilder = "[";

            foreach(var keyValue in this.hashTable)
            {
                strBuilder += keyValue.Key.Data + ": [";
                var count = 0;
                var iterator = keyValue.Value.GetEnumerator();
                while(count < keyValue.Value.Count - 1)
                {
                    count++;
                    iterator.MoveNext();
                    strBuilder += iterator.Current.Data + ",";
                }

                iterator.MoveNext();
                if(iterator.Current != null)
                {
                    strBuilder += iterator.Current.Data;
                }
                
                strBuilder += "]\n";
            }

            return strBuilder + "]";
        }

        public static void Test()
        {
            var graph = new UndirectedUnweightedHashTableGraph<string>();
            var you = new Node<string>("you");
            var alice = new Node<string>("alice");
            var claire = new Node<string>("claire");
            var bob = new Node<string>("bob");
            var anuj = new Node<string>("anuj");
            var peggy = new Node<string>("peggy");
            var thom = new Node<string>("thom");
            var jonny = new Node<string>("jonny");

            graph.Add(you, alice);
            graph.Add(you, bob);
            graph.Add(you, claire);

            graph.Add(bob, anuj);
            graph.Add(bob, peggy);

            graph.Add(alice, peggy);

            graph.Add(claire, thom);
            graph.Add(claire, jonny);

            Console.WriteLine(graph.ToString());
            
            foreach (var node in graph.BreadthEnumerator(you))
            {
                Console.WriteLine(node.Data);
            }

            Console.Read();
        }
    }
}
