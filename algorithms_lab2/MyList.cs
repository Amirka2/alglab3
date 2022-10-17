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
        }                                               // 1
        public void LastToHead()
        {
            var temp = Tail;
            temp.ClearLinks();

            Tail = Tail.Prev;
            Tail.Next = null;

            temp.Next = Head;
            Head = temp;
        }                                            // 2
        public void FirstToTail()
        {
            var temp = Head;
            temp.ClearLinks();

            Head = Head.Next;
            Head.Prev = null;

            temp.Prev = Tail;
            Tail = temp;
        }                                           // 2
        public int GetUnicValuesCount()
        {
            var unicValues = GetUnicValues();

            return unicValues.Length;
        }                                     // 3
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
        }                             // 4
        public void InsertThisListAfterX(T x)
        {
            var currentX = Head;
            while(currentX != null)
            {
                if (currentX.Data.Equals(x))
                    break;
                currentX = currentX.Next;
            }

            var current1 = Head;
            for (int i = 0; i < Length; i++)
            {
                currentX.Next = new ListItem<T>(current1.Data);
                currentX.Next.Prev = currentX;

                currentX = currentX.Next;
                current1 = current1.Next;
            }
            //for (int i = 0; )
        }// fix needed 5
        public static MyList<T> InsertElementByOrder(MyList<T> list, T data)
        {
            var current = list.Head;
            var element = new ListItem<T>(data);
            while(current != null)
            {
                //if (Int32.Parse(current.Data) > element.Data)
                    break;
            }
            return new MyList<T>();
        }// 6
        public void DeleteEveryX(T x)
        {
            var current = Head;
            while(current != null)
            {
                if(current.Data.Equals(x))
                {
                    if(current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                        if (current.Next == null)
                            Tail = current.Prev;
                    }
                    if(current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                        if (current.Prev == null)
                            Head = current.Next;
                    }
                }

                current = current.Next;
            }
        }                                       // 7
        public void InsertXBeforeY(T x, T y)
        {
            var current = Head;
            while(current != null)
            {
                if (current.Data.Equals(y))
                {
                    if (current.Prev == null)
                    {
                        AddFirst(x);
                    }
                    else
                    {
                        var item = new ListItem<T>(x);
                        current.Prev.Next = item;
                        current.Prev = item;

                        item.Prev = current.Prev.Next;
                        item.Next = current;
                    }
                }
                current = current.Next;
            }
        }                                // 8
        public void AddList(MyList<T> e)
        {
            var current1 = Tail;
            var current2 = e.Head;

            while(current2 != null)
            {
                if(current2.Next == null)
                {
                    Tail = current2;
                }
                current1.Next = current2;
                current2.Prev = current1;

                current1 = current1.Next;
                current2 = current2.Next;
            }
            
        }                                    // 9
        public MyList<T>[] SplitByX(T x)
        {
            var current = Head;
            while(current != null)
            {
                if (current.Data.Equals(x))
                    break;
                current = current.Next;
            }

            MyList<T> list2 = new MyList<T>();
            MyList<T>[] twoLists = new MyList<T>[2];

            if (current != null)
            {
                Tail = current.Prev;
                Tail.Next = null;

                while(current != null)
                {
                    list2.Add(current.Data);
                    current = current.Next;
                }
                MyList<T> list1 = new MyList<T>();
                var current1 = Head;
                while(current1 != null)
                {
                    list1.Add(current1.Data);
                    current1 = current1.Next;
                }

                twoLists[0] = list1;
                twoLists[1] = list2;
            }

            return twoLists;
        }                                       // 10
        public void InsertThisListToEnd()
        {
            var count = Length;
            var current = Head;
            while(count > 0)
            {
                Add(current.Data);
                count--;
                current = current.Next;
            }
        }                                   // 11
        public void Swap(T x, T y)
        {
            if (!Contains(x) || !Contains(y))
                return;

            var current1 = Head;
            var current2 = Head;

            while(current1 != null)
            {
                if (current1.Data.Equals(x))
                    break;
            }
            while (current2 != null)
            {
                if (current2.Data.Equals(y))
                    break;
            }

            if (current1.Prev == null)
                Head = current2;
            else if (current1.Next == null)
                Tail = current2;
            if (current2.Prev == null)
                Head = current1;
            else if (current2.Next == null)
                Tail = current1;

            var temp = new ListItem<T>(current1.Data);
            temp.Prev = current1.Prev;
            temp.Next = current1.Next;

            current1 = current2;

            current2 = temp;
        }//need fix


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

