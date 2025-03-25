using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

public class Reference
{
    public string Verse { get; private set; }
    public string Range { get; private set; }

    public Reference(string verse)
    {
        Verse = verse;
        Range = null;
    }

    public Reference(string verse, string range)
    {
        Verse = verse;
        Range = range;
    }

    public override string ToString()
    {
        return Range != null ? $"{Verse} - {Range}" : Verse;
    }
}

public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> Words { get; set; }
    private string lastHiddenWord; // Track the last hidden word

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int indexToHide;

        // Get a random index to hide
        do
        {
            indexToHide = random.Next(Words.Count);
        } while (Words[indexToHide].IsHidden);

        lastHiddenWord = Words[indexToHide].Text; // Store the hidden word
        Words[indexToHide].Hide();
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public void Display()
    {
        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", Words.Select(word => word.Display())));
    }

    public string GetLastHiddenWord()
    {
        return lastHiddenWord; // Return the last hidden word
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt user for scripture reference and text
        Console.WriteLine("Enter the scripture reference (e.g., John 3:16 or Proverbs 3:5-6):");
        string referenceInput = Console.ReadLine();

        // Check if the reference contains a range
        Reference reference;
        if (referenceInput.Contains('-'))
        {
            var parts = referenceInput.Split('-');
            reference = new Reference(parts[0].Trim(), parts[1].Trim());
        }
        else
        {
            reference = new Reference(referenceInput);
        }

        Console.WriteLine("Enter the scripture text:");
        string text = Console.ReadLine();

        // Create the scripture object
        Scripture scripture = new Scripture(reference, text);

        // Clear the console and display the complete scripture
        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");

        int score = 0;

        while (!scripture.AllWordsHidden())
        {
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                return;
            }

            // Hide a random word
            scripture.HideRandomWord();

            // Clear the console and display the scripture with hidden words
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nGuess the hidden word:");
            string guess = Console.ReadLine();

            // Check if the guess is correct
            string hiddenWord = scripture.GetLastHiddenWord();
            if (guess.Equals(hiddenWord, StringComparison.OrdinalIgnoreCase))
            {
                score += 10; // Award points for a correct guess
                Console.WriteLine("Correct! You've earned 10 points.");
            }
            else
            {
                Console.WriteLine($"Incorrect! The hidden word was: {hiddenWord}");
            }

            // Display current scores
            Console.WriteLine($"Current Score: {score}");
            Console.WriteLine("\nPress Enter to hide another word or type 'quit' to exit.");
        }

        // All words are hidden
        Console.Clear();
        Console.WriteLine("All words are now hidden:");
        scripture.Display();
        Console.WriteLine($"\nYour final score is: {score}");
        Console.WriteLine("\nExiting the program. Goodbye!");
    }
}