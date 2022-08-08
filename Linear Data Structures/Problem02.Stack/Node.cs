namespace Problem02.Stack
{   
    //Recursive data structure
    public class Node<T>
    {
        private T head;
        private T tail;

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }

       
        public void Add()
        {

        }

        public void Remove()
        {

        }
    }
}