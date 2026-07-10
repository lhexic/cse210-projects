using System;

public class Entry
{
    // Exact member variables from the design diagram
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }
    
    // Added for exceeding requirements
    public string _mood { get; set; } 

    public Entry() {}

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    // Exact method from the design diagram
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"{_entryText}\n");
    }
}