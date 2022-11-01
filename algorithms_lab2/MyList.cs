using System;
using System.Collections;

namespace algorithms_lab2
{
    public class MyList<T> : IEnumerable<T>
    {
        private ListItem<T> Head;
        private ListItem<T> Tail;
        public int Length { get; private set; }

        //public MyList(params T[] list)
        //{
        //    Length = list.Length;
        //    if(list.Length > 2)
        //    {
        //        Head = new ListItem<T>(list[0]);
        //        ListItem<T> temp = new ListItem<T>(list[1]);
                
        //        temp.Prev = Head;
        //        Head.Next = temp;

        //        for (int i = 2; i < list.Length; i++)
        //        {
        //            ListItem<T> item = new ListItem<T>(list[i]);
        //            item.Prev = temp;
        //            temp.Next = item;
        //            temp = item;
        //        }
        //        Tail = temp;
        //    }
        //    else if(list.Length == 2)
        //    {
        //        Head = new ListItem<T>(list[0]);
        //        Tail = new ListItem<T>(list[1]);
        //        Head.Next = Tail;
        //        Tail.Prev = Head;
        //    }
        //    else
        //    {
        //        Head = new ListItem<T>(list[0]);
        //        Tail = Head;
        //    }
        //}

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
            ListItem<T> current = Head;
            ListItem<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    Length--;
                }
                previous = current;
                current = current.Next;
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
        public void AddAt(int index, T data)
        {
            var current = Head;
            var count = 0;

            while(current != null)
            {
                if(count == index)
                {
                    
                }
                current = current.Next;
            }
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
        public void Print(int index)
        {
            var current = Head;
            while (current != null)
            {
                if(index == 0)
                {
                    Console.WriteLine(current.Data);
                }

                index--;
                current = current.Next;
            }
        }
        public void Print()
        {
            var current = Head;
            while (current != null)
            {
                if (current == Tail)
                {
                    Console.WriteLine(current.Data);
                }
                else
                {
                    Console.Write(current.Data + ", ");
                }

                current = current.Next;
            }
        }

        //методы для лабы
        public MyList<T> Reverse()
        {
            MyList<T> newList = new MyList<T>();
            ListItem<T> current1 = Tail;

            while(current1 != null)
            {
                newList.Add(current1.Data);
                current1 = current1.Prev;
            }

            return newList;
        }                                          // 1
        public void LastToHead()
        {
            var temp = Tail;

            Tail = Tail.Prev;
            Tail.Next = null;

            temp.Next = Head;
            Head = temp;
        }                                            // 2
        public void FirstToTail()
        {
            var temp = Head;

            Head = Head.Next;
            Head.Prev = null;

            var tempTail = Tail;
            Tail = temp;

            tempTail.Next = temp;
            temp.Prev = tempTail;
            temp.Next = null;
        }                                           // 2
        public int GetUnicValuesCount()
        {
            var unicValues = GetUnicValues();

            return unicValues.Length;
        }                                     // 3
        public bool RemoveDuplicateElement(T data) 
        {
            bool flag = false; 

            ListItem<T> current = Head;
            ListItem<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data) && flag)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    Length--;
                    return true;
                }

                if (current.Data.Equals(data) && !flag)
                {
                    flag = true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }                         // 4
        public void InsertThisListAfterX(T x) 
        {
            ListItem<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(x))
                {
                    var before = current.Next;
                    ListItem<T> node = new ListItem<T>(Head.Data);

                    var lastSize = Length;

                    MyList<T> buf = new MyList<T>(); 
                    var headBuf = buf.Head;
                    buf.Add(node.Data);
                    var currentNew = Head.Next;

                    while (currentNew != null)
                    {
                        buf.Add(currentNew.Data);
                        currentNew = currentNew.Next;
                    }

                    var currentBuf = buf.Head;

                    while (currentBuf != null)
                    {
                        current.Next = currentBuf;
                        current = current.Next;
                        currentBuf = currentBuf.Next;
                    }

                    Length += lastSize;
                    current.Next = before;
                    return;
                }
                current = current.Next;
            }
        }                              // 5
        public void InsertElementByOrder(T data)
        {
            if (Length == 1)
            {
                if (Convert.ToInt32(Head.Data) < Convert.ToInt32(data))
                {
                    Add(data);
                }
                else
                {
                    AddFirst(data);
                }
                return;
            }

            if (Convert.ToInt32(Head.Data) > Convert.ToInt32(data))
            {
                AddFirst(data);
                return;
            }

            if (Convert.ToInt32(Tail.Data) < Convert.ToInt32(data))
            {
                Add(data);
                return;
            }


            ListItem<T> current = Head.Next;
            ListItem<T> previous = Head;

            while (current != null)
            {
                if (Convert.ToInt32(current.Data) > Convert.ToInt32(data) && Convert.ToInt32(previous.Data) < Convert.ToInt32(data))
                {
                    ListItem<T> node = new ListItem<T>(data);
                    node.Next = current;
                    previous.Next = node;
                    Length++;
                    return;
                }

                previous = current;
                current = current.Next;

            }
        }                            // 6
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
                    Length--;
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
                    Length++;
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

                Length++;
            }
            
        }                                    // 9
        public MyList<T>[] SplitByX(T x)
        {
            if(Head.Data.Equals(x))
            {
                MyList<T>[] res = new MyList<T>[1];
                MyList<T> l = new MyList<T>();
                var cur = Head;
                while(cur != null)
                {
                    l.Add(cur.Data);
                    cur = cur.Next;
                }
                res[0] = l;
                return res;
            }
            var current = Head;
            while(current != null)
            {
                if (current.Data.Equals(x))
                    break;
                current = current.Next;
            }

            MyList<T> list2 = new MyList<T>();
            MyList<T>[] twoLists = new MyList<T>[2];


            if (current != null && current.Prev != null)
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
        }                                    // 10
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
                current1 = current1.Next;
            }
            while (current2 != null)
            {
                if (current2.Data.Equals(y))
                    break;
                current2 = current2.Next;
            }

            var temp = current1.Data;
            current1.Data = current2.Data;
            current2.Data = temp;
        }                                          // 12


        public MyList<T> GetUnicValues()
        {
            var current = Head;
            var unicValues = new MyList<T>();
            unicValues.Add(current.Data);
            

            while (current != null)
            {
                bool flag = false;

                foreach (var e in unicValues)
                {
                    if (current.Data.Equals(e))
                        flag = !flag;
                }

                if (!flag)
                    unicValues.Add(current.Data);

                current = current.Next;
            }
            return unicValues;
        }

        public void Subctract(MyList<T> B)
        {
            foreach (var bEl in B)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(bEl))
                        Remove(current.Data);

                    current = current.Next;
                }
            }
        }                                  // method for task3

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

