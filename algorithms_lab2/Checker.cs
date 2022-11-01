using System;
using System.Diagnostics;
using System.Text;

namespace algorithms_lab2
{
    public class Checker
    {
        private const int N = 100000;
        
        public static void CreateStackData()
        {
            MyStack<string> s = new MyStack<string>();
            for (int i = 0; i < 10; i++)
            {
                s.Push($"{i}");
            }

            StringBuilder data = new StringBuilder(" 1,7 3 2 4 5 ");
            StringBuilder value = new StringBuilder("1,7 3 2 4 5 ");
            for (int i = 0; i < N; i++)
            {
                RunStackTask(s, data.ToString());
                data.Append(value);
            }
        }                                   //stackTask
        private static void RunStackTask(MyStack<string> s, string data)
        {
            string temp;

            using (StreamWriter sw = new StreamWriter("stack.txt", false))
            {
                sw.Write(data);
            }
            using (StreamReader sr = new StreamReader("stack.txt"))
            {
                temp = sr.ReadLine();
            }
            var operations = temp.Trim().Split(' ');
            long memory;
            long timeInMicroSeconds = MeasureTime(operations, out memory, s);

            using (StreamWriter sw = new StreamWriter("stackTimeMeasures.csv", true))
            {
                sw.WriteLine($"{operations.Length}; {timeInMicroSeconds}");
            }
            using (StreamWriter sw = new StreamWriter("stackMemoryMeasures.csv", true))
            {
                sw.WriteLine($"{operations.Length}; {memory}");
            }

        }
        private static long MeasureTime(string[] arr, out long memory, MyStack<string> s)
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            foreach (var el in arr)
            {
                CalculateOperation(s, el);
            }
            sw.Stop();
            var ticks = sw.ElapsedTicks;
            var microSeconds = ticks / 10;
            memory = Process.GetCurrentProcess().WorkingSet64;

            return microSeconds;
        }
        private static void CalculateOperation(MyStack<string> s, string operation)
        {
            if (operation.Contains(','))
            {
                var value = operation.Split(',')[1];
                s.Push(value);
            }
            else
            {
                switch (operation)
                {
                    case "2":
                        s.Pop();
                        break;
                    case "3":
                        s.Top();
                        break;
                    case "4":
                        s.IsEmpty();
                        break;
                    case "5":
                        s.Print();
                        break;
                }
            }
        }



        public static void CreateQueueData()
        {
            MyQueue<string> q = new MyQueue<string>();
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue($"{i}");
            }

            StringBuilder data = new StringBuilder(" 1,7 3 2 4 5 ");
            StringBuilder value = new StringBuilder("1,7 3 2 4 5 ");
            for (int i = 0; i < N; i++)
            {
                RunQueueTask(q, data.ToString());
                data.Append(value);
            }
        }                                   //queueTask
        private static void RunQueueTask(MyQueue<string> q, string data)
        {
            string temp;

            using (StreamWriter sw = new StreamWriter("queue.txt", false))
            {
                sw.Write(data);
            }
            using (StreamReader sr = new StreamReader("queue.txt"))
            {
                temp = sr.ReadLine();
            }
            var operations = temp.Trim().Split(' ');
            long memory;
            long timeInMicroSeconds = MeasureTime(operations, out memory, q);

            using (StreamWriter sw = new StreamWriter("queueTimeMeasures.csv", true))
            {
                sw.WriteLine($"{operations.Length}; {timeInMicroSeconds}");
            }
            using (StreamWriter sw = new StreamWriter("queueMemoryMeasures.csv", true))
            {
                sw.WriteLine($"{operations.Length}; {memory}");
            }
        }
        private static long MeasureTime(string[] arr, out long memory, MyQueue<string> q)
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            foreach (var el in arr)
            {
                CalculateOperation(q, el);
            }
            sw.Stop();
            var ticks = sw.ElapsedTicks;
            var microSeconds = ticks / 10;
            memory = Process.GetCurrentProcess().WorkingSet64;

            return microSeconds;
        }
        private static void CalculateOperation(MyQueue<string> q, string operation)
        {
            if (operation.Contains(','))
            {
                var value = operation.Split(',')[1];
                q.Enqueue(value);
            }
            else
            {
                switch (operation)
                {
                    case "2":
                        q.Dequeue();
                        break;
                    case "3":
                        q.Peek();
                        break;
                    case "4":
                        var flag = q.IsEmpty;
                        break;
                    case "5":
                        q.Show();
                        break;
                }
            }
        }
    }
}

