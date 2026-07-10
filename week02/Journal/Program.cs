using System;

/* 
 * CREATIVITY AND EXCEEDING REQUIREMENTS:
 * 1. Saved additional information: I added a Mood tracker (_mood) to the Entry class so users can log their current emotional state alongside their text response.
 * 2. Alternative Storage Format: Instead of a basic pipe or comma-separated text file, I implemented full JSON Serialization/Deserialization using System.Text.Json. This inherently prevents formatting errors caused by users typing commas, quotes, or newlines in their journal entries.
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("How would you rate your mood today? (e.g., Happy, Tired, Motivated): ");
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, response, mood);
                    myJournal.AddEntry(newEntry);
                    break;

                case "2":
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename (e.g., journal.json)? ");
                    string loadFilename = Console.ReadLine();
                    myJournal.LoadFromFile(loadFilename);
                    break;

                case "4":
                    Console.Write("What is the filename (e.g., journal.json)? ");
                    string saveFilename = Console.ReadLine();
                    myJournal.SaveToFile(saveFilename);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a number from 1 to 5.");
                    break;
            }
        }
    }
}