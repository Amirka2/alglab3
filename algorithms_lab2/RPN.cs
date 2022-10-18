using System;
namespace algorithms_lab2
{
    public static class RPN
    {
        public static double Calculate(string postfixInput)
        {
            string expression = ConvertNotation(postfixInput);
            double result = Counting(expression);
            return result;
        }

        public static string ConvertNotation(string infix)
        {
            string output = string.Empty; 
            MyStack<char> operStack = new MyStack<char>(); 

            for (int i = 0; i < infix.Length; i++) 
            {
                if (IsDelimeter(infix[i]))
                    continue; 

                if (Char.IsDigit(infix[i])) 
                {
                    while (!IsDelimeter(infix[i]) && !IsOperator(infix[i]))
                    {
                        output += infix[i]; 
                        i++; 

                        if (i == infix.Length) break; 
                    }

                    output += " "; 
                    i--; 
                }

                if (IsOperator(infix[i])) 
                {
                    if (infix[i] == '(') 
                        operStack.Push(infix[i]); 
                    else if (infix[i] == ')') 
                    {
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else 
                    {
                        if (operStack.Count() > 0) 
                            if (GetPriority(infix[i]) <= GetPriority(operStack.Top())) 
                                output += operStack.Pop().ToString() + " "; 

                        operStack.Push(char.Parse(infix[i].ToString())); 

                    }
                }
            }

            while (operStack.Count() > 0)
                output += operStack.Pop() + " ";

            return output; 
        }

        public static double Counting(string expression)
        {
            double result = 0; 
            MyStack<double> temp = new MyStack<double>(); 

            for (int i = 0; i < expression.Length; i++) 
            {
                if (Char.IsDigit(expression[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(expression[i]) && !IsOperator(expression[i])) 
                    {
                        a += expression[i]; 
                        i++;
                        if (i == expression.Length) break;
                    }
                    temp.Push(double.Parse(a)); 
                    i--;
                }
                else if (IsOperator(expression[i]))
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (expression[i]) 
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result); 
                }
            }
            return temp.Top();
        }

        private static bool IsDelimeter(char c)
        {
            if (c == ' ' || c == '=')
                return true;
            return false;
        }
        private static bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }


    }
}

