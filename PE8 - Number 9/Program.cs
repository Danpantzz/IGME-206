using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Number_9
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: place double quotes around every word in a string
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Prints out every word in a string with double quotes around it
        //Restrictions: None
        static void Main(string[] args)
        {
            string newWord;
            string userInput;

            Console.Write("Enter a string: ");
            userInput = Console.ReadLine();

            string[] words = userInput.Split(' ');

            foreach (string word in words)
            {
                newWord = "\"" + word + "\"";
                Console.WriteLine(newWord);
            }

        }
    }
}
