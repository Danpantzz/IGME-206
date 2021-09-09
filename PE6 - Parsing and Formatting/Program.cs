using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6___Parsing_and_Formatting
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Random Number Generator and guesser
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Create a random number and ask the user to guess it
        //Restrictions: None
        static void Main(string[] args)
        {
            Random rand = new Random();
            int i;
            String sGuess;
            int guess;
            String playAgain = "y";

            //Opening message
            Console.WriteLine("Welcome to the Random Number Generator Game!\nTry to guess a random number from 0 to 100.");

            //Begins the play loop
            while (playAgain == "y" || playAgain == "yes")
            { 
                //Generate a random number between 0 inclusive and 101 exclusive
                int randomNumber = rand.Next(0, 101);

                //Used for testing the programs ability in guessing numbers too high, low, or correct
                //Commment out line when testing is complete
                //Console.WriteLine(randomNumber);

                //Allow the user to guess 8 times
                for (i = 0; i < 8; i++)
                {
                    Console.Write("Try to guess my number: ");
                    sGuess = Console.ReadLine();

                    //Used to catch exception where the user entered something other than a number
                    try
                    {
                        guess = Convert.ToInt32(sGuess);
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("Try again, numbers only this time.");

                        //substracts i to not count the guess, then loops back to beginnning of for loop
                        i -= 1;
                        continue;
                    }

                    //Checks if the guess is within the range of 0 and 100
                    while (guess > 100 || guess < 0)
                    {
                        Console.Write("I told you between 0 and 100! Try again: ");
                        sGuess = Console.ReadLine();
                        guess = Convert.ToInt32(sGuess);
                    }

                    //Tells the user their guess is too low
                    if (guess < randomNumber)
                    {
                        Console.WriteLine("Too low.");
                    }

                    //Tells the user their guess is too high
                    if (guess > randomNumber)
                    {
                        Console.WriteLine("Too high.");
                    }

                    //Ends the for loop if the user guesses correctly
                    if (guess == randomNumber)
                    {
                        Console.WriteLine("You guessed correctly! Congratulations!");

                        //Creates the correct grammar for one try or many tries
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

                //Outputs only if the user didn't guess correctly, tells them the answer
                if (i == 8)
                {
                    Console.WriteLine("No more chances. The Answer was: {0}", randomNumber);
                }

                //Prompt user to play again
                Console.Write("Would you like to play again? y or n: ");
                playAgain = Console.ReadLine().ToLower();

            }

            //Last line to exit the program
            Console.WriteLine("Have a nice day!");
        }
    }
}