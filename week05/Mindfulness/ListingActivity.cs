using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private int _count = 0;
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt inspired this month?",
            "Who are some of your personal heroes?"
        };

        private Random _rand = new Random();

        public ListingActivity() 
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

        public void GetRandomPrompt()
        {
            string prompt = _prompts[_rand.Next(_prompts.Count)];
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($" --- {prompt} --- ");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.WriteLine();
        }

        public List<string> GetListFromUser()
        {
            List<string> userList = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    userList.Add(input);
                }
            }

            _count = userList.Count;
            return userList;
        }

        public void Run()
        {
            DisplayStartingMessage();
            GetRandomPrompt();
            
            List<string> items = GetListFromUser();
            Console.WriteLine($"You listed {_count} items!");

            DisplayEndingMessage();
        }
    }
}