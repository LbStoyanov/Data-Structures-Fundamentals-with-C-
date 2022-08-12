namespace Problem02.Stack
{   
    //Recursive data structure
    public class Node<T>
    {
        private T head;
        private T tail;

        public Node(T value)
        {
            this.Element = value;
        }

        public T Element { get; set; }

        public Node<T> Next { get; set; }
        
    }
}