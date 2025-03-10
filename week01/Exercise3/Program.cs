using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random number between 1 and 100
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int numberOfGuesses = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");

            // Loop until the user guesses the magic number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                // Validate input
                if (!int.TryParse(input, out guess) || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 100.");
                    continue;
                }

                numberOfGuesses++;

                // Check the guess
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Inform the user of the number of guesses
            Console.WriteLine($"It took you {numberOfGuesses} guesses to find the magic number {magicNumber}.");

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";
        }

        Console.WriteLine("Thanks for playing!");
    }
}