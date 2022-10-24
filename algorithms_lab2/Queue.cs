using System;
namespace algorithms_lab2
{
    public class Queue<T>
    {
        MyList<T> queueElem = new MyList<T>();

        public void QueueAdd(T i)
        {
            queueElem.Add(i);
        }

        public void IsEmpty()
        {
            if (queueElem.Count() == 0)
            {
                Console.WriteLine("Очередь пуста!");
            }
            else
            {
                Console.WriteLine("В очереди есть элементы!");
            }
        }

        public void Pop()
        {
            queueElem.RemoveAt(0);
        }

        public void QueueDelElem(int i)
        {
            queueElem.RemoveAt(i);
        }

        public void PrintQueue()
        {
            foreach (var elem in queueElem)
            {
                Console.WriteLine(elem);
            }
        }

        public void PrintFirst()
        {
            queueElem.Print(0);
        }
    }
}

