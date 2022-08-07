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
                if (t == item)
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index > this.items.Length)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }

            T[] newArray = new T[this.items.Length];

            for (int i = 0; i < this.items.Length; i++)
            {
                if (i == index)
                {
                    co
                }
                newArray[i] = this.items[i];
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