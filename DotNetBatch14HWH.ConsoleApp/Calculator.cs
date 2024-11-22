using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp
{
    internal class Calculator
    {
        public void Calculation()
        {
            string firstNumber = "", secondNumber = "", operation = "";
            double x = 0, y = 0;
            Console.WriteLine("Enter first number: ");
            firstNumber = Console.ReadLine();
            x = Convert.ToDouble(firstNumber); 
            Console.WriteLine("Enter second number: ");
            secondNumber = Console.ReadLine();
            y = Convert.ToDouble(firstNumber);
            Console.WriteLine("Enter the operator (+, -, *, /): ");
            operation = Console.ReadLine();
            double result = 0;

            switch (operation)
            {
                case "+": 
                    result = x + y;
                    break;  
                case "-": 
                    result = x - y; 
                    break;
                case "*": 
                    result = x * y; 
                    break;
                case "/": 
                    if(y != 0)
                    {
                        result = x / y;
                    }
                    else
                    {
                        Console.WriteLine("Invalid divisor!");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    Console.ReadLine();
                    return;
            }

            Console.WriteLine("The result is: " + result);
            Console.ReadLine();
        }
    }
}
