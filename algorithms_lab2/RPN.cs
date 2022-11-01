using System;
namespace algorithms_lab2
{
    public static class RPN
    {
        public static double Calculate(string infix)
        {
            string[] infixArr = infix.Trim().Split(" ");
            string expression = ConvertNotation(infixArr);
            string[] expressionArr = expression.Trim().Split(" ");
            double result = Counting(expressionArr);
            return result;
        }

        public static string ConvertNotation(string[] infix)
        {
            string output = string.Empty;
            MyStack<string> operStack = new MyStack<string>();

            for (int i = 0; i < infix.Length; i++)
            {
                if (IsDelimeter(infix[i]))
                    continue;
                if (IsSymbol(infix[i]))
                {
                    output += infix[i];
                    output += " ";
                }
                if (IsFunc(infix[i]))
                {
                    var func = infix[i];

                    if (!IsSymbol(infix[i + 1]))
                        i++;

                    output += func;
                    output += " ";
                }
                if (IsOperator(infix[i]))
                {
                    if (infix[i] == "(")
                        operStack.Push(infix[i]);
                    else if (infix[i] == ")")
                    {
                        string s = operStack.Pop();

                        while (s != "(")
                        {
                            output += s + " ";
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count() > 0)
                            if (GetPriority(infix[i]) <= GetPriority(operStack.Top()))
                                output += operStack.Pop() + " ";

                        operStack.Push(infix[i]);
                    }
                }
            }

            while (operStack.Count() > 0)
                output += operStack.Pop() + " ";

            return output;
        }

        public static double Counting(string[] expression)
        {
            double result = 0;
            MyStack<double> temp = new MyStack<double>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsSymbol(expression[i]))
                {
                    temp.Push(double.Parse(expression[i]));
                }
                else if (IsOperator(expression[i]))
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (expression[i])
                    {
                        case "+": result = b + a; break;
                        case "-": result = b - a; break;
                        case "*": result = b * a; break;
                        case "/": result = b / a; break;
                        case "^": result = Math.Pow(b, a); break;
                    }
                    temp.Push(result);
                }
                else if (IsFunc(expression[i]))
                {
                    temp.Push(Double.Parse(expression[i + 1]));
                    double a = temp.Pop();

                    switch (expression[i])
                    {
                        case "cos": result = Math.Cos(a); break;
                        case "sin": result = Math.Sin(a); break;
                        case "ln": result = Math.Log10(a); break;
                        case "sqrt": result = Math.Sqrt(a); break;
                    }
                    temp.Push(result);

                    i += 2;
                }
            }
            return temp.Top();
        }



        private static bool IsSymbol(string input)
        {
            foreach(var c in input)
            {
                if(c == '1' || c == '2' || c == '3' || c == '4' || c == '5'
                            || c == '6' || c == '7' || c == '8' || c == '9')
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsDelimeter(string c)
        {
            if (c == " " || c == "=")
                return true;
            return false;
        }
        private static bool IsOperator(string input)
        {
            if (input == "+" || input == "-" || input == "/" || input == "*"
                             || input == "^" || input == "(" || input == ")")
                return true;
            return false;
        }
        private static bool IsFunc(string input)
        {
            if (input.Contains("cos") || input.Contains("sin")
                || input.Contains("ln") || input.Contains("sqrt"))
                return true;
            return false;
        }
        static private byte GetPriority(string s)
        {
            switch (s)
            {
                case "(": return 0;
                case ")": return 1;
                case "+": return 2;
                case "-": return 3;
                case "*": return 4;
                case "/": return 4;
                case "^": return 5;
                case "ln": return 5;
                case "cos": return 5;
                case "sin": return 5;
                default: return 6;
            }
        }
        public static string[] GetFormattedInput(string[] input)
        {
            //string[] infixArr = new string[]
            //List<string> formatedInput = new List<string>();
            //foreach(var el in infix)
            //{
            //    if (el.Contains("(") || el.Contains(")"))
            //    {
            //        if (el.Length > 1)
            //        {
            //            for(int i = 0; i < infix.Length + 1; i++)
            //            {
            //                if (infix[i].Contains("("))
            //                {
            //                    formatedInput.Add(infix[i].ToCharArray()[0].ToString());
            //                    if (infix[i].Substring(1).Contains(")"))
            //                    {
            //                        formatedInput.Add(infix[i].Trim().Substring(1).Replace(")", ""));
            //                        formatedInput.Add(")");
            //                    }
            //                    else
            //                    {
            //                        formatedInput.Add(infix[i].Trim().Substring(1));
            //                    }
            //                    continue;
            //                }
            //                formatedInput[i] = infix[i];
            //            }
            //        }
            //    }
            //    infixArr = new string[formatedInput.Count];
            //    for (int i = 0; i < formatedInput.Count; i++)
            //    {
            //        infix[i] = formatedInput.ElementAt(i);
            //    }
            //}
            return new string[0];
        }

    }
}