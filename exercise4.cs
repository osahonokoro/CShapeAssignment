using System;
using System.Collections.Generic;
using System.Linq; // This was Added for Max() method

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber;
        Console.WriteLine("Enter a list of numbers, type 0 when you are done.");
        
        do
        {
            Console.Write("Enter number: ");
            string userResponse = Console.ReadLine();

            if (int.TryParse(userResponse, out userNumber)) // Prevents crashes from invalid input
            {
                if (userNumber != 0)
                {
                    numbers.Add(userNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter an integer.");
            }
        } while (userNumber != 0);

        // Check if list is empty before calculations
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        // Compute sum
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Compute average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find max using LINQ
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        // Find smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers in the list.");
        }

        // Sort and display numbers
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}