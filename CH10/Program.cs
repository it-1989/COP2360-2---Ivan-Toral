using System;
using System.Collections.Generic;

public class Contractor
{
    // Private member variables
    private string contractorName;   // Stores the name of the contractor
    private int contractorNumber;    // Stores the contractor's unique number
    private DateTime startDate;      // Stores the start date of the contract

    // Constructor to initialize contractor details
    public Contractor(string name, int number, DateTime date)
    {
        contractorName = name;
        contractorNumber = number;
        startDate = date;
    }

    // Properties for encapsulated access to the contractor's details
    public string ContractorName
    {
        get { return contractorName; }
        set { contractorName = value; }
    }

    public int ContractorNumber
    {
        get { return contractorNumber; }
        set { contractorNumber = value; }
    }

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    // Method to display contractor's details
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Contractor Name: {contractorName}");
        Console.WriteLine($"Contractor Number: {contractorNumber}");
        Console.WriteLine($"Start Date: {startDate.ToShortDateString()}");
    }
}

public class Subcontractor : Contractor
{
    // Private member variables for Subcontractor
    private int shift;               // 1 for Day Shift, 2 for Night Shift
    private double hourlyPayRate;    // Hourly pay rate of the subcontractor

    // Constructor to initialize subcontractor details
    public Subcontractor(string name, int number, DateTime date, int shift, double hourlyPayRate)
        : base(name, number, date)
    {
        this.shift = shift;
        this.hourlyPayRate = hourlyPayRate;
    }

    // Properties to access subcontractor's additional details
    public int Shift
    {
        get { return shift; }
        set { shift = value; }
    }

    public double HourlyPayRate
    {
        get { return hourlyPayRate; }
        set { hourlyPayRate = value; }
    }

    // Method to calculate total pay, including a 3% shift differential for night shift
    public float ComputePay(float hoursWorked)
    {
        double pay = hoursWorked * hourlyPayRate;
        if (shift == 2) // Apply 3% extra for night shift
        {
            pay += pay * 0.03;
        }
        return (float)pay;
    }

    // Override to display subcontractor-specific information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        string shiftName = (shift == 1) ? "Day Shift" : "Night Shift";
        Console.WriteLine($"Shift: {shiftName}");
        Console.WriteLine($"Hourly Pay Rate: ${hourlyPayRate:F2}");
    }
}

class Program
{
    static HashSet<int> contractorNumbers = new HashSet<int>(); // To store unique contractor numbers

    static void Main(string[] args)
    {
        bool continueCreating = true;

        while (continueCreating)
        {
            // Get subcontractor details with validation
            string name = GetValidString("Enter Contractor Name (letters only): ");

            int number = GetUniqueContractorNumber("Enter Contractor Number: ");

            DateTime startDate = GetFutureDate("Enter Contractor Start Date (YYYY-MM-DD, cannot be in the past): ");

            int shift = GetValidOption("Enter Shift (1 for Day, 2 for Night): ", new[] { 1, 2 });

            double payRate = GetValidPayRate("Enter Hourly Pay Rate (minimum $13.00): ");

            // Create subcontractor instance
            Subcontractor sub = new Subcontractor(name, number, startDate, shift, payRate);

            // Display subcontractor info
            sub.DisplayInfo();

            // Get hours worked and calculate pay
            float hoursWorked = GetValidHoursWorked("Enter Hours Worked (maximum 70 hours): ");
            float totalPay = sub.ComputePay(hoursWorked);
            Console.WriteLine($"Total Pay: ${totalPay:F2}");

            // Ask if user wants to create another subcontractor
            continueCreating = GetYesNo("Do you want to create another subcontractor? (yes/no): ");
        }

        Console.WriteLine("Program ended.");
    }

    // Method to validate unique contractor number
    static int GetUniqueContractorNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (!contractorNumbers.Contains(result))
                {
                    contractorNumbers.Add(result);
                    return result;
                }
                Console.WriteLine("Contractor Number already exists. Please enter a unique number.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    // Method to validate contractor name (letters only)
   static string GetValidString(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine().Trim();

        // Validate that the name contains only letters and spaces
        if (!string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            return input;
        }
        Console.WriteLine("Invalid input. Please enter a valid name (letters and spaces only).");
    }
}

    // Method to validate future date
    static DateTime GetFutureDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
            {
                if (result.Date >= DateTime.Now.Date)
                {
                    return result;
                }
                Console.WriteLine("Invalid input. The date cannot be in the past.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD.");
            }
        }
    }

    // Method to validate hours worked
    static float GetValidHoursWorked(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (float.TryParse(Console.ReadLine(), out float result) && result <= 70)
            {
                return result;
            }
            Console.WriteLine("Invalid input. Hours worked cannot exceed 70. Please try again.");
        }
    }

    // Method to validate pay rate
    static double GetValidPayRate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result) && result >= 13)
            {
                return result;
            }
            Console.WriteLine("Invalid input. Pay rate must be at least $13.00. Please try again.");
        }
    }

    // Method to validate choice from allowed options
    static int GetValidOption(string prompt, int[] validOptions)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result) && Array.Exists(validOptions, option => option == result))
                return result;
            Console.WriteLine($"Invalid input. Please choose one of the following options: {string.Join(", ", validOptions)}.");
        }
    }

    // Method to validate yes/no input
    static bool GetYesNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "yes" || response == "y") return true;
            if (response == "no" || response == "n") return false;
            Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
        }
    }
}