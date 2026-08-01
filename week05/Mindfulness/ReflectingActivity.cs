using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
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

        private List<string> _unusedPrompts;
        private List<string> _unusedQuestions;
        private Random _rand = new Random();

        public ReflectingActivity() 
            : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") 
        {
            _unusedPrompts = new List<string>(_prompts);
            _unusedQuestions = new List<string>(_questions);
        }

        public string GetRandomPrompt()
        {
            if (_unusedPrompts.Count == 0)
            {
                _unusedPrompts = new List<string>(_prompts);
            }
            int index = _rand.Next(_unusedPrompts.Count);
            string selected = _unusedPrompts[index];
            _unusedPrompts.RemoveAt(index);
            return selected;
        }

        public string GetRandomQuestion()
        {
            if (_unusedQuestions.Count == 0)
            {
                _unusedQuestions = new List<string>(_questions);
            }
            int index = _rand.Next(_unusedQuestions.Count);
            string selected = _unusedQuestions[index];
            _unusedQuestions.RemoveAt(index);
            return selected;
        }

        public void DisplayPrompt()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine("Consider the following prompt:\n");
            Console.WriteLine($" --- {prompt} --- \n");
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
        }

        public void DisplayQuestions()
        {
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.Clear();

            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.Write($"> {question} ");
                ShowSpinner(5);
                Console.WriteLine();
            }
        }

        public void Run()
        {
            DisplayStartingMessage();
            DisplayPrompt();
            DisplayQuestions();
            DisplayEndingMessage();
        }
    }
}