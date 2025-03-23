using System;
using System.Collections.Generic;
using System.IO;

// The Journal class manages journal entries and file storage
class Journal
{
    private List<EntryMain> entries = new List<EntryMain>(); // List to store journal entries
    private string fileName = "journal.txt"; // File where journal entries are saved

    // List of prompts for journal entries
    private List<string> prompts = new List<string>
    {
        "What made you happy today?",
        "What challenge did you overcome today?",
        "What did you learn today?",
        "Who inspired you today?",
        "What are you grateful for today?",
        "How far have you gone with your CSE210: Programming with Classes?",
        "How far have you gone with WDD130: Web Fundamentals?",
        "Were there any notifications today?",
        "Do you have new emails?"
    };

    public Journal()
    {
        LoadFromFile();
    }

    // Adds a new journal entry
    public void AddEntry()
    {
        // Selects a random prompt from the list
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        
        // Get the user's response
        Console.Write("Your Response: ");
        string content = Console.ReadLine();

        // Create and store the new entry
        JournalEntry entry = new JournalEntry { Date = DateTime.Now, Content = content };
        entries.Add(entry);

        // Save the entry to the file
        SaveToFile(entry);
    }

    // Removes an entry from the journal by index
    public void RemoveEntry(int index)
    {
        if (index >= 0 && index < entries.Count)
        {
            entries.RemoveAt(index);
            Console.WriteLine("Entry removed successfully.");
            SaveAllEntries(); // Update file after removal
        }
        else
        {
            Console.WriteLine("Invalid entry index.");
        }
    }

    // Displays all journal entries
    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
        }
        else
        {
            foreach (var entry in entries)
            {
                entry.Display();
            }
        }
    }

    // Saves an entry to a text file
    private void SaveToFile(JournalEntry entry)
    {
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss")} | {entry.Content}");
        }
    }

    // Saves all entries (used after deletion)
    private void SaveAllEntries()
    {
        using (StreamWriter writer = new StreamWriter(fileName, false))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss")} | {entry.Content}");
            }
        }
    }

    // Loads journal entries from file
    private void LoadFromFile()
    {
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(" | ");
                if (parts.Length == 2 && DateTime.TryParse(parts[0], out DateTime date))
                {
                    entries.Add(new JournalEntry { Date = date, Content = parts[1] });
                }
            }
        }
    }
}