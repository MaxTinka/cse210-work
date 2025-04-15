using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EternalQuest
{
    public class User
    {
        public string Username { get; set; }
        public int Points { get; set; }
        public List<Goal> Goals { get; set; }

        public User(string username)
        {
            Username = username;
            Points = 0;
            Goals = new List<Goal>();
        }

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public void RecordEvent(string goalName)
        {
            var goal = Goals.Find(g => g.Name == goalName);
            if (goal != null)
            {
                Points += goal.RecordProgress();
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($":User   {Username}, Total Points: {Points}");
        }

        public void DisplayGoals()
        {
            foreach (var goal in Goals)
            {
                Console.WriteLine(goal.ToString());
            }
        }
    }

    public abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; set; }

        protected Goal(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public abstract int RecordProgress();
        public abstract string Status();
    }

    public class SimpleGoal : Goal
    {
        public bool IsComplete { get; set; }

        public SimpleGoal(string name, int points) : base(name, points)
        {
            IsComplete = false;
        }

        public override int RecordProgress()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                return Points;
            }
            return 0;
        }

        public override string Status()
        {
            return IsComplete ? "[X] Completed" : "[ ] Not Completed";
        }
    }

    public class EternalGoal : Goal
    {
        public int TimesRecorded { get; set; }

        public EternalGoal(string name, int points) : base(name, points)
        {
            TimesRecorded = 0;
        }

        public override int RecordProgress()
        {
            TimesRecorded++;
            return Points;
        }

        public override string Status()
        {
            return $"[ ] Eternal Goal - Recorded {TimesRecorded} times";
        }
    }

    public class ChecklistGoal : Goal
    {
        public int Target { get; set; }
        public int TimesCompleted { get; set; }

        public ChecklistGoal(string name, int target, int points) : base(name, points)
        {
            Target = target;
            TimesCompleted = 0;
        }

        public override int RecordProgress()
        {
            TimesCompleted++;
            int totalPoints = Points;

            if (TimesCompleted == Target)
            {
                totalPoints += 500; // Bonus for completing the checklist goal
            }

            return totalPoints;
        }

        public override string Status()
        {
            return $"[ ] Checklist Goal - Completed {TimesCompleted}/{Target} times";
        }
    }

    public class ProgressGoal : Goal
    {
        public int CurrentProgress { get; set; }
        public int Target { get; set; }

        public ProgressGoal(string name, int target, int points) : base(name, points)
        {
            Target = target;
            CurrentProgress = 0;
        }

        public override int RecordProgress()
        {
            if (CurrentProgress < Target)
            {
                CurrentProgress++;
                return Points; // Earn points for each step towards the target
            }
            return 0; // No points if the target is already reached
        }

        public override string Status()
        {
            return $"[ ] Progress Goal - Current Progress: {CurrentProgress}/{Target}";
        }
    }

    public class NegativeGoal : Goal
    {
        public int Penalty { get; set; }
        public int Occurrences { get; set; }

        public NegativeGoal(string name, int penalty) : base(name, penalty)
        {
            Penalty = penalty;
            Occurrences = 0;
        }

        public override int RecordProgress()
        {
            Occurrences++;
            return -Penalty; // Deduct points for each occurrence of the bad habit
        }

        public override string Status()
        {
            return $"[ ] Negative Goal - Occurrences: {Occurrences}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("JohnDoe");
            LoadUser Data(user);

            // Sample goal creation
            user.AddGoal(new SimpleGoal("Run a Marathon", 1000));
            user.AddGoal(new EternalGoal("Read Scriptures", 100));
            user.AddGoal(new ChecklistGoal("Attend Temple", 10, 50));
            user.AddGoal(new ProgressGoal("Train for Marathon", 26, 10)); // 26 miles for marathon
            user.AddGoal(new NegativeGoal("Limit Screen Time", 5)); // Lose points for excessive screen time

            // Record some events
            user.RecordEvent("Run a Marathon");
            user.RecordEvent("Read Scriptures");
            user.RecordEvent("Read Scriptures");
            user.RecordEvent("Attend Temple");
            user.RecordEvent("Attend Temple");
            user.RecordEvent("Train for Marathon");
            user.RecordEvent("Train for Marathon");
            user.RecordEvent("Limit Screen Time");
            user.RecordEvent("Limit Screen Time");
            user.RecordEvent("Limit Screen Time");

            // Display user score and goals
            user.DisplayScore();
            user.DisplayGoals();
        }

        static void LoadUser Data(User user)
        {
            // Load user data from a file or database (implementation not shown)
        }
    }
}