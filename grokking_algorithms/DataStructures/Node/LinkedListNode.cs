namespace grokking_algorithms.DataStructures.Node
{
    public class LinkedListNode<T> : Node<T>
    {
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode(T data) : base(data)
        {
        }
    }
}
