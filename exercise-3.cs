using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        Random randomGenerator = new Random(); // Ensures better randomness across rounds

        while (playAgain.ToLower().Trim() == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int attempts = 0;

            Console.WriteLine("\nI've picked a magic number between 1 and 100. Try to guess it!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine().Trim();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                    continue; // Skip this iteration if input is not a valid number
                }

                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {attempts} attempts.");
                }
            }

            Console.Write("\nDo you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();
        }

        Console.WriteLine("\nThanks for playing! Goodbye.");
    }
}