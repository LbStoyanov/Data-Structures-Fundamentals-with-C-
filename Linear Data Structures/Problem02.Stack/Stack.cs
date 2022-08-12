using Problem04.SinglyLinkedList;

namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {

        public class Node
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

        private Node<T> top;
        private LinkedList<T> linkedList;

        public Stack()
        {
            this.linkedList = new LinkedList<T>();
        }

        public int Count { get {return this.linkedList.Count;} }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            return this.linkedList.First.Value;
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(T item)
        {
            this.linkedList.AddFirst(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
            
    }
}