using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___number_7
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Reverse a string
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Takes any string and prints out the reverse
        //Restrictions: None
        static void Main(string[] args)
        {
            string userInput;
            string reverse = "";
            int i;
            int length;

            //Ask for string input
            Console.Write("Enter a string: ");
            userInput = Console.ReadLine();
            length = userInput.Length;

            //reverses the string by taking the length ( - 1) minus the element i is currently at
            for (i = 0; i < length; i++)
            {
                reverse += userInput.ElementAt((length - 1) - i);
            }

            //Print reversed string
            Console.WriteLine("Your string, reversed: {0}", reverse);

        }
    }
}
