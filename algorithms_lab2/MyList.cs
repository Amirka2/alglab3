using System;
using System.Collections;

namespace algorithms_lab2
{
    public class MyList<T> : IEnumerable<T>
    {
        private ListItem<T> Head;
        private ListItem<T> Tail;
        public int Length { get; private set; }

        public MyList(params T[] list)
        {
            Length = list.Length;
            if(list.Length > 2)
            {
                Head = new ListItem<T>(list[0]);
                ListItem<T> temp = new ListItem<T>(list[1]);
                
                temp.Prev = Head;
                Head.Next = temp;

                for (int i = 2; i < list.Length; i++)
                {
                    ListItem<T> item = new ListItem<T>(list[i]);
                    item.Prev = temp;
                    temp.Next = item;
                    temp = item;
                }
                Tail = temp;
            }
            else if(list.Length == 2)
            {
                Head = new ListItem<T>(list[0]);
                Tail = new ListItem<T>(list[1]);
                Head.Next = Tail;
                Tail.Prev = Head;
            }
            else
            {
                Head = new ListItem<T>(list[0]);
                Tail = Head;
            }
        }

        public MyList()
        {
        }

        public void Add(T data)
        {
            ListItem<T> el = new ListItem<T>(data);

            if(Head == null)
            {
                Head = el;
            }
            else
            {
                Tail.Next = el;
                el.Prev = Tail;
            }
            Tail = el;
            Length++;
        }
        public void AddFirst(T data)
        {
            ListItem<T> el = new ListItem<T>(data);

            if(Head != null)
            {
                Head.Prev = el;
                el.Next = Head;
            }
            
            Head = el;
        }
        public void Remove(T data)
        {
            if (Head == null) return;

            ListItem<T> el = new ListItem<T>(data);
            ListItem<T> current = Head;

            while(current != null)
            {
                if(current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if(current != null)
            {
                if(current.Prev == null)
                {
                    Head.Next.Prev = null;
                    Head = Head.Next;
                }

                if(current.Next == null)
                {
                    Tail.Prev.Next = null;
                    Tail = Tail.Prev;
                }

                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }
        }
        public void RemoveAt(int index)
        {
            if (Length < index + 1)
                return;

            int count = 0;
            var current = Head;

            while(count < index)
            {
                current = current.Next;
                count++;
            }

            Remove(current.Data);
        }
        public bool Contains(T data)
        {
            var current = new ListItem<T>(data);
            while(current != null)
            {
                if (current.Data.Equals(data))
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Length = 0;
        }

        //методы для лабы
        public void Reverse()
        {
            MyList<T> newList = new MyList<T>();
            ListItem<T> current1 = Tail;
            ListItem<T> current2 = new ListItem<T>(current1.Data);

            while(current1 != null)
            {
                newList.Add(current1.Data);
                current1 = current1.Prev;
            }
        }                       
        public void LastToHead()
        {
            var temp = Tail;
            temp.ClearLinks();

            Tail = Tail.Prev;
            Tail.Next = null;

            temp.Next = Head;
            Head = temp;
        }
        public void FirstToTail()
        {
            var temp = Head;
            temp.ClearLinks();

            Head = Head.Next;
            Head.Prev = null;

            temp.Prev = Tail;
            Tail = temp;
        }
        public int GetUnicValuesCount()
        {
            var unicValues = GetUnicValues();

            return unicValues.Length;
        }
        public void DeleteSecondRepeatedValue()
        {
            var unicValues = GetUnicValues();
            var current = Head;

            foreach(var el in unicValues)
            {
                if (current.Data.Equals(el))
                {
                    Remove(current.Data);
                    unicValues.Remove(el);
                }
            }
        }
        

        public MyList<T> GetUnicValues()
        {
            var current = Head;
            var unicValues = new MyList<T>();
            unicValues.Add(current.Data);
            current = current.Next;

            while (current != null)
            {
                foreach (var e in unicValues)
                {
                    if (current.Data.Equals(e))
                        break;
                    else
                        unicValues.Add(current.Data);
                }
            }
            return unicValues;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<T> BackEnumerator()
        {
            ListItem<T> current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Prev;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}

