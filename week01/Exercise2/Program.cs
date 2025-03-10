using System;

class Program
{
    static void Main()
    {
    
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        
        double gradePercentage;
        if (!double.TryParse(input, out gradePercentage))
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
            return;
        }

        // Variable to hold the letter grade
        string letter = "";

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

        Console.WriteLine($"Your letter grade is: {letter}");

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