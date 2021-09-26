using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;

            //Syntax error: missing semi-colon
            //int nY
            int nY;

            int nAnswer;

            //Syntax error: missing quotes
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");

                //Syntax error: missing sNumber =
                //Console.ReadLine();
                sNumber = Console.ReadLine();

            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            }
            //Logic error: missing ! and nY instead of nX
            //while (int.TryParse(sNumber, out nX));
            while (!int.TryParse(sNumber, out nY));

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Logic Error: brackets are not declared properly and variables are missing
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine("{0}^{1} = {2}", nX, nY, nAnswer);
        }

        //Syntax error: missing static definition
        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //Logic error: will result in everything multiplied by 0
                //returnVal = 0;
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //Runtime error: program will never end because 1 is being added
                //nextVal = Power(nBase, nExponent + 1);
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //Syntax Error: missing return statement
            //returnVal;
            return returnVal;
        }
    }
}