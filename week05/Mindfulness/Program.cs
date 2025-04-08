using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MindfulnessApp app = new MindfulnessApp();
            app.Run();
        }
    }

    public class MindfulnessApp
    {
        private int breathingActivityCount = 0;
        private int reflectionActivityCount = 0;
        private int listingActivityCount = 0;

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Activity Log");
                Console.WriteLine("5. Exit");
                string choice = Console.ReadLine();

                MindfulnessActivity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        breathingActivityCount++;
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        reflectionActivityCount++;
                        break;
                    case "3":
                        activity = new ListingActivity();
                        listingActivityCount++;
                        break;
                    case "4":
                        ShowActivityLog();
                        continue;
                    case "5":
                        Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                activity.Start();
            }
        }

        private void ShowActivityLog()
        {
            Console.Clear();
            Console.WriteLine("Activity Log:");
            Console.WriteLine($"Breathing Activity: {breathingActivityCount} times");
            Console.WriteLine($"Reflection Activity: {reflectionActivityCount} times");
            Console.WriteLine($"Listing Activity: {listingActivityCount} times");
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }
    }

    public abstract class MindfulnessActivity
    {
        protected int Duration { get; private set; }

        public void Start()
        {
            GetDuration();
            Prepare();
            Execute();
            End();
        }

        protected void GetDuration()
        {
            Console.Write("Enter the duration of the activity in seconds: ");
            Duration = int.Parse(Console.ReadLine());
        }

        protected void Prepare()
        {
            Console.WriteLine("Prepare to begin...");
            ShowAnimation(3); // Pause for 3 seconds with animation
        }

        protected void End()
        {
            Console.WriteLine("Good job! You have completed the activity.");
            ShowAnimation(3); // Pause for 3 seconds with animation
            Console.WriteLine($"You completed the activity for {Duration} seconds.");
            ShowAnimation(3); // Pause for 3 seconds with animation
        }

        protected void ShowAnimation(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("|");
                Thread.Sleep(250);
                Console.Write("\b/");
                Thread.Sleep(250);
                Console.Write("\b-");
                Thread.Sleep(250);
                Console.Write("\b\\");
                Thread.Sleep(250);
                Console.Write("\b|");
                Thread.Sleep(250);
            }
            Console.WriteLine();
        }

        protected abstract void Execute();
    }

    public class BreathingActivity : MindfulnessActivity
    {
        protected override void Execute()
        {
            Console.WriteLine("Let's start the breathing exercise!");
            int elapsed = 0;

            while (elapsed < Duration)
            {
                Console.WriteLine("Breathe in...");
                ShowCountdown(4); // 4 seconds for inhale
                Console.WriteLine("Breathe out...");
                ShowCountdown(4); // 4 seconds for exhale
                elapsed += 8; // Each cycle takes 8 seconds
            }
        }
    }

    public class ReflectionActivity : MindfulnessActivity
    {
        protected override void Execute()
        {
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
            List<string> prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            string selectedPrompt = prompts[new Random().Next(prompts.Count)];
            Console.WriteLine(selectedPrompt);
            ShowAnimation(5); // Pause for 5 seconds with animation

            List<string> questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            int elapsed = 0;

            while (elapsed < Duration)
            {
                string question = questions[new Random().Next(questions.Count)];
                Console.WriteLine(question);
                ShowSpinner(5); // Pause for 5 seconds with spinner
                elapsed += 5; // Each question takes 5 seconds
            }
        }
    }

    public class ListingActivity : MindfulnessActivity
    {
        protected override void Execute()
        {
            Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
            List<string> prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };

            string selectedPrompt = prompts[new Random().Next(prompts.Count)];
            Console.WriteLine(selectedPrompt);
            ShowCountdown(5); // Countdown for 5 seconds to think

            List<string> items = new List<string>();
            int elapsed = 0;

            while (elapsed < Duration)
            {
                Console.Write("Enter an item (or type 'done' to finish): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "done") break;
                items.Add(input);
                elapsed += 1; // Each entry takes approximately 1 second
            }

            Console.WriteLine($"You listed {items.Count} items.");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}