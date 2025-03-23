using System;

// A concrete implementation of EntryMain for a journal entry
class JournalEntry : EntryMain
{
    // Overrides the abstract method to display the journal entry
    public override void Display()
    {
        Console.WriteLine($"[{Date.ToShortDateString()}] {Content}\n");
    }
}

//To force modification
