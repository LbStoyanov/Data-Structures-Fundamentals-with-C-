namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var node = this.head;
            var list = new List<T>();
            bool isExist = false;

            while (node != null)
            {
                list.Add(node.Element);
                if (node.Element.Equals(item))
                {
                    isExist = true;
                }
                node = node.Next;
            }

            this.Count = 0;

            list.Reverse();

            foreach (var element in list)
            {
                this.Enqueue(element);
            }

            return isExist;

        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            this.head = oldHead.Next;

            this.Count--;
            return oldHead.Element;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                var node = this.head;

                while (node != null)
                {
                    node = node.Next;
                }

                node!.Next = newNode;
                this.tail = node.Next;
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            return this.tail.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}