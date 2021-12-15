using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_3___Question_1
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: create alphabet list and main method
    //Restrictions: None
    class Program
    {

        //List of alphabet and how many times each letter appears (initialized to zero)
        static (char, int)[][] alphabet = new (char, int)[][]
        {
            new (char, int)[] {('a', 0) },
            new (char, int)[] {('b', 0) },
            new (char, int)[] {('c', 0) },
            new (char, int)[] {('d', 0) },
            new (char, int)[] {('e', 0) },
            new (char, int)[] {('f', 0) },
            new (char, int)[] {('g', 0) },
            new (char, int)[] {('h', 0) },
            new (char, int)[] {('i', 0) },
            new (char, int)[] {('j', 0) },
            new (char, int)[] {('k', 0) },
            new (char, int)[] {('l', 0) },
            new (char, int)[] {('m', 0) },
            new (char, int)[] {('n', 0) },
            new (char, int)[] {('o', 0) },
            new (char, int)[] {('p', 0) },
            new (char, int)[] {('q', 0) },
            new (char, int)[] {('r', 0) },
            new (char, int)[] {('s', 0) },
            new (char, int)[] {('t', 0) },
            new (char, int)[] {('u', 0) },
            new (char, int)[] {('v', 0) },
            new (char, int)[] {('w', 0) },
            new (char, int)[] {('x', 0) },
            new (char, int)[] {('y', 0) },
            new (char, int)[] {('z', 0) },
        };

        //Method: Main
        //Purpose: Ask for a string, then check the amount of letters, print it in reverse and check if it is a palindrome
        //Restrictions: None
        static void Main(string[] args)
        {
            string userString;

            Console.Write("Enter a string: ");

            userString = Console.ReadLine();

            for (int i = 0; i < userString.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (alphabet[j][0].Item1 == userString.ToLower()[i])
                    {
                        ++alphabet[j][0].Item2;
                    }
                }
                
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i][0].Item2 == 0)
                {
                    continue;
                }

                Console.WriteLine(alphabet[i][0].Item1 + ": " + alphabet[i][0].Item2);
            }

            //string reverse = "";

            //for (int i = 0; i < userString.Length; i++)
            //{
            //    reverse += userString[(userString.Length - 1) - i];
            //}
            //
            //Console.WriteLine("Reversed: " + reverse);
            //
            //reverse = reverse.ToLower();
            //userString = userString.ToLower();
            //
            //reverse = reverse.Replace(",", "");
            //userString = userString.Replace(",", "");
            //
            //reverse = reverse.Replace("'", "");
            //userString = userString.Replace("'", "");
            //
            //reverse = reverse.Replace(" ", "");
            //userString = userString.Replace(" ", "");
            //
            //if (reverse == userString)
            //{
            //    Console.WriteLine("You entered a palindrome!");
            //}

        }
    }
}