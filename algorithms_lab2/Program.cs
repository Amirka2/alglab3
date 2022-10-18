using System;
using algorithms_lab2;

public class Program
{
    public static void Main(String[] args)
    {
       Run9Task();
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