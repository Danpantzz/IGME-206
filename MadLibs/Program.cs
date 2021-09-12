using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadLibs
{
    //Class: Program
    //Author: Daniel McErlean
    //Purpose: Play MadLibs by asking a user to fill in the blanks
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Ask user for name, madlibs story, and to fill in each blank space
        //Restrictions: None
        static void Main(string[] args)
        {
            StreamReader input = null;
            string line = null;
            string resultString = "";
            string userPlay = "";
            int numLines = 0;
            int current = 0;
            int nChoice = 0;

            //count the amount of madlibs
            try
            {
                input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");
            }
            catch
            {
                Console.WriteLine("File not found.");
            }
            while ((line = input.ReadLine()) != null)
            {
                numLines++;
            }
            input.Close();


            //create array for amount of madlibs
            string[] madLibs = new string[numLines];

            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                madLibs[current] = line;
                madLibs[current] = madLibs[current].Replace("\\n", "\n");
                current++;
            }
            input.Close();

            //Ask user if they want to play or not
            while (userPlay != "yes" && userPlay != "no")
            {
                Console.Write("Would you like to play MadLibs?: ");
                userPlay = Console.ReadLine().ToLower();
            }
            

            //Begin play
            while (userPlay == "yes")
            {
                //intro
                Console.Write("Welcome to MadLibs! Please enter your name: ");
                string userName = Console.ReadLine();

                //enter number for story
                Console.WriteLine("Hello, {0}. Please choose a story between 1 and {1}: ", userName, numLines);
                string stringLine = Console.ReadLine();

                try
                {
                    nChoice = Convert.ToInt32(stringLine);
                }
                catch
                {
                    Console.WriteLine("Error: could not convert int.");
                }

                //store words from madlibs line
                string[] words = madLibs[nChoice].Split(' ');

                //Go over each word, determining if its a placeholder for user input
                foreach (string word in words)
                {
                    //Convert placeholder into user input
                    if (word.Contains("{"))
                    {
                        string newWord = word;
                        newWord = newWord.Replace("_", " ");
                        newWord = newWord.Replace("{", "");
                        newWord = newWord.Replace("}", "");
                        Console.WriteLine(newWord + ": ");
                        string userWord = Console.ReadLine();
                        resultString += userWord + " ";
                        continue;
                    }
                    //Create new lines
                    if (word == "\n")
                    {
                        resultString += '\n';
                        continue;
                    }
                    //Add normal words the the end string
                    else
                    {
                        resultString += word + " ";
                    }

                }

                Console.WriteLine(resultString);

                //Ask user if they want to play again
                Console.Write("Would you like to play again? ");
                userPlay = Console.ReadLine().ToLower();
            }

            //leave game if answer is no
            if (userPlay == "no")
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}