using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //int i = 0
            //Syntax error: missing semicolon
            int i = 0;

            String allNumbers = null;

            // loop through the numbers 1 through 10
            //for (i = 1; i < 10; ++i)
            //Logic error: loop is not able to reach 10
            for (i = 1; i <= 10; ++i)

            {
                // declare string to hold all numbers
                //string allNumbers = null;
                //Logic Error: String does not exist outside of for loop
                //              must be declared before for loop.

                // output explanation of calculation
                //Console.Write(i + "/" + i - 1 + " = ");
                //Syntax error: "i - 1" operation cannot be completed while combining strings without parentheses
                Console.Write(i + "/" + (i - 1) + " = ");

                // output the calculation based on the numbers
                //Console.WriteLine(i / (i - 1));
                //Logic error: first run of the for loop will result in a divide by 0 error.
                if (i == 1)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(i / (i - 1));
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                //i = i + 1;
                //Logic error: "i" is incremented in the for loop
            }

            // output all numbers which have been processed
            //Console.WriteLine("These numbers have been processed: " allNumbers);
            //Syntax error: "allNumbers" variable must be added using the "+" sign
            Console.WriteLine("These numbers have been processed: " + allNumbers);

        }
    }
}
