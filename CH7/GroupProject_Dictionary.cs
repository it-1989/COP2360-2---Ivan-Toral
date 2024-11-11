using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Initialize the dictionary with some sample data
        Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>()
        {
            { "Cars", new List<string> { "Honda", "Nissan", "Ford" } },
            { "Video Games", new List<string> { "Resident Evil", "Silent Hill"} },
            { "Operating Systems", new List<string> { "MacOS", "Windows", "Linux" } }
        };

        bool continueProgram = true;

        // Main loop for user input
        while (continueProgram)
        {
            displayoption();
            Console.WriteLine("\nEnter the letter of your choice:");
            string input = Console.ReadLine();
            char choice = string.IsNullOrEmpty(input) ? ' ' : input[0];
            Console.WriteLine();

            // Switch statement to handle different tasks based on user input
            switch (choice)
            {
                case 'a':
                    PopulateDictionary(myDictionary);
                    break;
                case 'b':
                    DisplayDictionaryContents(myDictionary);
                    break;
                case 'c':
                    RemoveKey(myDictionary);
                    break;
                case 'd':
                    AddNewKeyValue(myDictionary);
                    break;
                case 'e':
                    AddValueToExistingKey(myDictionary);
                    break;
                case 'f':
                    SortKeys(myDictionary);
                    break;
                case 'x':
                    continueProgram = false;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    // Display menu options for the user
    static void displayoption()
    {
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("a. Populate the Dictionary with a new key and value");
        Console.WriteLine("b. Display Dictionary Contents");
        Console.WriteLine("c. Remove a Key from the Dictionary");
        Console.WriteLine("d. Add a New Key and Value");
        Console.WriteLine("e. Add a Value to an Existing Key");
        Console.WriteLine("f. Sort and Display the Dictionary by Keys");
        Console.WriteLine("x. Exit");
        Console.WriteLine("==================================");
    }

    // Method to ensure non-empty user input
    static string GetNonEmptyInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    // a. Populate the Dictionary with a new key and value
    static void PopulateDictionary(Dictionary<string, List<string>> dictionary)
    {
        // Get user input for key and value
        string key = GetNonEmptyInput("Enter key to add: ");
        string value = GetNonEmptyInput("Enter value to add: ");

        // Check if the key already exists
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = new List<string> { value };
            Console.WriteLine($"Key '{key}' added with initial value '{value}'.\n");
        }
        else
        {
            Console.WriteLine("Key already exists. Use option 'e' to add values to an existing key.\n");
        }
    }

    // b. Display the contents of the Dictionary
    static void DisplayDictionaryContents(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine("\nDictionary Contents:");
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"Key: {kvp.Key} -> Values: {string.Join(", ", kvp.Value)}");
        }
        Console.WriteLine();
    }

    // c. Remove a specified key from the Dictionary
    static void RemoveKey(Dictionary<string, List<string>> dictionary)
    {
        // Get user input for the key to remove
        string key = GetNonEmptyInput("Enter key to remove: ");

        // Attempt to remove the key and inform the user of the result
        if (dictionary.Remove(key))
        {
            Console.WriteLine($"Key '{key}' removed.\n");
        }
        else
        {
            Console.WriteLine("Key not found.\n");
        }
    }

    // d. Add a new key-value pair to the Dictionary
    static void AddNewKeyValue(Dictionary<string, List<string>> dictionary)
    {
        // Get user input for key and value
        string key = GetNonEmptyInput("Enter new key: ");
        string value = GetNonEmptyInput("Enter value: ");

        // Check if the key already exists before adding
        if (!dictionary.ContainsKey(key))
        {
            dictionary[key] = new List<string> { value };
            Console.WriteLine($"New key '{key}' added with value '{value}'.\n");
        }
        else
        {
            Console.WriteLine("Key already exists. Use option 'e' to add values to an existing key.\n");
        }
    }

    // e. Append a value to an existing key's list of values
    static void AddValueToExistingKey(Dictionary<string, List<string>> dictionary)
    {
        // Get user input for the key and value to add
        string key = GetNonEmptyInput("Enter key to add value to: ");

        if (dictionary.ContainsKey(key))
        {
            string value = GetNonEmptyInput("Enter value to add: ");
            dictionary[key].Add(value);
            Console.WriteLine($"Value '{value}' added to key '{key}'.\n");
        }
        else
        {
            Console.WriteLine("Key not found.\n");
        }
    }

    // f. Sort the dictionary by keys and display the sorted contents
    static void SortKeys(Dictionary<string, List<string>> dictionary)
    {
        Console.WriteLine("\nSorted Dictionary by Keys:");
        foreach (var kvp in dictionary.OrderBy(k => k.Key))
        {
            Console.WriteLine($"Key: {kvp.Key} -> Values: {string.Join(", ", kvp.Value)}");
        }
        Console.WriteLine();
    }
}
