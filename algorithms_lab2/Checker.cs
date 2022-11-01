using System;
using System.Diagnostics;
using System.Text;

namespace algorithms_lab2
{
    public class Checker
    {
        public void MemoryChecking(string fileName, string path)
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();
            string[] file = FileRead(path);

            for (int i = 0; i < file.Length; i += 10)
            {
                WorkForQueue(new ArraySegment<string>(file, 1, i));
                sb.Append($"{i};{(Process.GetCurrentProcess().WorkingSet64)}");
                list.Add(sb.ToString());
                sb.Clear();
            }

            File.WriteAllLines($"{fileName}.csv", list);
        }

        public string[] FileRead(string path)
        {
            return File.ReadAllText(path).Split(" ");
        }

        public static void CreateStackData()
        {
            MyStack<string> s = new MyStack<string>();
            for (int i = 0; i < 10; i++)
            {
                s.Push($"{i}");
            }

            StringBuilder data = new StringBuilder(" 3 1,7 2 5 4 ");
            StringBuilder value = new StringBuilder("3 1,7 2 5 4 ");
            for (int i = 0; i < 10000; i++)
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
            var arr = temp.Trim().Split(' ');

            long timeInMicroSeconds = MeasureTime(arr, s);

            using (StreamWriter sw = new StreamWriter("stackMeasures.csv", true))
            {
                sw.WriteLine($"{arr.Length}; {timeInMicroSeconds}");
            }
        }
        private static long MeasureTime(string[] arr, MyStack<string> s)
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

            StringBuilder data = new StringBuilder(" 3 1,7 2 5 4 ");
            StringBuilder value = new StringBuilder("3 1,7 2 5 4 ");
            for (int i = 0; i < 10000; i++)
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
            var arr = temp.Trim().Split(' ');

            long timeInMicroSeconds = MeasureTime(arr, q);

            using (StreamWriter sw = new StreamWriter("queueMeasures.csv", true))
            {
                sw.WriteLine($"{arr.Length}; {timeInMicroSeconds}");
            }
        }
        private static long MeasureTime(string[] arr, MyQueue<string> q)
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

