using System.IO.Compression;
using System.Linq;

namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4; 
        private T[] items;
        private int arrIndex = 0;

        public List()
            : this(DEFAULT_CAPACITY) 
        {
            this.items = new T[DEFAULT_CAPACITY];
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get => this.items[index];
            set
            {
                if (this.arrIndex > this.items.Length)
                {
                    throw new IndexOutOfRangeException("Index was outside of the range!");
                }
                this.items[index] = value;

                return; 
            }
        }

        public int Count => this.items.Length;

        public void Add(T item)
        {
            if (this.arrIndex == this.items.Length)
            {
                var newArr = new T[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    newArr[i] = this.items[i];
                }

                this.items = newArr;
            }

            this.items[arrIndex] = item;
            this.arrIndex++;
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

            for (int i = 0; i < this.items.Length; i++)
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
            throw new NotImplementedException();
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
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index > this.items.Length - 1)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }

            T[] newArray = new T[this.items.Length];

            var newArrIndex = 0;

            for (int i = 0; i < this.items.Length; i++)
            {
                if (i == index)
                {
                    continue;
                    ;
                }
                newArray[newArrIndex] = this.items[i];
                newArrIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => throw new NotImplementedException();
    }
}