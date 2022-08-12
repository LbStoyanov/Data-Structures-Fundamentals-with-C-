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
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            return this.Head.Element;
        }

        public T GetLast()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            return this.Tail.Element;
            
        }

        public T RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.Head;
            this.Head = oldHead.Next;
            this.Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (this.Tail == null)
            {
                throw new InvalidOperationException();
            }

            var oldTail = this.Tail;
            this.Tail = oldTail.Previous;
            this.Count--;
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