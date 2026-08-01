using System;

namespace MindfulnessProgram
{
    // ============================================================================
    // EXCEEDING REQUIREMENTS REPORT:
    // 1. Implemented prompt and question tracking in ReflectingActivity so that 
    //    no prompt or question repeats until all options have been shown at least once.
    // 2. Added a Session Activity Log counter in Program.cs that tracks and 
    //    displays the total number of activities completed during the active session.
    // ============================================================================
    class Program
    {
        static void Main(string[] args)
        {
            int activityLogCount = 0;
            ReflectingActivity reflecting = new ReflectingActivity();

            string choice = "";
            while (choice != "4")
            {
                Console.Clear();
                Console.WriteLine($"Session Log: You have completed {activityLogCount} activity(ies) this session.\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityLogCount++;
                }
                else if (choice == "2")
                {
                    reflecting.Run();
                    activityLogCount++;
                }
                else if (choice == "3")
                {
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityLogCount++;
                }
            }

            Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
        }
    }
}