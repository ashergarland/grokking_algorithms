using grokking_algorithms.DataStructures.Node;
using System.Collections;
using System.Collections.Generic;
using System;

namespace grokking_algorithms.DataStructures.Graph
{
    public class GraphBreadthEnumerator<T> : IEnumerator<Node<T>>, IEnumerable
    {
        private UndirectedUnweightedHashTableGraph<T> graph;
        private Queue<Node<T>> searchQueue;
        private LinkedList<Node<T>> visited;
        private Node<T> initial;
        private Node<T> curNode;

        public GraphBreadthEnumerator(UndirectedUnweightedHashTableGraph<T> graph, Node<T> initial)
        {
            this.graph = graph;
            this.initial = initial;
            this.Reset();
        }

        public Node<T> Current => this.curNode;

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (this.searchQueue.Count == 0)
            {
                return false;
            }

            this.curNode = this.searchQueue.Dequeue();
            this.visited.AddLast(this.curNode);

            var edges = this.graph.GetEdges(this.curNode);
            foreach (var node in edges)
            {
                if(!this.visited.Contains(node))
                {
                    this.searchQueue.Enqueue(node);
                }
            }

            return true;
        }

        public void Reset()
        {
            this.searchQueue = new Queue<Node<T>>();
            this.visited = new LinkedList<Node<T>>();
            this.curNode = default(Node<T>);

            this.searchQueue.Enqueue(this.initial);
        }

        public GraphBreadthEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}