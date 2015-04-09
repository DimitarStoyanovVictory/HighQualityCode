namespace DataStructures
{
    using System;

    public class CustomStack<T>
    {
        private const int DefaultStackCapacity = 4;

        private T[] elements;
        private int currentIndex;

        public CustomStack(int capacity = DefaultStackCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }
        }

        public void Push(T item)
        {
            if (this.currentIndex == this.elements.Length)
            {
                this.Resize();
            }

            this.elements[currentIndex] = item;
            this.currentIndex++;
        }

        public T Pop()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            var element = this.elements[currentIndex - 1];
            this.elements[currentIndex - 1] = default(T);
            this.currentIndex--;

            return element;
        }

        public T Peek()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return this.elements[currentIndex - 1];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        private void Resize()
        {
            T[] newElements = new T[this.currentIndex * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}
