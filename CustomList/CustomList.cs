using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public delegate void PerformListOperation();

    public delegate void BooleanListOperation(bool result);

    class CustomList
    {
        public event PerformListOperation OnAdd;

        public event PerformListOperation OnRemove;

        public event BooleanListOperation OnContains;

        private int[] array;
        private int currentIndex;

        public CustomList()
        {
            this.array = new int[4];
            this.currentIndex = 0;
        }

        public int this[int index]
        {
            get
            {
                return this.array[index];
            }

            set
            {
                this.array[index] = value;
            }
        }

        public int GetElementByIndex(int index)
        {
            if (index >= 0 && index < this.array.Length)
            {
                return this.array[index];
            }
            else
            {
                throw new IndexOutOfRangeException;
            }
        }

        public void Add(int newElement)
        {
            if (this.currentIndex >= this.array.Length)
            {
                int[] newArray = new int[this.array.Length * 2];
                for (int i = 0; i < this.array.Length; i++)
                {
                    newArray[i] = this.array[i];
                }
                newArray[currentIndex] = newElement;
                this.array = newArray;
                currentIndex++;
            }
            this.array[currentIndex] = newElement;
            currentIndex++;

            if (OnAdd != null)
            {
                OnAdd();
            }
        }

        public bool Remove(int element)
        {
            if (this.Contains(element)) {
                int elementIndex = Array.IndexOf(this.array, element);
                for (int i = elementIndex; i < this.array.Length - 1; i++)
                {
                    this.array[i] = this.array[i + 1];
                }
                currentIndex--;

                if (OnRemove != null)
                {
                    OnRemove();
                }
                return true;
            }
            else
            {
                throw new ArgumentException("The element can not be removed because it does not exist!");
            }

        }

        public bool Contains(int element)
        {
            bool result = false;
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] == element)
                {
                    result = true;
                    break;
                }
            }

            if (OnContains != null)
            {
                OnContains(result);
            }

            return result;
        }
    }
}
