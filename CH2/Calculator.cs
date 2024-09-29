using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Operators
{
    class Program
    {

        delegate int CalculatorOperation(int x, int y);
        static void Main(string[] args)
        {
            //OPERATORS, DECLARING MULTIPLE INTEGERS JUST PRACTICE
            //{
            //    int x = 100 + 50;
            //    int sum1 = 100 + 50;        // 150 (100 + 50)
            //    int sum2 = sum1 + 250;      // 400 (150 + 250)
            //    int sum3 = sum2 + sum2;     // 800 (400 + 400)
            //    Console.WriteLine(sum3);
            //    Console.WriteLine("");
            //}

            
            //CALCULATOR
            {
                Console.WriteLine("Enter first number");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter operation (add, subtract, multiply, divide):");
                string operation = Console.ReadLine();

                // Declare a variable of type CalculatorOperation
                CalculatorOperation calcOperation = null;

                // Assign the correct operation based on user input
                switch (operation.ToLower())
                {
                    case "add":
                        calcOperation = (x, y) => x + y;
                        break;
                    case "subtract":
                        calcOperation = (x, y) => x - y;
                        break;
                    case "multiply":
                        calcOperation = (x, y) => x * y;
                        break;
                    case "divide":
                        calcOperation = (x, y) =>
                    {
                        if (y == 0)
                            throw new DivideByZeroException();
                        return x / y;
                    };
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        return;
                }

                // Calculate the result using the selected operation
                int result = calcOperation(a, b);
                Console.WriteLine("The result is: " + result);

            }
            
            
        }
    }
}
