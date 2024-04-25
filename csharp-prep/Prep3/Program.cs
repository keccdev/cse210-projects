using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

            while (playAgain)
            {
                // Generate a random magic number between 1 and 100
                Random random = new Random();
                int magicNumber = random.Next(1, 101);

                // User Interaction and Riddles
                Console.WriteLine("Welcome to the Guess My Number game!");
                Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess what it is?");

                int userGuess;
                int guessCount = 0;
                bool guessedCorrectly = false;

                // Loop until the user guesses correctly
                while (!guessedCorrectly)
                {
                    Console.Write("What's your guess? ");
                    userGuess = Convert.ToInt32(Console.ReadLine());
                    guessCount++;

                    if (userGuess < magicNumber)
                    {
                        Console.WriteLine("No, the number I'm thinking of is higher than " + userGuess + ". Try again!");
                    }
                    else if (userGuess > magicNumber)
                    {
                        Console.WriteLine("No, the number I'm thinking of is lower than " + userGuess + ". Try again!");
                    }
                    else
                    {
                        Console.WriteLine("Correct! The magic number was " + magicNumber + ". Great job!");
                        guessedCorrectly = true;
                    }
                }

                Console.WriteLine("Number of attempts: " + guessCount);

                Console.Write("Do you want to play again? (yes/no): ");
                string playAgainInput = Console.ReadLine().ToLower();
                playAgain = (playAgainInput == "yes");
            }

            Console.WriteLine("Thanks for playing!");
    }
}

