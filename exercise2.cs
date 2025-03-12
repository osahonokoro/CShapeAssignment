using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        
        // Convert input to integer
        int grade;
        bool isValid = int.TryParse(userInput, out grade);

        if (!isValid)
        {
            Console.WriteLine("Invalid input! Please enter a number.");
            return;
        }

        // Determine the letter grade
        string letter = "";
        string sign = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch challenge: Determine "+" or "-" sign
        int lastDigit = grade % 10;
        
        if (grade >= 60 && grade < 100) // Exclude A+ and F+/- cases