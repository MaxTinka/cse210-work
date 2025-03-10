using System;

class Program
{
    static void Main()
    {
        // Call the function to display the welcome message
        DisplayWelcome();

        // Call the function to prompt for the user's name
        string userName = PromptUser Name();

        // Call the function to prompt for the user's favorite number
        int userNumber = PromptUser Number();

        // Call the function to square the user's number
        int squaredNumber = SquareNumber(userNumber);

        // Call the function to display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt for the user's name and return it
    static string PromptUser Name()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt for the user's favorite number and return it
    static int PromptUser Number()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber;
        while (!int.TryParse(Console.ReadLine(), out favoriteNumber))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }
        return favoriteNumber;
    }

    // Function to square the given number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the user's name and the squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}