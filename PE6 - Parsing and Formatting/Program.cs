using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6___Parsing_and_Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int i;
            String sGuess;
            int guess;
            String playAgain = "y";

            Console.WriteLine("Welcome to the Random Number Generator Game!\nTry to guess a random number from 0 to 100.");



            while (playAgain == "y" || playAgain == "yes")
            { 
                //Generate a random number between 0 inclusive and 101 exclusive
                int randomNumber = rand.Next(0, 101);

                //Used for testing the programs ability in guessing numbers too high, low, or correct
                //Commment out line when testing is complete
                //Console.WriteLine(randomNumber);

                for (i = 0; i < 8; i++)
                {
                    Console.Write("Try to guess my number: ");
                    sGuess = Console.ReadLine();

                    try
                    {
                        guess = Convert.ToInt32(sGuess);
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("Try again, numbers only this time.");
                        i -= 1;
                        continue;
                    }

                    while (guess > 100 || guess < 0)
                    {
                        Console.Write("I told you between 0 and 100! Try again: ");
                        sGuess = Console.ReadLine();
                        guess = Convert.ToInt32(sGuess);
                    }

                    if (guess < randomNumber)
                    {
                        Console.WriteLine("Too low.");
                    }
                    if (guess > randomNumber)
                    {
                        Console.WriteLine("Too high.");
                    }
                    if (guess == randomNumber)
                    {
                        Console.WriteLine("You guessed correctly! Congratulations!");

                        if (i == 0)
                        {
                            Console.WriteLine("It only took you " + (i + 1) + " try.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("It only took you " + (i + 1) + " tries.");
                            break;
                        }
                    }
                }

                if (i == 8)
                {
                    Console.WriteLine("No more chances. The Answer was: {0}", randomNumber);
                }


                Console.Write("Would you like to play again? y or n: ");
                playAgain = Console.ReadLine().ToLower();

            }

            Console.WriteLine("Have a nice day!");
        }
    }
}