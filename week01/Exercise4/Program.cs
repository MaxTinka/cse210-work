using System;
using System.Collections.Generic;

class Program
{7
    static void Main()
    {
        List<double> numbers = new List<double>();
        double input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers from the user
        while (true)
        {
            Console.Write("Enter number: ");
            input = Convert.ToDouble(Console.ReadLine());

            if (input == 0)
            {
                break; // Exit the loop if the user enters 0
            }

            numbers.Add(input); // Add the number to the list
        }

        // Calculate the sum
        double sum = 0;
        foreach (double number in numbers)
        {
            sum += number;
        }

        // Calculate the average
        double average = sum / numbers.Count;

        // Find the maximum number
        double max = numbers[0];
        foreach (double number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge: Find the smallest positive number
        double smallestPositive = double.MaxValue;
        foreach (double number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive == double.MaxValue)
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Sort the numbers
        numbers.Sort();

        // Display the sorted list
        Console.WriteLine("The sorted list is:");
        foreach (double number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}