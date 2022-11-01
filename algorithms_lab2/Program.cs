using System;
using System.Diagnostics;
using System.Text;
using algorithms_lab2;

public class Program
{
    public static void Main(String[] args)
    {
        //string[] s = { "2", "+", "2", "*", "2" }; //RPN
        //Console.WriteLine(RPN.ConvertNotation(s));
        //Console.WriteLine(RPN.Calculate("2 + 2 * 2 - ( 30 + 6 )"));

        ListWorker.RunListTasks();  //12tasks

        ListWorker.RunListTask();   //realization of using

        Checker.CreateStackData();  //creates files with n operations and time data for stack

        Checker.CreateQueueData();  //creates files with n operations and time data for queue
                
    }
    

    
}