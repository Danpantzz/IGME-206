using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Number_8
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: replace "no" with "yes"
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Takes a string to replace al words "no" with "yes"
        //Restrictions: None
        static void Main(string[] args)
        {
            string userInput;
            string replaced = "";
            string newWord = "yes";

            Console.Write("Enter a string: ");
            userInput = Console.ReadLine();

            if (userInput.ToLower().Contains("no"))
            {
                replaced = userInput.ToLower().Replace("no", "yes");
            }
            if (userInput.ToLower().Contains("no,"))
            {
                replaced = userInput.ToLower().Replace("no,", "yes,");
            }

            Console.WriteLine(replaced);

            /*
            string[] words = userInput.Split(' ');

            foreach (string word in words)
            {
                if (word.ToLower().Contains("no"))
                {
                    replaced += newWord;
                    continue;
                }
                replaced += word;
            }

            Console.WriteLine(replaced);
            */

        }
    }
}
