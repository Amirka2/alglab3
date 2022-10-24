using System;
using System.Diagnostics;
using System.Text;
using algorithms_lab2;

public class Program
{
    public static void Main(String[] args)
    {
        RunListTasks();
    }
    private static void CreateStackData()
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

        string postfix = RPN.ConvertNotation("2 + 2 * 2");
        Console.WriteLine("result = " + RPN.Counting(postfix));
    }//stackTask
    private static void RunStackTask(MyStack<string> s, string data)
    {
        string temp;

        using (StreamWriter sw = new StreamWriter("stack.txt", false))
        {
            sw.Write(data);
        }
        using(StreamReader sr = new StreamReader("stack.txt"))
        {
            temp = sr.ReadLine();
        }
        var arr = temp.Trim().Split(' ');

        long timeInMicroSeconds = MeasureTime(arr, s);

        using(StreamWriter sw = new StreamWriter("stackMeasures.csv", true))
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

    private static void RunListTasks()
    {
        Console.WriteLine("Если хотите закончить, введите '!'");
        var x = "";
        while (x.Trim() != "!")
        {
            Console.Write("Выберите номер из списка задач(1-12): ");
            x = Console.ReadLine();
            switch (x)
            {
                case "1":
                    Run1Task();
                    break;
                case "2":
                    Run2Task();
                    break;
                case "3":
                    Run3Task();
                    break;
                case "4":
                    Run4Task();
                    break;
                case "5":
                    Run5Task();
                    break;
                case "6":
                    Run6Task();
                    break;
                case "7":
                    Run7Task();
                    break;
                case "8":
                    Run8Task();
                    break;
                case "9":
                    Run9Task();
                    break;
                case "10":
                    Run10Task();
                    break;
                case "11":
                    Run11Task();
                    break;
                case "12":
                    Run12Task();
                    break;
                default:
                    Console.WriteLine("Неккоректный ввод!");
                    break;
            }
        }
    }
    private static void Run1Task()
    {
        var list = GetListFromConsole();
        list = list.Reverse();
        Console.Write("Перевернутый список: ");
        list.Print();
    }
    private static void Run2Task()
    {
        var list = GetListFromConsole();
        var list2 = new MyList<int>();
        list2.AddList(list);

        list.LastToHead();
        Console.WriteLine("last to head");
        list.Print();

        list2.FirstToTail();
        Console.WriteLine("first to tail");
        list2.Print();
    }
    private static void Run3Task()
    {
        var list = GetListFromConsole();
        int count = list.GetUnicValuesCount();
        Console.WriteLine("Уникальных значений: " + count);
    }
    private static void Run4Task()
    {
        var list = GetListFromConsole();
        Console.Write("Введите элемент для удаления дубликата: ");
        var x = Int32.Parse(Console.ReadLine());
        var flag = list.RemoveDuplicateElement(x);
        list.Print();
    }
    private static void Run5Task()
    {
        var list = GetListFromConsole();
        Console.Write("Введите число, после которого вставить список сам в себя: ");
        var x = Int32.Parse(Console.ReadLine());

        list.InsertThisListAfterX(x);
        list.Print();
    }
    private static void Run6Task()
    {
        var list = GetListFromConsole("Введите числа по возрастанию через пробел");
        Console.Write("Введите число, которое нужно вставить по возрастанию: ");
        var x = Int32.Parse(Console.ReadLine());

        list.InsertElementByOrder(x);
        list.Print();
    }
    private static void Run7Task()
    {
        var list = GetListFromConsole();
        Console.Write("Введите значение, все вхождения которого нужно удалить из списка: ");
        var x = Int32.Parse(Console.ReadLine());
        list.DeleteEveryX(x);
        list.Print();
    }
    private static void Run8Task()
    {
        var list = GetListFromConsole();
        Console.Write("Введите число(х), которое нужно вставить: ");
        var x = Int32.Parse(Console.ReadLine());

        Console.Write("Введите число(у), перед которым нужно вставить число х: ");
        var y = Int32.Parse(Console.ReadLine());


        list.InsertXBeforeY(x, y);
        list.Print();
    }
    private static void Run9Task()
    {
        string path = "9task.txt";
        MyList<int> list1 = new MyList<int>();
        MyList<int> list2 = new MyList<int>();
        string temp, temp2;

        Console.Write("Введите числа(1 список) через пробел: ");
        var l1 = Console.ReadLine();
        Console.Write("Введите числа(2 список) через пробел: ");
        var l2 = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(path, false))
        {
            sw.WriteLine(l1);
            sw.WriteLine(l2);
        }
        using (StreamReader sr = new StreamReader(path))
        {
            temp = sr.ReadLine();
            temp2 = sr.ReadLine();
        }
        var inputArr1 = temp.Trim().Split(" ");
        var inputArr2 = temp2.Trim().Split(" ");
        foreach (var el in inputArr1)
            list1.Add(Int32.Parse(el));
        foreach (var el in inputArr2)
            list2.Add(Int32.Parse(el));

        list1.AddList(list2);

        Console.WriteLine();

        foreach (var el in list1)
            Console.Write(el + " ");
    }
    private static void Run10Task()
    {
        var list = GetListFromConsole();
        Console.Write("Введите число, по 1 вхождению которого нужно разбить список: ");
        var x = Int32.Parse(Console.ReadLine());

        var lists = list.SplitByX(x);

        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null)
            {
                Console.Write($"{i + 1} список: ");
                lists[i].Print();
            }
        }
    }
    private static void Run11Task()
    {
        var list = GetListFromConsole();
        list.InsertThisListToEnd();
        list.Print();
    }
    private static void Run12Task()
    {
        var list = GetListFromConsole();
        Console.WriteLine("Введите числа, которые нужно поменять");
        Console.Write("х: ");
        var x = Int32.Parse(Console.ReadLine());
        Console.Write("y: ");
        var y = Int32.Parse(Console.ReadLine());

        list.Swap(x, y);
        list.Print();
    }

    private static MyList<int> GetListFromConsole(string message = "Введите числа через пробел: ")
    {
        Console.WriteLine(message);
        var input = Console.ReadLine().Trim().Split(" ");
        var list = new MyList<int>();
        foreach (var e in input)
        {
            try
            {
                var el = Int32.Parse(e);
                list.Add(el);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex);
            }
        }

        return list;
    }

}