using System.Text;
using System;
namespace Core
{
    public static class CalculatorHelper
    {
        public static string Calculate(double num1, double num2, string oper)
        {
            double result = 0;

            switch (oper)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                case "%":
                    result = (num1 * num2) / 100;
                    break;
            }

            return result.ToString();
        }

        public static string CalculateDel(double num1, double delNum, double num2, string oper)
        {
            double result = 0;
            string strNum2 = string.Empty;
            switch (oper)
            {
                case "+":
                    result = num1 - delNum + num2;

                    break;
                case "-":
                    result = num1 + delNum - num2;

                    break;
                case "*":
                    result = num2 != 0 ? num1 / delNum * num2 : num1 / delNum;
                    break;
                case "/":
                    result = num2 != 0 ? num1 * delNum / num2 : num1 * delNum;
                    break;
                case "%":
                    result = (num1 * num2) / 100;
                    break;
            }
            return result.ToString();
        }
    }
}