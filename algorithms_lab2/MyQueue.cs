using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms_lab2
{
    public class MyQueue<T> //: IEnumerable<T>
    {
        private ListItem<T> tail = null;
        private ListItem<T> head = null;

        public int Count { get; private set; } = 0;

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public T Peek()
        {
            if (head == null) return default(T);
            return head.Data;
        }

        public T? Dequeue()
        {
            if (head == null)
            {
                return default(T);
            }
            var temp = head.Data;
            head = head.Next;
            if (head == null) tail = null;
            Count--;

            return temp;
        }

        public void Show()
        {
            for (ListItem<T> node = head; node != null; node = node.Next)
                Console.Write(node.Data + ", ");
        }

        public void Enqueue(T item)
        {
            ListItem<T> node = new ListItem<T>(item);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        /*public IEnumerator<T> GetEnumerator()
        {
            while (!IsEmpty)
            {
                var item = Peek();
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }*/
    }
}
