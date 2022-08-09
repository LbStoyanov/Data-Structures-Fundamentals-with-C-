namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>(item);
            newHead.Next = this.Head;

            if (this.Head == null)
            {
                this.Tail = newHead;
            }
            this.Head = newHead;
            
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newTail = new Node<T>(item);

            if (this.Tail == null)
            {
                this.Tail = newTail;
                this.Head = newTail;
            }
            else
            {
                this.Tail.Next = newTail;
                newTail.Previous = this.Tail;
                this.Tail = newTail;
            }

            this.Count++;

        }

        public T GetFirst()
        {
            return this.Head.Value;
        }

        public T GetLast()
        {
            return this.Tail.Value;
        }

        public T RemoveFirst()
        {
            var oldHead = this.Head;
            this.Head = this.Head.Next;

            if (this.Head == null)
            {
                this.Tail = null;
            }

            if (this.Count > 0)
            {
                this.Count--;
            }

            return oldHead.Value;

        }

        public T RemoveLast()
        {
            var oldTail = this.Tail;
            this.Tail = oldTail.Previous;

            return oldTail.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}