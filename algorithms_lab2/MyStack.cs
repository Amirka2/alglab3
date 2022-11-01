using System;
using System.Collections;

namespace algorithms_lab2
{
    public class MyStack<T> : IEnumerable<T>
    {
        ListItem<T> Head;
        int count;

        public MyStack()
        {
        }

        public bool IsEmpty()
        {
            return count == 0;
        }
        public int Count()
        {
            return count;
        }

        public void Push(T data)
        {
            ListItem<T> item = new ListItem<T>(data);
            item.Next = Head;
            Head = item;
            count++;
        }
        public T Pop()
        {
            if (count == 0)
                Console.WriteLine("stack is empty");

            var temp = Head.Data;
            Head = Head.Next;
            count--;

            return temp;
        }
        public T Top()
        {
            if (count == 0)
                Console.WriteLine("stack is empty");

            return Head.Data;
        }
        public void Print()
        {
            var current = Head;
            while(current != null)
            {
                Console.Write(current.Data + ", ");

                current = current.Next;
            }
            Console.WriteLine();
        }

        public MyList<T> ToList()
        {
            MyList<T> list = new MyList<T>();
            var current = Head;
            while (current != null)
            {
                list.Add(current.Data);

                current = current.Next;
            }

            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            ListItem<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

