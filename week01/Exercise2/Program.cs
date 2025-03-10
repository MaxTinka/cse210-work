using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        
        // Convert the input to a double
        double gradePercentage;
        if (!double.TryParse(input, out gradePercentage) || gradePercentage < 0 || gradePercentage > 100)
        {
            Console.WriteLine("Invalid input. Please enter a numeric value between 0 and 100.");
            return;
        }

        // Variable to hold the letter grade
        string letter = "";
        string sign = "";

        // Determine the letter grade using if, else if, else statements
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign based on the last digit
        int lastDigit = (int)(gradePercentage % 10);

        if (letter == "A")
        {
            sign = "-"; // A- is the only option for A
        }
        else if (letter == "B" && lastDigit >= 7)
        {
            sign = "+";
        }
        else if (letter == "B" && lastDigit < 3)
        {
            sign = "-";
        }
        else if (letter == "C" && lastDigit >= 7)
        {
            sign = "+";
        }
        else if (letter == "C" && lastDigit < 3)
        {
            sign = "-";
        }
        else if (letter == "D" && lastDigit >= 7)
        {
            sign = "+";
        }
        else if (letter == "D" && lastDigit < 3)
        {
            sign = "-";
        }
        // No sign for F

        // Print the letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Check if the user passed the course
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry! Keep trying, and you'll do better next time.");
        }
    }
}