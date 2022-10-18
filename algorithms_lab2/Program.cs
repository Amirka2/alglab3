using System;
using algorithms_lab2;

public class Program
{
    public static void Main(String[] args)
    {
        MyStack<string> s = new MyStack<string>();
        for(int i = 0; i < 10; i++)
        {
            s.Push($"{i}");
        }
        s.Push("cat");
        s.Print();

        RunStackTask(s, "3 4 1,56 1,7 1,cat 2 5 4");
       //Run9Task();
    }
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

        foreach(var el in arr)
        {
            CalculateOperation(s, el);
        }
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

    private static void Run9Task()
    {
        string path = "9task.txt";
        MyList<int> list1 = new MyList<int>();
        MyList<int> list2 = new MyList<int>();
        string temp, temp2;
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            sw.WriteLine("1, 2, 3, 4");
            sw.WriteLine("5, 6, 7, 8");
        }
        using (StreamReader sr = new StreamReader(path))
        {
            temp = sr.ReadLine();
            temp2 = sr.ReadLine();
        }
        var inputArr1 = temp.Replace(" ", String.Empty).Split(',');
        var inputArr2 = temp2.Replace(" ", String.Empty).Split(',');
        foreach (var el in inputArr1)
            list1.Add(Int32.Parse(el));
        foreach (var el in inputArr2)
            list2.Add(Int32.Parse(el));

        list1.AddList(list2);

        Console.WriteLine();

        foreach (var el in list1)
            Console.Write(el + ", ");
    }
}