using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    // Exact member variable from the design diagram
    public List<Entry> _entries = new List<Entry>();

    // Exact methods from the design diagram
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nThe journal is currently empty.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_entries, options);
            
            File.WriteAllText(file, jsonString);
            Console.WriteLine("Journal saved successfully as JSON!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            _entries.Clear();
            string jsonString = File.ReadAllText(file);
            
            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            Console.WriteLine("Journal loaded successfully from JSON!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}