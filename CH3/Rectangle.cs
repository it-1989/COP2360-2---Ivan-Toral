using System;

class Rectangle
{
    public readonly float Width, Height; // readonly properties for width and height

    public Rectangle(float width, float height) // constructor to initialize readonly fields
    {
        Width = width;
        Height = height;
    }

    public void Deconstruct(out float width, out float height) // deconstruct method to extract width and height
    {
        width = Width;
        height = Height;
    }

    public float CalculatePerimeter() // method to calculate the perimeter of the rectangle
    {
        return 2 * (Width + Height);
    }
}

class Program
{
    static void Main() 
    {
        Rectangle rect = new Rectangle(5, 10);  // create a rectangle instance

        // attempt to modify the readonly field will result in a compile-time error)
        // rect.Width = 15; // This line will cause an error

        
        float perimeter = rect.CalculatePerimeter();    // calculate the perimeter

       
        (float w, float h) = rect;   // deconstruct the rectangle

        // display the results
        Console.WriteLine($"Perimeter: {perimeter}");   // display the calculated perimeter
        Console.WriteLine($"Width: {w}, Height: {h}");  // display the extracted width and height
    }
}