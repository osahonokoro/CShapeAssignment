using System;

// The main class that runs the journal application
class Program
{
    static void Main()
    {
        Journal journal = new Journal(); // Create a new journal object
        bool running = true; // Control variable for the menu loop

        // Application menu loop
        while (running)
        {
            // Display menu options
            Console.WriteLine("\nJournal App");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Remove Entry");
            Console.WriteLine("3. Display Entries");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            // Read user input
            string choice = Console.ReadLine();

            // Handle user choice
            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    Console.Write("Enter index to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        journal.RemoveEntry(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    break;
                case "3":
                    journal.DisplayEntries();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Exiting Journal App. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

//To force commit
