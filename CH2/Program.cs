using System;
using System.Security.Cryptography;
namespace Sum
{
  class Program
  {
    static void Main(string[] args)
    {
      //CONSTANT WITH INTEGER VARIABLE
      {
        const int x = 20; //x = 10 error
        int Y;
        Y = 4;
        int z = (x + Y);
        // Calculation int
        //Console.WriteLine(z);     
        /*The code below will print couple 
        of lines in separate rows*/
        Console.WriteLine("");      //blank row for spacing
        Console.WriteLine(x + " + " + Y + " = " + z);
      }

      //PHONE STATEMENT WITH STRING VARIABLE
      {
        string brand = "Samsung ";
        string model = "Galaxy S24 ";
        string brandmodel = brand + model;
        Console.WriteLine("My phone is a " + brandmodel);
      }

      //DISPLAY VARIABLES and declaring integers
      {
        int a, b, c;
        a = 20;
        b = 30;
        c = 50;
        Console.WriteLine("");    //blank row for spacing
        Console.WriteLine(a + " + " + b + " + " + c + " = " + (a + b + c));
        //Console.WriteLine(a+b+c); 
        string sum = "This is the result of the sum of ";
        Console.WriteLine(sum + a + ", " + b + " and " + c + ".");
        Console.WriteLine("");    //blank row for spacing
      }

      //IDENTIFIERS
      //{
      //Good
      //int minutesPerHour = 60;
      //int m=60;
      //}

      //IMPLICIT CASTING
      {
        int myInt = 9;
        double myDouble = myInt;       // Automatic casting: int to double
        Console.WriteLine("IMPLICIT VARIABLE");
        Console.WriteLine(myInt);      // Outputs 9
        Console.WriteLine(myDouble);   // Outputs 9
      }

      //EXPLICIT CASTING
      {
        double myDouble = 9.78;
        int myInt = (int)myDouble;    // Manual casting: double to int
        Console.WriteLine("");      //blank row for spacing
        Console.WriteLine("EXPLICIT VARIABLE");
        Console.WriteLine(myDouble);   // Outputs 9.78
        Console.WriteLine(myInt);      // Outputs 9
      }
      {
        int myInt = 10;
        double myDouble = 5.25;
        bool myBool = true;

        Console.WriteLine("");      //blank row for spacing
        Console.WriteLine(Convert.ToString(myInt));    // convert int to string
        Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
        Console.WriteLine(Convert.ToDouble(myDouble));  // convert double to int
        Console.WriteLine(Convert.ToString(myBool));   // convert bool to string
      }

      //USER INPUT

      {
        // Type your username and press enter
        Console.WriteLine("Enter your name:");

        // Create a string variable and get user input from the keyboard and store it in the variable
        string userName = Console.ReadLine();

        // Print the value of the variable (userName), which will display the input value
        Console.WriteLine("Name is: " + userName);

        //TYPE CASTING
        Console.WriteLine("Enter your age");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Your age is: " + age);
      }

      {
        //Console.WriteLine("End of Code");
      }

      
    }

  }
}


