using System;
using System.Collections.Generic;

namespace YouTubeAbstraction
{
    // Class responsible for tracking comment details
    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    // Class responsible for tracking video details and managing its comments
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }

        // Method to return the number of comments
        public int GetCommentCount()
        {
            return Comments.Count;
        }

        // Display method to output video information and associated comments
        public void DisplayVideoDetails()
        {
            Console.WriteLine($"==================================================");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Comments:");

            foreach (var comment in Comments)
            {
                Console.WriteLine($" - {comment.Name}: \"{comment.Text}\"");
            }

            Console.WriteLine($"==================================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create List to hold videos
            List<Video> videos = new List<Video>();

            // Video 1
            Video video1 = new Video("C# Abstraction Tutorial", "Code With Alex", 600);
            video1.Comments.Add(new Comment("User123", "Great explanation of abstraction!"));
            video1.Comments.Add(new Comment("DevGuru", "Clear, concise, and straight to the point."));
            video1.Comments.Add(new Comment("Sarah_P", "Loved the code examples. Thanks!"));
            videos.Add(video1);

            // Video 2
            Video video2 = new Video("Top 10 Programming Tips", "Tech Mastery", 480);
            video2.Comments.Add(new Comment("JakeCode", "Tip #4 saved my project today!"));
            video2.Comments.Add(new Comment("Maria_G", "Awesome overview for beginners."));
            video2.Comments.Add(new Comment("NoobCoder", "Could you do a deep dive into Tip #8?"));
            videos.Add(video2);

            // Video 3
            Video video3 = new Video("Building Web Apps in 2026", "WebDev Simplified", 900);
            video3.Comments.Add(new Comment("Liam_R", "The architecture section was super helpful."));
            video3.Comments.Add(new Comment("Chloe_M", "Adding this to my study list."));
            video3.Comments.Add(new Comment("Sam_K", "Excellent demonstration of practical setup!"));
            videos.Add(video3);

            // Video 4
            Video video4 = new Video("Understanding OOP Basics", "Data Structure Hub", 750);
            video4.Comments.Add(new Comment("Elena_V", "Encapsulation vs Abstraction cleared up at last."));
            video4.Comments.Add(new Comment("Rob_B", "Subscribed! High-quality content."));
            video4.Comments.Add(new Comment("Techie99", "This is exactly what I was looking for."));
            videos.Add(video4);

            // Iterate through the list of videos and display details
            foreach (Video video in videos)
            {
                video.DisplayVideoDetails();
            }
        }
    }
}