namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4; 
        private T[] items;
        private int index = 0;

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
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;

                return; 
            }
        }

        public int Count => this.items.Length;

        public void Add(T item)
        {
            if (index == items.Length)
            {
                var newArr = new T[items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {
                    newArr[i] = items[i];
                }

                this.items = newArr;
            }
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => throw new NotImplementedException();
    }
}