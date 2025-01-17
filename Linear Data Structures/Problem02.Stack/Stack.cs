﻿using System.Linq;
using System.Xml;


namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {

        private class Node
        {
            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }
            
            
            public T Element { get; set; }

            public Node Next { get; set; }

        }

        private Node top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var node = this.top;
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
                this.Push(element);
            }

            return isExist;

        }

        public T Peek()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
            return this.top.Element;
        }

        public T Pop()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }

            var oldTop = this.top;
            this.top = oldTop.Next;
            this.Count--;
            return oldTop.Element;
        }

        public void Push(T item)
        {
            var node = new Node(item, this.top);
            this.top = node;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.top;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
            
    }
}