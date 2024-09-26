// If you really want to use a keyword as an identifier, you can do so with the @ prefix.
// This can be useful for language interoperability.
{
int @class = 123;
string @namespace = "foo";

// The identifiers below are examples of *contextual* keywords, so we can use them without conflict:

int add = 3;
bool ascending = true;
int yield = 45;


// Statements can span multiple lines, thanks to the semicolon terminator:

Console.WriteLine
  (1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10);

int x = 3;   // Single-line comment

int y = 3;   /* This is a comment that
        spans two lines */
}
{
    Console.WriteLine("Hello World!");
}

{
    int x = 12 * 30;
    System.Console.WriteLine (x);   // Statement 2
} 

{
    
Console.WriteLine (FeetToInches (30));      // 360
Console.WriteLine (FeetToInches (100));     // 1200

int FeetToInches (int feet)
{
    int inches = feet * 500;
    return inches;
}
}

{
   // string, int and bool types are examples of predefined types:

string message = "Hello world";
string upperMessage = message.ToUpper();
Console.WriteLine (upperMessage);               // HELLO WORLD

int x = 2015;
message = message + x.ToString();
Console.WriteLine (message);                    // Hello world2015

bool simpleVar = false;
if (simpleVar)
  Console.WriteLine ("This will not print");

int y = 5000;
bool lessThanAMile = y < 5280;
if (lessThanAMile)
  Console.WriteLine ("This will print"); 
}
