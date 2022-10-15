using System;
namespace algorithms_lab2
{
    public class ListItem<T>
    {
        public T Data { get; private set; }
        public ListItem<T> Next { get; set; }
        public ListItem<T> Prev { get; set; }

        public ListItem(T data)
        {
            Data = data;
        }
        public void ClearLinks()
        {
            Next = null;
            Prev = null;
        }
    }
}

