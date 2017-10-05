namespace grokking_algorithms.DataStructures.Node
{
    class LinkedListNode<T> : Node<T>
    {
        public Node<T> Next { get; set; }
        public LinkedListNode(T data) : base(data)
        {
        }
    }
}
