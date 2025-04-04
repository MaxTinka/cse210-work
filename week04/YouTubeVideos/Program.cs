using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public string Display()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int LengthInSeconds { get; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment newComment = new Comment(commenterName, text);
        comments.Add(newComment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<string> GetComments()
    {
        List<string> commentList = new List<string>();
        foreach (var comment in comments)
        {
            commentList.Add(comment.Display());
        }
        return commentList;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create video instances and add them to the list
        Video video1 = new Video("Understanding Abstraction in Programming", "John Doe", 300);
        video1.AddComment("Alice", "Great explanation!");
        video1.AddComment("Bob", "I learned a lot from this video.");
        video1.AddComment("Charlie", "Can you explain more about abstraction?");
        videos.Add(video1);

        Video video2 = new Video("Introduction to OOP", "Jane Smith", 450);
        video2.AddComment("David", "Very informative!");
        video2.AddComment("Eve", "I love the examples you provided.");
        video2.AddComment("Frank", "Can you do a deep dive on inheritance?");
        videos.Add(video2);

        Video video3 = new Video("C# Basics for Beginners", "Alice Johnson", 600);
        video3.AddComment("Grace", "This is exactly what I needed!");
        video3.AddComment("Hank", "The explanations are clear and concise.");
        video3.AddComment("Ivy", "Looking forward to more videos!");
        videos.Add(video3);

        Video video4 = new Video("Advanced C# Techniques", "Michael Brown", 720);
        video4.AddComment("Jack", "Great content, very helpful!");
        video4.AddComment("Liam", "I appreciate the depth of this tutorial.");
        video4.AddComment("Mia", "Can you cover async programming next?");
        videos.Add(video4);

        // Display information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            // List all comments for the video
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment}");
            }

            Console.WriteLine(new string('-', 50)); // Separator for better readability
        }
    }
}