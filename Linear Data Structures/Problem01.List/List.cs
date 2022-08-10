﻿using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4; 
        private T[] items;
        private int elements;


        public List()
            : this(DEFAULT_CAPACITY) 
        {
            this.items = new T[DEFAULT_CAPACITY];
            this.elements = 0;
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this.items = new T[capacity];
            this.elements = 0;
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNecessary();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            foreach (var t in this.items)
            {
                if (t.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            var elementIndex = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    elementIndex = i;
                    return elementIndex;
                }
            }

            return elementIndex;
        }

        public void Insert(int index, T item)
        {
          this.ValidateIndex(index);
          this.GrowIfNecessary();

          for (int i = this.Count; i > index; i--)
          {
              this.items[i] = this.items[i - 1];

          }

          this.items[index] = item;
          this.elements++;


        }

        public bool Remove(T item)
        {
            int indexToRemove = 0;
            var isPresented = false;

            for (int i = 0; i < this.items.Length; i++)
            {
                var currentElement = this.items[i];
                if (currentElement.Equals(item))
                {
                    indexToRemove = i;
                    isPresented = true;
                }
            }

            if (isPresented)
            {
                this.items = this.items.Where((source, index) => index != indexToRemove).ToArray();
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
           this.ValidateIndex(index);

           for (int i = 0; i < this.Count - 1; i++)
           {
                this.items[i] = this.items[i + 1];
           }

           this.items[this.Count - 1] = default;
           this.elements--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();




        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private T[] Grow()
        {
            var newArray = new T[this.items.Length * 2];
            Array.Copy(this.items,newArray,this.items.Length);
            return newArray;
        }

        private void GrowIfNecessary()
        {
            if (this.Count == this.items.Length)
            {
                this.items = this.Grow();
            }
        }

    }
}