using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt for the first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine(); // Read the first name input

        // Prompt for the last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine(); // Read the last name input

        // Display the formatted output
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}