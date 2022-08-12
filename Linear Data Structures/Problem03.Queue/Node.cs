namespace Problem03.Queue
{
    public class Node<T>
    {
        public Node(T element)
        {
            this.Element = element;
        }
        public Node(T element, Node<T> next)
        {
            this.Element = element;
            this.Next = next;
        }


        public T Element { get; set; }

        public Node<T> Next { get; set; }

    }
}