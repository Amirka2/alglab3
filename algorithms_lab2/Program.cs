using System;
using algorithms_lab2;

public class Program
{
    public static void Main(String[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        MyList<int> l = new MyList<int>();
        l.Add(1);
        l.Add(2);
        l.Add(3);
        foreach(var e in l)
            Console.WriteLine(e);

        l.Remove(2);
        Console.WriteLine();
        foreach (var e in l)
            Console.WriteLine(e);

        l.AddFirst(0);
        l.Add(4);
        Console.WriteLine();
        foreach (var e in l)
            Console.WriteLine(e);

        Console.ReadLine();
    }
}