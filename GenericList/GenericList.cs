using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList<T> : IEnumerable<T> where T : IComparable // this way the list object can be iterated with foreach
    {
        private T[] array;
        private int currentIndex;

        public GenericList()
        {
            this.array = new T[4];
            this.currentIndex = 0;
        }

        public T this[int index]
        {
            get
            {
                return this.GetElementByIndex(index);
            }

            set
            {
                this.SetElementByIndex(index, value);
            }
        }

        // event; accept one int argument; void
        public event Action<int> OnAddEvent;

        public T GetElementByIndex(int index)
        {
            if (index >= 0 && index < this.array.Length)
            {
                return this.array[index];
            }
            else
            {
                throw new IndexOutOfRangeException(); // Default(T); - return default value of type T
            }
        }

        public void SetElementByIndex(int index, T value)
        {
            if (index >= 0 && index < this.array.Length)
            {
                this.array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(T newElement)
        {
            if (this.currentIndex >= this.array.Length)
            {
                T[] newArray = new T[this.array.Length * 2];
                for (int i = 0; i < this.array.Length; i++)
                {
                    newArray[i] = this.array[i];
                }
                newArray[currentIndex] = newElement;
                this.array = newArray;
                currentIndex++;
            }
            else
            {
                this.array[currentIndex] = newElement;
                currentIndex++;
            }

            if (this.OnAddEvent != null)
            {
                this.OnAddEvent(this.array.Length); // == this.OnAddEvent.invoke();
            }
        }

        public bool Remove(T element)
        {
            if (this.Contains(element))
            {
                int elementIndex = Array.IndexOf(this.array, element);
                for (int i = elementIndex; i < this.array.Length - 1; i++)
                {
                    this.array[i] = this.array[i + 1];
                }
                currentIndex--;

                return true;
            }
            else
            {
                throw new ArgumentException("The element can not be removed because it does not exist!");
            }
        }

        public bool Contains(T element)
        {
            bool result = false;
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i].CompareTo(element) == 0)
                {
                    result = true;
                    break;
                }
            }
        
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
