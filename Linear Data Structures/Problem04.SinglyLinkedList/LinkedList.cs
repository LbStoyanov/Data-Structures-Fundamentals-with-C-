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

            if (this.Head == null)
            {
                this.Head = newHead;
                this.Tail = newHead;
            }
            else
            {
                newHead.Next = this.Head;
                this.Head = newHead;
            }
            
            
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
            return this.Head.Element;
        }

        public T GetLast()
        {
            return this.Tail.Element;
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

            return oldHead.Element;

        }

        public T RemoveLast()
        {
            var oldTail = this.Tail;
            this.Tail = oldTail.Previous;

            return oldTail.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var head = this.Head;

            while (head.Next != null)
            {
                yield return head.Element;
                head = head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}