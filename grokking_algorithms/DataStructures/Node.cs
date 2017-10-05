namespace DataStructures
{
    public class Node<T>
    {
        public T Data { get; private set; }
        public Node<T> Next { get; set;  }

        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
        }

        public override string ToString()
        {
            var next = this.Next == null ? "Null" : this.Next.ToString();
            return string.Format("{ Data: {0}, Next: {1} }", this.Data, next);
        }
    }
}
