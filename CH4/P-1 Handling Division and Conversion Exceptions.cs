using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number: ");
        string input1 = Console.ReadLine();

        Console.WriteLine("Enter the second number:");
        string input2 = Console.ReadLine();

        try

        {
            int number1 = Convert.ToInt32(input1);
            int number2 = Convert.ToInt32(input2);
            if (number2 == 0) //if statement added to give user a second oportunity before exception error shows up
            {
                Console.WriteLine("Division by zero not possibe, please try again and enter the second number:");
                input2 = Console.ReadLine();
                number2 = Convert.ToInt32(input2); //update number 2 with the new input
            }
            else  
            {
                static int Divide(int a, int b)
                {
                    return a / b;
                }
            }
            

            if (number1 == 000)
            /* if statement to force a general exception when number1 
            equals 000 (for testing) since there was not possible with 
            the original code*/
            {
                throw new Exception("Forced exception for testing purposes.");
            }

            int result = Divide(number1, number2);
            Console.WriteLine($"The result of {number1} divided by {number2} is: {result}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: One or both of the inputs are not valid integers.");
            Console.WriteLine($"Detailed error message: {ex.Message}");
            Console.WriteLine($"The following values are invalid integers: '{input1}' and '{input2}'");
            //line above added to show what specific values triggered the error
        }

        /*overflow exception added to output 
        message that integer number is too large*/
        catch (OverflowException ex)
        {
            Console.WriteLine("Error: The input number is too large or too small for an integer.");
            Console.WriteLine($"Detailed error message: {ex.Message}");
            Console.WriteLine($"The following values too large: '{input1}' and '{input2}'");
            //line above added to show what specific values triggered the error
        }

        catch (DivideByZeroException ex)
        {

            Console.WriteLine("Error: You entered a zero AGAIN! Division by zero is not allowed.");
            Console.WriteLine($"Detailed error message: {ex.Message}");
            Console.WriteLine($"One of the values was a zero when you attempted to divide {input1} by {input2}, which caused the error.");
            //line above added to show what specific values triggered the error
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine($"Detailed error message: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.Read();
    }

    static int Divide(int a, int b)
    {
        return a / b;
    }
}