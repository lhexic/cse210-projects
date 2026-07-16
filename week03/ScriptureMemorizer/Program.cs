using System;
using System.Collections.Generic;

/*
=============================================================================
EXCEEDING REQUIREMENTS STATEMENT:
To exceed the baseline requirements and achieve 100%, this program:
1. Implements a library (list) of multiple scriptures containing both single
   and multi-verse formats.
2. Randomly selects one scripture from the library at runtime to offer a 
   varied study experience.
3. Implements the stretch challenge of keeping track of and only selecting 
   words that are not already hidden. This avoids redundant random operations 
   and guarantees a smooth, predictable progression.
=============================================================================
*/

class Program
{
    static void Main(string[] args)
    {
        // 1. Initialize our library of scripture options
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6), 
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16), 
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Philippians", 4, 13), 
                "I can do all things through Christ which strengtheneth me."
            ),
            new Scripture(
                new Reference("Joshua", 1, 9), 
                "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."
            )
        };

        // 2. Select a scripture from the library at random
        Random random = new Random();
        int randomIndex = random.Next(scriptureLibrary.Count);
        Scripture selectedScripture = scriptureLibrary[randomIndex];

        // 3. Command loop execution
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to end.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide 3 words at a time
            selectedScripture.HideRandomWords(3);

            // Break early if everything is hidden, displaying the final state
            if (selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden! Great job practicing!");
                break;
            }
        }
    }
}