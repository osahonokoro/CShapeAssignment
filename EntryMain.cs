using System;

// Abstract class representing a journal entry
abstract class EntryMain
{
    public DateTime Date { get; set; } // Stores the date of the journal entry
    public string Content { get; set; } // Stores the user's journal content

    // Abstract method to display the entry
    public abstract void Display();
}