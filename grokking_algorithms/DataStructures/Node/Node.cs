namespace grokking_algorithms.DataStructures.Node
{
    public class Node<T>
    {
        public T Data { get; }
        public Node(T data)
        {
            this.Data = data;
        }
    }
}
