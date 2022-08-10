using System.IO.Compression;
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
            foreach (var element in this.items.Take(this.Count)) //or we can use for i<this.Count
            {
                if (item.Equals(element))
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
                if (item.Equals(this.items[i]))
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
          this.Count++;
            
        }

        public bool Remove(T item)
        {
            int indexToRemove = this.IndexOf(item);


            if (indexToRemove == -1)
            {
                return false;
            }

            this.RemoveAt(indexToRemove);
            return true;

        }

        public void RemoveAt(int index)
        {
           this.ValidateIndex(index);

           for (int i = index; i < this.Count - 1; i++)
           {
                this.items[i] = this.items[i + 1];
           }

           this.items[this.Count - 1] = default;
           this.Count--;

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
            //Array.Copy(this.items,newArray,this.Count);

            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

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