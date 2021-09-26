using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Unit_Test_1___Question_4
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Asks user to answer questions in 5 seconds
    //Restrictions: None
    class Program
    {

        //initialize timer variables
        static bool bTimeOut = false;
        static Timer timeOutTimer;

        static string answer;

        //Method: Main
        //Purpose: Ask user to answer questions
        //Restrictions: None
        static void Main(string[] args)
        {
            int choice;

            string questions;
            string userAnswer;
            string playAgain = "y";

        start:
            bTimeOut = false;

            Console.Write("Choose your question (1-3): ");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                //something other than a number was entered
                goto start;
            }

            if (choice == 1)
            {
                answer = "black";
                questions = $"What is your favorite color?";
            }
            else if (choice == 2)
            {
                answer = "42";
                questions = $"What is the answer to life, the universe and everything?";
            }
            else if (choice == 3)
            {
                answer = "What do you mean? African or European swallow?";
                questions = $"What is the airspeed velocity of an unladen swallow?";
            }
            else
            {
                //choice was not an option
                goto start;
            }

            Console.WriteLine("You have 5 seconds to answer the following question:");

            // display the question and prompt for the answer
            //create and start 5 second timer
            timeOutTimer = new Timer(5000);

            ElapsedEventHandler elapsedEventHandler;

            elapsedEventHandler = new ElapsedEventHandler(TimesUp);

            timeOutTimer.Elapsed += elapsedEventHandler;

            timeOutTimer.Start();

            Console.WriteLine(questions);
            userAnswer = Console.ReadLine().ToLower();

            //timer stops when user presses enter
            timeOutTimer.Stop();

            // if userAnswer == answer, say well done
            // else output answer
            if (!bTimeOut)
            {
                if (userAnswer == answer.ToLower())
                {
                    Console.WriteLine("Well done!");
                }
                else
                {
                    Console.WriteLine("Wrong! The answer is: {0}", answer);
                }
            }

            do
            {
                // prompt if they want to play again
                Console.Write("Play again? ");

                playAgain = Console.ReadLine();

                if (playAgain.ToLower().StartsWith("y"))
                {
                    goto start;
                }
                else if (playAgain.ToLower().StartsWith("n"))
                {
                    break;
                }
            } while (true);

        }



        //Method: TimesUp
        //Purpose: Displays answer and times up message
        //Restrictions: None
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            timeOutTimer.Stop();
            Console.WriteLine("Times up!");
            Console.WriteLine("The answer is: {0}", answer);
            Console.WriteLine("Please press enter.");
            bTimeOut = true;
        }
    }
}
